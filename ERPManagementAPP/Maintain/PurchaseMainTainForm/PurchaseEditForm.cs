using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
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
using System.Threading;
using System.Threading.Tasks;
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
        /// 被選擇的公司資訊
        /// </summary>
        private CompanySetting SelectCompanySetting { get; set; }
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
        public PurchaseEditForm(List<CompanySetting> companySettings, List<EmployeeSetting> employeeSettings, List<ProductSetting> productSettings, PurchaseSetting purchaseSetting, APIMethod apiMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            action.Commands.Add(FlyoutCommand.Yes);
            CompanySettings = companySettings;
            EmployeeSettings = employeeSettings;
            ProductSettings = productSettings;
            PurchaseSetting = purchaseSetting;
            Create_slt_PurchasecompanyNumber();
            Create_cbt_EmployeeNumber_cbt();
            Create_cbt_ProductName_cbt();
            if (purchaseSetting != null)
            {
                cbt_PurchaseFlag.Enabled = false;
                cbt_PurchaseFlag.SelectedIndex = purchaseSetting.PurchaseFlag - 1;
                txt_PurchaseNumber.Text = purchaseSetting.PurchaseNumber;
                det_PurchaseDate.Text = purchaseSetting.PurchaseDate.ToString("yyyy年MM月dd日");
                Show_ProductCompanyNumber_Index();
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
                if (cbt_ProductName.SelectedIndex > -1 && !string.IsNullOrEmpty(txt_ProducUnit.Text) && !string.IsNullOrEmpty(txt_productPrice.Text))
                {
                    PurchaseSubSettings.Add(new PurchaseSubSetting()
                    {
                        PurchaseFlag = cbt_PurchaseFlag.SelectedIndex + 1,
                        PurchaseNumber = "",
                        PurchaseNo = PurchaseSubSettings.Count() + 1,
                        ProductNumber = Get_cbt_ProductName_Number(),
                        ProductName = cbt_ProductName.Text,
                        ProductUnit = txt_ProducUnit.Text,
                        ProductQty = Convert.ToDouble(txt_productQty.Text),
                        ProductPrice = Convert.ToDouble(txt_productPrice.Text),
                        ProductTotal = Convert.ToDouble(txt_productQty.Text) * Convert.ToDouble(txt_productPrice.Text)
                    });
                    cbt_ProductName.SelectedIndex = -1;
                    //txt_ProducUnit.Text = "";
                    txt_productQty.Text = "";
                    txt_productPrice.Text = "";
                    CacalculateData();
                    RefreshData();
                    FocuseMainGrid();
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
                cbt_ProductName.SelectedIndex = -1;
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
                FocuseMainGrid();
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
                FocusePurchaseSubSetting.ProductName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductName").ToString();
                FocusePurchaseSubSetting.ProductUnit = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductUnit").ToString();
                FocusePurchaseSubSetting.ProductQty = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductQty").ToString());
                FocusePurchaseSubSetting.ProductPrice = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductPrice").ToString());
                FocusePurchaseSubSetting.ProductTotal = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductTotal").ToString());
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
            if (cbt_ProductName.Properties.Items.Count > 0)
            {
                cbt_ProductName.Properties.Items.Clear();
            }
            if (ProductSettings != null)
            {
                foreach (var item in ProductSettings)
                {
                    cbt_ProductName.Properties.Items.Add(item.ProductName);
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
            if (ProductSettings != null)
            {
                if (ProductSettings.Count > 0)
                {
                    value = ProductSettings[cbt_ProductName.SelectedIndex].ProductNumber;
                }
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
                string value = JsonConvert.SerializeObject(purchaseSetting);
                response = apiMethod.Put_Purchase(value);
                if (response == "200")
                {
                    if (!string.IsNullOrEmpty(AttachmentFilePath))
                    {
                        response = apiMethod.Post_PurchaseAttachmentFile(purchaseSetting.PurchaseFlag, purchaseSetting.PurchaseCompanyNumber, purchaseSetting.PurchaseDate, purchaseSetting.PurchaseNumber, AttachmentFilePath);
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
                        PurchaseDate = Convert.ToDateTime(det_PurchaseDate.Text),
                        PurchaseCompanyNumber = SelectCompanySetting.CompanyNumber,
                        PurchaseTax = cbt_PurchaseTax.SelectedIndex,
                        PurchaseInvoiceNo = txt_PurchaseInvoiceNo.Text,
                        PurchaseEmployeeNumber = Get_cbt_EmployeeNumber_Number(),
                        Remark = mmt_Remark.Text,
                        Posting = cbt_Posting.SelectedIndex,
                        PurchaseSub = PurchaseSubSettings
                    };
                    string value = JsonConvert.SerializeObject(PurchaseSetting);
                    response = apiMethod.Post_Purchase(value);
                    if (response == "200")
                    {
                        if (!string.IsNullOrEmpty(AttachmentFilePath) && !string.IsNullOrEmpty(apiMethod.ResponseDataMessage))
                        {
                            List<PurchaseSetting> settings = JsonConvert.DeserializeObject<List<PurchaseSetting>>(apiMethod.ResponseDataMessage);
                            response = apiMethod.Post_PurchaseAttachmentFile(settings[0].PurchaseFlag, settings[0].PurchaseCompanyNumber, settings[0].PurchaseDate, settings[0].PurchaseNumber, AttachmentFilePath);
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