using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;
using DevExpress.XtraSplashScreen;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain
{
    public partial class PartnerMaintainControl : Field4MaintainControl
    {
        /// <summary>
        /// 客戶資訊
        /// </summary>
        private List<CustomerSetting> CustomerSettings { get; set; }
        /// <summary>
        /// 合作夥伴資訊
        /// </summary>
        private List<EmployeeSetting> EmployeeSettings { get; set; }
        /// <summary>
        /// 聚焦銷貨表頭
        /// </summary>
        private SalesMainSetting FocuseSalesMainSetting { get; set; } = new SalesMainSetting();
        /// <summary>
        /// 總表頭
        /// </summary>
        private List<SalesMainSetting> SalesMainSettings { get; set; } = new List<SalesMainSetting>();
        public PartnerMaintainControl(APIMethod APIMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            apiMethod = APIMethod;
            det_SalesDate.Text = DateTime.Now.ToString("yyyy/MM");
            if (Form1.EmployeeSetting.Token > 0)
            {
                Refresh_Main_GridView();
            }
            action.Commands.Add(FlyoutCommand.Yes);
            action1.Commands.Add(FlyoutCommand.Yes);
            #region 銷貨資料表
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 銷貨資訊報表按鈕 2022/4/13拔除
            //RepositoryItemButtonEdit Salesedit = new RepositoryItemButtonEdit();
            //Salesedit.ButtonClick += (s, e) =>
            //{
            //    FocuseMainGrid();
            //    if (e.Button.Kind == ButtonPredefines.Plus)
            //    {
            //        foreach (var item in SalesMainSettings)
            //        {
            //            if (item.SalesNumber == FocuseSalesMainSetting.SalesNumber)
            //            {
            //                if (item.Posting == 1)
            //                {
            //                    if (item.ProfitSharingDate == null)
            //                    {
            //                        item.ProfitSharingDate = DateTime.Now;
            //                        FocuseSalesMainSetting.ProfitSharingDate = DateTime.Now;
            //                        string value = JsonConvert.SerializeObject(FocuseSalesMainSetting);
            //                        apiMethod.Put_SalesMain(value);
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }
            //                else
            //                {
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //};
            //Salesedit.Buttons[0].Kind = ButtonPredefines.Plus;
            //Salesedit.Buttons[0].Caption = "分潤日期";
            //Salesedit.TextEditStyle = TextEditStyles.DisableTextEditor;
            //SalesgridControl.RepositoryItems.Add(Salesedit);
            //gridView1.Columns["ProfitSharingDate"].ColumnEdit = Salesedit;
            //gridView1.Columns["ProfitSharingDate"].ShowButtonMode = ShowButtonModeEnum.ShowAlways;
            #endregion
            #region 群組功能
            gridView1.Columns["SalesEmployeeNumber"].Group();
            gridView1.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "ProfitSharing",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "分潤: {0:c0}",
                ShowInGroupColumnFooter = gridView1.Columns["ProfitSharing"]
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
                EmployeeSetting employee = EmployeeSettings.SingleOrDefault(g => g.EmployeeNumber == Index);
                if (employee != null)
                {
                    row.GroupText = $"客戶編號 : {employee.EmployeeName}";
                }
            };
            #endregion
            #region 報表修改字串功能
            gridView1.CustomColumnDisplayText += (s, e) =>
            {
                if (e.Column.FieldName == "SalesFlag")
                {
                    string Index = e.DisplayText.ToString();
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
                    string Index = e.DisplayText.ToString();
                    CustomerSetting company = CustomerSettings.SingleOrDefault(g => g.CustomerNumber == Index);
                    if (company != null)
                    {
                        e.DisplayText = company.CustomerName;
                    }
                }
                else if (e.Column.FieldName == "SalesTax")
                {
                    string Index = e.DisplayText.ToString();
                    switch (Index)
                    {
                        case "0":
                            {
                                e.DisplayText = "應稅";
                            }
                            break;
                        case "1":
                            {
                                e.DisplayText = "零稅";
                            }
                            break;
                        case "2":
                            {
                                e.DisplayText = "免稅";
                            }
                            break;
                        case "3":
                            {
                                e.DisplayText = "二聯";
                            }
                            break;
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
            btn_Sales_Search.Click += (s, e) =>
            {
                if (cbt_Posting.SelectedIndex == 2 && cbt_ProfitSharing.SelectedIndex == 1)
                {
                    btn_TransferDate.Visible = true;
                }
                else
                {
                    btn_TransferDate.Visible = false;
                }
                Refresh_Main_GridView();
            };
            #endregion
            #endregion
            #region 報表匯出按鈕
            btn_Export.Click += (s, e) =>
              {
                  if (gridView1.Columns.Count > 0 && SalesgridControl.DataSource != null)
                  {
                      using (SaveFileDialog saveFile = new SaveFileDialog())
                      {
                          saveFile.Filter = "*.xlsx | *.xlsx";
                          saveFile.DefaultExt = "xlsx";//設定副檔名預設格式
                          saveFile.AddExtension = true;//設定自動在檔名中新增副檔名
                          if (saveFile.ShowDialog() == DialogResult.OK)
                          {
                              var options = new XlsxExportOptions();
                              options.TextExportMode = TextExportMode.Text;
                              SalesgridControl.ExportToXlsx(saveFile.FileName, options);
                          }
                      }
                  }
              };
            #endregion
            #region 全部分潤按鈕 2022/4/13新增
            btn_TransferDate.Click += (s, e) =>
            {
                action.Caption = "代墊代付是否全部過帳";
                if (FlyoutDialog.Show(Form1, action) == DialogResult.Yes)
                {
                    foreach (var item in SalesMainSettings)
                    {
                        if (item.ProfitSharingDate == null)
                        {
                            item.ProfitSharingDate = DateTime.Now;
                            string value = JsonConvert.SerializeObject(item);
                            apiMethod.Put_SalesMain(value);
                            Thread.Sleep(80);
                        }
                    }
                    action1.Caption = "代墊代付全部過帳完成";
                    FlyoutDialog.Show(Form1, action1);
                    Refresh_Main_GridView();
                }
            };
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
            handle = SplashScreenManager.ShowOverlayForm(FindForm());
            for (int i = 0; i < length; i++)
            {
                Refresh_API();
                var salesMainSettings = apiMethod.Get_Sales(det_SalesDate.Text.Replace("/", ""));
                if (salesMainSettings != null)
                {
                    SalesMainSettings = new List<SalesMainSetting>();
                    if (cbt_Employee.SelectedIndex == 0)//查詢全部合作夥伴
                    {
                        foreach (var item in EmployeeSettings)
                        {
                            if (cbt_Posting.SelectedIndex == 0)//查詢過帳全部
                            {
                                if (cbt_ProfitSharing.SelectedIndex == 0)//查詢分潤全部
                                {
                                    SalesMainSettings.AddRange(salesMainSettings.Where(g => g.SalesEmployeeNumber == item.EmployeeNumber).ToList());
                                }
                                else if (cbt_ProfitSharing.SelectedIndex == 1)//查詢全部未分潤
                                {
                                    SalesMainSettings.AddRange(salesMainSettings.Where(g => g.SalesEmployeeNumber == item.EmployeeNumber && g.ProfitSharingDate == null).ToList());
                                }
                                else if (cbt_ProfitSharing.SelectedIndex == 2)//查詢全部分潤
                                {
                                    SalesMainSettings.AddRange(salesMainSettings.Where(g => g.SalesEmployeeNumber == item.EmployeeNumber && g.ProfitSharingDate != null).ToList());
                                }
                            }
                            else//查詢全部過帳/未過帳
                            {
                                if (cbt_ProfitSharing.SelectedIndex == 0)//查詢分潤全部
                                {
                                    SalesMainSettings.AddRange(salesMainSettings.Where(g => g.SalesEmployeeNumber == item.EmployeeNumber && g.Posting == cbt_Posting.SelectedIndex - 1).ToList());
                                }
                                else if (cbt_ProfitSharing.SelectedIndex == 1)//查詢全部未分潤
                                {
                                    SalesMainSettings.AddRange(salesMainSettings.Where(g => g.SalesEmployeeNumber == item.EmployeeNumber && g.Posting == cbt_Posting.SelectedIndex - 1 && g.ProfitSharingDate == null).ToList());
                                }
                                else if (cbt_ProfitSharing.SelectedIndex == 2)//查詢全部分潤
                                {
                                    SalesMainSettings.AddRange(salesMainSettings.Where(g => g.SalesEmployeeNumber == item.EmployeeNumber && g.Posting == cbt_Posting.SelectedIndex - 1 && g.ProfitSharingDate != null).ToList());
                                }
                            }
                        }
                    }
                    else//查詢單一合作夥伴
                    {
                        if (cbt_Posting.SelectedIndex == 0)//查詢過帳全部
                        {
                            if (cbt_ProfitSharing.SelectedIndex == 0)//查詢分潤全部
                            {
                                SalesMainSettings.AddRange(salesMainSettings.Where(g => g.SalesEmployeeNumber == EmployeeSettings[cbt_Employee.SelectedIndex - 1].EmployeeNumber).ToList());
                            }
                            else if (cbt_ProfitSharing.SelectedIndex == 1)//查詢全部未分潤
                            {
                                SalesMainSettings.AddRange(salesMainSettings.Where(g => g.SalesEmployeeNumber == EmployeeSettings[cbt_Employee.SelectedIndex - 1].EmployeeNumber && g.ProfitSharingDate == null).ToList());
                            }
                            else if (cbt_ProfitSharing.SelectedIndex == 2)//查詢全部分潤
                            {
                                SalesMainSettings.AddRange(salesMainSettings.Where(g => g.SalesEmployeeNumber == EmployeeSettings[cbt_Employee.SelectedIndex - 1].EmployeeNumber && g.ProfitSharingDate != null).ToList());
                            }
                        }
                        else//查詢全部過帳/未過帳
                        {
                            if (cbt_ProfitSharing.SelectedIndex == 0)//查詢分潤全部
                            {
                                SalesMainSettings.AddRange(salesMainSettings.Where(g => g.SalesEmployeeNumber == EmployeeSettings[cbt_Employee.SelectedIndex - 1].EmployeeNumber && g.Posting == cbt_Posting.SelectedIndex - 1).ToList());
                            }
                            else if (cbt_ProfitSharing.SelectedIndex == 1)//查詢全部未分潤
                            {
                                SalesMainSettings.AddRange(salesMainSettings.Where(g => g.SalesEmployeeNumber == EmployeeSettings[cbt_Employee.SelectedIndex - 1].EmployeeNumber && g.Posting == cbt_Posting.SelectedIndex - 1 && g.ProfitSharingDate == null).ToList());
                            }
                            else if (cbt_ProfitSharing.SelectedIndex == 2)//查詢全部分潤
                            {
                                SalesMainSettings.AddRange(salesMainSettings.Where(g => g.SalesEmployeeNumber == EmployeeSettings[cbt_Employee.SelectedIndex - 1].EmployeeNumber && g.Posting == cbt_Posting.SelectedIndex - 1 && g.ProfitSharingDate != null).ToList());
                            }
                        }
                    }

                    foreach (var item in SalesMainSettings)
                    {
                        EmployeeSetting employee = EmployeeSettings.SingleOrDefault(g => g.EmployeeNumber == item.SalesEmployeeNumber);
                        if (employee != null)
                        {
                            item.SalesEmployeeNumber = employee.EmployeeName;
                        }
                        if (item.SalesFlag == 4)
                        {
                            item.Total = -1 * item.Total;
                            item.TotalTax = -1 * item.TotalTax;
                            item.ProfitSharing = -1 * item.ProfitSharing;
                        }
                    }
                    SalesgridControl.DataSource = SalesMainSettings;
                    gridView1.ExpandAllGroups();
                    for (int index = 0; index < gridView1.Columns.Count; index++)
                    {
                        gridView1.Columns[index].BestFit();
                    }
                    break;
                }
            }
            CloseProgressPanel(handle);
        }
        private void Refresh_API()
        {
            CustomerSettings = apiMethod.Get_Customer();
            var employeeSettings = apiMethod.Get_Employee();
            if (employeeSettings != null)
            {
                EmployeeSettings = employeeSettings.Where(g => g.Token == 2).ToList();

                if (EmployeeSettings.Count > cbt_Employee.Properties.Items.Count - 1)
                {
                    if (cbt_Employee.Properties.Items.Count > 0)
                    {
                        cbt_Employee.Properties.Items.Clear();
                    }
                    cbt_Employee.Properties.Items.Add("全部");
                    if (EmployeeSettings != null)
                    {
                        foreach (var item in EmployeeSettings)
                        {
                            cbt_Employee.Properties.Items.Add(item.EmployeeName);
                        }
                    }
                    cbt_Employee.SelectedIndex = 0;
                }
            }
        }
    }
}
