using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraSplashScreen;
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
        /// 總進貨表頭
        /// </summary>
        private List<PurchaseMainSetting> PurchaseMainSettings { get; set; } = new List<PurchaseMainSetting>();
        /// <summary>
        /// 總營運表頭
        /// </summary>
        private List<OperatingMainSetting> OperatingMainSettings { get; set; } = new List<OperatingMainSetting>();
        /// <summary>
        /// 專案資訊
        /// </summary>
        private List<ProjectSetting> ProjectSettings { get; set; }
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
                    if (FocusePurchaseMainSetting.PurchaseFlag == 1 || FocusePurchaseMainSetting.PurchaseFlag == 2)
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
                    else if (FocusePurchaseMainSetting.PurchaseFlag == 7 || FocusePurchaseMainSetting.PurchaseFlag == 8)
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
                                    OperatingMainSetting setting = new OperatingMainSetting()
                                    {
                                        OperatingFlag = item.PurchaseFlag,
                                        OperatingNumber = item.PurchaseNumber,
                                        OperatingDate = item.PurchaseDate,
                                        OperatingCompanyNumber = item.PurchaseCompanyNumber,
                                        ProjectNumber = item.ProjectNumber,
                                        OperatingTax = item.PurchaseTax,
                                        OperatingInvoiceNo = item.PurchaseInvoiceNo,
                                        OperatingEmployeeNumber = item.PurchaseEmployeeNumber,
                                        Remark = item.Remark,
                                        Total = item.Total,
                                        Tax = item.Tax,
                                        TotalTax = item.TotalTax,
                                        FileName = item.FileName,
                                        Posting = item.Posting,
                                        PostingDate = item.PostingDate
                                    };
                                    string value = JsonConvert.SerializeObject(setting);
                                    apiMethod.Put_OperatingMain(value);
                                }
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
            gridView1.CustomColumnDisplayText += (s, e) =>
            {
                if (e.Column.FieldName == "PurchaseFlag")
                {
                    string Index = e.DisplayText.ToString();
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
                        case "7":
                            {
                                e.DisplayText = "營運";
                            }
                            break;
                        case "8":
                            {
                                e.DisplayText = "營運退出";
                            }
                            break;
                    }
                }
                else if (e.Column.FieldName == "ProjectNumber")
                {
                    if (e.DisplayText != null && ProjectSettings != null)
                    {
                        string Index = e.DisplayText.ToString();
                        ProjectSetting project = ProjectSettings.SingleOrDefault(g => g.ProjectNumber == Index);
                        if (project != null)
                        {
                            e.DisplayText = project.ProjectName;
                        }
                    }
                }
                else if (e.Column.FieldName == "PurchaseCompanyNumber")
                {
                    string Index = e.DisplayText.ToString();
                    CompanySetting company = CompanySettings.SingleOrDefault(g => g.CompanyNumber == Index);
                    if (company != null)
                    {
                        e.DisplayText = company.CompanyName;
                    }
                }
                else if (e.Column.FieldName == "Posting")
                {
                    string Index = e.DisplayText.ToString();
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
            handle = SplashScreenManager.ShowOverlayForm(FindForm());
            for (int i = 0; i < length; i++)
            {
                Refersh_API();
                PurchaseMainSettings = apiMethod.Get_PurchasePosting();
                OperatingMainSettings = apiMethod.Get_OperatingPosting();
                if (PurchaseMainSettings != null)
                {
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
                if (OperatingMainSettings != null)
                {
                    foreach (var item in OperatingMainSettings)
                    {
                        if (item.OperatingFlag == 8)
                        {
                            item.Total = -1 * item.Total;
                            item.TotalTax = -1 * item.TotalTax;
                        }
                    }
                    break;
                }
            }
            CloseProgressPanel(handle);
        }
        private void Refersh_API()
        {
            CompanySettings = apiMethod.Get_Company();
            ProjectSettings = apiMethod.Get_Project();
        }
        #region 未過戶廠商篩選功能
        /// <summary>
        /// 未過戶廠商篩選功能
        /// </summary>
        private void Controller()
        {
            FilterPurchaseMainSettings = new List<PurchaseMainSetting>();
            int SystemTime = DateTime.Now.Month;
            if (CompanySettings != null)
            {
                foreach (var Companyitem in CompanySettings)
                {
                    switch (Companyitem.CheckoutType)
                    {
                        case 0://現金
                            {
                                List<PurchaseMainSetting> PurchaseSetting = PurchaseMainSettings.Where(g => g.PurchaseCompanyNumber == Companyitem.CompanyNumber).ToList();
                                List<OperatingMainSetting> OperatingMainSetting = OperatingMainSettings.Where(g => g.OperatingCompanyNumber == Companyitem.CompanyNumber).ToList();
                                if (PurchaseSetting != null)
                                {
                                    foreach (var item in PurchaseSetting)
                                    {
                                        FilterPurchaseMainSettings.Add(item);
                                    }
                                }
                                if (OperatingMainSetting != null)
                                {
                                    foreach (var item in OperatingMainSetting)
                                    {
                                        PurchaseMainSetting setting = new PurchaseMainSetting()
                                        {
                                            PurchaseFlag = item.OperatingFlag,
                                            PurchaseNumber = item.OperatingNumber,
                                            PurchaseDate = item.OperatingDate,
                                            PurchaseCompanyNumber = item.OperatingCompanyNumber,
                                            ProjectNumber = item.ProjectNumber,
                                            PurchaseTax = item.OperatingTax,
                                            PurchaseInvoiceNo = item.OperatingInvoiceNo,
                                            PurchaseEmployeeNumber = item.OperatingEmployeeNumber,
                                            Remark = item.Remark,
                                            Total = item.Total,
                                            Tax = item.Tax,
                                            TotalTax = item.TotalTax,
                                            FileName = item.FileName,
                                            Posting = item.Posting,
                                            PostingDate = item.PostingDate
                                        };
                                        FilterPurchaseMainSettings.Add(setting);
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
                                List<PurchaseMainSetting> PurchaseSetting = PurchaseMainSettings.Where(g => g.PurchaseCompanyNumber == Companyitem.CompanyNumber).ToList();
                                List<OperatingMainSetting> OperatingMainSetting = OperatingMainSettings.Where(g => g.OperatingCompanyNumber == Companyitem.CompanyNumber).ToList();
                                if (PurchaseSetting != null)
                                {
                                    foreach (var item in PurchaseSetting)
                                    {
                                        if (SystemTime >= item.PurchaseDate.Month)
                                        {
                                            FilterPurchaseMainSettings.Add(item);
                                        }
                                    }
                                }
                                if (OperatingMainSetting != null)
                                {
                                    foreach (var item in OperatingMainSetting)
                                    {
                                        PurchaseMainSetting setting = new PurchaseMainSetting()
                                        {
                                            PurchaseFlag = item.OperatingFlag,
                                            PurchaseNumber = item.OperatingNumber,
                                            PurchaseDate = item.OperatingDate,
                                            PurchaseCompanyNumber = item.OperatingCompanyNumber,
                                            ProjectNumber = item.ProjectNumber,
                                            PurchaseTax = item.OperatingTax,
                                            PurchaseInvoiceNo = item.OperatingInvoiceNo,
                                            PurchaseEmployeeNumber = item.OperatingEmployeeNumber,
                                            Remark = item.Remark,
                                            Total = item.Total,
                                            Tax = item.Tax,
                                            TotalTax = item.TotalTax,
                                            FileName = item.FileName,
                                            Posting = item.Posting,
                                            PostingDate = item.PostingDate
                                        };
                                        FilterPurchaseMainSettings.Add(setting);
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
                                List<PurchaseMainSetting> PurchaseSetting = PurchaseMainSettings.Where(g => g.PurchaseCompanyNumber == Companyitem.CompanyNumber).ToList();
                                List<OperatingMainSetting> OperatingMainSetting = OperatingMainSettings.Where(g => g.OperatingCompanyNumber == Companyitem.CompanyNumber).ToList();
                                if (PurchaseSetting != null)
                                {
                                    foreach (var item in PurchaseSetting)
                                    {
                                        if (SystemTime >= item.PurchaseDate.Month)
                                        {
                                            FilterPurchaseMainSettings.Add(item);
                                        }
                                    }
                                }
                                if (OperatingMainSetting != null)
                                {
                                    foreach (var item in OperatingMainSetting)
                                    {
                                        PurchaseMainSetting setting = new PurchaseMainSetting()
                                        {
                                            PurchaseFlag = item.OperatingFlag,
                                            PurchaseNumber = item.OperatingNumber,
                                            PurchaseDate = item.OperatingDate,
                                            PurchaseCompanyNumber = item.OperatingCompanyNumber,
                                            ProjectNumber = item.ProjectNumber,
                                            PurchaseTax = item.OperatingTax,
                                            PurchaseInvoiceNo = item.OperatingInvoiceNo,
                                            PurchaseEmployeeNumber = item.OperatingEmployeeNumber,
                                            Remark = item.Remark,
                                            Total = item.Total,
                                            Tax = item.Tax,
                                            TotalTax = item.TotalTax,
                                            FileName = item.FileName,
                                            Posting = item.Posting,
                                            PostingDate = item.PostingDate
                                        };
                                        FilterPurchaseMainSettings.Add(setting);
                                    }
                                }
                            }
                            break;
                        case 3://其他
                            {
                                if (cet_Other.CheckState == CheckState.Checked)
                                {
                                    List<PurchaseMainSetting> PurchaseSetting = PurchaseMainSettings.Where(g => g.PurchaseCompanyNumber == Companyitem.CompanyNumber).ToList();
                                    List<OperatingMainSetting> OperatingMainSetting = OperatingMainSettings.Where(g => g.OperatingCompanyNumber == Companyitem.CompanyNumber).ToList();
                                    if (PurchaseSetting != null)
                                    {
                                        foreach (var item in PurchaseSetting)
                                        {
                                            FilterPurchaseMainSettings.Add(item);
                                        }
                                    }
                                    if (OperatingMainSetting != null)
                                    {
                                        foreach (var item in OperatingMainSetting)
                                        {
                                            PurchaseMainSetting setting = new PurchaseMainSetting()
                                            {
                                                PurchaseFlag = item.OperatingFlag,
                                                PurchaseNumber = item.OperatingNumber,
                                                PurchaseDate = item.OperatingDate,
                                                PurchaseCompanyNumber = item.OperatingCompanyNumber,
                                                ProjectNumber = item.ProjectNumber,
                                                PurchaseTax = item.OperatingTax,
                                                PurchaseInvoiceNo = item.OperatingInvoiceNo,
                                                PurchaseEmployeeNumber = item.OperatingEmployeeNumber,
                                                Remark = item.Remark,
                                                Total = item.Total,
                                                Tax = item.Tax,
                                                TotalTax = item.TotalTax,
                                                FileName = item.FileName,
                                                Posting = item.Posting,
                                                PostingDate = item.PostingDate
                                            };
                                            FilterPurchaseMainSettings.Add(setting);
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
        }
        #endregion
    }
}
