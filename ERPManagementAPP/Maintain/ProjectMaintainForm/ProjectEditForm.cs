using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain.ProjectMaintainForm
{
    public partial class ProjectEditForm : BaseEditForm
    {
        /// <summary>
        /// 總專案成員資料
        /// </summary>
        private List<ProjectEmployeeSetting> ProjectEmployeeSettings { get; set; }
        /// <summary>
        /// 聚焦專案成員資料
        /// </summary>
        private ProjectEmployeeSetting FocuseProjectEmployeeSetting { get; set; } = new ProjectEmployeeSetting();
        /// <summary>
        /// 專案資訊
        /// </summary>
        private ProjectSetting ProjectSetting { get; set; } = new ProjectSetting();
        /// <summary>
        /// 員工資訊
        /// </summary>
        private List<EmployeeSetting> EmployeeSettings { get; set; }
        public ProjectEditForm(List<EmployeeSetting> employeeSettings, ProjectSetting projectSetting, APIMethod apiMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            action.Commands.Add(FlyoutCommand.Yes);
            EmployeeSettings = employeeSettings;
            ProjectSetting = projectSetting;
            Create_cbt_EmployeeNumber_cbt();
            if (projectSetting != null && !String.IsNullOrEmpty(projectSetting.ProjectNumber))
            {
                txt_ProjectNumber.Enabled = false;
                txt_ProjectNumber.Text = projectSetting.ProjectNumber;
                txt_ProjectName.Text = projectSetting.ProjectName;
                ProjectEmployeeSettings = projectSetting.ProjectEmployee;
                txt_ProjectIncome.Text = projectSetting.ProjectIncome.ToString();
                txt_ProjectCost.Text = projectSetting.ProjectCost.ToString();
                txt_ProjcetProfit.Text = projectSetting.ProjectProfit.ToString();
                txt_ProjectBonusCommission.Text = projectSetting.ProjectBonusCommission.ToString();
                mmt_Remark.Text = projectSetting.Remark.ToString();
                det_PostingDate.EditValue = projectSetting.PostingDate;
            }
            else
            {
                ProjectEmployeeSettings = new List<ProjectEmployeeSetting>();
            }
            RefreshData();
            #region 載入檔案按鈕
            btn_LoadFile.Click += (s, e) =>
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog.OpenFile() != null)
                    {
                        AttachmentFilePath = openFileDialog.FileName;
                        txt_FileName.Text = Path.GetFileName(openFileDialog.FileName);
                    }
                }
            };
            #endregion
            #region 清除載入檔案
            btn_ClearFile.Click += (s, e) =>
            {
                AttachmentFilePath = "";
                txt_FileName.Text = "";
            };
            #endregion
            #region 報表聚焦功能
            gridView2.FocusedRowChanged += (s, e) =>
            {
                FocuseMainGrid();
            };
            #endregion
            #region 細項新增
            btn_Add.Click += (s, e) =>
            {
                if (!string.IsNullOrEmpty(txt_BounsRatio.Text) && cbt_EmployeeNumber.SelectedIndex > -1)
                {
                    ProjectEmployeeSettings.Add(new ProjectEmployeeSetting()
                    {
                        ProjectNumber = txt_ProjectNumber.Text,
                        EmployeeNumber = Get_cbt_EmployeeNumber_Number(),
                        BonusRatio = Convert.ToDouble(txt_BounsRatio.Text),
                    });
                    cbt_EmployeeNumber.SelectedIndex = -1;
                    txt_BounsRatio.Text = "";
                    RefreshData();
                    FocuseMainGrid();
                }
                else
                {
                    action.Caption = "細項新增錯誤";
                    action.Description = "請確認資料是否完整";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 表身輸入框清除
            btn_Clear.Click += (s, e) =>
            {
                cbt_EmployeeNumber.SelectedIndex = -1;
                txt_BounsRatio.Text = "";
            };
            #endregion
            #region 報表修改字串功能
            gridView2.CustomDrawCell += (s, e) =>
            {
                if (e.Column.FieldName == "EmployeeNumber")
                {
                    e.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                    string Index = e.CellValue.ToString();
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
            #region 刪除細項
            btn_Delete.Click += (s, e) =>
            {
                for (int i = 0; i < ProjectEmployeeSettings.Count; i++)
                {
                    if (ProjectEmployeeSettings[i].EmployeeNumber == FocuseProjectEmployeeSetting.EmployeeNumber)
                    {
                        ProjectEmployeeSettings.RemoveAt(i);
                    }
                }
                RefreshData();
                FocuseMainGrid();
            };
            #endregion
            #region 取消按鈕
            btn_Cancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
            };
            #endregion
            #region 儲存按鈕
            btn_Save.Click += (s, e) =>
            {
                CheckNumber(ProjectSetting, apiMethod);
            };
            #endregion
        }
        #region 聚焦主資料表功能
        private void FocuseMainGrid()
        {
            if (gridView2.FocusedRowHandle > -1 && gridView2.DataRowCount > 0)
            {
                FocuseProjectEmployeeSetting.ProjectNumber = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ProjectNumber").ToString();
                FocuseProjectEmployeeSetting.EmployeeNumber = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "EmployeeNumber").ToString();
                FocuseProjectEmployeeSetting.BonusRatio = Convert.ToDouble(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "BonusRatio").ToString());
            }
            else
            {
                FocuseProjectEmployeeSetting = new ProjectEmployeeSetting();
            }
        }
        #endregion
        #region 員工編號功能
        /// <summary>
        /// 創建員工編號下拉選單
        /// </summary>
        /// <param name="companySettings"></param>
        private void Create_cbt_EmployeeNumber_cbt()
        {
            if (cbt_EmployeeNumber.Properties.Items.Count > 0)
            {
                cbt_EmployeeNumber.Properties.Items.Clear();
            }
            if (EmployeeSettings != null)
            {
                foreach (var item in EmployeeSettings)
                {
                    cbt_EmployeeNumber.Properties.Items.Add(item.EmployeeName);
                }
            }
        }
        /// <summary>
        /// 取得員工編號
        /// </summary>
        /// <returns></returns>
        private string Get_cbt_EmployeeNumber_Number()
        {
            string value = "";
            if (EmployeeSettings != null)
            {
                if (EmployeeSettings.Count > 0)
                {
                    value = EmployeeSettings[cbt_EmployeeNumber.SelectedIndex].EmployeeNumber;
                }
            }
            return value;
        }
        #endregion
        #region 刷新報表
        /// <summary>
        /// 刷新報表
        /// </summary>
        private void RefreshData()
        {
            gridControl2.DataSource = ProjectEmployeeSettings;
            gridControl2.RefreshDataSource();
        }
        #endregion
        #region 檢查資料問題
        private void CheckNumber(ProjectSetting projectSetting, APIMethod apiMethod)
        {
            string response = "";
            if (projectSetting != null && projectSetting.ProjectNumber != null)
            {
                action.Caption = "專案修改錯誤";
                projectSetting.ProjectNumber = txt_ProjectNumber.Text;
                projectSetting.ProjectName = txt_ProjectName.Text;
                projectSetting.Remark = mmt_Remark.Text;
                projectSetting.ProjectIncome = Convert.ToDouble(txt_ProjectIncome.Text);
                projectSetting.ProjectCost = Convert.ToDouble(txt_ProjectCost.Text);
                projectSetting.ProjectProfit = Convert.ToDouble(txt_ProjcetProfit.Text);
                projectSetting.ProjectBonusCommission = Convert.ToDouble(txt_ProjectBonusCommission.Text);
                projectSetting.ProjectEmployee = ProjectEmployeeSettings;
                if (det_PostingDate.Text != "")
                {
                    projectSetting.PostingDate = Convert.ToDateTime(det_PostingDate.EditValue);
                }
                else
                {
                    projectSetting.PostingDate = null;
                }
                string value = JsonConvert.SerializeObject(projectSetting);
                response = apiMethod.Put_Project(value);
                if (response == "200")
                {
                    if (!string.IsNullOrEmpty(AttachmentFilePath))
                    {
                        response = apiMethod.Post_ProjectAttachmentFile(projectSetting.ProjectNumber, AttachmentFilePath);
                        if (response == "200")
                        {
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            action.Description = response;
                            FlyoutDialog.Show(Form1, action);
                        }
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    action.Description = response;
                    FlyoutDialog.Show(Form1, action);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txt_ProjectNumber.Text) && !string.IsNullOrEmpty(txt_ProjectName.Text))
                {
                    ProjectSetting ProjectSetting1 = new ProjectSetting()
                    {
                        ProjectNumber = txt_ProjectNumber.Text,
                        ProjectName = txt_ProjectName.Text,
                        Remark = mmt_Remark.Text,
                        ProjectIncome = Convert.ToDouble(txt_ProjectIncome.Text),
                        ProjectCost = Convert.ToDouble(txt_ProjectCost.Text),
                        ProjectProfit = Convert.ToDouble(txt_ProjcetProfit.Text),
                        ProjectBonusCommission = Convert.ToDouble(txt_ProjectBonusCommission.Text),
                        ProjectEmployee = ProjectEmployeeSettings
                    };
                    if (det_PostingDate.Text != "")
                    {
                        ProjectSetting1.PostingDate = Convert.ToDateTime(det_PostingDate.EditValue);
                    }
                    else
                    {
                        ProjectSetting1.PostingDate = null;
                    }
                    string value = JsonConvert.SerializeObject(ProjectSetting1);
                    response = apiMethod.Post_Project(value);
                    if (response == "200")
                    {
                        if (!string.IsNullOrEmpty(AttachmentFilePath))
                        {
                            response = apiMethod.Post_ProjectAttachmentFile(txt_ProjectNumber.Text, AttachmentFilePath);
                            if (response == "200")
                            {
                                DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                action.Description = response;
                                FlyoutDialog.Show(Form1, action);
                            }
                        }
                        else
                        {
                            DialogResult = DialogResult.OK;
                        }
                    }
                    else
                    {
                        action.Description = response;
                        FlyoutDialog.Show(Form1, action);
                    }
                }
                else
                {
                    action.Description = "資料未填選完整";
                    FlyoutDialog.Show(Form1, action);
                }
            }
        }
        #endregion
    }
}