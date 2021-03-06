using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraSplashScreen;
using ERPManagementAPP.Maintain.PaymentMaintainForm;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        /// <summary>
        /// 專案資訊
        /// </summary>
        private List<ProjectSetting> ProjectSettings { get; set; }
        public PaymentMiantainControl(APIMethod APIMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            apiMethod = APIMethod;
            det_PaymentDate.EditValue = DateTime.Now;
            if (Form1.EmployeeSetting.Token > 0)
            {
                Refresh_Main_GridView();
                Refresh_Second_GridView("");
            }
            action.Commands.Add(FlyoutCommand.Yes);
            Delectaction.Commands.Add(FlyoutCommand.Yes);
            Delectaction.Commands.Add(FlyoutCommand.Cancel);
            Delectaction.Caption = "刪除確認";
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
                Delectaction.Description = $"刪除名稱 : {FocusePaymentItemSetting.PaymentItemName}";
                if (FlyoutDialog.Show(Form1, Delectaction) == DialogResult.Yes)
                {
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
                Refresh_API();
                PaymentEditForm product = new PaymentEditForm(PaymentSettings, ProjectSettings, null, EmployeeSettings, PaymentItemSettings, apiMethod, Form1);
                if (product.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Second_GridView("");
                }
            };
            #endregion
            #region 修改代墊代付
            btn_Payment_Edit.Click += (s, e) =>
            {
                if (Form1.EmployeeSetting.Token == 2)
                {
                    Refresh_API();
                    List<PaymentSetting> paymentsetting = null;
                    for (int i = 0; i < length; i++)
                    {
                        paymentsetting = APIMethod.Get_Payment(FocusePaymentSetting.PaymentNumber);
                        if (paymentsetting != null)
                        {
                            break;
                        }
                    }
                    PaymentEditForm product = new PaymentEditForm(PaymentSettings, ProjectSettings, paymentsetting[0], EmployeeSettings, PaymentItemSettings, apiMethod, Form1);
                    if (product.ShowDialog() == DialogResult.OK)
                    {
                        Refresh_Second_GridView("");
                    }
                }
                else if (Form1.EmployeeSetting.Token == 1)
                {
                    if (FocusePaymentSetting.EmployeeNumber == Form1.EmployeeSetting.EmployeeNumber)
                    {
                        Refresh_API();
                        List<PaymentSetting> paymentsetting = null;
                        for (int i = 0; i < length; i++)
                        {
                            paymentsetting = APIMethod.Get_Payment(FocusePaymentSetting.PaymentNumber);
                            if (paymentsetting != null)
                            {
                                break;
                            }
                        }
                        PaymentEditForm product = new PaymentEditForm(PaymentSettings, ProjectSettings, paymentsetting[0], EmployeeSettings, PaymentItemSettings, apiMethod, Form1);
                        if (product.ShowDialog() == DialogResult.OK)
                        {
                            Refresh_Second_GridView("");
                        }
                    }
                    else
                    {
                        action.Caption = "權限不足";
                        action.Description = "請管理員或該帳號做修改";
                        FlyoutDialog.Show(Form1, action);
                    }
                }
            };
            #endregion
            #region 雙擊修改代墊代付
            gridControl1.DoubleClick += (s, e) =>
            {
                if (Form1.EmployeeSetting.Token == 2)
                {
                    Refresh_API();
                    FocuseSecondGrid();
                    List<PaymentSetting> paymentsetting = null;
                    for (int i = 0; i < length; i++)
                    {
                        paymentsetting = APIMethod.Get_Payment(FocusePaymentSetting.PaymentNumber);
                        if (paymentsetting != null)
                        {
                            break;
                        }
                    }
                    PaymentEditForm product = new PaymentEditForm(PaymentSettings, ProjectSettings, paymentsetting[0], EmployeeSettings, PaymentItemSettings, apiMethod, Form1);
                    if (product.ShowDialog() == DialogResult.OK)
                    {
                        Refresh_Second_GridView("");
                    }
                }
                else if (Form1.EmployeeSetting.Token == 1)
                {
                    if (FocusePaymentSetting.EmployeeNumber == Form1.EmployeeSetting.EmployeeNumber)
                    {
                        Refresh_API();
                        FocuseSecondGrid();
                        List<PaymentSetting> paymentsetting = null;
                        for (int i = 0; i < length; i++)
                        {
                            paymentsetting = APIMethod.Get_Payment(FocusePaymentSetting.PaymentNumber);
                            if (paymentsetting != null)
                            {
                                break;
                            }
                        }
                        PaymentEditForm product = new PaymentEditForm(PaymentSettings, ProjectSettings, paymentsetting[0], EmployeeSettings, PaymentItemSettings, apiMethod, Form1);
                        if (product.ShowDialog() == DialogResult.OK)
                        {
                            Refresh_Second_GridView("");
                        }
                    }
                    else
                    {
                        action.Caption = "權限不足";
                        action.Description = "請管理員或該帳號做修改";
                        FlyoutDialog.Show(Form1, action);
                    }
                }
            };
            #endregion
            #region 刪除代墊代付
            btn_Payment_Delete.Click += (s, e) =>
            {
                FocuseSecondGrid();
                if (Form1.EmployeeSetting.Token != 2)
                {
                    if (FocusePaymentSetting.EmployeeNumber == Form1.EmployeeSetting.EmployeeNumber)
                    {
                        Delectaction.Description = $"刪除編碼 : {FocusePaymentSetting.PaymentNumber}";
                        if (FlyoutDialog.Show(Form1, Delectaction) == DialogResult.Yes)
                        {
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
                        }
                    }
                    else
                    {
                        action.Caption = "刪除代墊代付失敗，不可刪除其他人代墊代付資訊";
                        FlyoutDialog.Show(Form1, action);
                    }
                }
                else if (Form1.EmployeeSetting.Token == 2)
                {
                    Delectaction.Description = $"刪除編碼 : {FocusePaymentSetting.PaymentNumber}";
                    if (FlyoutDialog.Show(Form1, Delectaction) == DialogResult.Yes)
                    {
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
                    }
                }
            };
            #endregion
            #region 產品資料刷新
            btn_Payment_Refresh.Click += (s, e) =>
            {
                //if (PaymentItemSettings != null)
                //{
                //    Refresh_Main_GridView();
                //}
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
                    FocusePaymentItemSetting.PaymentItemName = null;
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
                else
                {
                    FocusePaymentSetting.PaymentInvoiceNo = null;
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProjectNumber") != null)
                {
                    FocusePaymentSetting.ProjectNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProjectNumber").ToString();
                }
                else
                {
                    FocusePaymentSetting.ProjectNumber = null;
                }
                FocusePaymentSetting.PaymentItemNo = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PaymentItemNo").ToString();

                FocusePaymentSetting.PaymentUse = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PaymentUse").ToString();

                FocusePaymentSetting.EmployeeNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "EmployeeNumber").ToString();

                FocusePaymentSetting.PaymentAmount = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PaymentAmount").ToString());
                FocusePaymentSetting.PaymentMethod = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PaymentMethod").ToString());
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Remark") != null)
                {
                    FocusePaymentSetting.Remark = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Remark").ToString();
                }
                else
                {
                    FocusePaymentSetting.Remark = null;
                }
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
                else
                {
                    FocusePaymentSetting.FileName = null;
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
            gridView1.CustomColumnDisplayText += (s, e) =>
            {
                //if (e.Column.FieldName == "PaymentItemNo")
                //{
                //    if (e.DisplayText != null)
                //    {
                //        string Index = e.DisplayText.ToString();
                //        foreach (var item in PaymentItemSettings)
                //        {
                //            if (item.PaymentItemNo == Index)
                //            {
                //                e.DisplayText = item.PaymentItemName;
                //            }
                //        }
                //    }
                //}
                //else if (e.Column.FieldName == "EmployeeNumber")
                //{
                //    if (e.DisplayText != null)
                //    {
                //        string Index = e.DisplayText.ToString();
                //        foreach (var item in EmployeeSettings)
                //        {
                //            if (item.EmployeeNumber == Index)
                //            {
                //                e.DisplayText = item.EmployeeName;
                //            }
                //        }
                //    }
                //}
                if (e.Column.FieldName == "PaymentMethod")
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
                //else if (e.Column.FieldName == "ProjectNumber")
                //{
                //    if (e.DisplayText != null)
                //    {
                //        string Index = e.DisplayText.ToString();
                //        ProjectSetting project = ProjectSettings.SingleOrDefault(g => g.ProjectNumber == Index);
                //        if (project != null)
                //        {
                //            e.DisplayText = project.ProjectName;
                //        }
                //    }
                //}
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
            handle = SplashScreenManager.ShowOverlayForm(FindForm());
            for (int i = 0; i < length; i++)
            {
                PaymentItemSettings = apiMethod.Get_PaymentItem();
                if (PaymentItemSettings != null)
                {
                    gridControl2.DataSource = PaymentItemSettings;
                    Refresh_Second_GridView();
                    break;
                }
            }
            CloseProgressPanel(handle);
        }
        public override void Refresh_Second_GridView(string Number)
        {
            handle = SplashScreenManager.ShowOverlayForm(FindForm());
            //PaymentSettings = apiMethod.Get_PaymentTransferDate();//未付款
            for (int x = 0; x < length; x++)
            {
                PaymentSettings = apiMethod.Get_PaymentMonth(det_PaymentDate.Text.Replace("/", ""));
                if (PaymentSettings != null && EmployeeSettings != null)
                {
                    gridControl1.DataSource = PaymentSettings;
                    gridView1.Columns["EmployeeNumber"].Group();
                    for (int i = 0; i < gridView1.Columns.Count; i++)
                    {
                        if (gridView1.Columns[i].FieldName != "PaymentUse")
                        {
                            gridView1.Columns[i].BestFit();
                        }
                    }
                    gridView1.ExpandAllGroups();
                    ChangeGridStr();
                    break;
                }
            }
            CloseProgressPanel(handle);
        }
        private void Refresh_Second_GridView()
        {
            for (int x = 0; x < length; x++)
            {
                PaymentSettings = apiMethod.Get_PaymentMonth(det_PaymentDate.Text.Replace("/", ""));
                if (PaymentSettings != null && EmployeeSettings != null)
                {
                    gridControl1.DataSource = PaymentSettings;
                    gridView1.Columns["EmployeeNumber"].Group();
                    for (int i = 0; i < gridView1.Columns.Count; i++)
                    {
                        if (gridView1.Columns[i].FieldName != "PaymentUse")
                        {
                            gridView1.Columns[i].BestFit();
                        }
                    }
                    gridView1.ExpandAllGroups();
                    ChangeGridStr();
                    break;
                }
            }
        }
        private void Refresh_API()
        {
            for (int i = 0; i < length; i++)
            {
                EmployeeSettings = apiMethod.Get_Employee();
                if (EmployeeSettings != null)
                {
                    break;
                }
            }
            for (int i = 0; i < length; i++)
            {
                ProjectSettings = apiMethod.Get_Project();
                if (ProjectSettings != null)
                {
                    break;
                }
            }
        }
        public override void Refresh_Token()
        {
            if (Form1.EmployeeSetting.Token != 2)
            {
                //btn_Payment_Delete.Visible = false;
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
