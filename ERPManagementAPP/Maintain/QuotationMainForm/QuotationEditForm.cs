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

namespace ERPManagementAPP.Maintain.QuotationMainForm
{
    public partial class QuotationEditForm : BaseEditForm
    {
        /// <summary>
        /// 聚焦表身資訊
        /// </summary>
        private QuotationSubSetting FocuseQuotationSubSetting { get; set; } = new QuotationSubSetting();
        /// <summary>
        /// 表身資訊
        /// </summary>
        private List<QuotationSubSetting> QuotationSubSettings { get; set; } = new List<QuotationSubSetting>();
        /// <summary>
        /// 進貨資訊
        /// </summary>
        private QuotationSetting QuotationSetting { get; set; } = new QuotationSetting();
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
        /// 被選擇的公司資訊
        /// </summary>
        private CustomerSetting SelectCustomerSetting { get; set; }
        /// <summary>
        /// 被選擇的項次資訊
        /// </summary>
        private QuotationSubSetting SelectQuotationSubSetting { get; set; }
        /// <summary>
        /// 下拉選單項次資訊
        /// </summary>
        private List<QuotationSubSetting> sltQuotationSubSetting { get; set; }
        /// <summary>
        /// 被選擇的專案資訊
        /// </summary>
        private ProjectSetting SelectProjectSetting { get; set; }
        /// <summary>
        /// 訂購需知
        /// </summary>
        private string QuotationNote = "";
        /// <summary>
        /// 產品數量
        /// </summary>
        private double ProductQty = 0;
        /// <summary>
        /// 產品單價
        /// </summary>
        private double ProductPrice = 0;
        /// <summary>
        /// 數量合計
        /// </summary>
        private double TotalQty = 0;
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
        public QuotationEditForm(List<CustomerSetting> customerSettings, List<EmployeeSetting> employeeSettings, List<ProjectSetting> projectSettings, QuotationSetting quotationSetting, APIMethod apiMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            action.Commands.Add(FlyoutCommand.Yes);
            action1.Commands.Add(FlyoutCommand.Yes);
            action1.Commands.Add(FlyoutCommand.Cancel);
            CustomerSettings = customerSettings;
            EmployeeSettings = employeeSettings;
            QuotationSetting = quotationSetting;
            ProjectSettings = projectSettings;
            Create_slt_QuotationcustomerNumber_cbt();
            Create_cbt_EmployeeNumber_cbt();
            Create_slt_ProjectNumber();
            if (QuotationSetting != null)
            {
                txt_QuotationNumber.Text = quotationSetting.QuotationNumber;
                det_QuotationDate.Text = quotationSetting.QuotationDate.ToString("yyyy年MM月dd日");
                cbt_InvalidFlag.SelectedIndex = Convert.ToInt32(quotationSetting.InvalidFlag);
                Show_QuotationCustomerNumber_Index();
                Show_ProjectNumber_Index();
                Show_EmployeeNumber_Index();
                cbt_QuotationTax.SelectedIndex = quotationSetting.QuotationTax;
                txt_Address.Text = quotationSetting.Address;
                mmt_Remark.Text = quotationSetting.Remark;
                QuotationSubSettings = quotationSetting.QuotationSub;
            }
            else
            {
                det_QuotationDate.EditValue = DateTime.Now;
                if (Form1.EmployeeSetting != null)
                {
                    Show_EmployeeNumber_Index(Form1.EmployeeSetting.EmployeeName);
                }
            }
            mmt_Remark.EditValue = "1、報價有效期限 : 14天\r\n2、付款方式 : 依客戶規定\r\n3、貨幣別 : NTD\r\n4、本報價單經客戶簽名加蓋公司章回傳、即視同客戶訂購單";
            CacalculateData();
            RefreshData();
            First_FocuseMainGrid();
            Create_cbt_Quotation();
            cbt_QuotationTax.SelectedIndexChanged += (s, e) =>
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
                if (!string.IsNullOrEmpty(txt_ProductName.Text))
                {
                    QuotationSubSetting setting = new QuotationSubSetting()
                    {
                        QuotationNumber = "",
                        ProductName = txt_ProductName.Text,
                        ProductUnit = txt_ProducUnit.Text,
                        ProductQty = Convert.ToDouble(txt_productQty.Text),
                        ProductPrice = Convert.ToDouble(txt_productPrice.Text),
                        ProductTotal = Convert.ToDouble(txt_productQty.Text) * Convert.ToDouble(txt_productPrice.Text)
                    };
                    if (String.IsNullOrEmpty(slt_QuotationSub.Text))
                    {
                        setting.LineFlag = 0;
                        var data = QuotationSubSettings.Where(g => g.QuotationSubNo == 0 & g.QuotationThrNo == 0).ToList();
                        setting.QuotationNo = data.Count + 1;
                        setting.QuotationSubNo = 0;
                        setting.QuotationThrNo = 0;
                        //setting.QuotationNoStr = $"{setting.QuotationNo}";
                    }
                    else
                    {
                        if (SelectQuotationSubSetting != null)
                        {
                            if (SelectQuotationSubSetting.QuotationSubNo != 0)
                            {
                                setting.LineFlag = 2;
                                var data = QuotationSubSettings.Where(g => g.QuotationNo == SelectQuotationSubSetting.QuotationNo & g.QuotationSubNo == SelectQuotationSubSetting.QuotationSubNo & g.QuotationThrNo != 0).ToList();
                                setting.QuotationNo = SelectQuotationSubSetting.QuotationNo;
                                setting.QuotationSubNo = SelectQuotationSubSetting.QuotationSubNo;
                                setting.QuotationThrNo = data.Count() + 1;
                                //setting.QuotationNoStr = $"";
                            }
                            else
                            {
                                setting.LineFlag = 1;
                                var data = QuotationSubSettings.Where(g => g.QuotationNo == SelectQuotationSubSetting.QuotationNo & g.QuotationSubNo != 0 & g.QuotationThrNo == 0).ToList();
                                setting.QuotationNo = SelectQuotationSubSetting.QuotationNo;
                                setting.QuotationSubNo = data.Count() + 1;
                                setting.QuotationThrNo = 0;
                                //setting.QuotationNoStr = $"{setting.QuotationNo}-{setting.QuotationSubNo}";
                            }
                        }
                    }
                    QuotationSubSettings.Add(setting);
                    if (QuotationSubSettings != null)
                    {
                        sltQuotationSubSetting = QuotationSubSettings.Where(g => g.QuotationThrNo == 0).ToList();
                    }
                    slt_QuotationSub.Properties.DataSource = sltQuotationSubSetting.OrderBy(g => g.QuotationNo).ToList();
                    slt_QuotationSub.EditValue = null;
                    SelectQuotationSubSetting = null;
                    txt_productQty.Text = "0";
                    txt_productPrice.Text = "0";
                    txt_ProductName.Text = "";
                    CacalculateData();
                    RefreshData();
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
                slt_QuotationSub.EditValue = null;
                SelectQuotationSubSetting = null;
                txt_ProducUnit.Text = "";
                txt_productQty.Text = "0";
                txt_productPrice.Text = "0";
                txt_ProductName.Text = "";
            };
            #endregion
            #region 刪除細項
            btn_Delete.Click += (s, e) =>
            {
                if (FocuseQuotationSubSetting.QuotationSubNo == 0 && FocuseQuotationSubSetting.QuotationThrNo == 0)
                {
                    QuotationSubSettings.RemoveAll(g => g.QuotationNo == FocuseQuotationSubSetting.QuotationNo);
                }
                else if (FocuseQuotationSubSetting.QuotationSubNo != 0 && FocuseQuotationSubSetting.QuotationThrNo == 0)
                {
                    QuotationSubSettings.RemoveAll(g => g.QuotationNo == FocuseQuotationSubSetting.QuotationNo && g.QuotationSubNo == FocuseQuotationSubSetting.QuotationSubNo);
                }
                else if (FocuseQuotationSubSetting.QuotationSubNo != 0 && FocuseQuotationSubSetting.QuotationThrNo != 0)
                {
                    QuotationSubSettings.RemoveAll(g => g.QuotationNo == FocuseQuotationSubSetting.QuotationNo && g.QuotationSubNo == FocuseQuotationSubSetting.QuotationSubNo && g.QuotationThrNo == FocuseQuotationSubSetting.QuotationThrNo);
                }
                RefraeshPurchaseNo();
                CacalculateData();
                RefreshData();
                if (QuotationSubSettings != null)
                {
                    sltQuotationSubSetting = QuotationSubSettings.Where(g => g.QuotationThrNo == 0).ToList();
                }
                slt_QuotationSub.Properties.DataSource = sltQuotationSubSetting.OrderBy(g => g.QuotationNo).ToList();
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
                CheckNumber(quotationSetting, apiMethod);
            };
            #endregion
            #region 另存按鈕
            btn_SaveAs.Click += (s, e) =>
            {
                CheckNumber_New(apiMethod);
            };
            #endregion
            #region 列印
            btn_Export.Click += (s, e) =>
            {
                if (quotationSetting != null)
                {
                    action1.Caption = "訂購單儲存並預覽";
                    if (FlyoutDialog.Show(Form1, action1) == DialogResult.Yes)
                    {
                        string response = "";
                        quotationSetting.QuotationNumber = txt_QuotationNumber.Text;
                        quotationSetting.ProjectNumber = Get_slt_ProjectNumber();
                        quotationSetting.QuotationDate = Convert.ToDateTime(det_QuotationDate.Text);
                        quotationSetting.QuotationCustomerNumber = SelectCustomerSetting.CustomerNumber;
                        quotationSetting.QuotationDirectoryNumber = "";
                        quotationSetting.Address = txt_Address.Text;
                        quotationSetting.QuotationEmployeeNumber = Get_cbt_EmployeeNumber_Number();
                        quotationSetting.Remark = mmt_Remark.Text;
                        quotationSetting.TotalQty = Convert.ToDouble(txt_TotalQty.EditValue);
                        quotationSetting.QuotationSub = QuotationSubSettings;
                        quotationSetting.Total = Convert.ToDouble(txt_Total.EditValue);
                        quotationSetting.Tax = Convert.ToDouble(txt_Tax.EditValue);
                        quotationSetting.TotalTax = Convert.ToDouble(txt_TotalTax.EditValue);
                        quotationSetting.QuotationNote = QuotationNote;
                        foreach (var item in quotationSetting.QuotationSub)
                        {
                            item.QuotationNumber = txt_QuotationNumber.Text;
                        }
                        string value = JsonConvert.SerializeObject(quotationSetting);
                        response = apiMethod.Put_Quotation(value);
                        QuotationReportForm purchaseEdit = new QuotationReportForm(SelectCustomerSetting, EmployeeSettings[cbt_EmployeeNumber.SelectedIndex], SelectProjectSetting, quotationSetting);
                        if (purchaseEdit.ShowDialog() == DialogResult.Cancel) { }
                    }
                    //else
                    //{
                    //    QuotationReportForm purchaseEdit = new QuotationReportForm(SelectCustomerSetting, EmployeeSettings[cbt_EmployeeNumber.SelectedIndex], SelectProjectSetting, quotationSetting);
                    //    if (purchaseEdit.ShowDialog() == DialogResult.Cancel) { }
                    //}
                }
                else
                {
                    action1.Caption = "訂購單儲存並預覽";
                    if (FlyoutDialog.Show(Form1, action1) == DialogResult.Yes)
                    {
                        if (!string.IsNullOrEmpty(det_QuotationDate.Text) && SelectCustomerSetting != null && cbt_EmployeeNumber.SelectedIndex > -1)
                        {
                            string response = "";
                            QuotationSetting QuotationSetting = new QuotationSetting()
                            {
                                QuotationNumber = txt_QuotationNumber.Text,
                                ProjectNumber = Get_slt_ProjectNumber(),
                                QuotationDate = Convert.ToDateTime(det_QuotationDate.Text),
                                QuotationCustomerNumber = SelectCustomerSetting.CustomerNumber,
                                QuotationDirectoryNumber = "",
                                Address = txt_Address.Text,
                                QuotationEmployeeNumber = Get_cbt_EmployeeNumber_Number(),
                                Remark = mmt_Remark.Text,
                                TotalQty = Convert.ToDouble(txt_TotalQty.EditValue),
                                QuotationNote = QuotationNote,
                                Total = Convert.ToDouble(txt_Total.EditValue),
                                Tax = Convert.ToDouble(txt_Tax.EditValue),
                                TotalTax = Convert.ToDouble(txt_TotalTax.EditValue),
                                QuotationSub = QuotationSubSettings
                            };
                            string value = JsonConvert.SerializeObject(QuotationSetting);
                            response = apiMethod.Post_Quotation(value);
                            if (apiMethod.ResponseDataMessage != null)
                            {
                                var quotationsetting = JsonConvert.DeserializeObject<List<QuotationSetting>>(apiMethod.ResponseDataMessage);
                                txt_QuotationNumber.Text = quotationsetting[0].QuotationNumber;
                                QuotationReportForm purchaseEdit = new QuotationReportForm(SelectCustomerSetting, EmployeeSettings[cbt_EmployeeNumber.SelectedIndex], SelectProjectSetting, quotationsetting[0]);
                                if (purchaseEdit.ShowDialog() == DialogResult.Cancel) { }
                            }
                        }
                    }
                }
            };
            #endregion
        }
        #region 客戶編號功能
        /// <summary>
        /// 創建客戶編號下拉選單
        /// </summary>
        private void Create_slt_QuotationcustomerNumber_cbt()
        {
            slt_QuotationCustomerNumber.Properties.DataSource = CustomerSettings;
            slt_QuotationCustomerNumber.Properties.DisplayMember = "CustomerName";
            slt_QuotationCustomerNumber.CustomDisplayText += (s, e) =>
            {
                if (QuotationSetting != null)
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
        private void Show_QuotationCustomerNumber_Index()
        {
            for (int i = 0; i < CustomerSettings.Count; i++)
            {
                if (CustomerSettings[i].CustomerNumber == QuotationSetting.QuotationCustomerNumber)
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
        #region 聚焦主資料表功能
        /// <summary>
        /// 聚焦主資料表功能
        /// </summary>
        private void FocuseMainGrid()
        {
            if (gridView1.FocusedRowHandle > -1 && gridView1.DataRowCount > 0)
            {
                FocuseQuotationSubSetting.QuotationNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "QuotationNumber").ToString();
                FocuseQuotationSubSetting.QuotationNo = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "QuotationNo").ToString());
                FocuseQuotationSubSetting.QuotationSubNo = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "QuotationSubNo").ToString());
                FocuseQuotationSubSetting.QuotationThrNo = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "QuotationThrNo").ToString());
                FocuseQuotationSubSetting.ProductName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductName").ToString();
                FocuseQuotationSubSetting.ProductUnit = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductUnit").ToString();
                FocuseQuotationSubSetting.ProductQty = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductQty").ToString());
                FocuseQuotationSubSetting.ProductPrice = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductPrice").ToString());
                FocuseQuotationSubSetting.ProductTotal = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductTotal").ToString());
            }
            else
            {
                FocuseQuotationSubSetting = new QuotationSubSetting();
            }
        }
        private void First_FocuseMainGrid()
        {
            if (gridView1.DataRowCount > 0)
            {
                FocuseQuotationSubSetting.QuotationNumber = gridView1.GetRowCellValue(0, "QuotationNumber").ToString();
                FocuseQuotationSubSetting.QuotationNo = Convert.ToInt32(gridView1.GetRowCellValue(0, "QuotationNo").ToString());
                FocuseQuotationSubSetting.ProductName = gridView1.GetRowCellValue(0, "ProductName").ToString();
                FocuseQuotationSubSetting.ProductUnit = gridView1.GetRowCellValue(0, "ProductUnit").ToString();
                FocuseQuotationSubSetting.ProductQty = Convert.ToDouble(gridView1.GetRowCellValue(0, "ProductQty").ToString());
                FocuseQuotationSubSetting.ProductPrice = Convert.ToDouble(gridView1.GetRowCellValue(0, "ProductPrice").ToString());
                FocuseQuotationSubSetting.ProductTotal = Convert.ToDouble(gridView1.GetRowCellValue(0, "ProductTotal").ToString());
            }
            else
            {
                FocuseQuotationSubSetting = new QuotationSubSetting();
            }
        }
        #endregion
        #region 刷新細項編號
        /// <summary>
        /// 刷新細項編號
        /// </summary>
        private void RefraeshPurchaseNo()
        {
            var data = QuotationSubSettings.Where(g => g.QuotationSubNo == 0 & g.QuotationThrNo == 0).ToList();
            for (int x = 0; x < data.Count(); x++)
            {
                var datasub = QuotationSubSettings.Where(g => g.QuotationNo == data[x].QuotationNo && g.QuotationSubNo != 0 && g.QuotationThrNo == 0).ToList();
                for (int i = 0; i < datasub.Count(); i++)
                {
                    var datathr = QuotationSubSettings.Where(g => g.QuotationNo == data[x].QuotationNo && g.QuotationSubNo == datasub[i].QuotationSubNo && g.QuotationThrNo != 0).ToList();
                    for (int y = 0; y < datathr.Count(); y++)
                    {
                        datathr[y].QuotationNo = x + 1;
                        datathr[y].QuotationSubNo = i + 1;
                        datathr[y].QuotationThrNo = y + 1;
                    }
                    datasub[i].QuotationNo = x + 1;
                    datasub[i].QuotationSubNo = i + 1;
                    datasub[i].QuotationThrNo = 0;
                }
                data[x].QuotationNo = x + 1;
                data[x].QuotationSubNo = 0;
                data[x].QuotationThrNo = 0;

            }
        }
        #endregion
        #region 刷新報表
        /// <summary>
        /// 刷新報表
        /// </summary>
        private void RefreshData()
        {
            gridControl1.DataSource = QuotationSubSettings.OrderBy(g => g.QuotationNo).ToList();
            //QuotationSubSettings.OrderBy(g => g.QuotationNo & g.QuotationSubNo & g.QuotationThrNo).ToList();
            //gridView1.Columns["QuotationNo"].Group();
            gridControl1.RefreshDataSource();
        }
        #endregion
        #region 刷新計算數值
        /// <summary>
        /// 刷新計算數值
        /// </summary>
        private void CacalculateData()
        {
            TotalQty = 0;
            Total = 0;
            Tax = 0;
            TotalTax = 0;
            if (QuotationSubSettings.Count > 0)
            {
                foreach (var item in QuotationSubSettings)
                {
                    Total += item.ProductTotal;
                    TotalQty += item.ProductQty;
                }
            }
            if (cbt_QuotationTax.SelectedIndex == 0)
            {
                Tax = Math.Round(Total * 0.05, 0, MidpointRounding.AwayFromZero);
            }
            TotalTax = Total + Tax;
            txt_Total.EditValue = Total.ToString();
            txt_Tax.EditValue = Tax.ToString();
            txt_TotalTax.EditValue = $"{TotalTax.ToString()}";
            txt_TotalQty.Text = TotalQty.ToString();
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
                    if (item.EmployeeNumber == QuotationSetting.QuotationEmployeeNumber)
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
        private void Show_EmployeeNumber_Index(string Name)
        {
            int Index = -1;
            if (EmployeeSettings != null)
            {
                foreach (var item in EmployeeSettings)
                {
                    if (item.EmployeeName == Name)
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
        #region 項次功能
        private void Create_cbt_Quotation()
        {
            if (QuotationSubSettings != null)
            {
                sltQuotationSubSetting = QuotationSubSettings.Where(g => g.QuotationThrNo == 0).ToList();
            }
            slt_QuotationSub.Properties.DataSource = sltQuotationSubSetting;
            slt_QuotationSub.Properties.DisplayMember = "ProductName";
            gridView21.CustomColumnDisplayText += (s, e) =>
            {
                if (e.Column.FieldName == "LineFlag")
                {
                    int value = Convert.ToInt32(e.Value.ToString());
                    switch (value)
                    {
                        case 0:
                            {
                                e.DisplayText = "大項";
                            }
                            break;
                        case 1:
                            {
                                e.DisplayText = "中項";
                            }
                            break;
                        case 2:
                            {
                                e.DisplayText = "小項";
                            }
                            break;
                    }
                }
            };
            slt_QuotationSub.CustomDisplayText += (s, e) =>
            {
                SelectQuotationSubSetting = e.Value as QuotationSubSetting;
                if (SelectQuotationSubSetting != null)
                {
                    e.DisplayText = $"{SelectQuotationSubSetting.QuotationNoStr},{SelectQuotationSubSetting.ProductName}";
                }
                else
                {
                    e.DisplayText = "";
                }
            };
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
                if (QuotationSetting != null)
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
                if (ProjectSettings[i].ProjectNumber == QuotationSetting.ProjectNumber)
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
        private void CheckNumber(QuotationSetting quotationSetting, APIMethod apiMethod)
        {
            string response = "";
            if (quotationSetting != null && quotationSetting.QuotationNumber != null)
            {
                foreach (var item in QuotationSubSettings)
                {
                    item.QuotationNumber = txt_QuotationNumber.Text;
                }
                action.Caption = "訂購修改錯誤";
                quotationSetting.InvalidFlag = Convert.ToBoolean(cbt_InvalidFlag.SelectedIndex);
                quotationSetting.QuotationNumber = txt_QuotationNumber.Text;
                quotationSetting.ProjectNumber = Get_slt_ProjectNumber();
                quotationSetting.QuotationDate = Convert.ToDateTime(det_QuotationDate.Text);
                quotationSetting.QuotationCustomerNumber = SelectCustomerSetting.CustomerNumber;
                quotationSetting.QuotationDirectoryNumber = "";
                quotationSetting.Address = txt_Address.Text;
                quotationSetting.QuotationEmployeeNumber = Get_cbt_EmployeeNumber_Number();
                quotationSetting.Remark = mmt_Remark.Text;
                quotationSetting.QuotationTax = cbt_QuotationTax.SelectedIndex;
                quotationSetting.TotalQty = Convert.ToDouble(txt_TotalQty.EditValue);
                quotationSetting.QuotationSub = QuotationSubSettings;
                quotationSetting.Total = Convert.ToDouble(txt_Total.EditValue);
                quotationSetting.Tax = Convert.ToDouble(txt_Tax.EditValue);
                quotationSetting.TotalTax = Convert.ToDouble(txt_TotalTax.EditValue);
                quotationSetting.QuotationNote = QuotationNote;
                foreach (var item in quotationSetting.QuotationSub)
                {
                    item.QuotationNumber = txt_QuotationNumber.Text;
                }
                string value = JsonConvert.SerializeObject(quotationSetting);
                response = apiMethod.Put_Quotation(value);
                if (response == "200")
                {
                    if (!string.IsNullOrEmpty(AttachmentFilePath))
                    {
                        response = apiMethod.Post_QuotationAttachmentFile(quotationSetting.QuotationDate, quotationSetting.QuotationNumber, AttachmentFilePath);
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
                if (!string.IsNullOrEmpty(det_QuotationDate.Text) && SelectCustomerSetting != null && cbt_EmployeeNumber.SelectedIndex > -1)
                {
                    QuotationSetting QuotationSetting = new QuotationSetting()
                    {
                        InvalidFlag = Convert.ToBoolean(cbt_InvalidFlag.SelectedIndex),
                        QuotationNumber = txt_QuotationNumber.Text,
                        ProjectNumber = Get_slt_ProjectNumber(),
                        QuotationDate = Convert.ToDateTime(det_QuotationDate.Text),
                        QuotationCustomerNumber = SelectCustomerSetting.CustomerNumber,
                        QuotationDirectoryNumber = "",
                        Address = txt_Address.Text,
                        QuotationEmployeeNumber = Get_cbt_EmployeeNumber_Number(),
                        Remark = mmt_Remark.Text,
                        QuotationTax = cbt_QuotationTax.SelectedIndex,
                        TotalQty = Convert.ToDouble(txt_TotalQty.EditValue),
                        QuotationNote = QuotationNote,
                        Total = Convert.ToDouble(txt_Total.EditValue),
                        Tax = Convert.ToDouble(txt_Tax.EditValue),
                        TotalTax = Convert.ToDouble(txt_TotalTax.EditValue),
                        QuotationSub = QuotationSubSettings,
                    };
                    string value = JsonConvert.SerializeObject(QuotationSetting);
                    response = apiMethod.Post_Quotation(value);
                    if (response == "200")
                    {
                        if (!string.IsNullOrEmpty(AttachmentFilePath) && !string.IsNullOrEmpty(apiMethod.ResponseDataMessage))
                        {
                            List<QuotationSetting> settings = JsonConvert.DeserializeObject<List<QuotationSetting>>(apiMethod.ResponseDataMessage);
                            response = apiMethod.Post_QuotationAttachmentFile(settings[0].QuotationDate, settings[0].QuotationNumber, AttachmentFilePath);
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
        #region 另存檢查資料問題
        private void CheckNumber_New(APIMethod apiMethod)
        {
            string response = "";
            if (!string.IsNullOrEmpty(det_QuotationDate.Text) && SelectCustomerSetting != null && cbt_EmployeeNumber.SelectedIndex > -1)
            {
                QuotationSetting QuotationSetting = new QuotationSetting()
                {
                    InvalidFlag = Convert.ToBoolean(cbt_InvalidFlag.SelectedIndex),
                    QuotationNumber = txt_QuotationNumber.Text,
                    ProjectNumber = Get_slt_ProjectNumber(),
                    QuotationDate = Convert.ToDateTime(det_QuotationDate.Text),
                    QuotationCustomerNumber = SelectCustomerSetting.CustomerNumber,
                    QuotationDirectoryNumber = "",
                    Address = txt_Address.Text,
                    QuotationEmployeeNumber = Get_cbt_EmployeeNumber_Number(),
                    Remark = mmt_Remark.Text,
                    QuotationTax = cbt_QuotationTax.SelectedIndex,
                    TotalQty = Convert.ToDouble(txt_TotalQty.EditValue),
                    QuotationNote = QuotationNote,
                    Total = Convert.ToDouble(txt_Total.EditValue),
                    Tax = Convert.ToDouble(txt_Tax.EditValue),
                    TotalTax = Convert.ToDouble(txt_TotalTax.EditValue),
                    QuotationSub = QuotationSubSettings,
                };
                string value = JsonConvert.SerializeObject(QuotationSetting);
                response = apiMethod.Post_Quotation(value);
                if (response == "200")
                {
                    if (!string.IsNullOrEmpty(AttachmentFilePath) && !string.IsNullOrEmpty(apiMethod.ResponseDataMessage))
                    {
                        List<QuotationSetting> settings = JsonConvert.DeserializeObject<List<QuotationSetting>>(apiMethod.ResponseDataMessage);
                        response = apiMethod.Post_QuotationAttachmentFile(settings[0].QuotationDate, settings[0].QuotationNumber, AttachmentFilePath);
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
        #endregion
    }
}