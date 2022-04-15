using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using ERPManagementAPP.Maintain.PickingMaintainForm;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain
{
    public partial class PickingMaintainControl : Field4MaintainControl
    {
        /// <summary>
        /// 產品資訊
        /// </summary>
        private List<ProductSetting> ProductSettings { get; set; }
        /// <summary>
        /// 客戶資訊
        /// </summary>
        private List<CustomerSetting> CustomerSettings { get; set; }
        /// <summary>
        /// 員工資訊
        /// </summary>
        private List<EmployeeSetting> EmployeeSettings { get; set; }
        /// <summary>
        /// 專案資訊
        /// </summary>
        private List<ProjectSetting> ProjectSettings { get; set; }
        /// <summary>
        /// 聚焦領料表頭
        /// </summary>
        private PickingMainSetting FocusePickingMainSetting { get; set; } = new PickingMainSetting();
        /// <summary>
        /// 總表頭
        /// </summary>
        private List<PickingMainSetting> PickingMainSettings { get; set; } = new List<PickingMainSetting>();
        /// <summary>
        /// 總領料資訊
        /// </summary>
        private List<PickingSetting> PickingSettings { get; set; } = new List<PickingSetting>();
        public PickingMaintainControl(APIMethod APIMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            apiMethod = APIMethod;
            det_PickingDate.Text = DateTime.Now.ToString("yyyy/MM");
            if (Form1.EmployeeSetting.Token > 0)
            {
                Refresh_Main_GridView();
            }
            action.Commands.Add(FlyoutCommand.Yes);
            #region 領料資料表
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 領料資訊報表按鈕
            RepositoryItemButtonEdit Pickingedit = new RepositoryItemButtonEdit();
            Pickingedit.ButtonClick += (s, e) =>
            {
                FocuseMainGrid();
                if (e.Button.Kind == ButtonPredefines.Plus)
                {
                    if (FocusePickingMainSetting.FileName != null)
                    {
                        if (FocusePickingMainSetting.FileName != "")
                        {
                            byte[] File = apiMethod.Get_PickingAttachmentFile(FocusePickingMainSetting.PickingCustomerNumber, FocusePickingMainSetting.FileName);
                            SaveFile(File, 0);
                        }
                    }
                }
            };
            Pickingedit.Buttons[0].Kind = ButtonPredefines.Plus;
            Pickingedit.Buttons[0].Caption = "下載";
            Pickingedit.TextEditStyle = TextEditStyles.DisableTextEditor;
            PickinggridControl.RepositoryItems.Add(Pickingedit);
            gridView1.Columns["FileName"].ColumnEdit = Pickingedit;
            gridView1.Columns["FileName"].ShowButtonMode = ShowButtonModeEnum.ShowAlways;
            #endregion
            #region 領料聚焦功能
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
            #region 報表修改字串功能
            gridView1.CustomDrawCell += (s, e) =>
            {
                if (e.Column.FieldName == "PickingFlag")
                {
                    e.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
                    string Index = e.CellValue.ToString();
                    switch (Index)
                    {
                        case "5":
                            {
                                e.DisplayText = "領料";
                            }
                            break;
                        case "6":
                            {
                                e.DisplayText = "領料退回";
                            }
                            break;
                    }
                }
                else if (e.Column.FieldName == "PickingCustomerNumber")
                {
                    e.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
                    string Index = e.CellValue.ToString();
                    CustomerSetting company = CustomerSettings.SingleOrDefault(g => g.CustomerNumber == Index);
                    if (company != null)
                    {
                        e.DisplayText = company.CustomerName;
                    }
                }
                else if (e.Column.FieldName == "ProjectNumber")
                {
                    e.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
                    if (e.CellValue != null)
                    {
                        string Index = e.CellValue.ToString();
                        ProjectSetting project = ProjectSettings.SingleOrDefault(g => g.ProjectNumber == Index);
                        if (project != null)
                        {
                            e.DisplayText = project.ProjectName;
                        }
                    }
                }
                else if (e.Column.FieldName == "PickingTax")
                {
                    e.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
                    string Index = e.CellValue.ToString();
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
            #region 新增領料資訊
            btn_Picking_Add.Click += (s, e) =>
            {
                Refresh_API();
                PickingEditForm purchaseEdit = new PickingEditForm(CustomerSettings, EmployeeSettings, ProductSettings, ProjectSettings, null, apiMethod, Form1);
                if (purchaseEdit.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #region 修改領料資訊
            btn_Picking_Edit.Click += (s, e) =>
            {
                Refresh_API();
                PickingSettings = APIMethod.Get_Picking(FocusePickingMainSetting);
                PickingEditForm purchaseEdit = new PickingEditForm(CustomerSettings, EmployeeSettings, ProductSettings, ProjectSettings, PickingSettings[0], apiMethod, Form1);
                if (purchaseEdit.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #region 雙擊修改領料資訊
            PickinggridControl.DoubleClick += (s, e) =>
            {
                Refresh_API();
                FocuseMainGrid();
                PickingSettings = APIMethod.Get_Picking(FocusePickingMainSetting);
                PickingEditForm purchaseEdit = new PickingEditForm(CustomerSettings, EmployeeSettings, ProductSettings, ProjectSettings, PickingSettings[0], apiMethod, Form1);
                if (purchaseEdit.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #region 刪除領料資訊
            btn_Picking_Delete.Click += (s, e) =>
            {
                FocuseMainGrid();
                string response = APIMethod.Delete_Picking(FocusePickingMainSetting.PickingFlag, FocusePickingMainSetting.PickingNumber);
                if (response == "200")
                {
                    Refresh_Main_GridView();
                    action.Caption = "刪除領料資訊成功";
                    action.Description = "";
                    FlyoutDialog.Show(Form1, action);
                }
                else
                {
                    action.Caption = "刪除領料資訊失敗";
                    action.Description = "";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 產品類別資料查詢
            btn_Picking_Search.Click += (s, e) =>
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
                FocusePickingMainSetting.PickingFlag = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PickingFlag").ToString());
                FocusePickingMainSetting.PickingNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PickingNumber").ToString();
                FocusePickingMainSetting.PickingDate = Convert.ToDateTime(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PickingDate").ToString());
                FocusePickingMainSetting.PickingCustomerNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PickingCustomerNumber").ToString();
                FocusePickingMainSetting.PickingTax = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PickingTax").ToString());
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PickingInvoiceNo") != null)
                {
                    FocusePickingMainSetting.PickingInvoiceNo = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PickingInvoiceNo").ToString();
                }
                else
                {
                    FocusePickingMainSetting.PickingInvoiceNo = "";
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PickingEmployeeNumber") != null)
                {
                    FocusePickingMainSetting.PickingEmployeeNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PickingEmployeeNumber").ToString();
                }
                else
                {
                    FocusePickingMainSetting.PickingEmployeeNumber = "";
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Remark") != null)
                {
                    FocusePickingMainSetting.Remark = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Remark").ToString();
                }
                else
                {
                    FocusePickingMainSetting.Remark = "";
                }
                FocusePickingMainSetting.Total = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Total").ToString());
                FocusePickingMainSetting.Tax = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tax").ToString());
                FocusePickingMainSetting.TotalTax = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TotalTax").ToString());
                FocusePickingMainSetting.Posting = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Posting").ToString());
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FileName") != null)
                {
                    FocusePickingMainSetting.FileName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FileName").ToString();
                }
                else
                {
                    FocusePickingMainSetting.FileName = "";
                }
                FocusePickingMainSetting.TakeACut = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TakeACut").ToString());
                FocusePickingMainSetting.Cost = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Cost").ToString());
                FocusePickingMainSetting.ProfitSharing = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProfitSharing").ToString());
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PostingDate") != null)
                {
                    FocusePickingMainSetting.PostingDate = Convert.ToDateTime(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PostingDate").ToString());
                }
                else
                {
                    FocusePickingMainSetting.PostingDate = null;
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProfitSharingDate") != null)
                {
                    FocusePickingMainSetting.ProfitSharingDate = Convert.ToDateTime(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProfitSharingDate").ToString());
                }
                else
                {
                    FocusePickingMainSetting.ProfitSharingDate = null;
                }
            }
            else
            {
                FocusePickingMainSetting = new PickingMainSetting();
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
                    saveFileDialog.FileName = FocusePickingMainSetting.FileName;
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
            PickingMainSettings = apiMethod.Get_Picking(det_PickingDate.Text.Replace("/", ""));
            if (PickingMainSettings != null)
            {
                PickinggridControl.DataSource = PickingMainSettings;
            }
        }
        private void Refresh_API()
        {
            CustomerSettings = apiMethod.Get_Customer();
            EmployeeSettings = apiMethod.Get_Employee();
            ProductSettings = apiMethod.Get_Product();
            ProjectSettings = apiMethod.Get_Project();
        }
        public override void Refresh_Token()
        {
            if (Form1.EmployeeSetting.Token != 2)
            {
                btn_Picking_Delete.Visible = false;
            }
            else
            {
                btn_Picking_Delete.Visible = true;
            }
        }
    }
}
