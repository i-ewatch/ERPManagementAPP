using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain
{
    public partial class PaymentTransferMaintainControl : Field4MaintainControl
    {
        /// <summary>
        /// 聚焦代墊代付資料
        /// </summary>
        private PaymentSetting FocusePaymentSetting { get; set; } = new PaymentSetting();
        /// <summary>
        /// 總代墊代付資料
        /// </summary>
        private List<PaymentSetting> PaymentSettings { get; set; } = new List<PaymentSetting>();
        /// <summary>
        /// 總請款品項
        /// </summary>
        private List<PaymentItemSetting> PaymentItemSettings { get; set; } = new List<PaymentItemSetting>();
        /// <summary>
        /// 總員工資料
        /// </summary>
        private List<EmployeeSetting> EmployeeSettings { get; set; } = new List<EmployeeSetting>();
        /// <summary>
        /// 專案資訊
        /// </summary>
        private List<ProjectSetting> ProjectSettings { get; set; }
        public PaymentTransferMaintainControl(APIMethod APIMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            apiMethod = APIMethod;
            action.Commands.Add(FlyoutCommand.Yes);
            action.Commands.Add(FlyoutCommand.Cancel);
            action1.Commands.Add(FlyoutCommand.Yes);
            #region 代墊代付資料表
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 產品資訊報表按鈕 (不使用 2022/4/7)
            //RepositoryItemButtonEdit paymentedit = new RepositoryItemButtonEdit();
            //paymentedit.ButtonClick += (s, e) =>
            //{
            //    FocuseMainGrid();
            //    if (e.Button.Kind == ButtonPredefines.Plus)
            //    {
            //        if (FocusePaymentSetting.TransferDate == null)
            //        {
            //            foreach (var item in PaymentSettings)
            //            {
            //                if (item.PaymentNumber == FocusePaymentSetting.PaymentNumber)
            //                {
            //                    item.TransferDate = DateTime.Now;
            //                    FocusePaymentSetting.TransferDate= DateTime.Now;
            //                    string value = JsonConvert.SerializeObject(FocusePaymentSetting);
            //                    apiMethod.Put_Payment(value);
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //};
            //paymentedit.Buttons[0].Kind = ButtonPredefines.Plus;
            //paymentedit.Buttons[0].Caption = "匯款日期";
            //paymentedit.TextEditStyle = TextEditStyles.DisableTextEditor;
            //gridControl1.RepositoryItems.Add(paymentedit);
            //gridView1.Columns["TransferDate"].ColumnEdit = paymentedit;
            //gridView1.Columns["TransferDate"].ShowButtonMode = ShowButtonModeEnum.ShowAlways;
            #endregion
            #region 群組功能
            gridView1.Columns["EmployeeNumber"].Group();
            gridView1.GroupSummary.Add(new GridGroupSummaryItem()
            {
                FieldName = "PaymentAmount",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "金額: {0:c0}",
                ShowInGroupColumnFooter = gridView1.Columns["PaymentAmount"]
            });
            #endregion
            #region 報表群組修改字串功能
            gridView1.CustomDrawGroupRow += (s, e) =>
            {
                GridGroupRowInfo row = e.Info as GridGroupRowInfo;
                string Index = row.EditValue.ToString();
                EmployeeSetting employee = EmployeeSettings.SingleOrDefault(g => g.EmployeeNumber == Index);
                if (employee != null)
                {
                    row.GroupText = $"員工編號 : {employee.EmployeeName}";
                }
            };
            #endregion
            #region 報表聚焦功能
            gridView1.FocusedRowChanged += (s, ex) =>
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
            #region 產品資料刷新
            btn_Payment_Refresh.Click += (s, e) =>
            {
                Refresh_Main_GridView();
            };
            #endregion
            #region 全部過帳按鈕(新增 2022/4/7)
            btn_TransferDate.Click += (s, e) =>
            {
                action.Caption = "代墊代付是否全部過帳完成";
                if (FlyoutDialog.Show(Form1, action) == DialogResult.Yes)
                {
                    if (PaymentSettings != null)
                    {
                        foreach (var Paymentitem in PaymentSettings)
                        {
                            Paymentitem.TransferDate = DateTime.Now;
                            string value = JsonConvert.SerializeObject(Paymentitem);
                            apiMethod.Put_Payment(value);
                            Thread.Sleep(80);
                        }
                    }
                    action1.Caption = "代墊代付全部過帳完成";
                    FlyoutDialog.Show(Form1, action1);
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #endregion
        }
        #region 代墊代付字串修改
        /// <summary>
        /// 代墊代付字串修改
        /// </summary>
        private void ChangeGridStr()
        {
            gridView1.CustomColumnDisplayText += (s, e) =>
            {
                if (e.Column.FieldName == "PaymentItemNo")
                {
                    if (e.DisplayText != null)
                    {
                        string Index = e.DisplayText.ToString();
                        foreach (var item in PaymentItemSettings)
                        {
                            if (item.PaymentItemNo == Index)
                            {
                                e.DisplayText = item.PaymentItemName;
                            }
                        }
                    }
                }
                else if (e.Column.FieldName == "EmployeeNumber")
                {
                    if (e.DisplayText != null)
                    {
                        string Index = e.DisplayText.ToString();
                        foreach (var item in EmployeeSettings)
                        {
                            if (item.EmployeeNumber == Index)
                            {
                                e.DisplayText = item.EmployeeName;
                            }
                        }
                    }
                }
                else if (e.Column.FieldName == "PaymentMethod")
                {
                    string Index = e.DisplayText.ToString();
                    switch (Index)
                    {
                        case "0":
                            {
                                e.DisplayText = "隨薪資轉帳";
                            }
                            break;
                        case "1":
                            {
                                e.DisplayText = "零用金請款";
                            }
                            break;
                    }
                }
                else if (e.Column.FieldName == "ProjectNumber")
                {
                    if (e.DisplayText != null)
                    {
                        string Index = e.DisplayText.ToString();
                        ProjectSetting project = ProjectSettings.SingleOrDefault(g => g.ProjectNumber == Index);
                        if (project != null)
                        {
                            e.DisplayText = project.ProjectName;
                        }
                    }
                }
            };
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
                FocusePaymentSetting.PaymentNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PaymentNumber").ToString();
                FocusePaymentSetting.PaymentDate = Convert.ToDateTime(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PaymentDate").ToString());
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PaymentInvoiceNo") != null)
                {
                    FocusePaymentSetting.PaymentInvoiceNo = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PaymentInvoiceNo").ToString();
                }
                FocusePaymentSetting.PaymentItemNo = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PaymentItemNo").ToString();
                FocusePaymentSetting.PaymentUse = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PaymentUse").ToString();
                FocusePaymentSetting.EmployeeNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "EmployeeNumber").ToString();
                FocusePaymentSetting.PaymentAmount = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PaymentAmount").ToString());
                FocusePaymentSetting.PaymentMethod = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PaymentMethod").ToString());
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TransferDate") != null)
                {
                    FocusePaymentSetting.TransferDate = Convert.ToDateTime(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TransferDate").ToString());
                }
                else
                {
                    FocusePaymentSetting.TransferDate = null;
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FileName") != null)
                {
                    FocusePaymentSetting.FileName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FileName").ToString();
                }
            }
            else
            {
                FocusePaymentSetting = new PaymentSetting();
            }
        }
        #endregion
        public override void Refresh_Main_GridView()
        {
            Refresh_API();
            PaymentItemSettings = apiMethod.Get_PaymentItem();
            PaymentSettings = apiMethod.Get_PaymentTransferDate();
            if (PaymentSettings != null && EmployeeSettings != null)
            {
                gridControl1.DataSource = PaymentSettings;
                gridView1.ExpandAllGroups();
                ChangeGridStr();
            }
        }
        private void Refresh_API()
        {
            EmployeeSettings = apiMethod.Get_Employee();
            ProjectSettings = apiMethod.Get_Project();
        }
    }
}
