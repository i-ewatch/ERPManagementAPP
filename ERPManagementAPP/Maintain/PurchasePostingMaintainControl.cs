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
    public partial class PurchasePostingMaintainControl : Field4MaintainControl
    {
        /// <summary>
        /// 公司資訊
        /// </summary>
        private List<CompanySetting> CompanySettings { get; set; }
        /// <summary>
        /// 聚焦進貨表頭
        /// </summary>
        private PurchaseMainSetting FocusePurchaseMainSetting { get; set; } = new PurchaseMainSetting();
        /// <summary>
        /// 總表頭
        /// </summary>
        private List<PurchaseMainSetting> PurchaseMainSettings { get; set; } = new List<PurchaseMainSetting>();
        /// <summary>
        /// 篩選總表頭
        /// </summary>
        private List<PurchaseMainSetting> FilterPurchaseMainSettings { get; set; } = new List<PurchaseMainSetting>();
        public PurchasePostingMaintainControl(APIMethod APIMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            apiMethod = APIMethod;
            #region 進貨資料表
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 進貨資訊報表按鈕
            RepositoryItemButtonEdit PurchasePostingedit = new RepositoryItemButtonEdit();
            PurchasePostingedit.ButtonClick += (s, e) =>
            {
                FocuseMainGrid();
                if (e.Button.Kind == ButtonPredefines.Plus)
                {
                    if (FocusePurchaseMainSetting.Posting == 0)
                    {
                        foreach (var item in FilterPurchaseMainSettings)
                        {
                            if (item.PurchaseNumber == FocusePurchaseMainSetting.PurchaseNumber)
                            {
                                item.Posting = 1;
                                item.PostingDate = DateTime.Now;
                                FocusePurchaseMainSetting.Posting = 1;
                                FocusePurchaseMainSetting.PostingDate = DateTime.Now;
                                string value = JsonConvert.SerializeObject(FocusePurchaseMainSetting);
                                apiMethod.Put_PurchaseMain(value);
                            }
                        }
                    }
                }
            };
            PurchasePostingedit.Buttons[0].Kind = ButtonPredefines.Plus;
            PurchasePostingedit.Buttons[0].Caption = "過帳";
            PurchasePostingedit.TextEditStyle = TextEditStyles.DisableTextEditor;
            PurchasegridControl.RepositoryItems.Add(PurchasePostingedit);
            gridView1.Columns["Posting"].ColumnEdit = PurchasePostingedit;
            gridView1.Columns["Posting"].ShowButtonMode = ShowButtonModeEnum.ShowAlways;
            #endregion
            #region 群組功能
            gridView1.Columns["PurchaseCompanyNumber"].Group();
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
            #region 進貨聚焦功能
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
                CompanySetting company = CompanySettings.SingleOrDefault(g => g.CompanyNumber == Index);
                if (company != null)
                {
                    string checkoutType = "";
                    switch (company.CheckoutType)
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
                    row.GroupText = $"廠商編號 : {company.CompanyName} , 付款方式 : {checkoutType}";
                }
            };
            #endregion
            #region 報表修改字串功能
            gridView1.CustomDrawCell += (s, e) =>
            {
                if (e.Column.FieldName == "PurchaseFlag")
                {
                    e.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
                    string Index = e.CellValue.ToString();
                    switch (Index)
                    {
                        case "1":
                            {
                                e.DisplayText = "進貨";
                            }
                            break;
                        case "2":
                            {
                                e.DisplayText = "進貨退出";
                            }
                            break;
                    }
                }
                else if (e.Column.FieldName == "PurchaseCompanyNumber")
                {
                    e.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
                    string Index = e.CellValue.ToString();
                    CompanySetting company = CompanySettings.SingleOrDefault(g => g.CompanyNumber == Index);
                    if (company != null)
                    {
                        e.DisplayText = company.CompanyName;
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
            btn_Purchase_Search.Click += (s, e) =>
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
                FocusePurchaseMainSetting.PurchaseFlag = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PurchaseFlag").ToString());
                FocusePurchaseMainSetting.PurchaseNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PurchaseNumber").ToString();
                FocusePurchaseMainSetting.PurchaseDate = Convert.ToDateTime(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PurchaseDate").ToString());
                FocusePurchaseMainSetting.PurchaseCompanyNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PurchaseCompanyNumber").ToString();
                FocusePurchaseMainSetting.PurchaseTax = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PurchaseTax").ToString());
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PurchaseInvoiceNo") != null)
                {
                    FocusePurchaseMainSetting.PurchaseInvoiceNo = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PurchaseInvoiceNo").ToString();
                }
                else
                {
                    FocusePurchaseMainSetting.PurchaseInvoiceNo = "";
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PurchaseEmployeeNumber") != null)
                {
                    FocusePurchaseMainSetting.PurchaseEmployeeNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PurchaseEmployeeNumber").ToString();
                }
                else
                {
                    FocusePurchaseMainSetting.PurchaseEmployeeNumber = "";
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Remark") != null)
                {
                    FocusePurchaseMainSetting.Remark = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Remark").ToString();
                }
                else
                {
                    FocusePurchaseMainSetting.Remark = "";
                }
                FocusePurchaseMainSetting.Total = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Total").ToString());
                FocusePurchaseMainSetting.Tax = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tax").ToString());
                FocusePurchaseMainSetting.TotalTax = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TotalTax").ToString());
                FocusePurchaseMainSetting.Posting = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Posting").ToString());
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FileName") != null)
                {
                    FocusePurchaseMainSetting.FileName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FileName").ToString();
                }
                else
                {
                    FocusePurchaseMainSetting.FileName = "";
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PostingDate") != null)
                {
                    FocusePurchaseMainSetting.PostingDate = Convert.ToDateTime(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PostingDate").ToString());
                }
                else
                {
                    FocusePurchaseMainSetting.PostingDate = null;
                }
            }
            else
            {
                FocusePurchaseMainSetting = new PurchaseMainSetting();
            }
        }
        #endregion
        public override void Refresh_Main_GridView()
        {
            Refersh_API();
            PurchaseMainSettings = apiMethod.Get_PurchasePosting();
            foreach (var item in PurchaseMainSettings)
            {
                if (item.PurchaseFlag == 2)
                {
                    item.Total = -1 * item.Total;
                    item.TotalTax = -1 * item.TotalTax;
                }
            }
            Controller();
        }
        private void Refersh_API()
        {
            CompanySettings = apiMethod.Get_Company();
        }
        #region 未過戶廠商篩選功能
        /// <summary>
        /// 未過戶廠商篩選功能
        /// </summary>
        private void Controller()
        {
            FilterPurchaseMainSettings = new List<PurchaseMainSetting>();
            int SystemTime = DateTime.Now.Month;
            foreach (var Companyitem in CompanySettings)
            {
                switch (Companyitem.CheckoutType)
                {
                    case 0://現金
                        {
                            List<PurchaseMainSetting> setting = PurchaseMainSettings.Where(g => g.PurchaseCompanyNumber == Companyitem.CompanyNumber).ToList();
                            if (setting != null)
                            {
                                foreach (var item in setting)
                                {
                                    FilterPurchaseMainSettings.Add(item);
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
                            List<PurchaseMainSetting> setting = PurchaseMainSettings.Where(g => g.PurchaseCompanyNumber == Companyitem.CompanyNumber).ToList();
                            if (setting != null)
                            {
                                foreach (var item in setting)
                                {
                                    if (SystemTime >= item.PurchaseDate.Month)
                                    {
                                        FilterPurchaseMainSettings.Add(item);
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
                            List<PurchaseMainSetting> setting = PurchaseMainSettings.Where(g => g.PurchaseCompanyNumber == Companyitem.CompanyNumber).ToList();
                            if (setting != null)
                            {
                                foreach (var item in setting)
                                {
                                    if (SystemTime >= item.PurchaseDate.Month)
                                    {
                                        FilterPurchaseMainSettings.Add(item);
                                    }
                                }
                            }
                        }
                        break;
                    case 3://其他
                        {
                            if (cet_Other.CheckState == CheckState.Checked)
                            {
                                List<PurchaseMainSetting> setting = PurchaseMainSettings.Where(g => g.PurchaseCompanyNumber == Companyitem.CompanyNumber).ToList();
                                if (setting != null)
                                {
                                    foreach (var item in setting)
                                    {
                                        FilterPurchaseMainSettings.Add(item);
                                    }
                                }
                            }
                        }
                        break;
                }
            }
            PurchasegridControl.DataSource = FilterPurchaseMainSettings;
            gridView1.ExpandAllGroups();
        }
        #endregion
    }
}
