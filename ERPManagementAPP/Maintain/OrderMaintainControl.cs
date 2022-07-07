using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using ERPManagementAPP.Maintain.OrderMaintainForm;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain
{
    public partial class OrderMaintainControl : Field4MaintainControl
    {
        /// <summary>
        /// 產品資訊
        /// </summary>
        private List<ProductSetting> ProductSettings { get; set; }
        /// <summary>
        /// 公司資訊
        /// </summary>
        private List<CompanySetting> CompanySettings { get; set; }
        /// <summary>
        /// 公司員工編號
        /// </summary>
        private List<CompanyDirectorySetting> CompanyDirectorySettings { get; set; }
        /// <summary>
        /// 員工資訊
        /// </summary>
        private List<EmployeeSetting> EmployeeSettings { get; set; }
        /// <summary>
        /// 專案資訊
        /// </summary>
        private List<ProjectSetting> ProjectSettings { get; set; }
        /// <summary>
        /// 聚焦訂購表頭
        /// </summary>
        private OrderMainSetting FocuseOrderMainSetting { get; set; } = new OrderMainSetting();
        /// <summary>
        /// 總表頭
        /// </summary>
        private List<OrderMainSetting> OrderMainSettings { get; set; } = new List<OrderMainSetting>();
        /// <summary>
        /// 總訂購資訊
        /// </summary>
        private List<OrderSetting> OrderSettings { get; set; } = new List<OrderSetting>();
        public OrderMaintainControl(APIMethod APIMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            apiMethod = APIMethod;
            det_OrderDate.EditValue = DateTime.Now;
            if (Form1.EmployeeSetting.Token > 0)
            {
                Refresh_Main_GridView();
            }
            action.Commands.Add(FlyoutCommand.Yes);
            Delectaction.Commands.Add(FlyoutCommand.Yes);
            Delectaction.Commands.Add(FlyoutCommand.Cancel);
            Delectaction.Caption = "刪除確認";
            #region 訂購資料表
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 訂購資訊報表按鈕
            RepositoryItemButtonEdit Orderedit = new RepositoryItemButtonEdit();
            Orderedit.ButtonClick += (s, e) =>
            {
                FocuseMainGrid();
                if (e.Button.Kind == ButtonPredefines.Plus)
                {
                    if (FocuseOrderMainSetting.FileName != null)
                    {
                        if (FocuseOrderMainSetting.FileName != "")
                        {
                            byte[] File = apiMethod.Get_OrderAttachmentFile(FocuseOrderMainSetting.OrderNumber, FocuseOrderMainSetting.FileName);
                            SaveFile(File, 0);
                        }
                    }
                }
            };
            Orderedit.Buttons[0].Kind = ButtonPredefines.Plus;
            Orderedit.Buttons[0].Caption = "下載";
            Orderedit.TextEditStyle = TextEditStyles.DisableTextEditor;
            OrdergridControl.RepositoryItems.Add(Orderedit);
            gridView1.Columns["FileName"].ColumnEdit = Orderedit;
            gridView1.Columns["FileName"].ShowButtonMode = ShowButtonModeEnum.ShowAlways;
            #endregion
            #region 訂購聚焦功能
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
            #region 報表修改字串功能 (後台已整合，不使用2022/7/7)
            //gridView1.CustomColumnDisplayText += (s, e) =>
            //{
            //    if (e.Column.FieldName == "OrderCompanyNumber")
            //    {
            //        string Index = e.DisplayText.ToString();
            //        CompanySetting company = CompanySettings.SingleOrDefault(g => g.CompanyNumber == Index);
            //        if (company != null)
            //        {
            //            e.DisplayText = company.CompanyName;
            //        }
            //    }
            //    else if (e.Column.FieldName == "OrderDirectoryNumber")
            //    {
            //        string Index = e.DisplayText.ToString();
            //        CompanyDirectorySetting company = CompanyDirectorySettings.SingleOrDefault(g => g.DirectoryNumber == Index);
            //        if (company != null)
            //        {
            //            e.DisplayText = company.DirectoryName;
            //        }
            //    }
            //    else if (e.Column.FieldName == "ProjectNumber")
            //    {
            //        if (e.DisplayText != null)
            //        {
            //            string Index = e.DisplayText.ToString();
            //            ProjectSetting project = ProjectSettings.SingleOrDefault(g => g.ProjectNumber == Index);
            //            if (project != null)
            //            {
            //                e.DisplayText = project.ProjectName;
            //            }
            //        }
            //    }
            //};
            #endregion
            #region 使用/作廢功能
            gridView1.RowStyle += (s, e) =>
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
            btn_Order_Add.Click += (s, e) =>
            {
                Refresh_API();
                OrderEditForm purchaseEdit = new OrderEditForm(CompanySettings, CompanyDirectorySettings, EmployeeSettings, ProductSettings, ProjectSettings, null, apiMethod, Form1);
                if (purchaseEdit.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #region 修改訂購資訊
            btn_Order_Edit.Click += (s, e) =>
            {
                Refresh_API();
                OrderSettings = APIMethod.Get_Order(FocuseOrderMainSetting);
                OrderEditForm purchaseEdit = new OrderEditForm(CompanySettings, CompanyDirectorySettings, EmployeeSettings, ProductSettings, ProjectSettings, OrderSettings[0], apiMethod, Form1);
                if (purchaseEdit.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #region 雙擊修改訂購資訊
            OrdergridControl.DoubleClick += (s, e) =>
            {
                Refresh_API();
                FocuseMainGrid();
                OrderSettings = APIMethod.Get_Order(FocuseOrderMainSetting);
                if (OrderSettings != null)
                {
                    if (OrderSettings[0] != null)
                    {
                        OrderEditForm purchaseEdit = new OrderEditForm(CompanySettings, CompanyDirectorySettings, EmployeeSettings, ProductSettings, ProjectSettings, OrderSettings[0], apiMethod, Form1);
                        if (purchaseEdit.ShowDialog() == DialogResult.OK)
                        {
                            Refresh_Main_GridView();
                        }
                    }
                }
            };
            #endregion
            #region 刪除訂購資訊
            btn_Order_Delete.Click += (s, e) =>
            {
                FocuseMainGrid();
                Delectaction.Description = $"刪除編碼 : {FocuseOrderMainSetting.OrderNumber}";
                if (FlyoutDialog.Show(Form1, Delectaction) == DialogResult.Yes)
                {
                    string response = APIMethod.Delete_Order(FocuseOrderMainSetting.OrderNumber);
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
            btn_Order_Search.Click += (s, e) =>
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
                FocuseOrderMainSetting.OrderNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderNumber").ToString();
                FocuseOrderMainSetting.OrderDate = Convert.ToDateTime(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderDate").ToString());

                FocuseOrderMainSetting.OrderCompanyNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderCompanyNumber").ToString();

                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProjectNumber") != null)
                {
                    FocuseOrderMainSetting.ProjectNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProjectNumber").ToString();
                }
                else
                {
                    FocuseOrderMainSetting.ProjectNumber = null;
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderEmployeeNumber") != null)
                {
                    FocuseOrderMainSetting.OrderEmployeeNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderEmployeeNumber").ToString();
                }
                else
                {
                    FocuseOrderMainSetting.OrderEmployeeNumber = "";
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Remark") != null)
                {
                    FocuseOrderMainSetting.Remark = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Remark").ToString();
                }
                else
                {
                    FocuseOrderMainSetting.Remark = "";
                }
                FocuseOrderMainSetting.Total = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Total").ToString());
                FocuseOrderMainSetting.Tax = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tax").ToString());
                FocuseOrderMainSetting.TotalTax = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TotalTax").ToString());
                FocuseOrderMainSetting.TotalQty = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TotalQty").ToString());
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FileName") != null)
                {
                    FocuseOrderMainSetting.FileName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FileName").ToString();
                }
                else
                {
                    FocuseOrderMainSetting.FileName = "";
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderNote") != null)
                {
                    FocuseOrderMainSetting.OrderNote = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OrderNote").ToString();
                }
                else
                {
                    FocuseOrderMainSetting.OrderNote = "";
                }
            }
            else
            {
                FocuseOrderMainSetting = new OrderMainSetting();
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
                    saveFileDialog.FileName = FocuseOrderMainSetting.FileName;
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
                if (cet_InvaildFlag.CheckState == CheckState.Checked)//作廢顯示
                {
                    OrderMainSettings = apiMethod.Get_Order(det_OrderDate.Text);
                }
                else//不顯示作廢
                {
                    OrderMainSettings = apiMethod.Get_Order(det_OrderDate.Text).Where(g => !g.InvalidFlag).ToList();
                }
                if (OrderMainSettings != null)
                {
                    OrdergridControl.DataSource = OrderMainSettings;
                    gridView1.Columns["OrderDate"].GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DateMonth;
                    gridView1.Columns["OrderDate"].GroupFormat.FormatString = "M" + "月";
                    gridView1.Columns["OrderDate"].GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    gridView1.Columns["OrderDate"].Group();
                    gridView1.ExpandAllGroups();
                    break;
                }
            }
            CloseProgressPanel(handle);
        }
        private void Refresh_API()
        {
            for (int i = 0; i < length; i++)
            {
                CompanySettings = apiMethod.Get_Company();
                if (CompanySettings.Count > 0)
                {
                    break;
                }
            }
            for (int i = 0; i < length; i++)
            {
                EmployeeSettings = apiMethod.Get_Employee();
                if (EmployeeSettings.Count > 0)
                {
                    break;
                }
            }
            for (int i = 0; i < length; i++)
            {
                ProductSettings = apiMethod.Get_Product();
                if (ProductSettings.Count > 0)
                {
                    break;
                }
            }
            for (int i = 0; i < length; i++)
            {
                ProjectSettings = apiMethod.Get_Project();
                if (ProjectSettings.Count > 0)
                {
                    break;
                }
            }
            for (int i = 0; i < length; i++)
            {
                CompanyDirectorySettings = apiMethod.Get_CompanyDirectory();
                if (CompanyDirectorySettings.Count > 0)
                {
                    break;
                }
            }
        }
        public override void Refresh_Token()
        {
            if (Form1.EmployeeSetting.Token != 2)
            {
                btn_Order_Delete.Visible = false;
            }
            else
            {
                btn_Order_Delete.Visible = true;
            }
        }
    }
}
