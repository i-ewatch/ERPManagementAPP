using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraSplashScreen;
using ERPManagementAPP.Maintain.CompanyMaintainForm;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain
{
    public partial class CompanyMaintainControl : Field4MaintainControl
    {
        /// <summary>
        /// 聚焦廠商資料
        /// </summary>
        private CompanySetting FocuseCompanySetting { get; set; } = new CompanySetting();
        /// <summary>
        /// 聚焦廠商通訊錄資料
        /// </summary>
        private CompanyDirectorySetting FocuseCompanyDirectorySetting { get; set; } = new CompanyDirectorySetting();
        /// <summary>
        /// 總廠商資料
        /// </summary>
        private List<CompanySetting> CompanySettings { get; set; } = new List<CompanySetting>();
        /// <summary>
        /// 總廠商資料
        /// </summary>
        private List<CompanyDirectorySetting> CompanyDirectorySettings { get; set; } = new List<CompanyDirectorySetting>();
        public CompanyMaintainControl(APIMethod APIMethod, Form1 form1)
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
            #region 廠商資料表
            advBandedGridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 廠商資訊報表按鈕
            RepositoryItemButtonEdit Companyedit = new RepositoryItemButtonEdit();
            Companyedit.ButtonClick += (s, e) =>
            {
                FocuseMainGrid();
                if (e.Button.Kind == ButtonPredefines.Plus)
                {
                    if (FocuseCompanySetting.FileName != null)
                    {
                        if (FocuseCompanySetting.FileName != "")
                        {
                            byte[] File = apiMethod.Get_CompanyAttachmentFile(FocuseCompanySetting.CompanyNumber, FocuseCompanySetting.CompanyName, FocuseCompanySetting.FileName);
                            SaveFile(File, 0);
                        }
                    }
                }
            };
            Companyedit.Buttons[0].Kind = ButtonPredefines.Plus;
            Companyedit.Buttons[0].Caption = "下載";
            Companyedit.TextEditStyle = TextEditStyles.DisableTextEditor;
            CompanygridControl.RepositoryItems.Add(Companyedit);
            advBandedGridView1.Bands["OthergridBand"].Columns["colFileName"].ColumnEdit = Companyedit;
            advBandedGridView1.Bands["OthergridBand"].Columns["colFileName"].ShowButtonMode = ShowButtonModeEnum.ShowAlways;
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
            #region 報表修改字串功能
            advBandedGridView1.CustomDrawCell += (s, e) =>
            {
                if (e.Column.FieldName == "CheckoutType")
                {
                    e.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                    string Index = e.CellValue.ToString();
                    switch (Index)
                    {
                        case "0":
                            {
                                e.DisplayText = "現金";
                            }
                            break;
                        case "1":
                            {
                                e.DisplayText = "30天";
                            }
                            break;
                        case "2":
                            {
                                e.DisplayText = "60天";
                            }
                            break;
                        case "3":
                            {
                                e.DisplayText = "其他";
                            }
                            break;
                    }
                }
            };
            #endregion
            #region 新增廠商
            btn_Company_Add.Click += (s, e) =>
            {
                CompanyEditForm company = new CompanyEditForm(CompanySettings, null, apiMethod, Form1);
                if (company.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #region 修改廠商
            btn_Company_Edit.Click += (s, e) =>
            {
                CompanyEditForm company = new CompanyEditForm(CompanySettings, FocuseCompanySetting, apiMethod, Form1);
                if (company.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #region 雙擊修改廠商
            CompanygridControl.DoubleClick += (s, e) =>
            {
                FocuseMainGrid();
                CompanyEditForm company = new CompanyEditForm(CompanySettings, FocuseCompanySetting, apiMethod, Form1);
                if (company.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #region 刪除廠商
            btn_Company_Delete.Click += (s, e) =>
            {
                FocuseMainGrid();
                Delectaction.Description = $"刪除名稱 : {FocuseCompanySetting.CompanyName}";
                if (FlyoutDialog.Show(Form1, Delectaction) == DialogResult.Yes)
                {
                    string data = JsonConvert.SerializeObject(FocuseCompanySetting);
                    string response = apiMethod.Delete_Company(data);
                    if (response == "200")
                    {
                        Refresh_Main_GridView();
                        action.Caption = "刪除廠商成功";
                        action.Description = "";
                        FlyoutDialog.Show(Form1, action);
                    }
                    else
                    {
                        action.Caption = "刪除廠商失敗";
                        action.Description = "";
                        FlyoutDialog.Show(Form1, action);
                    }
                }
            };
            #endregion
            #region 廠商資料刷新
            btn_Company_Refresh.Click += (s, e) =>
            {
                Refresh_Main_GridView();
            };
            #endregion
            #endregion

            #region 廠商通訊錄資料表
            advBandedGridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 廠商資訊報表按鈕
            RepositoryItemButtonEdit CompanyDirectoryedit = new RepositoryItemButtonEdit();
            CompanyDirectoryedit.ButtonClick += (s, e) =>
            {
                FocuseSecondGrid();
                if (e.Button.Kind == ButtonPredefines.Plus)
                {
                    if (FocuseCompanyDirectorySetting.FileName != null)
                    {
                        if (FocuseCompanyDirectorySetting.FileName != "")
                        {
                            byte[] File = apiMethod.Get_CompanyDirectoryAttachmentFile(FocuseCompanyDirectorySetting.DirectoryCompany, FocuseCompanyDirectorySetting.DirectoryName, FocuseCompanyDirectorySetting.FileName);
                            SaveFile(File, 1);
                        }
                    }
                }
            };
            CompanyDirectoryedit.Buttons[0].Kind = ButtonPredefines.Plus;
            CompanyDirectoryedit.Buttons[0].Caption = "下載";
            CompanyDirectoryedit.TextEditStyle = TextEditStyles.DisableTextEditor;
            CompanyDirectorygridControl.RepositoryItems.Add(CompanyDirectoryedit);
            advBandedGridView2.Bands["OthergridBand1"].Columns["colFileName1"].ColumnEdit = CompanyDirectoryedit;
            advBandedGridView2.Bands["OthergridBand1"].Columns["colFileName1"].ShowButtonMode = ShowButtonModeEnum.ShowAlways;
            #endregion
            #region 報表聚焦功能
            advBandedGridView2.FocusedRowChanged += (s, ex) =>
            {
                FocuseSecondGrid();
            };
            #endregion
            #region 關鍵字聚焦
            advBandedGridView2.ColumnFilterChanged += (s, e) =>
             {
                 FocuseSecondGrid();
             };
            #endregion
            #region 新增廠商通訊錄
            btn_CompanyDirectory_Add.Click += (s, e) =>
              {

                  CompanyDirectoryEditForm companyDirectory = new CompanyDirectoryEditForm(FocuseCompanySetting.CompanyNumber, CompanyDirectorySettings, null, apiMethod, Form1);
                  if (companyDirectory.ShowDialog() == DialogResult.OK)
                  {
                      Refresh_Second_GridView(FocuseCompanySetting.CompanyNumber);
                  }
              };
            #endregion
            #region 修改廠商通訊錄
            btn_CompanyDirectory_Edit.Click += (s, e) =>
              {
                  CompanyDirectoryEditForm companyDirectory = new CompanyDirectoryEditForm(FocuseCompanySetting.CompanyNumber, CompanyDirectorySettings, FocuseCompanyDirectorySetting, apiMethod, Form1);
                  if (companyDirectory.ShowDialog() == DialogResult.OK)
                  {
                      Refresh_Second_GridView(FocuseCompanySetting.CompanyNumber);
                  }
              };
            #endregion
            #region 雙擊修改廠商通訊錄
            CompanyDirectorygridControl.DoubleClick += (s, e) =>
              {
                  FocuseSecondGrid();
                  CompanyDirectoryEditForm companyDirectory = new CompanyDirectoryEditForm(FocuseCompanySetting.CompanyNumber, CompanyDirectorySettings, FocuseCompanyDirectorySetting, apiMethod, Form1);
                  if (companyDirectory.ShowDialog() == DialogResult.OK)
                  {
                      Refresh_Second_GridView(FocuseCompanySetting.CompanyNumber);
                  }
              };
            #endregion
            #region 刪除廠商通訊錄
            btn_CompanyDirectory_Delete.Click += (s, e) =>
              {
                  FocuseSecondGrid();
                  Delectaction.Description = $"刪除名稱 : {FocuseCompanyDirectorySetting.DirectoryName}";
                  if (FlyoutDialog.Show(Form1, Delectaction) == DialogResult.Yes)
                  {
                      string data = JsonConvert.SerializeObject(FocuseCompanyDirectorySetting);
                      string response = apiMethod.Delete_CompanyDirectory(data);
                      if (response == "200")
                      {
                          Refresh_Second_GridView(FocuseCompanySetting.CompanyNumber);
                          action.Caption = "刪除廠商通訊錄成功";
                          action.Description = "";
                          FlyoutDialog.Show(Form1, action);
                      }
                      else
                      {
                          action.Caption = "刪除廠商通訊錄失敗";
                          action.Description = "";
                          FlyoutDialog.Show(Form1, action);
                      }
                  }
              };
            #endregion
            #region 廠商通訊錄刷新
            btn_CompanyDirectory_Refresh.Click += (s, e) =>
            {
                handle = SplashScreenManager.ShowOverlayForm(FindForm());
                Refresh_Second_GridView(FocuseCompanySetting.CompanyNumber);
                CloseProgressPanel(handle);
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
            if (advBandedGridView1.FocusedRowHandle > -1 && advBandedGridView1.DataRowCount > 0)
            {
                FocuseCompanySetting.CompanyNumber = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "CompanyNumber").ToString();
                FocuseCompanySetting.CompanyName = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "CompanyName").ToString();
                if (advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "CompanyShortName") != null)
                {
                    FocuseCompanySetting.CompanyShortName = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "CompanyShortName").ToString();
                }
                else
                {
                    FocuseCompanySetting.CompanyShortName = "";
                }
                FocuseCompanySetting.UniformNumbers = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "UniformNumbers").ToString();
                FocuseCompanySetting.Phone = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "Phone").ToString();
                FocuseCompanySetting.Fax = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "Fax").ToString();
                FocuseCompanySetting.RemittanceAccount = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "RemittanceAccount").ToString();
                FocuseCompanySetting.ContactName = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "ContactName").ToString();
                FocuseCompanySetting.ContactEmail = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "ContactEmail").ToString();
                FocuseCompanySetting.ContactPhone = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "ContactPhone").ToString();
                FocuseCompanySetting.CheckoutType = Convert.ToInt32(advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "CheckoutType").ToString());
                if (advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "Remark") != null)
                {
                    FocuseCompanySetting.Remark = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "Remark").ToString();
                }
                else
                {
                    FocuseCompanySetting.Remark = "";
                }
                if (advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "FileName") != null)
                {
                    FocuseCompanySetting.FileName = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "FileName").ToString();
                }
                else
                {
                    FocuseCompanySetting.FileName = "";
                }
                #region 刷新通訊錄功能
                Refresh_Second_GridView(FocuseCompanySetting.CompanyNumber);
                if (advBandedGridView2.FocusedRowHandle > -1)
                {
                    if (FocuseCompanyDirectorySetting.DirectoryCompany != advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "DirectoryCompany").ToString())
                    {
                        FocuseCompanyDirectorySetting.DirectoryCompany = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "DirectoryCompany").ToString();
                        FocuseCompanyDirectorySetting.DirectoryNumber = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "DirectoryNumber").ToString();
                        FocuseCompanyDirectorySetting.DirectoryName = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "DirectoryName").ToString();
                        if (advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "JobTitle") != null)
                        {
                            FocuseCompanyDirectorySetting.JobTitle = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "JobTitle").ToString();
                        }
                        else
                        {
                            FocuseCompanyDirectorySetting.JobTitle = "";
                        }
                        if (advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "Phone") != null)
                        {
                            FocuseCompanyDirectorySetting.Phone = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "Phone").ToString();
                        }
                        else
                        {
                            FocuseCompanyDirectorySetting.Phone = "";
                        }
                        if (advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "MobilePhone") != null)
                        {
                            FocuseCompanyDirectorySetting.MobilePhone = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "MobilePhone").ToString();
                        }
                        else
                        {
                            FocuseCompanyDirectorySetting.MobilePhone = "";
                        }
                        if (advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "Email") != null)
                        {
                            FocuseCompanyDirectorySetting.Email = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "Email").ToString();
                        }
                        else
                        {
                            FocuseCompanyDirectorySetting.Email = "";
                        }
                        if (advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "Remark") != null)
                        {
                            FocuseCompanyDirectorySetting.Remark = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "Remark").ToString();
                        }
                        else
                        {
                            FocuseCompanyDirectorySetting.Remark = "";
                        }
                        if (advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "FileName") != null)
                        {
                            FocuseCompanyDirectorySetting.FileName = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "FileName").ToString();
                        }
                        else
                        {
                            FocuseCompanyDirectorySetting.FileName = "";
                        }
                    }
                }
                #endregion
            }
            else
            {
                FocuseCompanySetting = new CompanySetting();
            }
        }
        #endregion
        #region 聚焦次資料表功能
        /// <summary>
        /// 聚焦次資料表功能
        /// </summary>
        private void FocuseSecondGrid()
        {
            if (advBandedGridView2.FocusedRowHandle > -1 && advBandedGridView2.DataRowCount > 0)
            {
                FocuseCompanyDirectorySetting.DirectoryCompany = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "DirectoryCompany").ToString();
                FocuseCompanyDirectorySetting.DirectoryNumber = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "DirectoryNumber").ToString();
                FocuseCompanyDirectorySetting.DirectoryName = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "DirectoryName").ToString();
                if (advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "JobTitle") != null)
                {
                    FocuseCompanyDirectorySetting.JobTitle = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "JobTitle").ToString();
                }
                else
                {
                    FocuseCompanyDirectorySetting.JobTitle = "";
                }
                if (advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "Phone") != null)
                {
                    FocuseCompanyDirectorySetting.Phone = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "Phone").ToString();
                }
                else
                {
                    FocuseCompanyDirectorySetting.Phone = "";
                }
                if (advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "MobilePhone") != null)
                {
                    FocuseCompanyDirectorySetting.MobilePhone = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "MobilePhone").ToString();
                }
                else
                {
                    FocuseCompanyDirectorySetting.MobilePhone = "";
                }
                if (advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "Email") != null)
                {
                    FocuseCompanyDirectorySetting.Email = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "Email").ToString();
                }
                else
                {
                    FocuseCompanyDirectorySetting.Email = "";
                }
                if (advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "Remark") != null)
                {
                    FocuseCompanyDirectorySetting.Remark = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "Remark").ToString();
                }
                else
                {
                    FocuseCompanyDirectorySetting.Remark = "";
                }
                if (advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "FileName") != null)
                {
                    FocuseCompanyDirectorySetting.FileName = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "FileName").ToString();
                }
                else
                {
                    FocuseCompanyDirectorySetting.FileName = "";
                }
            }
            else
            {
                FocuseCompanyDirectorySetting = new CompanyDirectorySetting();
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
                        saveFileDialog.FileName = FocuseCompanySetting.FileName;
                    }
                    else
                    {
                        saveFileDialog.FileName = FocuseCompanyDirectorySetting.FileName;
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
                CompanySettings = apiMethod.Get_Company();
                if (CompanySettings != null)
                {
                    CompanygridControl.DataSource = CompanySettings;
                    advBandedGridView1.HideFindPanel();
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
            for (int i = 0; i < length; i++)
            {
                CompanyDirectorySettings = apiMethod.Get_DirectoryCompany(Number);
                advBandedGridView2.HideFindPanel();
                if (CompanyDirectorySettings != null)
                {
                    CompanyDirectorygridControl.DataSource = CompanyDirectorySettings;
                    break;
                }
            }
        }
        public override void Refresh_Token()
        {
            if (Form1.EmployeeSetting.Token != 2)
            {
                btn_Company_Delete.Visible = false;
                btn_CompanyDirectory_Delete.Visible = false;
            }
            else
            {
                btn_Company_Delete.Visible = true;
                btn_CompanyDirectory_Delete.Visible = true;
            }
        }
    }
}
