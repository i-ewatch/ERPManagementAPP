﻿using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using ERPManagementAPP.Maintain.OperatingMaintainForm;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain
{
    public partial class OperatingMaintainControl : Field4MaintainControl
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
        /// 員工資訊
        /// </summary>
        private List<EmployeeSetting> EmployeeSettings { get; set; }
        /// <summary>
        /// 專案資訊
        /// </summary>
        private List<ProjectSetting> ProjectSettings { get; set; }
        /// <summary>
        /// 聚焦營運表頭
        /// </summary>
        private OperatingMainSetting FocuseOperatingMainSetting { get; set; } = new OperatingMainSetting();
        /// <summary>
        /// 總表頭
        /// </summary>
        private List<OperatingMainSetting> OperatingMainSettings { get; set; } = new List<OperatingMainSetting>();
        /// <summary>
        /// 總營運資訊
        /// </summary>
        private List<OperatingSetting> OperatingSettings { get; set; } = new List<OperatingSetting>();
        public OperatingMaintainControl(APIMethod APIMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            apiMethod = APIMethod;
            det_OperatingDate.Text = DateTime.Now.ToString("yyyy/MM");
            if (Form1.EmployeeSetting.Token > 0)
            {
                Refresh_Main_GridView();
            }
            action.Commands.Add(FlyoutCommand.Yes);
            #region 營運資料表
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 營運資訊報表按鈕
            RepositoryItemButtonEdit Operatingedit = new RepositoryItemButtonEdit();
            Operatingedit.ButtonClick += (s, e) =>
            {
                FocuseMainGrid();
                if (e.Button.Kind == ButtonPredefines.Plus)
                {
                    if (FocuseOperatingMainSetting.FileName != null)
                    {
                        if (FocuseOperatingMainSetting.FileName != "")
                        {
                            byte[] File = apiMethod.Get_OperatingAttachmentFile(FocuseOperatingMainSetting.OperatingCompanyNumber, FocuseOperatingMainSetting.FileName);
                            SaveFile(File, 0);
                        }
                    }
                }
            };
            Operatingedit.Buttons[0].Kind = ButtonPredefines.Plus;
            Operatingedit.Buttons[0].Caption = "下載";
            Operatingedit.TextEditStyle = TextEditStyles.DisableTextEditor;
            OperatinggridControl.RepositoryItems.Add(Operatingedit);
            gridView1.Columns["FileName"].ColumnEdit = Operatingedit;
            gridView1.Columns["FileName"].ShowButtonMode = ShowButtonModeEnum.ShowAlways;
            #endregion
            #region 營運聚焦功能
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
                if (e.Column.FieldName == "OperatingFlag")
                {
                    e.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
                    string Index = e.CellValue.ToString();
                    switch (Index)
                    {
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
                //else if (e.Column.FieldName == "OperatingCompanyNumber")
                //{
                //    e.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
                //    string Index = e.CellValue.ToString();
                //    CompanySetting company = CompanySettings.SingleOrDefault(g => g.CompanyNumber == Index);
                //    if (company != null)
                //    {
                //        e.DisplayText = company.CompanyName;
                //    }
                //}
                //else if (e.Column.FieldName == "ProjectNumber")
                //{
                //    e.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
                //    if (e.CellValue != null)
                //    {
                //        string Index = e.CellValue.ToString();
                //        ProjectSetting project = ProjectSettings.SingleOrDefault(g => g.ProjectNumber == Index);
                //        if (project != null)
                //        {
                //            e.DisplayText = project.ProjectName;
                //        }
                //    }
                //}
                else if (e.Column.FieldName == "OperatingTax")
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
            #region 新增營運資訊
            btn_Operating_Add.Click += (s, e) =>
            {
                Refresh_API();
                OperatingEditForm purchaseEdit = new OperatingEditForm(CompanySettings, EmployeeSettings, ProductSettings, ProjectSettings, null, apiMethod, Form1);
                if (purchaseEdit.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #region 修改營運資訊
            btn_Operating_Edit.Click += (s, e) =>
            {
                Refresh_API();
                OperatingSettings = APIMethod.Get_Operating(FocuseOperatingMainSetting);
                OperatingEditForm purchaseEdit = new OperatingEditForm(CompanySettings, EmployeeSettings, ProductSettings, ProjectSettings, OperatingSettings[0], apiMethod, Form1);
                if (purchaseEdit.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #region 雙擊修改營運資訊
            OperatinggridControl.DoubleClick += (s, e) =>
            {
                Refresh_API();
                FocuseMainGrid();
                OperatingSettings = APIMethod.Get_Operating(FocuseOperatingMainSetting);
                OperatingEditForm purchaseEdit = new OperatingEditForm(CompanySettings, EmployeeSettings, ProductSettings, ProjectSettings, OperatingSettings[0], apiMethod, Form1);
                if (purchaseEdit.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #region 刪除營運資訊
            btn_Operating_Delete.Click += (s, e) =>
            {
                FocuseMainGrid();
                string response = APIMethod.Delete_Operating(FocuseOperatingMainSetting.OperatingFlag, FocuseOperatingMainSetting.OperatingNumber);
                if (response == "200")
                {
                    Refresh_Main_GridView();
                    action.Caption = "刪除營運資訊成功";
                    action.Description = "";
                    FlyoutDialog.Show(Form1, action);
                }
                else
                {
                    action.Caption = "刪除營運資訊失敗";
                    action.Description = "";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 產品類別資料查詢
            btn_Operating_Search.Click += (s, e) =>
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
                FocuseOperatingMainSetting.OperatingFlag = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OperatingFlag").ToString());
                FocuseOperatingMainSetting.OperatingNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OperatingNumber").ToString();
                FocuseOperatingMainSetting.OperatingDate = Convert.ToDateTime(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OperatingDate").ToString());

                var purchaseComanyNumber = CompanySettings.SingleOrDefault(g => g.CompanyName == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OperatingCompanyNumber").ToString());
                if (purchaseComanyNumber != null) FocuseOperatingMainSetting.OperatingCompanyNumber = purchaseComanyNumber.CompanyNumber;
                else FocuseOperatingMainSetting.OperatingCompanyNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OperatingCompanyNumber").ToString();

                FocuseOperatingMainSetting.OperatingTax = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OperatingTax").ToString());

                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProjectNumber") != null)
                {
                    var projectNumber = ProjectSettings.SingleOrDefault(g => g.ProjectName == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProjectNumber").ToString());
                    if (projectNumber != null) FocuseOperatingMainSetting.ProjectNumber = projectNumber.ProjectNumber;
                    else FocuseOperatingMainSetting.ProjectNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProjectNumber").ToString();
                }
                else
                {
                    FocuseOperatingMainSetting.ProjectNumber = null;
                }

                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OperatingInvoiceNo") != null)
                {
                    FocuseOperatingMainSetting.OperatingInvoiceNo = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OperatingInvoiceNo").ToString();
                }
                else
                {
                    FocuseOperatingMainSetting.OperatingInvoiceNo = "";
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OperatingEmployeeNumber") != null)
                {
                    FocuseOperatingMainSetting.OperatingEmployeeNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OperatingEmployeeNumber").ToString();
                }
                else
                {
                    FocuseOperatingMainSetting.OperatingEmployeeNumber = "";
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Remark") != null)
                {
                    FocuseOperatingMainSetting.Remark = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Remark").ToString();
                }
                else
                {
                    FocuseOperatingMainSetting.Remark = "";
                }
                FocuseOperatingMainSetting.Total = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Total").ToString());
                FocuseOperatingMainSetting.Tax = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tax").ToString());
                FocuseOperatingMainSetting.TotalTax = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TotalTax").ToString());
                FocuseOperatingMainSetting.Posting = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Posting").ToString());
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FileName") != null)
                {
                    FocuseOperatingMainSetting.FileName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FileName").ToString();
                }
                else
                {
                    FocuseOperatingMainSetting.FileName = "";
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PostingDate") != null)
                {
                    FocuseOperatingMainSetting.PostingDate = Convert.ToDateTime(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PostingDate").ToString());
                }
                else
                {
                    FocuseOperatingMainSetting.PostingDate = null;
                }
            }
            else
            {
                FocuseOperatingMainSetting = new OperatingMainSetting();
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
                    saveFileDialog.FileName = FocuseOperatingMainSetting.FileName;
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
            OperatingMainSettings = apiMethod.Get_Operating(det_OperatingDate.Text.Replace("/", ""));
            if (OperatingMainSettings != null)
            {
                foreach (var item in CompanySettings)
                {
                    OperatingMainSettings.Where(g => g.OperatingCompanyNumber == item.CompanyNumber).ToList().ForEach(t => t.OperatingCompanyNumber = item.CompanyName);
                }
                foreach (var item in ProjectSettings)
                {
                    OperatingMainSettings.Where(g => g.ProjectNumber == item.ProjectNumber).ToList().ForEach(t => t.ProjectNumber = item.ProjectName);
                }
                OperatinggridControl.DataSource = OperatingMainSettings;
            }
        }
        private void Refresh_API()
        {
            CompanySettings = apiMethod.Get_Company();
            EmployeeSettings = apiMethod.Get_Employee();
            ProductSettings = apiMethod.Get_Product();
            ProjectSettings = apiMethod.Get_Project();

        }
        public override void Refresh_Token()
        {
            if (Form1.EmployeeSetting.Token != 2)
            {
                btn_Operating_Delete.Visible = false;
            }
            else
            {
                btn_Operating_Delete.Visible = true;
            }
        }
    }
}
