using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraSplashScreen;
using ERPManagementAPP.Maintain.ProjectMaintainForm;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain
{
    public partial class ProjectMaintainControl : Field4MaintainControl
    {
        /// <summary>
        /// 總專案資料
        /// </summary>
        private List<ProjectSetting> ProjectSettings { get; set; }
        /// <summary>
        /// 聚焦專案資料
        /// </summary>
        private ProjectSetting FocuseProjectSetting { get; set; } = new ProjectSetting();
        /// <summary>
        /// 總專案成員資料
        /// </summary>
        private List<ProjectEmployeeSetting> ProjectEmployeeSettings { get; set; }
        /// <summary>
        /// 聚焦專案成員資料
        /// </summary>
        private ProjectEmployeeSetting FocuseProjectEmployeeSetting { get; set; } = new ProjectEmployeeSetting();
        /// <summary>
        /// 總員工資料
        /// </summary>
        private List<EmployeeSetting> EmployeeSettings { get; set; }

        public ProjectMaintainControl(APIMethod APIMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            apiMethod = APIMethod;
            if (Form1.EmployeeSetting.Token > 0)
            {
                Refresh_Main_GridView();
            }
            action.Commands.Add(FlyoutCommand.Yes);
            Delectaction.Commands.Add(FlyoutCommand.Yes);
            Delectaction.Commands.Add(FlyoutCommand.Cancel);
            Delectaction.Caption = "刪除確認";
            #region 專案資料表
            advBandedGridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            advBandedGridView1.OptionsDetail.EnableMasterViewMode = false;
            #region 專案資訊報表按鈕
            RepositoryItemButtonEdit Projectedit = new RepositoryItemButtonEdit();
            Projectedit.ButtonClick += (s, e) =>
            {
                FocuseMainGrid();
                if (e.Button.Kind == ButtonPredefines.Plus)
                {
                    if (FocuseProjectSetting.FileName != null)
                    {
                        if (FocuseProjectSetting.FileName != "")
                        {
                            byte[] File = apiMethod.Get_ProjectAttachmentFile(FocuseProjectSetting.ProjectNumber, FocuseProjectSetting.FileName);
                            SaveFile(File, 0);
                        }
                    }
                }
            };
            Projectedit.Buttons[0].Kind = ButtonPredefines.Plus;
            Projectedit.Buttons[0].Caption = "下載";
            Projectedit.TextEditStyle = TextEditStyles.DisableTextEditor;
            gridControl1.RepositoryItems.Add(Projectedit);
            advBandedGridView1.Columns["FileName"].ColumnEdit = Projectedit;
            advBandedGridView1.Columns["FileName"].ShowButtonMode = ShowButtonModeEnum.ShowAlways;
            advBandedGridView1.Columns["FileName"].ColumnEdit = Projectedit;
            #endregion
            #region 報表聚焦功能
            advBandedGridView1.FocusedRowChanged += (s, ex) =>
            {
                FocuseMainGrid();
            };
            #endregion
            #region 關鍵字搜尋
            advBandedGridView1.ColumnFilterChanged += (s, e) =>
            {

                FocuseMainGrid();
            };
            #endregion
            #region 新增專案
            btn_Project_Add.Click += (s, e) =>
            {
                ProjectEditForm company = new ProjectEditForm(EmployeeSettings, null, apiMethod, Form1);
                if (company.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #region 修改專案
            btn_Project_Edit.Click += (s, e) =>
            {
                ProjectEditForm company = new ProjectEditForm(EmployeeSettings, FocuseProjectSetting, apiMethod, Form1);
                if (company.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #region 雙擊修改專案
            gridControl1.DoubleClick += (s, e) =>
            {
                FocuseMainGrid();
                ProjectEditForm company = new ProjectEditForm(EmployeeSettings, FocuseProjectSetting, apiMethod, Form1);
                if (company.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #region 刪除專案
            btn_Project_Delete.Click += (s, e) =>
            {
                FocuseMainGrid();
                Delectaction.Description = $"刪除編碼 : {FocuseProjectSetting.ProjectName}";
                if (FlyoutDialog.Show(Form1, Delectaction) == DialogResult.Yes)
                {
                    string response = apiMethod.Delete_Project(FocuseProjectSetting.ProjectNumber);
                    if (response == "200")
                    {
                        Refresh_Main_GridView();
                        action.Caption = "刪除專案成功";
                        action.Description = "";
                        FlyoutDialog.Show(Form1, action);
                    }
                    else
                    {
                        action.Caption = "刪除專案失敗";
                        action.Description = "";
                        FlyoutDialog.Show(Form1, action);
                    }
                }
            };
            #endregion
            #region 專案資料刷新
            btn_Project_Refresh.Click += (s, e) =>
            {
                Refresh_Main_GridView();
            };
            #endregion
            #endregion
            #region 專案成員資料表
            gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 報表修改字串功能
            gridView2.CustomColumnDisplayText += (s, e) =>
            {
                if (e.Column.FieldName == "EmployeeNumber")
                {
                    string Index = e.DisplayText.ToString();
                    for (int i = 0; i < EmployeeSettings.Count; i++)
                    {
                        if (Index == EmployeeSettings[i].EmployeeNumber)
                        {
                            e.DisplayText = EmployeeSettings[i].EmployeeName;
                            break;
                        }
                    }
                }
            };
            #endregion
            #endregion
        }
        #region 聚焦主資料表功能
        private void FocuseMainGrid()
        {
            if (advBandedGridView1.FocusedRowHandle > -1 && advBandedGridView1.DataRowCount > 0)
            {
                FocuseProjectSetting.ProjectNumber = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "ProjectNumber").ToString();
                FocuseProjectSetting.ProjectName = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "ProjectName").ToString();
                FocuseProjectSetting.ProjectIncome = Convert.ToDouble(advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "ProjectIncome").ToString());
                FocuseProjectSetting.ProjectCost = Convert.ToDouble(advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "ProjectCost").ToString());
                FocuseProjectSetting.ProjectProfit = Convert.ToDouble(advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "ProjectProfit").ToString());
                FocuseProjectSetting.ProjectBonusCommission = Convert.ToDouble(advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "ProjectBonusCommission").ToString());
                if (advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "PostingDate") != null)
                {
                    FocuseProjectSetting.PostingDate = Convert.ToDateTime(advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "PostingDate").ToString());
                }
                else
                {
                    FocuseProjectSetting.PostingDate = null;
                }
                if (advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "ProfitSharingDate") != null)
                {
                    FocuseProjectSetting.ProfitSharingDate = Convert.ToDateTime(advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "ProfitSharingDate").ToString());
                }
                else
                {
                    FocuseProjectSetting.ProfitSharingDate = null;
                }
                if (advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "Remark") != null)
                {
                    FocuseProjectSetting.Remark = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "Remark").ToString();
                }
                else
                {
                    FocuseProjectSetting.Remark = "";
                }
                if (advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "FileName") != null)
                {
                    FocuseProjectSetting.FileName = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "FileName").ToString();
                }
                else
                {
                    FocuseProjectSetting.FileName = "";
                }
                FocuseProjectSetting.ProjectEmployee = ProjectSettings[advBandedGridView1.FocusedRowHandle].ProjectEmployee;
                #region 刷新通訊錄功能
                Refresh_Second_GridView("0");
                #endregion
            }
            else
            {
                FocuseProjectSetting = new ProjectSetting();
            }
        }
        #endregion
        #region 下載檔案功能
        private void SaveFile(byte[] File, int Index)
        {
            if (File != null)
            {
                apiMethod.ClientFlag = true;
                if (File.Length > 133)
                {
                    saveFileDialog = new SaveFileDialog();
                    if (Index == 0)
                    {
                        saveFileDialog.FileName = FocuseProjectSetting.FileName;
                    }
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
                EmployeeSettings = apiMethod.Get_Employee();
                ProjectSettings = apiMethod.Get_Project();
                if (ProjectSettings != null)
                {
                    gridControl1.DataSource = ProjectSettings;
                    for (int index = 0; index < advBandedGridView1.Columns.Count; index++)
                    {
                        advBandedGridView1.Columns[index].BestFit();
                    }
                    break;
                }
            }
            CloseProgressPanel(handle);
        }
        public override void Refresh_Second_GridView(string Number)
        {
            gridControl2.DataSource = FocuseProjectSetting.ProjectEmployee;
            gridControl2.RefreshDataSource();
        }
        public override void Refresh_Token()
        {
            if (Form1.EmployeeSetting.Token != 2)
            {
                btn_Project_Delete.Visible = false;
            }
            else
            {
                btn_Project_Delete.Visible = true;
            }
        }
    }
}
