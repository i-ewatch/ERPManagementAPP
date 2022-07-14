using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraSplashScreen;
using ERPManagementAPP.Maintain.EmployeeMaintainForm;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain
{
    public partial class EmployeeMaintainControl : Field4MaintainControl
    {
        /// <summary>
        /// 聚焦員工資料
        /// </summary>
        private EmployeeSetting FocuseEmployeeSetting { get; set; } = new EmployeeSetting();
        /// <summary>
        /// 總員工資料
        /// </summary>
        private List<EmployeeSetting> EmployeeSettings { get; set; } = new List<EmployeeSetting>();
        public EmployeeMaintainControl(APIMethod APIMethod, Form1 form1)
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
            #region 員工資料表
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 報表聚焦功能
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
                if (e.Column.FieldName == "Token")
                {
                    e.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                    string Index = e.CellValue.ToString();
                    switch (Index)
                    {
                        case "0":
                            {
                                e.DisplayText = "一般使用者";
                            }
                            break;
                        case "1":
                            {
                                e.DisplayText = "管理員";
                            }
                            break;
                        case "2":
                            {
                                e.DisplayText = "合作夥伴";
                            }
                            break;
                    }
                }
            };
            #endregion
            #region 新增員工
            btn_Employee_Add.Click += (s, e) =>
            {
                if (Form1.EmployeeSetting.Token == 2)
                {
                    EmployeeEditForm company = new EmployeeEditForm(EmployeeSettings, null, apiMethod, Form1);
                    if (company.ShowDialog() == DialogResult.OK)
                    {
                        Refresh_Main_GridView();
                    }
                }
                else
                {
                    action.Caption = "權限不足";
                    action.Description = "請管理員做新增";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 修改員工
            btn_Employee_Edit.Click += (s, e) =>
                {
                    if (Form1.EmployeeSetting.Token == 2)
                    {
                        EmployeeEditForm company = new EmployeeEditForm(EmployeeSettings, FocuseEmployeeSetting, apiMethod, Form1);
                        if (company.ShowDialog() == DialogResult.OK)
                        {
                            Refresh_Main_GridView();
                        }
                    }
                    else if (Form1.EmployeeSetting.Token == 1)
                    {
                        if (FocuseEmployeeSetting.AccountNo == Form1.EmployeeSetting.AccountNo)
                        {
                            EmployeeEditForm company = new EmployeeEditForm(EmployeeSettings, FocuseEmployeeSetting, apiMethod, Form1);
                            if (company.ShowDialog() == DialogResult.OK)
                            {
                                Refresh_Main_GridView();
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
            #region 雙擊修改員工
            EmployeegridControl.DoubleClick += (s, e) =>
            {
                if (Form1.EmployeeSetting.Token == 2)
                {
                    FocuseMainGrid();
                    EmployeeEditForm company = new EmployeeEditForm(EmployeeSettings, FocuseEmployeeSetting, apiMethod, Form1);
                    if (company.ShowDialog() == DialogResult.OK)
                    {
                        Refresh_Main_GridView();
                    }
                }
                else if (Form1.EmployeeSetting.Token == 1)
                {
                    FocuseMainGrid();
                    if (FocuseEmployeeSetting.AccountNo == Form1.EmployeeSetting.AccountNo)
                    {
                        EmployeeEditForm company = new EmployeeEditForm(EmployeeSettings, FocuseEmployeeSetting, apiMethod, Form1);
                        if (company.ShowDialog() == DialogResult.OK)
                        {
                            Refresh_Main_GridView();
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
            #region 刪除員工
            btn_Employee_Delete.Click += (s, e) =>
             {
                 //if (Form1.EmployeeSetting.Token == 2)
                 //{
                 FocuseMainGrid();
                 Delectaction.Description = $"刪除名稱 : {FocuseEmployeeSetting.EmployeeName}";
                 if (FlyoutDialog.Show(Form1, Delectaction) == DialogResult.Yes)
                 {
                     string data = JsonConvert.SerializeObject(FocuseEmployeeSetting);
                     string response = apiMethod.Delete_Employee(data);
                     if (response == "200")
                     {
                         Refresh_Main_GridView();
                         action.Caption = "刪除員工成功";
                         action.Description = "";
                         FlyoutDialog.Show(Form1, action);
                     }
                     else
                     {
                         action.Caption = "刪除員工失敗";
                         action.Description = "";
                         FlyoutDialog.Show(Form1, action);
                     }
                 }
                 //}
                 //else
                 //{
                 //    action.Caption = "權限不足";
                 //    action.Description = "請管理員做刪除";
                 //    FlyoutDialog.Show(Form1, action);
                 //}
             };
            #endregion
            #region 員工資料刷新
            btn_Employee_Refresh.Click += (s, e) =>
            {
                Refresh_Main_GridView();
            };
            #endregion
            #endregion
        }
        #region 聚焦次資料表功能
        /// <summary>
        /// 聚焦次資料表功能
        /// </summary>
        private void FocuseMainGrid()
        {
            if (gridView1.FocusedRowHandle > -1 && gridView1.DataRowCount > 0)
            {
                FocuseEmployeeSetting.EmployeeNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "EmployeeNumber").ToString();
                FocuseEmployeeSetting.EmployeeName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "EmployeeName").ToString();
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Phone") != null)
                {
                    FocuseEmployeeSetting.Phone = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Phone").ToString();
                }
                else
                {
                    FocuseEmployeeSetting.Phone = "";
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Address") != null)
                {
                    FocuseEmployeeSetting.Address = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Address").ToString();
                }
                else
                {
                    FocuseEmployeeSetting.Address = "";
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "AccountNo") != null)
                {
                    FocuseEmployeeSetting.AccountNo = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "AccountNo").ToString();
                }
                else
                {
                    FocuseEmployeeSetting.AccountNo = "";
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PassWord") != null)
                {
                    FocuseEmployeeSetting.PassWord = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PassWord").ToString();
                }
                else
                {
                    FocuseEmployeeSetting.PassWord = "";
                }
                FocuseEmployeeSetting.Token = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Token").ToString());
            }
            else
            {
                FocuseEmployeeSetting = new EmployeeSetting();
            }
        }
        #endregion
        public override void Refresh_Main_GridView()
        {
            handle = SplashScreenManager.ShowOverlayForm(FindForm());
            for (int i = 0; i < length; i++)
            {
                EmployeeSettings = apiMethod.Get_Employee();
                gridView1.HideFindPanel();
                if (EmployeeSettings != null)
                {
                    EmployeegridControl.DataSource = EmployeeSettings;
                    break;
                }
            }
            CloseProgressPanel(handle);
        }
        public override void Refresh_Token()
        {
            if (Form1.EmployeeSetting.Token != 2)
            {
                btn_Employee_Add.Visible = false;
                btn_Employee_Delete.Visible = false;
            }
            else
            {
                btn_Employee_Add.Visible = true;
                btn_Employee_Delete.Visible = true;
            }
        }
    }
}
