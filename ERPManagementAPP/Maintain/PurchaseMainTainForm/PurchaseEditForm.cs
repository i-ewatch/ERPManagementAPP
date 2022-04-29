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

namespace ERPManagementAPP.Maintain.PurchaseMainTainForm
{
    public partial class PurchaseEditForm : BaseEditForm
    {
        /// <summary>
        /// 聚焦表身資訊
        /// </summary>
        private PurchaseSubSetting FocusePurchaseSubSetting { get; set; } = new PurchaseSubSetting();
        /// <summary>
        /// 表身資訊
        /// </summary>
        private List<PurchaseSubSetting> PurchaseSubSettings { get; set; } = new List<PurchaseSubSetting>();
        /// <summary>
        /// 進貨資訊
        /// </summary>
        private PurchaseSetting PurchaseSetting { get; set; } = new PurchaseSetting();
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
        public PurchaseEditForm(List<CompanySetting> companySettings, List<EmployeeSetting> employeeSettings, List<ProductSetting> productSettings, List<ProjectSetting> projectSettings, PurchaseSetting purchaseSetting, APIMethod apiMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            action.Commands.Add(FlyoutCommand.Yes);
            CompanySettings = companySettings;
            EmployeeSettings = employeeSettings;
            ProductSettings = productSettings;
            PurchaseSetting = purchaseSetting;
            ProjectSettings = projectSettings;
            Create_slt_PurchasecompanyNumber();
            Create_cbt_EmployeeNumber_cbt();
            Create_cbt_ProductName_cbt();
            Create_slt_ProjectNumber();
            if (purchaseSetting != null)
            {
                cbt_PurchaseFlag.Enabled = false;
                cbt_PurchaseFlag.SelectedIndex = purchaseSetting.PurchaseFlag - 1;
                txt_PurchaseNumber.Text = purchaseSetting.PurchaseNumber;
                det_PurchaseDate.Text = purchaseSetting.PurchaseDate.ToString("yyyy年MM月dd日");
                Show_ProductCompanyNumber_Index();
                Show_ProjectNumber_Index();
                cbt_PurchaseTax.SelectedIndex = purchaseSetting.PurchaseTax;
                txt_PurchaseInvoiceNo.Text = purchaseSetting.PurchaseInvoiceNo;
                Show_EmployeeNumber_Index();
                mmt_Remark.Text = purchaseSetting.Remark;
                cbt_Posting.SelectedIndex = purchaseSetting.Posting;
                PurchaseSubSettings = purchaseSetting.PurchaseSub;
            }
            else
            {
                det_PurchaseDate.EditValue = DateTime.Now;
            }
            CacalculateData();
            RefreshData();
            cbt_PurchaseTax.SelectedIndexChanged += (s, e) =>
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
                if (SelectProductSetting != null && !string.IsNullOrEmpty(txt_ProducUnit.Text) && !string.IsNullOrEmpty(txt_productPrice.Text))
                {
                    PurchaseSubSettings.Add(new PurchaseSubSetting()
                    {
                        PurchaseFlag = cbt_PurchaseFlag.SelectedIndex + 1,
                        PurchaseNumber = "",
                        PurchaseNo = PurchaseSubSettings.Count() + 1,
                        ProductNumber = Get_cbt_ProductName_Number(),
                        ProductName = SelectProductSetting.ProductName,
                        ProductUnit = txt_ProducUnit.Text,
                        ProductQty = Convert.ToDouble(txt_productQty.Text),
                        ProductPrice = Convert.ToDouble(txt_productPrice.Text),
                        ProductTotal = Convert.ToDouble(txt_productQty.Text) * Convert.ToDouble(txt_productPrice.Text)
                    });
                    slt_ProductName.EditValue = null;
                    SelectProductSetting = null;
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
                slt_ProductName.EditValue = null;
                SelectProductSetting = null;
                txt_ProducUnit.Text = "";
                txt_productQty.Text = "";
                txt_productPrice.Text = "";
            };
            #endregion
            #region 刪除細項
            btn_Delete.Click += (s, e) =>
            {
                for (int i = 0; i < PurchaseSubSettings.Count; i++)
                {
                    if (PurchaseSubSettings[i].PurchaseNo == FocusePurchaseSubSetting.PurchaseNo)
                    {
                        PurchaseSubSettings.RemoveAt(i);
                    }
                }
                RefraeshPurchaseNo();
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
                FocusePurchaseSubSetting.PurchaseFlag = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PurchaseFlag").ToString()) - 1;
                FocusePurchaseSubSetting.PurchaseNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PurchaseNumber").ToString();
                FocusePurchaseSubSetting.PurchaseNo = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PurchaseNo").ToString());
                FocusePurchaseSubSetting.ProductNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductNumber").ToString();
                FocusePurchaseSubSetting.ProductName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductName").ToString();
                FocusePurchaseSubSetting.ProductUnit = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductUnit").ToString();
                FocusePurchaseSubSetting.ProductQty = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductQty").ToString());
                FocusePurchaseSubSetting.ProductPrice = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductPrice").ToString());
                FocusePurchaseSubSetting.ProductTotal = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductTotal").ToString());

                //Show_ProductNumber_Index();
                //txt_ProducUnit.Text = FocusePurchaseSubSetting.ProductUnit;
                //txt_productQty.Text = FocusePurchaseSubSetting.ProductQty.ToString();
                //txt_productPrice.Text = FocusePurchaseSubSetting.ProductPrice.ToString();
            }
            else
            {
                FocusePurchaseSubSetting = new PurchaseSubSetting();
            }
        }
        #endregion
        #region 刷新細項編號
        /// <summary>
        /// 刷新細項編號
        /// </summary>
        private void RefraeshPurchaseNo()
        {
            for (int i = 0; i < PurchaseSubSettings.Count; i++)
            {
                PurchaseSubSettings[i].PurchaseNo = i + 1;
            }
        }
        #endregion
        #region 刷新報表
        /// <summary>
        /// 刷新報表
        /// </summary>
        private void RefreshData()
        {
            gridControl1.DataSource = PurchaseSubSettings;
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
            if (PurchaseSubSettings.Count > 0)
            {
                foreach (var item in PurchaseSubSettings)
                {
                    Total += item.ProductTotal;
                }
            }
            if (cbt_PurchaseTax.SelectedIndex == 0)
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
        private void Create_slt_PurchasecompanyNumber()
        {
            slt_PurchasecompanyNumber.Properties.DataSource = CompanySettings;
            slt_PurchasecompanyNumber.Properties.DisplayMember = "CompanyName";
            slt_PurchasecompanyNumber.CustomDisplayText += (s, e) =>
              {
                  if (PurchaseSetting != null)
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
                if (CompanySettings[i].CompanyNumber == PurchaseSetting.PurchaseCompanyNumber)
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
                    if (item.EmployeeNumber == PurchaseSetting.PurchaseEmployeeNumber)
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
                    if (ProductSettings[i].ProductNumber == FocusePurchaseSubSetting.ProductNumber)
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
                if (PurchaseSetting != null)
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
                if (ProjectSettings[i].ProjectNumber == PurchaseSetting.ProjectNumber)
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
        private void CheckNumber(PurchaseSetting purchaseSetting, APIMethod apiMethod)
        {
            string response = "";
            if (purchaseSetting != null && purchaseSetting.PurchaseNumber != null)
            {
                foreach (var item in PurchaseSubSettings)
                {
                    item.PurchaseNumber = txt_PurchaseNumber.Text;
                }
                action.Caption = "進貨修改錯誤";
                purchaseSetting.PurchaseFlag = cbt_PurchaseFlag.SelectedIndex + 1;
                purchaseSetting.PurchaseNumber = txt_PurchaseNumber.Text;
                purchaseSetting.ProjectNumber = Get_slt_ProjectNumber();
                purchaseSetting.PurchaseDate = Convert.ToDateTime(det_PurchaseDate.Text);
                purchaseSetting.PurchaseCompanyNumber = SelectCompanySetting.CompanyNumber;
                purchaseSetting.PurchaseTax = cbt_PurchaseTax.SelectedIndex;
                purchaseSetting.PurchaseInvoiceNo = txt_PurchaseInvoiceNo.Text;
                purchaseSetting.PurchaseEmployeeNumber = Get_cbt_EmployeeNumber_Number();
                purchaseSetting.Remark = mmt_Remark.Text;
                purchaseSetting.Posting = cbt_Posting.SelectedIndex;
                purchaseSetting.PurchaseSub = PurchaseSubSettings;
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
                response = apiMethod.Put_Purchase(value);
                if (response == "200")
                {
                    if (!string.IsNullOrEmpty(AttachmentFilePath))
                    {
                        response = apiMethod.Post_PurchaseAttachmentFile(purchaseSetting.PurchaseFlag, purchaseSetting.PurchaseDate, purchaseSetting.PurchaseNumber, AttachmentFilePath);
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
                if (!string.IsNullOrEmpty(det_PurchaseDate.Text) && SelectCompanySetting != null && cbt_EmployeeNumber.SelectedIndex > -1)
                {
                    PurchaseSetting PurchaseSetting = new PurchaseSetting()
                    {
                        PurchaseFlag = cbt_PurchaseFlag.SelectedIndex + 1,
                        PurchaseNumber = txt_PurchaseNumber.Text,
                        ProjectNumber = Get_slt_ProjectNumber(),
                        PurchaseDate = Convert.ToDateTime(det_PurchaseDate.Text),
                        PurchaseCompanyNumber = SelectCompanySetting.CompanyNumber,
                        PurchaseTax = cbt_PurchaseTax.SelectedIndex,
                        PurchaseInvoiceNo = txt_PurchaseInvoiceNo.Text,
                        PurchaseEmployeeNumber = Get_cbt_EmployeeNumber_Number(),
                        Remark = mmt_Remark.Text,
                        Posting = cbt_Posting.SelectedIndex,
                        PurchaseSub = PurchaseSubSettings
                    };
                    if (PurchaseSetting.Posting == 1)
                    {
                        PurchaseSetting.PostingDate = DateTime.Now;
                    }
                    else
                    {
                        PurchaseSetting.PostingDate = null;
                    }
                    string value = JsonConvert.SerializeObject(PurchaseSetting);
                    response = apiMethod.Post_Purchase(value);
                    if (response == "200")
                    {
                        if (!string.IsNullOrEmpty(AttachmentFilePath) && !string.IsNullOrEmpty(apiMethod.ResponseDataMessage))
                        {
                            List<PurchaseSetting> settings = JsonConvert.DeserializeObject<List<PurchaseSetting>>(apiMethod.ResponseDataMessage);
                            response = apiMethod.Post_PurchaseAttachmentFile(settings[0].PurchaseFlag, settings[0].PurchaseDate, settings[0].PurchaseNumber, AttachmentFilePath);
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