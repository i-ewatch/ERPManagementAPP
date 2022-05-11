using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain.PickingMaintainForm
{
    public partial class PickingEditForm : BaseEditForm
    {
        /// <summary>
        /// 聚焦表身資訊
        /// </summary>
        private PickingSubSetting FocusePickingSubSetting { get; set; } = new PickingSubSetting();
        /// <summary>
        /// 表身資訊
        /// </summary>
        private List<PickingSubSetting> PickingSubSettings { get; set; } = new List<PickingSubSetting>();
        /// <summary>
        /// 進貨資訊
        /// </summary>
        private PickingSetting PickingSetting { get; set; } = new PickingSetting();
        /// <summary>
        /// 產品資訊
        /// </summary>
        private List<ProductSetting> ProductSettings { get; set; }
        /// <summary>
        /// 客戶資訊
        /// </summary>
        private List<CustomerSetting> CustomerSettings { get; set; }
        /// <summary>
        /// 員工資訊
        /// </summary>
        private List<EmployeeSetting> EmployeeSettings { get; set; }
        /// <summary>
        /// 專案資訊
        /// </summary>
        private List<ProjectSetting> ProjectSettings { get; set; }
        /// <summary>
        /// 公司資訊
        /// </summary>
        private List<CompanySetting> CompanySettings { get; set; }
        /// <summary>
        /// 被選擇的客戶資訊
        /// </summary>
        private CustomerSetting SelectCustomerSetting { get; set; }
        /// <summary>
        /// 被選擇的產品資訊
        /// </summary>
        private ProductSetting SelectProductSetting { get; set; }
        /// <summary>
        /// 被選擇的專案資訊
        /// </summary>
        private ProjectSetting SelectProjectSetting { get; set; }
        /// <summary>
        /// 產品數量
        /// </summary>
        private double ProductQty { get; set; } = 0;
        /// <summary>
        /// 產品單價
        /// </summary>
        private double ProductPrice { get; set; } = 0;
        /// <summary>
        /// 合計
        /// </summary>
        private double Total { get; set; } = 0;
        /// <summary>
        /// 稅金
        /// </summary>
        private double Tax { get; set; } = 0;
        /// <summary>
        /// 稅後總計
        /// </summary>
        private double TotalTax { get; set; } = 0;
        public PickingEditForm(List<CompanySetting> companySettings, List<CustomerSetting> customerSettings, List<EmployeeSetting> employeeSettings, List<ProductSetting> productSettings, List<ProjectSetting> projectSettings, PickingSetting pickingSetting, APIMethod apiMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            action.Commands.Add(FlyoutCommand.Yes);
            CompanySettings = companySettings;
            CustomerSettings = customerSettings;
            EmployeeSettings = employeeSettings;
            ProductSettings = productSettings;
            PickingSetting = pickingSetting;
            ProjectSettings = projectSettings;
            Create_slt_SalescustomerNumber_cbt();
            Create_cbt_EmployeeNumber_cbt();
            Create_cbt_ProductName_cbt();
            Create_slt_ProjectNumber();
            if (pickingSetting != null && pickingSetting.PickingNumber != null)
            {
                cbt_PickingFlag.SelectedIndex = pickingSetting.PickingFlag - 5;
                txt_PickingNumber.Text = pickingSetting.PickingNumber;
                det_PickingDate.Text = pickingSetting.PickingDate.ToString("yyyy年MM月dd日");
                Show_ProductCustomerNumber_Index();
                Show_ProjectNumber_Index();
                cbt_PickingTax.SelectedIndex = pickingSetting.PickingTax;
                Show_EmployeeNumber_Index();
                mmt_Remark.Text = pickingSetting.Remark;
                PickingSubSettings = pickingSetting.PickingSub;
            }
            else
            {
                det_PickingDate.EditValue = DateTime.Now;
            }
            CacalculateData();
            RefreshData();
            cbt_PickingTax.SelectedIndexChanged += (s, e) =>
            {
                CacalculateData();
            };
            #region 載入檔案按鈕
            btn_LoadFile.Click += (s, e) =>
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog.OpenFile() != null)
                    {
                        AttachmentFilePath = openFileDialog.FileName;
                        txt_FileName.Text = Path.GetFileName(openFileDialog.FileName);
                    }
                }
            };
            #endregion
            #region 清除載入檔案
            btn_ClearFile.Click += (s, e) =>
            {
                AttachmentFilePath = "";
                txt_FileName.Text = "";
            };
            #endregion
            #region 產品小計計算功能
            gridView1.CellValueChanging += (s, e) =>
            {
                if (e.Column.FieldName == "ProductQty")
                {
                    if (e.Value.ToString() != "")
                    {
                        ProductQty = Convert.ToDouble(e.Value.ToString());
                        ProductPrice = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductPrice"));
                        gridView1.SetFocusedRowCellValue("ProductTotal", (ProductQty * ProductPrice).ToString());
                        CacalculateData();
                    }
                    else
                    {
                        gridView1.SetFocusedRowCellValue("ProductTotal", 0);
                    }
                }
                else if (e.Column.FieldName == "ProductPrice")
                {
                    if (e.Value.ToString() != "")
                    {
                        ProductQty = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductQty"));
                        ProductPrice = Convert.ToDouble(e.Value.ToString());
                        gridView1.SetFocusedRowCellValue("ProductTotal", (ProductQty * ProductPrice).ToString());
                        CacalculateData();
                    }
                    else
                    {
                        gridView1.SetFocusedRowCellValue("ProductTotal", 0);
                    }
                }
                else
                {
                    return;
                }
            };
            #endregion
            #region 報表聚焦功能
            gridView1.FocusedRowChanged += (s, e) =>
            {
                FocuseMainGrid();
            };
            #endregion
            #region 細項新增
            btn_Add.Click += (s, e) =>
            {
                if (!string.IsNullOrEmpty(txt_ProducUnit.Text) && !string.IsNullOrEmpty(txt_productPrice.Text))
                {
                    PickingSubSettings.Add(new PickingSubSetting()
                    {
                        PickingFlag = cbt_PickingFlag.SelectedIndex + 5,
                        PickingNumber = "",
                        PickingNo = PickingSubSettings.Count() + 1,
                        ProductNumber = SelectProductSetting.ProductNumber,
                        ProductName = SelectProductSetting.ProductName,
                        ProductUnit = txt_ProducUnit.Text,
                        ProductQty = Convert.ToDouble(txt_productQty.Text),
                        ProductPrice = Convert.ToDouble(txt_productPrice.Text),
                        ProductTotal = Convert.ToDouble(txt_productQty.Text) * Convert.ToDouble(txt_productPrice.Text)
                    });
                    slt_ProductName.Text = "";
                    txt_productQty.Text = "";
                    SelectProductSetting = null;
                    txt_productPrice.Text = "";
                    CacalculateData();
                    RefreshData();
                    //FocuseMainGrid();
                }
                else
                {
                    action.Caption = "細項新增錯誤";
                    action.Description = "請確認資料是否完整";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 表身輸入框清除
            btn_Clear.Click += (s, e) =>
            {
                slt_ProductName.Text = "";
                txt_ProducUnit.Text = "";
                SelectProductSetting = null;
                txt_productQty.Text = "";
                txt_productPrice.Text = "";
            };
            #endregion
            #region 刪除細項
            btn_Delete.Click += (s, e) =>
            {
                for (int i = 0; i < PickingSubSettings.Count; i++)
                {
                    if (PickingSubSettings[i].PickingNo == FocusePickingSubSetting.PickingNo)
                    {
                        PickingSubSettings.RemoveAt(i);
                    }
                }
                RefraeshSalesNo();
                CacalculateData();
                RefreshData();
                //FocuseMainGrid();
            };
            #endregion
            #region 取消按鈕
            btn_Cancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
            };
            #endregion
            #region 儲存按鈕
            btn_Save.Click += (s, e) =>
            {
                CheckNumber(PickingSetting, apiMethod);
            };
            #endregion
        }
        #region 聚焦主資料表功能
        /// <summary>
        /// 聚焦主資料表功能
        /// </summary>
        private void FocuseMainGrid()
        {
            if (gridView1.FocusedRowHandle > -1 && gridView1.DataRowCount > 0)
            {
                FocusePickingSubSetting.PickingFlag = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PickingFlag").ToString()) - 1;
                FocusePickingSubSetting.PickingNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PickingNumber").ToString();
                FocusePickingSubSetting.PickingNo = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PickingNo").ToString());
                FocusePickingSubSetting.ProductNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductNumber").ToString();
                FocusePickingSubSetting.ProductName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductName").ToString();
                FocusePickingSubSetting.ProductUnit = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductUnit").ToString();
                FocusePickingSubSetting.ProductQty = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductQty").ToString());
                FocusePickingSubSetting.ProductPrice = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductPrice").ToString());
                FocusePickingSubSetting.ProductTotal = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductTotal").ToString());

                //Show_ProductNumber_Index();
                //txt_ProducUnit.Text = FocusePickingSubSetting.ProductUnit;
                //txt_productQty.Text = FocusePickingSubSetting.ProductQty.ToString();
                //txt_productPrice.Text = FocusePickingSubSetting.ProductPrice.ToString();
            }
            else
            {
                FocusePickingSubSetting = new PickingSubSetting();
            }
        }
        #endregion
        #region 刷新細項編號
        /// <summary>
        /// 刷新細項編號
        /// </summary>
        private void RefraeshSalesNo()
        {
            for (int i = 0; i < PickingSubSettings.Count; i++)
            {
                PickingSubSettings[i].PickingNo = i + 1;
            }
        }
        #endregion
        #region 刷新報表
        /// <summary>
        /// 刷新報表
        /// </summary>
        private void RefreshData()
        {
            gridControl1.DataSource = PickingSubSettings;
            gridControl1.RefreshDataSource();
        }
        #endregion
        #region 刷新計算數值
        /// <summary>
        /// 刷新計算數值
        /// </summary>
        private void CacalculateData()
        {
            Total = 0;
            Tax = 0;
            TotalTax = 0;
            if (PickingSubSettings.Count > 0)
            {
                foreach (var item in PickingSubSettings)
                {
                    Total += item.ProductTotal;
                }
            }
            if (cbt_PickingTax.SelectedIndex == 0)
            {
                Tax = Math.Round(Total * 0.05, 0);
            }
            TotalTax = Total + Tax;
            txt_Total.EditValue = Total.ToString();
            txt_Tax.EditValue = Tax.ToString();
            txt_TotalTax.EditValue = $"{TotalTax.ToString()}";
        }
        #endregion
        #region 客戶編號功能
        /// <summary>
        /// 創建客戶編號下拉選單
        /// </summary>
        private void Create_slt_SalescustomerNumber_cbt()
        {
            slt_PickingCustomerNumber.Properties.DataSource = CustomerSettings;
            slt_PickingCustomerNumber.Properties.DisplayMember = "CustomerName";
            slt_PickingCustomerNumber.CustomDisplayText += (s, e) =>
            {
                if (PickingSetting != null)
                {
                    if (SelectCustomerSetting != null)
                    {
                        if (e.Value.ToString() != "")
                        {
                            SelectCustomerSetting = e.Value as CustomerSetting;
                            e.DisplayText = SelectCustomerSetting.CustomerName;
                        }
                        else
                        {
                            e.DisplayText = SelectCustomerSetting.CustomerName;
                        }
                    }
                    else
                    {
                        e.DisplayText = "";
                    }
                }
                else
                {
                    SelectCustomerSetting = e.Value as CustomerSetting;
                }
            };
        }
        /// <summary>
        /// 顯示客戶選單項目
        /// </summary>
        private void Show_ProductCustomerNumber_Index()
        {
            for (int i = 0; i < CustomerSettings.Count; i++)
            {
                if (CustomerSettings[i].CustomerNumber == PickingSetting.PickingCustomerNumber)
                {
                    SelectCustomerSetting = CustomerSettings[i];
                    break;
                }
                else
                {
                    SelectCustomerSetting = null;
                }
            }
        }
        #endregion
        #region 員工編號功能
        /// <summary>
        /// 創建員工編號下拉選單
        /// </summary>
        /// <param name="companySettings"></param>
        private void Create_cbt_EmployeeNumber_cbt()
        {
            if (cbt_EmployeeNumber.Properties.Items.Count > 0)
            {
                cbt_EmployeeNumber.Properties.Items.Clear();
            }
            if (EmployeeSettings != null)
            {
                foreach (var item in EmployeeSettings)
                {
                    cbt_EmployeeNumber.Properties.Items.Add(item.EmployeeName);
                }
            }
        }
        /// <summary>
        /// 取得員工編號
        /// </summary>
        /// <returns></returns>
        private string Get_cbt_EmployeeNumber_Number()
        {
            string value = "";
            if (EmployeeSettings != null)
            {
                if (EmployeeSettings.Count > 0)
                {
                    value = EmployeeSettings[cbt_EmployeeNumber.SelectedIndex].EmployeeNumber;
                }
            }
            return value;
        }
        /// <summary>
        /// 顯示員工名稱
        /// </summary>
        private void Show_EmployeeNumber_Index()
        {
            int Index = -1;
            if (EmployeeSettings != null)
            {
                foreach (var item in EmployeeSettings)
                {
                    if (item.EmployeeNumber == PickingSetting.PickingEmployeeNumber)
                    {
                        Index++;
                        cbt_EmployeeNumber.SelectedIndex = Index;
                    }
                    else
                    {
                        Index++;
                    }
                }
            }
        }
        #endregion
        #region 產品編號功能
        /// <summary>
        /// 創建產品編號下拉選單
        /// </summary>
        /// <param name="companySettings"></param>
        private void Create_cbt_ProductName_cbt()
        {
            slt_ProductName.Properties.DataSource = ProductSettings;
            slt_ProductName.Properties.DisplayMember = "ProductName";
            gridView3.CustomColumnDisplayText += (s, e) =>
            {
                if (e.Column.FieldName == "ProductCompanyNumber")
                {
                    if (CompanySettings != null)
                    {
                        foreach (var item in CompanySettings)
                        {
                            if (item.CompanyNumber == e.Value.ToString())
                            {
                                e.DisplayText = item.CompanyName;
                            }
                        }
                    }
                }
            };
            slt_ProductName.CustomDisplayText += (s, e) =>
            {
                SelectProductSetting = e.Value as ProductSetting;
                if (SelectProductSetting != null)
                {
                    e.DisplayText = SelectProductSetting.ProductName;
                }
                else
                {
                    e.DisplayText = "";
                }
            };
        }
        private void Show_ProductNumber_Index()
        {
            if (ProductSettings != null)
            {
                for (int i = 0; i < ProductSettings.Count; i++)
                {
                    if (ProductSettings[i].ProductNumber == FocusePickingSubSetting.ProductNumber)
                    {
                        slt_ProductName.EditValue = ProductSettings[i];
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// 取得產品編號
        /// </summary>
        /// <returns></returns>
        private string Get_cbt_ProductName_Number()
        {
            string value = "";
            if (SelectProductSetting != null)
            {
                value = SelectProductSetting.ProductNumber;
            }
            return value;
        }
        #endregion
        #region 專案代碼功能
        /// <summary>
        /// 創建專案代碼下拉選單
        /// </summary>
        private void Create_slt_ProjectNumber()
        {
            slt_ProjectNumber.Properties.DataSource = ProjectSettings;
            slt_ProjectNumber.Properties.DisplayMember = "ProjectName";
            slt_ProjectNumber.CustomDisplayText += (s, e) =>
            {
                if (PickingSetting != null)
                {
                    if (SelectProjectSetting != null)
                    {
                        if (e.Value == null)
                        {
                            SelectProjectSetting = null;
                            e.DisplayText = "";
                        }
                        else if (e.Value.ToString() != "")
                        {
                            SelectProjectSetting = e.Value as ProjectSetting;
                            e.DisplayText = SelectProjectSetting.ProjectName;
                        }
                        else
                        {
                            e.DisplayText = SelectProjectSetting.ProjectName;
                        }
                    }
                    else
                    {
                        SelectProjectSetting = e.Value as ProjectSetting;
                    }
                }
                else
                {
                    SelectProjectSetting = e.Value as ProjectSetting;
                }
            };
        }
        /// <summary>
        /// 顯示專案代碼項目
        /// </summary>
        private void Show_ProjectNumber_Index()
        {
            for (int i = 0; i < ProjectSettings.Count; i++)
            {
                if (ProjectSettings[i].ProjectNumber == PickingSetting.ProjectNumber)
                {
                    SelectProjectSetting = ProjectSettings[i];
                }
                else
                {
                    SelectProjectSetting = null;
                }
            }
        }
        /// <summary>
        /// 取得專案代碼
        /// </summary>
        /// <returns></returns>
        private string Get_slt_ProjectNumber()
        {
            string value = null;
            if (SelectProjectSetting != null)
            {
                value = SelectProjectSetting.ProjectNumber;
            }
            return value;
        }
        #endregion
        #region 檢查資料問題
        private void CheckNumber(PickingSetting salesSetting, APIMethod apiMethod)
        {
            string response = "";
            if (salesSetting != null && salesSetting.PickingNumber != null)
            {
                foreach (var item in PickingSubSettings)
                {
                    item.PickingNumber = txt_PickingNumber.Text;
                }
                action.Caption = "進貨修改錯誤";
                salesSetting.PickingFlag = cbt_PickingFlag.SelectedIndex + 5;
                salesSetting.PickingNumber = txt_PickingNumber.Text;
                salesSetting.ProjectNumber = Get_slt_ProjectNumber();
                salesSetting.PickingDate = Convert.ToDateTime(det_PickingDate.Text);
                salesSetting.PickingCustomerNumber = SelectCustomerSetting.CustomerNumber;
                salesSetting.PickingTax = cbt_PickingTax.SelectedIndex;
                salesSetting.PickingInvoiceNo = null;
                salesSetting.PickingEmployeeNumber = Get_cbt_EmployeeNumber_Number();
                salesSetting.Remark = mmt_Remark.Text;
                salesSetting.Posting = 0;
                salesSetting.PickingSub = PickingSubSettings;
                salesSetting.Total = Convert.ToDouble(txt_Total.EditValue);
                salesSetting.Tax = Convert.ToDouble(txt_Tax.EditValue);
                salesSetting.TotalTax = Convert.ToDouble(txt_TotalTax.EditValue);
                salesSetting.TakeACut = 0;
                salesSetting.Cost = 0;
                double profitSharing = 0;
                //profitSharing = TotalTax - (TotalTax * salesSetting.TakeACut / 100) - salesSetting.Cost;
                salesSetting.ProfitSharing = profitSharing;
                if (salesSetting.Posting == 1)
                {
                    salesSetting.PostingDate = DateTime.Now;
                }
                else
                {
                    salesSetting.PostingDate = null;
                }
                string value = JsonConvert.SerializeObject(salesSetting);
                response = apiMethod.Put_Picking(value);
                if (response == "200")
                {
                    if (!string.IsNullOrEmpty(AttachmentFilePath))
                    {
                        response = apiMethod.Post_PickingAttachmentFile(salesSetting.PickingFlag, salesSetting.PickingCustomerNumber, salesSetting.PickingDate, salesSetting.PickingNumber, AttachmentFilePath);
                        if (response == "200")
                        {
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            action.Description = response;
                            FlyoutDialog.Show(Form1, action);
                        }
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    action.Description = response;
                    FlyoutDialog.Show(Form1, action);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(det_PickingDate.Text) && SelectCustomerSetting != null && cbt_EmployeeNumber.SelectedIndex > -1)
                {
                    PickingSetting PickingSetting = new PickingSetting()
                    {
                        PickingFlag = cbt_PickingFlag.SelectedIndex + 5,
                        PickingNumber = txt_PickingNumber.Text,
                        ProjectNumber = Get_slt_ProjectNumber(),
                        PickingDate = Convert.ToDateTime(det_PickingDate.Text),
                        PickingCustomerNumber = SelectCustomerSetting.CustomerNumber,
                        PickingTax = cbt_PickingTax.SelectedIndex,
                        PickingInvoiceNo = null,
                        PickingEmployeeNumber = Get_cbt_EmployeeNumber_Number(),
                        Remark = mmt_Remark.Text,
                        Posting = 0,
                        PickingSub = PickingSubSettings,
                        TakeACut = 0,
                        Cost = 0
                    };
                    double profitSharing = 0;
                    //profitSharing = TotalTax - (TotalTax * PickingSetting.TakeACut / 100) - PickingSetting.Cost;
                    PickingSetting.ProfitSharing = profitSharing;
                    if (PickingSetting.Posting == 1)
                    {
                        PickingSetting.PostingDate = DateTime.Now;
                    }
                    else
                    {
                        PickingSetting.PostingDate = null;
                    }
                    string value = JsonConvert.SerializeObject(PickingSetting);
                    response = apiMethod.Post_Picking(value);
                    if (response == "200")
                    {
                        if (!string.IsNullOrEmpty(AttachmentFilePath) && !string.IsNullOrEmpty(apiMethod.ResponseDataMessage))
                        {
                            List<PickingSetting> settings = JsonConvert.DeserializeObject<List<PickingSetting>>(apiMethod.ResponseDataMessage);
                            response = apiMethod.Post_PickingAttachmentFile(settings[0].PickingFlag, settings[0].PickingCustomerNumber, settings[0].PickingDate, settings[0].PickingNumber, AttachmentFilePath);
                            if (response == "200")
                            {
                                DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                action.Description = response;
                                FlyoutDialog.Show(Form1, action);
                            }
                        }
                        else
                        {
                            DialogResult = DialogResult.OK;
                        }
                    }
                    else
                    {
                        action.Description = response;
                        FlyoutDialog.Show(Form1, action);
                    }
                }
                else
                {
                    action.Description = "資料未填選完整";
                    FlyoutDialog.Show(Form1, action);
                }
            }
        }
        #endregion
    }
}