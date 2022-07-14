using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using ERPManagementAPP.Maintain.QuotationMainForm;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain
{
    public partial class QuotationMaintainControl : Field4MaintainControl
    {
        /// <summary>
        /// 客戶資訊
        /// </summary>
        public List<CustomerSetting> CustomerSettings { get; set; }
        /// <summary>
        /// 專案資訊
        /// </summary>
        private List<ProjectSetting> ProjectSettings { get; set; }
        /// <summary>
        /// 員工資訊
        /// </summary>
        private List<EmployeeSetting> EmployeeSettings { get; set; }
        /// <summary>
        /// 聚焦訂購表頭
        /// </summary>
        private QuotationMainSetting FocuseQuotationMainSetting { get; set; } = new QuotationMainSetting();
        /// <summary>
        /// 總表頭
        /// </summary>
        private List<QuotationMainSetting> QuotationMainSettings { get; set; } = new List<QuotationMainSetting>();
        /// <summary>
        /// 總報價資訊
        /// </summary>
        private List<QuotationSetting> QuotationSettings { get; set; } = new List<QuotationSetting>();
        public QuotationMaintainControl(APIMethod APIMethod,Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            apiMethod = APIMethod;
            det_QuotationDate.EditValue = DateTime.Now;
            action.Commands.Add(FlyoutCommand.Yes);
            Delectaction.Commands.Add(FlyoutCommand.Yes);
            Delectaction.Commands.Add(FlyoutCommand.Cancel);
            Delectaction.Caption = "刪除確認";
            #region 訂購資訊報表按鈕
            RepositoryItemButtonEdit Quotationedit = new RepositoryItemButtonEdit();
            Quotationedit.ButtonClick += (s, e) =>
            {
                FocuseMainGrid();
                if (e.Button.Kind == ButtonPredefines.Plus)
                {
                    if (FocuseQuotationMainSetting.FileName != null)
                    {
                        if (FocuseQuotationMainSetting.FileName != "")
                        {
                            byte[] File = apiMethod.Get_QuotationAttachmentFile(FocuseQuotationMainSetting.QuotationNumber, FocuseQuotationMainSetting.FileName);
                            SaveFile(File, 0);
                        }
                    }
                }
            };
            Quotationedit.Buttons[0].Kind = ButtonPredefines.Plus;
            Quotationedit.Buttons[0].Caption = "下載";
            Quotationedit.TextEditStyle = TextEditStyles.DisableTextEditor;
            QuotationgridControl.RepositoryItems.Add(Quotationedit);
            QuotationgridView.Columns["FileName"].ColumnEdit = Quotationedit;
            QuotationgridView.Columns["FileName"].ShowButtonMode = ShowButtonModeEnum.ShowAlways;
            #endregion
            #region 訂購聚焦功能
            QuotationgridView.FocusedRowChanged += (s, e) =>
            {
                FocuseMainGrid();
            };
            #endregion
            #region 關鍵字搜尋
            QuotationgridView.ColumnFilterChanged += (s, e) =>
            {
                FocuseMainGrid();
            };
            #endregion
            #region 使用/作廢功能
            QuotationgridView.RowStyle += (s, e) =>
            {
                GridView view = s as GridView;
                if (e.RowHandle >= 0)
                {
                    bool InvalidFlag = Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, view.Columns["InvalidFlag"]).ToString());
                    if (InvalidFlag)
                    {
                        e.Appearance.BackColor = Color.FromArgb(150, Color.Salmon);
                    }
                }
            };
            #endregion
            #region 新增訂購資訊
            btn_Quotation_Add.Click += (s, e) =>
            {
                Refresh_API();
                QuotationEditForm purchaseEdit = new QuotationEditForm(CustomerSettings,  EmployeeSettings,  ProjectSettings, null, apiMethod, Form1);
                if (purchaseEdit.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #region 修改訂購資訊
            btn_Quotation_Edit.Click += (s, e) =>
            {
                Refresh_API();
                FocuseMainGrid();
                for (int i = 0; i < length; i++)
                {
                    QuotationSettings = APIMethod.Get_Quotation(FocuseQuotationMainSetting);
                    if (QuotationSettings != null)
                    {
                        break;
                    }
                }
                QuotationEditForm purchaseEdit = new QuotationEditForm(CustomerSettings, EmployeeSettings, ProjectSettings, QuotationSettings[0], apiMethod, Form1);
                if (purchaseEdit.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #region 雙擊修改訂購資訊
            QuotationgridControl.DoubleClick += (s, e) =>
            {
                Refresh_API();
                FocuseMainGrid();
                for (int i = 0; i < length; i++)
                {
                    QuotationSettings = APIMethod.Get_Quotation(FocuseQuotationMainSetting);
                    if (QuotationSettings != null)
                    {
                        break;
                    }
                }
                if (QuotationSettings != null)
                {
                    if (QuotationSettings[0] != null)
                    {
                        QuotationEditForm purchaseEdit = new QuotationEditForm(CustomerSettings, EmployeeSettings, ProjectSettings, QuotationSettings[0], apiMethod, Form1);
                        if (purchaseEdit.ShowDialog() == DialogResult.OK)
                        {
                            Refresh_Main_GridView();
                        }
                    }
                }
            };
            #endregion
            #region 刪除訂購資訊
            btn_Quotation_Delete.Click += (s, e) =>
            {
                FocuseMainGrid();
                Delectaction.Description = $"刪除編碼 : {FocuseQuotationMainSetting.QuotationNumber}";
                if (FlyoutDialog.Show(Form1, Delectaction) == DialogResult.Yes)
                {
                    string response = APIMethod.Delete_Quotation(FocuseQuotationMainSetting.QuotationNumber);
                    if (response == "200")
                    {
                        Refresh_Main_GridView();
                        action.Caption = "刪除訂購資訊成功";
                        action.Description = "";
                        FlyoutDialog.Show(Form1, action);
                    }
                    else
                    {
                        action.Caption = "刪除訂購資訊失敗";
                        action.Description = "";
                        FlyoutDialog.Show(Form1, action);
                    }
                }
            };
            #endregion
            #region 產品類別資料查詢
            btn_Quotation_Search.Click += (s, e) =>
            {
                Refresh_Main_GridView();
            };
            #endregion
        }
        #region 聚焦主資料表功能
        private void FocuseMainGrid()
        {
            if (QuotationgridView.FocusedRowHandle > -1 && QuotationgridView.DataRowCount > 0)
            {
                FocuseQuotationMainSetting.QuotationNumber = QuotationgridView.GetRowCellValue(QuotationgridView.FocusedRowHandle, "QuotationNumber").ToString();
                FocuseQuotationMainSetting.QuotationDate = Convert.ToDateTime(QuotationgridView.GetRowCellValue(QuotationgridView.FocusedRowHandle, "QuotationDate").ToString());

                FocuseQuotationMainSetting.QuotationCustomerNumber = QuotationgridView.GetRowCellValue(QuotationgridView.FocusedRowHandle, "QuotationCustomerNumber").ToString();

                if (QuotationgridView.GetRowCellValue(QuotationgridView.FocusedRowHandle, "ProjectNumber") != null)
                {
                    FocuseQuotationMainSetting.ProjectNumber = QuotationgridView.GetRowCellValue(QuotationgridView.FocusedRowHandle, "ProjectNumber").ToString();
                }
                else
                {
                    FocuseQuotationMainSetting.ProjectNumber = null;
                }
                if (QuotationgridView.GetRowCellValue(QuotationgridView.FocusedRowHandle, "QuotationEmployeeNumber") != null)
                {
                    FocuseQuotationMainSetting.QuotationEmployeeNumber = QuotationgridView.GetRowCellValue(QuotationgridView.FocusedRowHandle, "QuotationEmployeeNumber").ToString();
                }
                else
                {
                    FocuseQuotationMainSetting.QuotationEmployeeNumber = "";
                }
                if (QuotationgridView.GetRowCellValue(QuotationgridView.FocusedRowHandle, "Remark") != null)
                {
                    FocuseQuotationMainSetting.Remark = QuotationgridView.GetRowCellValue(QuotationgridView.FocusedRowHandle, "Remark").ToString();
                }
                else
                {
                    FocuseQuotationMainSetting.Remark = "";
                }
                FocuseQuotationMainSetting.Total = Convert.ToDouble(QuotationgridView.GetRowCellValue(QuotationgridView.FocusedRowHandle, "Total").ToString());
                FocuseQuotationMainSetting.Tax = Convert.ToDouble(QuotationgridView.GetRowCellValue(QuotationgridView.FocusedRowHandle, "Tax").ToString());
                FocuseQuotationMainSetting.TotalTax = Convert.ToDouble(QuotationgridView.GetRowCellValue(QuotationgridView.FocusedRowHandle, "TotalTax").ToString());
                FocuseQuotationMainSetting.TotalQty = Convert.ToInt32(QuotationgridView.GetRowCellValue(QuotationgridView.FocusedRowHandle, "TotalQty").ToString());
                if (QuotationgridView.GetRowCellValue(QuotationgridView.FocusedRowHandle, "FileName") != null)
                {
                    FocuseQuotationMainSetting.FileName = QuotationgridView.GetRowCellValue(QuotationgridView.FocusedRowHandle, "FileName").ToString();
                }
                else
                {
                    FocuseQuotationMainSetting.FileName = "";
                }
                if (QuotationgridView.GetRowCellValue(QuotationgridView.FocusedRowHandle, "QuotationNote") != null)
                {
                    FocuseQuotationMainSetting.QuotationNote = QuotationgridView.GetRowCellValue(QuotationgridView.FocusedRowHandle, "QuotationNote").ToString();
                }
                else
                {
                    FocuseQuotationMainSetting.QuotationNote = "";
                }
            }
            else
            {
                FocuseQuotationMainSetting = new QuotationMainSetting();
            }
        }
        #endregion
        #region 下載檔案功能
        private void SaveFile(byte[] File, int Index)
        {
            if (File != null)
            {
                apiMethod.ClientFlag = true;
                if (File.Length > 147)
                {
                    saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = FocuseQuotationMainSetting.FileName;
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
            if (cet_InvaildFlag.CheckState == CheckState.Checked)//作廢顯示
            {
                for (int i = 0; i < length; i++)
                {
                    QuotationMainSettings = apiMethod.Get_Quotation(det_QuotationDate.Text);
                    if (QuotationMainSettings != null)
                    {
                        QuotationgridView.HideFindPanel();
                        QuotationgridControl.DataSource = QuotationMainSettings;
                        QuotationgridView.Columns["QuotationDate"].GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DateMonth;
                        QuotationgridView.Columns["QuotationDate"].GroupFormat.FormatString = "M" + "月";
                        QuotationgridView.Columns["QuotationDate"].GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        QuotationgridView.Columns["QuotationDate"].Group();
                        QuotationgridView.ExpandAllGroups();
                        break;
                    }
                }
            }
            else//不顯示作廢
            {
                for (int i = 0; i < length; i++)
                {
                    var quotationMainSettings = apiMethod.Get_Quotation(det_QuotationDate.Text);
                    if (quotationMainSettings != null)
                    {
                        QuotationMainSettings = quotationMainSettings.Where(g => !g.InvalidFlag).ToList();
                        QuotationgridView.HideFindPanel();
                        QuotationgridControl.DataSource = QuotationMainSettings;
                        QuotationgridView.Columns["QuotationDate"].GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DateMonth;
                        QuotationgridView.Columns["QuotationDate"].GroupFormat.FormatString = "M" + "月";
                        QuotationgridView.Columns["QuotationDate"].GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        QuotationgridView.Columns["QuotationDate"].Group();
                        QuotationgridView.ExpandAllGroups();
                        break;
                    }
                }
            }
            CloseProgressPanel(handle);
        }
        private void Refresh_API()
        {
            for (int i = 0; i < length; i++)
            {
                CustomerSettings = apiMethod.Get_Customer();
                if (CustomerSettings != null)
                {
                    break;
                }
            }
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
                btn_Quotation_Delete.Visible = false;
            }
            else
            {
                btn_Quotation_Delete.Visible = true;
            }
        }
    }
}
