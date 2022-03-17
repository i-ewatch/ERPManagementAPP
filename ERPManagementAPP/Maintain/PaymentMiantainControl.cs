using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using ERPManagementAPP.Maintain.PaymentMaintainForm;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain
{
    public partial class PaymentMiantainControl : Field4MaintainControl
    {
        /// <summary>
        /// 聚焦代墊代付資料
        /// </summary>
        private PaymentSetting FocusePaymentSetting { get; set; } = new PaymentSetting();
        /// <summary>
        /// 聚焦請款品項
        /// </summary>
        private PaymentItemSetting FocusePaymentItemSetting { get; set; } = new PaymentItemSetting();
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
        public PaymentMiantainControl(APIMethod APIMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            apiMethod = APIMethod;
            det_PaymentDate.EditValue = DateTime.Now;
            if (Form1.EmployeeSetting.Token > 0)
            {
                Refresh_Main_GridView();
            }
            action.Commands.Add(FlyoutCommand.Yes);
            #region 代墊代付品項資料表
            gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 產品類別聚焦功能
            gridView2.FocusedRowChanged += (s, ex) =>
            {
                FocuseMainGrid();
            };
            #endregion
            #region 關鍵字搜尋
            gridView2.ColumnFilterChanged += (s, e) =>
            {
                FocuseMainGrid();
            };
            #endregion
            #region 新增代墊代付品項
            btn_PaymentItem_Add.Click += (s, e) =>
            {
                Refresh_API();
                PaymentItemEditForm paymentItem = new PaymentItemEditForm(PaymentItemSettings, null, apiMethod, Form1);
                if (paymentItem.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                    Refresh_Second_GridView("");
                }
            };
            #endregion
            #region 修改代墊代付品項
            btn_PaymentItem_Edit.Click += (s, e) =>
            {
                Refresh_API();
                PaymentItemEditForm paymentItem = new PaymentItemEditForm(PaymentItemSettings, FocusePaymentItemSetting, apiMethod, Form1);
                if (paymentItem.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                    Refresh_Second_GridView("");
                }
            };
            #endregion
            #region 雙擊修改代墊代付品項
            gridControl2.DoubleClick += (s, e) =>
            {
                Refresh_API();
                FocuseMainGrid();
                PaymentItemEditForm paymentItem = new PaymentItemEditForm(PaymentItemSettings, FocusePaymentItemSetting, apiMethod, Form1);
                if (paymentItem.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                    Refresh_Second_GridView("");
                }
            };
            #endregion
            #region 刪除代墊代付品項
            btn_PaymentItem_Delete.Click += (s, e) =>
            {
                FocuseMainGrid();
                string data = JsonConvert.SerializeObject(FocusePaymentItemSetting);
                string response = apiMethod.Delete_PaymentItem(data);
                if (response == "200")
                {
                    Refresh_Main_GridView();
                    action.Caption = "刪除代墊代付品項成功";
                    action.Description = "";
                    FlyoutDialog.Show(Form1, action);
                }
                else
                {
                    action.Caption = "刪除代墊代付品項失敗";
                    action.Description = "";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 產品類別資料刷新
            btn_PaymentItem_Refresh.Click += (s, e) =>
            {
                Refresh_Main_GridView();
            };
            #endregion
            #endregion

            #region 代墊代付資料表
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 產品資訊報表按鈕
            RepositoryItemButtonEdit paymentedit = new RepositoryItemButtonEdit();
            paymentedit.ButtonClick += (s, e) =>
            {
                FocuseSecondGrid();
                if (e.Button.Kind == ButtonPredefines.Plus)
                {
                    if (FocusePaymentSetting.FileName != null)
                    {
                        if (FocusePaymentSetting.FileName != "")
                        {
                            byte[] File = apiMethod.Get_PaymentAttachmentFile(FocusePaymentSetting.PaymentNumber, FocusePaymentSetting.FileName);
                            SaveFile(File);
                        }
                    }
                }
            };
            paymentedit.Buttons[0].Kind = ButtonPredefines.Plus;
            paymentedit.Buttons[0].Caption = "下載";
            paymentedit.TextEditStyle = TextEditStyles.DisableTextEditor;
            gridControl1.RepositoryItems.Add(paymentedit);
            gridView1.Columns["FileName"].ColumnEdit = paymentedit;
            gridView1.Columns["FileName"].ShowButtonMode = ShowButtonModeEnum.ShowAlways;
            #endregion
            #region 報表聚焦功能
            gridView1.FocusedRowChanged += (s, ex) =>
            {
                FocuseSecondGrid();
            };
            #endregion
            #region 關鍵字搜尋
            gridView1.ColumnFilterChanged += (s, e) =>
            {
                FocuseSecondGrid();
            };
            #endregion
            #region 新增代墊代付
            btn_Payment_Add.Click += (s, e) =>
            {
                PaymentEditForm product = new PaymentEditForm(PaymentSettings, null, EmployeeSettings, PaymentItemSettings, apiMethod, Form1);
                if (product.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Second_GridView("");
                }
            };
            #endregion
            #region 修改代墊代付
            btn_Payment_Edit.Click += (s, e) =>
            {
                PaymentEditForm product = new PaymentEditForm(PaymentSettings, FocusePaymentSetting, EmployeeSettings, PaymentItemSettings, apiMethod, Form1);
                if (product.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Second_GridView("");
                }
            };
            #endregion
            #region 雙擊修改代墊代付
            gridControl1.DoubleClick += (s, e) =>
            {
                FocuseSecondGrid();
                PaymentEditForm product = new PaymentEditForm(PaymentSettings, FocusePaymentSetting, EmployeeSettings, PaymentItemSettings, apiMethod, Form1);
                if (product.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Second_GridView("");
                }
            };
            #endregion
            #region 刪除代墊代付
            btn_Payment_Delete.Click += (s, e) =>
            {
                FocuseSecondGrid();
                string data = JsonConvert.SerializeObject(FocusePaymentSetting);
                string response = apiMethod.Delete_Payment(data);
                if (response == "200")
                {
                    Refresh_Second_GridView("0");
                    action.Caption = "刪除代墊代付成功";
                    FlyoutDialog.Show(Form1, action);
                }
                else
                {
                    action.Caption = "刪除代墊代付失敗";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 產品資料刷新
            btn_Payment_Refresh.Click += (s, e) =>
            {
                if (PaymentItemSettings == null)
                {
                    Refresh_Main_GridView();
                }
                Refresh_Second_GridView("");
            };
            #endregion
            #endregion
        }
        #region 聚焦主資料表功能
        /// <summary>
        /// 聚焦主資料表功能
        /// </summary>
        private void FocuseMainGrid()
        {
            if (gridView2.FocusedRowHandle > -1 && gridView2.DataRowCount > 0)
            {
                FocusePaymentItemSetting.PaymentItemNo = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "PaymentItemNo").ToString();
                if (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "PaymentItemName") != null)
                {
                    FocusePaymentItemSetting.PaymentItemName = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "PaymentItemName").ToString();
                }
                else
                {
                    FocusePaymentItemSetting.PaymentItemName = "";
                }
            }
            else
            {
                FocusePaymentItemSetting = new PaymentItemSetting();
            }
        }
        #endregion
        #region 聚焦次資料表功能
        /// <summary>
        /// 聚焦次資料表功能
        /// </summary>
        private void FocuseSecondGrid()
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
        #region 下載檔案功能
        private void SaveFile(byte[] File)
        {
            if (File != null)
            {
                if (File.Length > 133)
                {
                    saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = FocusePaymentSetting.FileName;
                    saveFileDialog.Title = "Save File Path";
                    saveFileDialog.Filter = "All|*.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream data = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                        {
                            data.Write(File, 0, File.Length);
                            data.Close();
                        }
                        action.Caption = "下載檔案成功";
                        action.Description = "";
                        FlyoutDialog.Show(Form1, action);
                    }
                }
                else
                {
                    action.Caption = "下載檔案錯誤";
                    action.Description = "伺服器找不到此檔案";
                    FlyoutDialog.Show(Form1, action);
                }
            }
            else
            {
                apiMethod.ClientFlag = false;
                action.Caption = "下載檔案錯誤";
                action.Description = apiMethod.ErrorStr;
                FlyoutDialog.Show(Form1, action);
            }
        }
        #endregion
        public override void Refresh_Main_GridView()
        {
            Refresh_API();
            PaymentItemSettings = apiMethod.Get_PaymentItem();
            gridControl2.DataSource = PaymentItemSettings;
            Refresh_Second_GridView("");
        }
        public override void Refresh_Second_GridView(string Number)
        {
            //PaymentSettings = apiMethod.Get_PaymentTransferDate();//未付款
            PaymentSettings = apiMethod.Get_PaymentMonth(det_PaymentDate.Text.Replace("/", ""));
            gridControl1.DataSource = PaymentSettings;
            ChangeGridStr();
        }
        private void Refresh_API()
        {
            EmployeeSettings = apiMethod.Get_Employee();
        }
        public override void Refresh_Token()
        {
            if (Form1.EmployeeSetting.Token != 2)
            {
                btn_Payment_Delete.Visible = false;
                btn_PaymentItem_Delete.Visible = false;
            }
            else
            {
                btn_Payment_Delete.Visible = true;
                btn_PaymentItem_Delete.Visible = true;
            }
        }
    }
}
