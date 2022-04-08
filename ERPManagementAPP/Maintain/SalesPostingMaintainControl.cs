using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain
{
    public partial class SalesPostingMaintainControl : Field4MaintainControl
    {
        /// <summary>
        /// 客戶資訊
        /// </summary>
        private List<CustomerSetting> CustomerSettings { get; set; }
        /// <summary>
        /// 聚焦銷貨表頭
        /// </summary>
        private SalesMainSetting FocuseSalesMainSetting { get; set; } = new SalesMainSetting();
        /// <summary>
        /// 總表頭
        /// </summary>
        private List<SalesMainSetting> SalesMainSettings { get; set; } = new List<SalesMainSetting>();
        /// <summary>
        /// 篩選總表頭
        /// </summary>
        private List<SalesMainSetting> FilterSalesMainSettings { get; set; } = new List<SalesMainSetting>();
        public SalesPostingMaintainControl(APIMethod APIMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            apiMethod = APIMethod;
            #region 銷貨資料表
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 銷貨資訊報表按鈕
            RepositoryItemButtonEdit SalesPostingedit = new RepositoryItemButtonEdit();
            SalesPostingedit.ButtonClick += (s, e) =>
            {
                FocuseMainGrid();
                if (e.Button.Kind == ButtonPredefines.Plus)
                {
                    if (FocuseSalesMainSetting.Posting == 0)
                    {
                        foreach (var item in FilterSalesMainSettings)
                        {
                            if (item.SalesNumber == FocuseSalesMainSetting.SalesNumber)
                            {
                                if (item.Posting == 0)
                                {
                                    item.Posting = 1;
                                    item.PostingDate = DateTime.Now;
                                    item.ProfitSharingDate = null;
                                    FocuseSalesMainSetting.Posting = 1;
                                    FocuseSalesMainSetting.PostingDate = DateTime.Now;
                                    FocuseSalesMainSetting.ProfitSharingDate = null;
                                    string value = JsonConvert.SerializeObject(FocuseSalesMainSetting);
                                    apiMethod.Put_SalesMain(value);
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            };
            SalesPostingedit.Buttons[0].Kind = ButtonPredefines.Plus;
            SalesPostingedit.Buttons[0].Caption = "過帳";
            SalesPostingedit.TextEditStyle = TextEditStyles.DisableTextEditor;
            SalesgridControl.RepositoryItems.Add(SalesPostingedit);
            gridView1.Columns["Posting"].ColumnEdit = SalesPostingedit;
            gridView1.Columns["Posting"].ShowButtonMode = ShowButtonModeEnum.ShowAlways;
            #endregion
            #region 群組功能
            gridView1.Columns["SalesCustomerNumber"].Group();
            gridView1.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "Total",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "合計: {0:c0}",
                ShowInGroupColumnFooter = gridView1.Columns["Total"]
            });
            gridView1.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "TotalTax",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "稅後總計: {0:c0}",
                ShowInGroupColumnFooter = gridView1.Columns["TotalTax"]
            });
            #endregion
            #region 銷貨聚焦功能
            gridView1.FocusedRowChanged += (s, e) =>
            {
                FocuseMainGrid();
            };
            #endregion
            #region 關鍵字搜尋
            gridView1.ColumnFilterChanged += (s, e) =>
            {
                FocuseMainGrid();
            };
            #endregion
            #region 報表群組修改字串功能
            gridView1.CustomDrawGroupRow += (s, e) =>
            {
                GridGroupRowInfo row = e.Info as GridGroupRowInfo;
                string Index = row.EditValue.ToString();
                CustomerSetting customer = CustomerSettings.SingleOrDefault(g => g.CustomerNumber == Index);
                if (customer != null)
                {
                    string checkoutType = "";
                    switch (customer.CheckoutType)
                    {
                        case 0:
                            {
                                checkoutType = "現金";
                            }
                            break;
                        case 1:
                            {
                                checkoutType = "月結30天";
                            }
                            break;
                        case 2:
                            {
                                checkoutType = "月結60天";
                            }
                            break;
                        case 3:
                            {
                                checkoutType = "其他";
                            }
                            break;
                    }
                    row.GroupText = $"客戶編號 : {customer.CustomerName} , 付款方式 : {checkoutType}";
                }
            };
            #endregion
            #region 報表修改字串功能
            gridView1.CustomDrawCell += (s, e) =>
            {
                if (e.Column.FieldName == "SalesFlag")
                {
                    e.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
                    string Index = e.CellValue.ToString();
                    switch (Index)
                    {
                        case "3":
                            {
                                e.DisplayText = "銷貨";
                            }
                            break;
                        case "4":
                            {
                                e.DisplayText = "銷貨退出";
                            }
                            break;
                    }
                }
                else if (e.Column.FieldName == "SalesCustomerNumber")
                {
                    e.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
                    string Index = e.CellValue.ToString();
                    CustomerSetting company = CustomerSettings.SingleOrDefault(g => g.CustomerNumber == Index);
                    if (company != null)
                    {
                        e.DisplayText = company.CustomerName;
                    }
                }
                else if (e.Column.FieldName == "Posting")
                {
                    e.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
                    string Index = e.CellValue.ToString();
                    switch (Index)
                    {
                        case "0":
                            {
                                e.DisplayText = "未過帳";
                            }
                            break;
                        case "1":
                            {
                                e.DisplayText = "過帳";
                            }
                            break;
                    }
                }
            };
            #endregion
            #region 產品類別資料查詢
            btn_Sales_Search.Click += (s, e) =>
            {
                Refresh_Main_GridView();
            };
            #endregion
            #endregion
        }
        #region 聚焦主資料表功能
        private void FocuseMainGrid()
        {
            if (gridView1.FocusedRowHandle > -1 && gridView1.DataRowCount > 0)
            {
                FocuseSalesMainSetting.SalesFlag = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SalesFlag").ToString());
                FocuseSalesMainSetting.SalesNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SalesNumber").ToString();
                FocuseSalesMainSetting.SalesDate = Convert.ToDateTime(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SalesDate").ToString());
                FocuseSalesMainSetting.SalesCustomerNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SalesCustomerNumber").ToString();
                FocuseSalesMainSetting.SalesTax = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SalesTax").ToString());
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SalesInvoiceNo") != null)
                {
                    FocuseSalesMainSetting.SalesInvoiceNo = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SalesInvoiceNo").ToString();
                }
                else
                {
                    FocuseSalesMainSetting.SalesInvoiceNo = "";
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SalesEmployeeNumber") != null)
                {
                    FocuseSalesMainSetting.SalesEmployeeNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SalesEmployeeNumber").ToString();
                }
                else
                {
                    FocuseSalesMainSetting.SalesEmployeeNumber = "";
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Remark") != null)
                {
                    FocuseSalesMainSetting.Remark = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Remark").ToString();
                }
                else
                {
                    FocuseSalesMainSetting.Remark = "";
                }
                FocuseSalesMainSetting.Total = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Total").ToString());
                FocuseSalesMainSetting.Tax = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tax").ToString());
                FocuseSalesMainSetting.TotalTax = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TotalTax").ToString());
                FocuseSalesMainSetting.Posting = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Posting").ToString());
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FileName") != null)
                {
                    FocuseSalesMainSetting.FileName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FileName").ToString();
                }
                else
                {
                    FocuseSalesMainSetting.FileName = "";
                }
                FocuseSalesMainSetting.TakeACut = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TakeACut").ToString());
                FocuseSalesMainSetting.Cost = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Cost").ToString());
                FocuseSalesMainSetting.ProfitSharing = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProfitSharing").ToString());
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PostingDate") != null)
                {
                    FocuseSalesMainSetting.PostingDate = Convert.ToDateTime(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PostingDate").ToString());
                }
                else
                {
                    FocuseSalesMainSetting.PostingDate = null;
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProfitSharingDate") != null)
                {
                    FocuseSalesMainSetting.ProfitSharingDate = Convert.ToDateTime(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProfitSharingDate").ToString());
                }
                else
                {
                    FocuseSalesMainSetting.ProfitSharingDate = null;
                }
            }
            else
            {
                FocuseSalesMainSetting = new SalesMainSetting();
            }
        }
        #endregion
        public override void Refresh_Main_GridView()
        {
            Refresh_API();
            SalesMainSettings = apiMethod.Get_SalesPosting();
            if (SalesMainSettings != null)
            {
                foreach (var item in SalesMainSettings)
                {
                    if (item.SalesFlag == 4)
                    {
                        item.Total = -1 * item.Total;
                        item.TotalTax = -1 * item.TotalTax;
                    }
                }
                Controller();
            }
        }
        private void Refresh_API()
        {
            CustomerSettings = apiMethod.Get_Customer();
        }
        #region 未過帳客戶篩選功能
        /// <summary>
        /// 未過帳客戶篩選功能
        /// </summary>
        private void Controller()
        {
            FilterSalesMainSettings = new List<SalesMainSetting>();
            int SystemTime = DateTime.Now.Month;
            if (CustomerSettings != null)
            {
                foreach (var Customeritem in CustomerSettings)
                {
                    switch (Customeritem.CheckoutType)
                    {
                        case 0://現金
                            {
                                List<SalesMainSetting> setting = SalesMainSettings.Where(g => g.SalesCustomerNumber == Customeritem.CustomerNumber).ToList();
                                if (setting != null)
                                {
                                    foreach (var item in setting)
                                    {
                                        FilterSalesMainSettings.Add(item);
                                    }
                                }
                            }
                            break;
                        case 1://月結30天
                            {
                                if (SystemTime == 1)
                                {
                                    SystemTime = 11;
                                }
                                else if (SystemTime == 2)
                                {
                                    SystemTime = 12;
                                }
                                else
                                {
                                    SystemTime = SystemTime - 2;
                                }
                                List<SalesMainSetting> setting = SalesMainSettings.Where(g => g.SalesCustomerNumber == Customeritem.CustomerNumber).ToList();
                                if (setting != null)
                                {
                                    foreach (var item in setting)
                                    {
                                        if (SystemTime >= item.SalesDate.Month)
                                        {
                                            FilterSalesMainSettings.Add(item);
                                        }
                                    }
                                }
                            }
                            break;
                        case 2://月結60天
                            {
                                if (SystemTime == 1)
                                {
                                    SystemTime = 10;
                                }
                                else if (SystemTime == 2)
                                {
                                    SystemTime = 11;
                                }
                                else if (SystemTime == 3)
                                {
                                    SystemTime = 12;
                                }
                                else
                                {
                                    SystemTime = SystemTime - 3;
                                }
                                List<SalesMainSetting> setting = SalesMainSettings.Where(g => g.SalesCustomerNumber == Customeritem.CustomerNumber).ToList();
                                if (setting != null)
                                {
                                    foreach (var item in setting)
                                    {
                                        if (SystemTime >= item.SalesDate.Month)
                                        {
                                            FilterSalesMainSettings.Add(item);
                                        }
                                    }
                                }
                            }
                            break;
                        case 3://其他
                            {
                                if (cet_Other.CheckState == CheckState.Checked)
                                {
                                    List<SalesMainSetting> setting = SalesMainSettings.Where(g => g.SalesCustomerNumber == Customeritem.CustomerNumber).ToList();
                                    if (setting != null)
                                    {
                                        foreach (var item in setting)
                                        {
                                            FilterSalesMainSettings.Add(item);
                                        }
                                    }
                                }
                            }
                            break;
                    }
                }
                SalesgridControl.DataSource = FilterSalesMainSettings;
                gridView1.ExpandAllGroups();
            }
        }
        #endregion
    }
}
