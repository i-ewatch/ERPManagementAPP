using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraSplashScreen;
using ERPManagementAPP.Maintain.SalesMaintainForm;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain
{
    public partial class SalesMaintainControl : Field4MaintainControl
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
        /// 聚焦銷貨表頭
        /// </summary>
        private SalesMainSetting FocuseSalesMainSetting { get; set; } = new SalesMainSetting();
        /// <summary>
        /// 總表頭
        /// </summary>
        private List<SalesMainSetting> SalesMainSettings { get; set; } = new List<SalesMainSetting>();
        /// <summary>
        /// 總銷貨資訊
        /// </summary>
        private List<SalesSetting> SalesSettings { get; set; } = new List<SalesSetting>();
        public SalesMaintainControl(APIMethod APIMethod, Form1 form1)
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
            #region 銷貨資料表
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 銷貨資訊報表按鈕
            RepositoryItemButtonEdit Salesedit = new RepositoryItemButtonEdit();
            Salesedit.ButtonClick += (s, e) =>
            {
                FocuseMainGrid();
                if (e.Button.Kind == ButtonPredefines.Plus)
                {
                    if (FocuseSalesMainSetting.FileName != null)
                    {
                        if (FocuseSalesMainSetting.FileName != "")
                        {
                            byte[] File = apiMethod.Get_SalesAttachmentFile(FocuseSalesMainSetting.SalesCustomerNumber, FocuseSalesMainSetting.FileName);
                            SaveFile(File, 0);
                        }
                    }
                }
            };
            Salesedit.Buttons[0].Kind = ButtonPredefines.Plus;
            Salesedit.Buttons[0].Caption = "下載";
            Salesedit.TextEditStyle = TextEditStyles.DisableTextEditor;
            SalesgridControl.RepositoryItems.Add(Salesedit);
            gridView1.Columns["FileName"].ColumnEdit = Salesedit;
            gridView1.Columns["FileName"].ShowButtonMode = ShowButtonModeEnum.ShowAlways;
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
                                e.DisplayText = "銷貨退回";
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
            #region 新增銷貨資訊
            btn_Sales_Add.Click += (s, e) =>
            {
                Refresh_API();
                SalesEditForm purchaseEdit = new SalesEditForm(CustomerSettings, EmployeeSettings, ProductSettings, ProjectSettings, null, apiMethod, Form1);
                if (purchaseEdit.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #region 修改銷貨資訊
            btn_Sales_Edit.Click += (s, e) =>
            {
                Refresh_API();
                SalesSettings = APIMethod.Get_Sales(FocuseSalesMainSetting);
                SalesEditForm purchaseEdit = new SalesEditForm(CustomerSettings, EmployeeSettings, ProductSettings, ProjectSettings, SalesSettings[0], apiMethod, Form1);
                if (purchaseEdit.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #region 雙擊修改銷貨資訊
            SalesgridControl.DoubleClick += (s, e) =>
            {
                Refresh_API();
                FocuseMainGrid();
                SalesSettings = APIMethod.Get_Sales(FocuseSalesMainSetting);
                SalesEditForm purchaseEdit = new SalesEditForm(CustomerSettings, EmployeeSettings, ProductSettings, ProjectSettings, SalesSettings[0], apiMethod, Form1);
                if (purchaseEdit.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #region 刪除銷貨資訊
            btn_Sales_Delete.Click += (s, e) =>
            {
                FocuseMainGrid();
                string response = APIMethod.Delete_Sales(FocuseSalesMainSetting.SalesFlag, FocuseSalesMainSetting.SalesNumber);
                if (response == "200")
                {
                    Refresh_Main_GridView();
                    action.Caption = "刪除銷貨資訊成功";
                    action.Description = "";
                    FlyoutDialog.Show(Form1, action);
                }
                else
                {
                    action.Caption = "刪除銷貨資訊失敗";
                    action.Description = "";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 產品類別資料查詢
            btn_Sales_Search.Click += (s, e) =>
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
                FocuseSalesMainSetting.SalesFlag = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SalesFlag").ToString());
                FocuseSalesMainSetting.SalesNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SalesNumber").ToString();
                FocuseSalesMainSetting.SalesDate = Convert.ToDateTime(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SalesDate").ToString());
                FocuseSalesMainSetting.SalesCustomerNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SalesCustomerNumber").ToString();

                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProjectNumber") != null)
                {
                    FocuseSalesMainSetting.ProjectNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProjectNumber").ToString();
                }
                else
                {
                    FocuseSalesMainSetting.ProjectNumber = null;
                }

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
        #region 下載檔案功能
        private void SaveFile(byte[] File, int Index)
        {
            if (File != null)
            {
                apiMethod.ClientFlag = true;
                if (File.Length > 147)
                {
                    saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = FocuseSalesMainSetting.FileName;
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
                Refresh_API();
                SalesMainSettings = apiMethod.Get_Sales(det_SalesDate.Text.Replace("/", ""));
                if (SalesMainSettings != null)
                {
                    SalesgridControl.DataSource = SalesMainSettings;
                    break;
                }
            }
            CloseProgressPanel(handle);
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
                btn_Sales_Delete.Visible = false;
            }
            else
            {
                btn_Sales_Delete.Visible = true;
            }
        }
    }
}
