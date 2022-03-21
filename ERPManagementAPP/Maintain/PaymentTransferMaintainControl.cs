using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public PaymentTransferMaintainControl(APIMethod APIMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            apiMethod = APIMethod;
            #region 代墊代付資料表
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 產品資訊報表按鈕
            RepositoryItemButtonEdit paymentedit = new RepositoryItemButtonEdit();
            paymentedit.ButtonClick += (s, e) =>
            {
                FocuseMainGrid();
                if (e.Button.Kind == ButtonPredefines.Plus)
                {
                    if (FocusePaymentSetting.TransferDate == null)
                    {
                        foreach (var item in PaymentSettings)
                        {
                            if (item.PaymentNumber == FocusePaymentSetting.PaymentNumber)
                            {
                                item.TransferDate = DateTime.Now;
                                FocusePaymentSetting.TransferDate= DateTime.Now;
                                string value = JsonConvert.SerializeObject(FocusePaymentSetting);
                                apiMethod.Put_Payment(value);
                                break;
                            }
                        }
                    }
                }
            };
            paymentedit.Buttons[0].Kind = ButtonPredefines.Plus;
            paymentedit.Buttons[0].Caption = "匯款日期";
            paymentedit.TextEditStyle = TextEditStyles.DisableTextEditor;
            gridControl1.RepositoryItems.Add(paymentedit);
            gridView1.Columns["TransferDate"].ColumnEdit = paymentedit;
            gridView1.Columns["TransferDate"].ShowButtonMode = ShowButtonModeEnum.ShowAlways;
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
            ChangeGridStr();
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
            #endregion
        }
        #region 代墊代付字串修改
        /// <summary>
        /// 代墊代付字串修改
        /// </summary>
        private void ChangeGridStr()
        {
            gridView1.CustomDrawCell += (s, e) =>
            {
                if (e.Column.FieldName == "PaymentItemNo")
                {
                    if (e.CellValue != null)
                    {
                        string Index = e.CellValue.ToString();
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
                    if (e.CellValue != null)
                    {
                        string Index = e.CellValue.ToString();
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
                    e.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                    string Index = e.CellValue.ToString();
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
            gridControl1.DataSource = PaymentSettings;
            gridView1.ExpandAllGroups();
        }
        private void Refresh_API()
        {
            EmployeeSettings = apiMethod.Get_Employee();
        }
    }
}
