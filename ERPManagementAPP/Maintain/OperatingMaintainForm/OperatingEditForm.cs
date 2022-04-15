using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain.OperatingMaintainForm
{
    public partial class OperatingEditForm : BaseEditForm
    {
        /// <summary>
        /// 聚焦表身資訊
        /// </summary>
        private OperatingSubSetting FocuseOperatingSubSetting { get; set; } = new OperatingSubSetting();
        /// <summary>
        /// 表身資訊
        /// </summary>
        private List<OperatingSubSetting> OperatingSubSettings { get; set; } = new List<OperatingSubSetting>();
        /// <summary>
        /// 進貨資訊
        /// </summary>
        private OperatingSetting OperatingSetting { get; set; } = new OperatingSetting();
        /// <summary>
        /// 產品資訊
        /// </summary>
        private List<ProductSetting> ProductSettings { get; set; }
        /// <summary>
        /// 公司資訊
        /// </summary>
        private List<CompanySetting> CompanySettings { get; set; }
        /// <summary>
        /// 員工資訊
        /// </summary>
        private List<EmployeeSetting> EmployeeSettings { get; set; }
        /// <summary>
        /// 專案資訊
        /// </summary>
        private List<ProjectSetting> ProjectSettings { get; set; }
        /// <summary>
        /// 被選擇的公司資訊
        /// </summary>
        private CompanySetting SelectCompanySetting { get; set; }
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
        private double ProductQty = 0;
        /// <summary>
        /// 產品單價
        /// </summary>
        private double ProductPrice = 0;
        /// <summary>
        /// 合計
        /// </summary>
        private double Total = 0;
        /// <summary>
        /// 稅金
        /// </summary>
        private double Tax = 0;
        /// <summary>
        /// 稅後總計
        /// </summary>
        private double TotalTax = 0;
        public OperatingEditForm(List<CompanySetting> companySettings, List<EmployeeSetting> employeeSettings, List<ProductSetting> productSettings, List<ProjectSetting> projectSettings, OperatingSetting purchaseSetting, APIMethod apiMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            action.Commands.Add(FlyoutCommand.Yes);
            CompanySettings = companySettings;
            EmployeeSettings = employeeSettings;
            ProductSettings = productSettings;
            OperatingSetting = purchaseSetting;
            ProjectSettings = projectSettings;
            Create_slt_OperatingcompanyNumber();
            Create_cbt_EmployeeNumber_cbt();
            //Create_cbt_ProductName_cbt();
            Create_slt_ProjectNumber();
            if (purchaseSetting != null)
            {
                cbt_OperatingFlag.Enabled = false;
                cbt_OperatingFlag.SelectedIndex = purchaseSetting.OperatingFlag - 7;
                txt_OperatingNumber.Text = purchaseSetting.OperatingNumber;
                det_OperatingDate.Text = purchaseSetting.OperatingDate.ToString("yyyy年MM月dd日");
                Show_ProductCompanyNumber_Index();
                Show_ProjectNumber_Index();
                cbt_OperatingTax.SelectedIndex = purchaseSetting.OperatingTax;
                txt_OperatingInvoiceNo.Text = purchaseSetting.OperatingInvoiceNo;
                Show_EmployeeNumber_Index();
                mmt_Remark.Text = purchaseSetting.Remark;
                cbt_Posting.SelectedIndex = purchaseSetting.Posting;
                OperatingSubSettings = purchaseSetting.OperatingSub;
            }
            else
            {
                det_OperatingDate.EditValue = DateTime.Now;
            }
            CacalculateData();
            RefreshData();
            cbt_OperatingTax.SelectedIndexChanged += (s, e) =>
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
                    OperatingSubSettings.Add(new OperatingSubSetting()
                    {
                        OperatingFlag = cbt_OperatingFlag.SelectedIndex + 7,
                        OperatingNumber = "",
                        OperatingNo = OperatingSubSettings.Count() + 1,
                        //ProductNumber = Get_cbt_ProductName_Number(),
                        ProductNumber = "",
                        //ProductName = SelectProductSetting.ProductName,
                        ProductName = txt_ProductName.Text,
                        ProductUnit = txt_ProducUnit.Text,
                        ProductQty = Convert.ToDouble(txt_productQty.Text),
                        ProductPrice = Convert.ToDouble(txt_productPrice.Text),
                        ProductTotal = Convert.ToDouble(txt_productQty.Text) * Convert.ToDouble(txt_productPrice.Text)
                    });
                    txt_ProductName.Text = "";
                    //slt_ProductName.EditValue = null;
                    //SelectProductSetting = null;
                    txt_productQty.Text = "";
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
                txt_ProductName.Text = "";
                //slt_ProductName.EditValue = null;
                //SelectProductSetting = null;
                txt_ProducUnit.Text = "";
                txt_productQty.Text = "";
                txt_productPrice.Text = "";
            };
            #endregion
            #region 刪除細項
            btn_Delete.Click += (s, e) =>
            {
                for (int i = 0; i < OperatingSubSettings.Count; i++)
                {
                    if (OperatingSubSettings[i].OperatingNo == FocuseOperatingSubSetting.OperatingNo)
                    {
                        OperatingSubSettings.RemoveAt(i);
                    }
                }
                RefraeshOperatingNo();
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
                CheckNumber(purchaseSetting, apiMethod);
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
                FocuseOperatingSubSetting.OperatingFlag = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OperatingFlag").ToString()) - 1;
                FocuseOperatingSubSetting.OperatingNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OperatingNumber").ToString();
                FocuseOperatingSubSetting.OperatingNo = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OperatingNo").ToString());
                FocuseOperatingSubSetting.ProductNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductNumber").ToString();
                FocuseOperatingSubSetting.ProductName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductName").ToString();
                FocuseOperatingSubSetting.ProductUnit = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductUnit").ToString();
                FocuseOperatingSubSetting.ProductQty = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductQty").ToString());
                FocuseOperatingSubSetting.ProductPrice = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductPrice").ToString());
                FocuseOperatingSubSetting.ProductTotal = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductTotal").ToString());

                //Show_ProductNumber_Index();
                //txt_ProducUnit.Text = FocuseOperatingSubSetting.ProductUnit;
                //txt_productQty.Text = FocuseOperatingSubSetting.ProductQty.ToString();
                //txt_productPrice.Text = FocuseOperatingSubSetting.ProductPrice.ToString();
            }
            else
            {
                FocuseOperatingSubSetting = new OperatingSubSetting();
            }
        }
        #endregion
        #region 刷新細項編號
        /// <summary>
        /// 刷新細項編號
        /// </summary>
        private void RefraeshOperatingNo()
        {
            for (int i = 0; i < OperatingSubSettings.Count; i++)
            {
                OperatingSubSettings[i].OperatingNo = i + 1;
            }
        }
        #endregion
        #region 刷新報表
        /// <summary>
        /// 刷新報表
        /// </summary>
        private void RefreshData()
        {
            gridControl1.DataSource = OperatingSubSettings;
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
            if (OperatingSubSettings.Count > 0)
            {
                foreach (var item in OperatingSubSettings)
                {
                    Total += item.ProductTotal;
                }
            }
            if (cbt_OperatingTax.SelectedIndex == 0)
            {
                Tax = Math.Round(Total * 0.05, 0);
            }
            TotalTax = Total + Tax;
            txt_Total.EditValue = Total.ToString();
            txt_Tax.EditValue = Tax.ToString();
            txt_TotalTax.EditValue = $"{TotalTax.ToString()}";
        }
        #endregion
        #region 廠商編號功能
        /// <summary>
        /// 創建廠商下拉選單
        /// </summary>
        private void Create_slt_OperatingcompanyNumber()
        {
            slt_OperatingcompanyNumber.Properties.DataSource = CompanySettings;
            slt_OperatingcompanyNumber.Properties.DisplayMember = "CompanyName";
            slt_OperatingcompanyNumber.CustomDisplayText += (s, e) =>
            {
                if (OperatingSetting != null)
                {
                    if (SelectCompanySetting != null)
                    {
                        if (e.Value.ToString() != "")
                        {
                            SelectCompanySetting = e.Value as CompanySetting;
                            e.DisplayText = SelectCompanySetting.CompanyName;
                        }
                        else
                        {
                            e.DisplayText = SelectCompanySetting.CompanyName;
                        }
                    }
                    else
                    {
                        e.DisplayText = "";
                    }
                }
                else
                {
                    SelectCompanySetting = e.Value as CompanySetting;
                }
            };
        }
        /// <summary>
        /// 顯示廠商選單項目
        /// </summary>
        private void Show_ProductCompanyNumber_Index()
        {
            for (int i = 0; i < CompanySettings.Count; i++)
            {
                if (CompanySettings[i].CompanyNumber == OperatingSetting.OperatingCompanyNumber)
                {
                    SelectCompanySetting = CompanySettings[i];
                    break;
                }
                else
                {
                    SelectCompanySetting = null;
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
                    if (item.EmployeeNumber == OperatingSetting.OperatingEmployeeNumber)
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
        //private void Create_cbt_ProductName_cbt()
        //{
        //    slt_ProductName.Properties.DataSource = ProductSettings;
        //    slt_ProductName.Properties.DisplayMember = "ProductName";
        //    slt_ProductName.CustomDisplayText += (s, e) =>
        //    {
        //        SelectProductSetting = e.Value as ProductSetting;
        //        if (SelectProductSetting != null)
        //        {
        //            e.DisplayText = SelectProductSetting.ProductName;
        //        }
        //        else
        //        {
        //            e.DisplayText = "";
        //        }
        //    };
        //}
        //private void Show_ProductNumber_Index()
        //{
        //    if (ProductSettings != null)
        //    {
        //        for (int i = 0; i < ProductSettings.Count; i++)
        //        {
        //            if (ProductSettings[i].ProductNumber == FocuseOperatingSubSetting.ProductNumber)
        //            {
        //                slt_ProductName.EditValue = ProductSettings[i];
        //                break;
        //            }
        //        }
        //    }
        //}
        /// <summary>
        /// 取得產品編號
        /// </summary>
        /// <returns></returns>
        //private string Get_cbt_ProductName_Number()
        //{
        //    string value = "";
        //    if (SelectProductSetting != null)
        //    {
        //        value = SelectProductSetting.ProductNumber;
        //    }
        //    return value;
        //}
        #endregion
        #region 專案代碼功能 2022/4/13新增此功能
        /// <summary>
        /// 創建專案代碼下拉選單
        /// </summary>
        private void Create_slt_ProjectNumber()
        {
            slt_ProjectNumber.Properties.DataSource = ProjectSettings;
            slt_ProjectNumber.Properties.DisplayMember = "ProjectName";
            slt_ProjectNumber.CustomDisplayText += (s, e) =>
            {
                if (OperatingSetting != null)
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
                if (ProjectSettings[i].ProjectNumber == OperatingSetting.ProjectNumber)
                {
                    SelectProjectSetting = ProjectSettings[i];
                    break;
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
        private void CheckNumber(OperatingSetting purchaseSetting, APIMethod apiMethod)
        {
            string response = "";
            if (purchaseSetting != null && purchaseSetting.OperatingNumber != null)
            {
                foreach (var item in OperatingSubSettings)
                {
                    item.OperatingNumber = txt_OperatingNumber.Text;
                }
                action.Caption = "進貨修改錯誤";
                purchaseSetting.OperatingFlag = cbt_OperatingFlag.SelectedIndex + 7;
                purchaseSetting.OperatingNumber = txt_OperatingNumber.Text;
                purchaseSetting.ProjectNumber = Get_slt_ProjectNumber();
                purchaseSetting.OperatingDate = Convert.ToDateTime(det_OperatingDate.Text);
                purchaseSetting.OperatingCompanyNumber = SelectCompanySetting.CompanyNumber;
                purchaseSetting.OperatingTax = cbt_OperatingTax.SelectedIndex;
                purchaseSetting.OperatingInvoiceNo = txt_OperatingInvoiceNo.Text;
                purchaseSetting.OperatingEmployeeNumber = Get_cbt_EmployeeNumber_Number();
                purchaseSetting.Remark = mmt_Remark.Text;
                purchaseSetting.Posting = cbt_Posting.SelectedIndex;
                purchaseSetting.OperatingSub = OperatingSubSettings;
                purchaseSetting.Total = Convert.ToDouble(txt_Total.EditValue);
                purchaseSetting.Tax = Convert.ToDouble(txt_Tax.EditValue);
                purchaseSetting.TotalTax = Convert.ToDouble(txt_TotalTax.EditValue);
                if (purchaseSetting.Posting == 1)
                {
                    purchaseSetting.PostingDate = DateTime.Now;
                }
                else
                {
                    purchaseSetting.PostingDate = null;
                }
                string value = JsonConvert.SerializeObject(purchaseSetting);
                response = apiMethod.Put_Operating(value);
                if (response == "200")
                {
                    if (!string.IsNullOrEmpty(AttachmentFilePath))
                    {
                        response = apiMethod.Post_OperatingAttachmentFile(purchaseSetting.OperatingFlag, purchaseSetting.OperatingCompanyNumber, purchaseSetting.OperatingDate, purchaseSetting.OperatingNumber, AttachmentFilePath);
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
                if (!string.IsNullOrEmpty(det_OperatingDate.Text) && SelectCompanySetting != null && cbt_EmployeeNumber.SelectedIndex > -1)
                {
                    OperatingSetting OperatingSetting = new OperatingSetting()
                    {
                        OperatingFlag = cbt_OperatingFlag.SelectedIndex + 7,
                        OperatingNumber = txt_OperatingNumber.Text,
                        ProjectNumber = Get_slt_ProjectNumber(),
                        OperatingDate = Convert.ToDateTime(det_OperatingDate.Text),
                        OperatingCompanyNumber = SelectCompanySetting.CompanyNumber,
                        OperatingTax = cbt_OperatingTax.SelectedIndex,
                        OperatingInvoiceNo = txt_OperatingInvoiceNo.Text,
                        OperatingEmployeeNumber = Get_cbt_EmployeeNumber_Number(),
                        Remark = mmt_Remark.Text,
                        Posting = cbt_Posting.SelectedIndex,
                        OperatingSub = OperatingSubSettings
                    };
                    if (OperatingSetting.Posting == 1)
                    {
                        OperatingSetting.PostingDate = DateTime.Now;
                    }
                    else
                    {
                        OperatingSetting.PostingDate = null;
                    }
                    string value = JsonConvert.SerializeObject(OperatingSetting);
                    response = apiMethod.Post_Operating(value);
                    if (response == "200")
                    {
                        if (!string.IsNullOrEmpty(AttachmentFilePath) && !string.IsNullOrEmpty(apiMethod.ResponseDataMessage))
                        {
                            List<OperatingSetting> settings = JsonConvert.DeserializeObject<List<OperatingSetting>>(apiMethod.ResponseDataMessage);
                            response = apiMethod.Post_OperatingAttachmentFile(settings[0].OperatingFlag, settings[0].OperatingCompanyNumber, settings[0].OperatingDate, settings[0].OperatingNumber, AttachmentFilePath);
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
            }
        }
        #endregion
    }
}