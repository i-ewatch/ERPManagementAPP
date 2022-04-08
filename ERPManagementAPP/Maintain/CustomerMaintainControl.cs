using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using ERPManagementAPP.Maintain.CustomerMaintainForm;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain
{
    public partial class CustomerMaintainControl : Field4MaintainControl
    {
        /// <summary>
        /// 聚焦客戶資料
        /// </summary>
        private CustomerSetting FocuseCustomerSetting { get; set; } = new CustomerSetting();
        /// <summary>
        /// 聚焦客戶通訊錄資料
        /// </summary>
        private CustomerDirectorySetting FocuseCustomerDirectorySetting { get; set; } = new CustomerDirectorySetting();
        /// <summary>
        /// 總客戶資料
        /// </summary>
        private List<CustomerSetting> CustomerSettings { get; set; } = new List<CustomerSetting>();
        /// <summary>
        /// 總客戶通訊錄資料
        /// </summary>
        private List<CustomerDirectorySetting> CustomerDirectorySettings { get; set; } = new List<CustomerDirectorySetting>();
        public CustomerMaintainControl(APIMethod APIMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            apiMethod = APIMethod;
            if (Form1.EmployeeSetting.Token > 0)
            {
                Refresh_Main_GridView();
            }
            action.Commands.Add(FlyoutCommand.Yes);
            #region 客戶資料表
            advBandedGridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 客戶資訊報表按鈕
            RepositoryItemButtonEdit Customeredit = new RepositoryItemButtonEdit();
            Customeredit.ButtonClick += (s, e) =>
            {
                FocuseMainGrid();
                if (e.Button.Kind == ButtonPredefines.Plus)
                {
                    if (FocuseCustomerSetting.FileName != null)
                    {
                        if (FocuseCustomerSetting.FileName != "")
                        {
                            byte[] File = apiMethod.Get_CustomerAttachmentFile(FocuseCustomerSetting.CustomerNumber, FocuseCustomerSetting.ContactName, FocuseCustomerSetting.FileName);
                            SaveFile(File, 0);
                        }
                    }
                }
            };
            Customeredit.Buttons[0].Kind = ButtonPredefines.Plus;
            Customeredit.Buttons[0].Caption = "下載";
            Customeredit.TextEditStyle = TextEditStyles.DisableTextEditor;
            CustomergridControl.RepositoryItems.Add(Customeredit);
            advBandedGridView1.Bands["OthergridBand"].Columns["colFileName"].ColumnEdit = Customeredit;
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
            #region 新增客戶
            btn_Customer_Add.Click += (s, e) =>
            {
                CustomerEditForm company = new CustomerEditForm(CustomerSettings, null, apiMethod, Form1);
                if (company.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #region 修改客戶
            btn_Customer_Edit.Click += (s, e) =>
            {
                CustomerEditForm company = new CustomerEditForm(CustomerSettings, FocuseCustomerSetting, apiMethod, Form1);
                if (company.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #region 雙擊修改客戶
            CustomergridControl.DoubleClick += (s, e) =>
            {
                FocuseMainGrid();
                CustomerEditForm company = new CustomerEditForm(CustomerSettings, FocuseCustomerSetting, apiMethod, Form1);
                if (company.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                }
            };
            #endregion
            #region 刪除客戶
            btn_Customer_Delete.Click += (s, e) =>
            {
                FocuseMainGrid();
                string data = JsonConvert.SerializeObject(FocuseCustomerSetting);
                string response = apiMethod.Delete_Customer(data);
                if (response == "200")
                {
                    Refresh_Main_GridView();
                    action.Caption = "刪除客戶成功";
                    action.Description = "";
                    FlyoutDialog.Show(Form1, action);
                }
                else
                {
                    action.Caption = "刪除客戶失敗";
                    action.Description = "";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 客戶資料刷新
            btn_Customer_Refresh.Click += (s, e) =>
            {
                Refresh_Main_GridView();
            };
            #endregion
            #endregion

            #region 客戶通訊錄資料表
            advBandedGridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 客戶資訊報表按鈕
            RepositoryItemButtonEdit CustomerDirectoryedit = new RepositoryItemButtonEdit();
            CustomerDirectoryedit.ButtonClick += (s, e) =>
            {
                FocuseSecondGrid();
                if (e.Button.Kind == ButtonPredefines.Plus)
                {
                    if (FocuseCustomerDirectorySetting.FileName != null)
                    {
                        if (FocuseCustomerDirectorySetting.FileName != "")
                        {
                            byte[] File = apiMethod.Get_CustomerDirectoryAttachmentFile(FocuseCustomerDirectorySetting.DirectoryCustomer, FocuseCustomerDirectorySetting.DirectoryName, FocuseCustomerDirectorySetting.FileName);
                            SaveFile(File, 1);
                        }
                    }
                }
            };
            CustomerDirectoryedit.Buttons[0].Kind = ButtonPredefines.Plus;
            CustomerDirectoryedit.Buttons[0].Caption = "下載";
            CustomerDirectoryedit.TextEditStyle = TextEditStyles.DisableTextEditor;
            CustomerDirectorygridControl.RepositoryItems.Add(CustomerDirectoryedit);
            advBandedGridView2.Bands["OthergridBand1"].Columns["colFileName1"].ColumnEdit = CustomerDirectoryedit;
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
            #region 新增客戶通訊錄
            btn_CustomerDirectory_Add.Click += (s, e) =>
            {

                CustomerDirectoryEditForm companyDirectory = new CustomerDirectoryEditForm(FocuseCustomerSetting.CustomerNumber, CustomerDirectorySettings, null, apiMethod, Form1);
                if (companyDirectory.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Second_GridView(FocuseCustomerSetting.CustomerNumber);
                }
            };
            #endregion
            #region 修改客戶通訊錄
            btn_CustomerDirectory_Edit.Click += (s, e) =>
            {
                CustomerDirectoryEditForm companyDirectory = new CustomerDirectoryEditForm(FocuseCustomerSetting.CustomerNumber, CustomerDirectorySettings, FocuseCustomerDirectorySetting, apiMethod, Form1);
                if (companyDirectory.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Second_GridView(FocuseCustomerSetting.CustomerNumber);
                }
            };
            #endregion
            #region 雙擊修改客戶通訊錄
            CustomerDirectorygridControl.DoubleClick += (s, e) =>
            {
                FocuseSecondGrid();
                CustomerDirectoryEditForm companyDirectory = new CustomerDirectoryEditForm(FocuseCustomerSetting.CustomerNumber, CustomerDirectorySettings, FocuseCustomerDirectorySetting, apiMethod, Form1);
                if (companyDirectory.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Second_GridView(FocuseCustomerSetting.CustomerNumber);
                }
            };
            #endregion
            #region 刪除客戶通訊錄
            btn_CustomerDirectory_Delete.Click += (s, e) =>
            {
                FocuseSecondGrid();
                string data = JsonConvert.SerializeObject(FocuseCustomerDirectorySetting);
                string response = apiMethod.Delete_CustomerDirectory(data);
                if (response == "200")
                {
                    Refresh_Second_GridView(FocuseCustomerSetting.CustomerNumber);
                    action.Caption = "刪除客戶通訊錄成功";
                    action.Description = "";
                    FlyoutDialog.Show(Form1, action);
                }
                else
                {
                    action.Caption = "刪除客戶通訊錄失敗";
                    action.Description = "";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 客戶通訊錄刷新
            btn_CustomerDirectory_Refresh.Click += (s, e) =>
            {
                Refresh_Second_GridView(FocuseCustomerSetting.CustomerNumber);
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
                FocuseCustomerSetting.CustomerNumber = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "CustomerNumber").ToString();
                FocuseCustomerSetting.CustomerName = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "CustomerName").ToString();
                FocuseCustomerSetting.UniformNumbers = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "UniformNumbers").ToString();
                FocuseCustomerSetting.Phone = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "Phone").ToString();
                FocuseCustomerSetting.Fax = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "Fax").ToString();
                FocuseCustomerSetting.RemittanceAccount = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "RemittanceAccount").ToString();
                FocuseCustomerSetting.ContactName = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "ContactName").ToString();
                FocuseCustomerSetting.ContactEmail = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "ContactEmail").ToString();
                FocuseCustomerSetting.ContactPhone = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "ContactPhone").ToString();
                FocuseCustomerSetting.CheckoutType = Convert.ToInt32(advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "CheckoutType").ToString());
                FocuseCustomerSetting.CheckoutType = Convert.ToInt32(advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "CheckoutType").ToString());
                if (advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "FileName") != null)
                {
                    FocuseCustomerSetting.FileName = advBandedGridView1.GetRowCellValue(advBandedGridView1.FocusedRowHandle, "FileName").ToString();
                }
                else
                {
                    FocuseCustomerSetting.FileName = "";
                }
                #region 刷新通訊錄功能
                Refresh_Second_GridView(FocuseCustomerSetting.CustomerNumber);
                if (advBandedGridView2.FocusedRowHandle > -1)
                {
                    if (FocuseCustomerDirectorySetting.DirectoryCustomer != advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "DirectoryCustomer").ToString())
                    {
                        FocuseCustomerDirectorySetting.DirectoryCustomer = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "DirectoryCustomer").ToString();
                        FocuseCustomerDirectorySetting.DirectoryNumber = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "DirectoryNumber").ToString();
                        FocuseCustomerDirectorySetting.DirectoryName = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "DirectoryName").ToString();
                        if (advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "JobTitle") != null)
                        {
                            FocuseCustomerDirectorySetting.JobTitle = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "JobTitle").ToString();
                        }
                        else
                        {
                            FocuseCustomerDirectorySetting.JobTitle = "";
                        }
                        if (advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "Phone") != null)
                        {
                            FocuseCustomerDirectorySetting.Phone = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "Phone").ToString();
                        }
                        else
                        {
                            FocuseCustomerDirectorySetting.Phone = "";
                        }
                        if (advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "MobilePhone") != null)
                        {
                            FocuseCustomerDirectorySetting.MobilePhone = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "MobilePhone").ToString();
                        }
                        else
                        {
                            FocuseCustomerDirectorySetting.MobilePhone = "";
                        }
                        if (advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "Email") != null)
                        {
                            FocuseCustomerDirectorySetting.Email = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "Email").ToString();
                        }
                        else
                        {
                            FocuseCustomerDirectorySetting.Email = "";
                        }
                        if (advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "Remark") != null)
                        {
                            FocuseCustomerDirectorySetting.Remark = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "Remark").ToString();
                        }
                        else
                        {
                            FocuseCustomerDirectorySetting.Remark = "";
                        }
                        if (advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "FileName") != null)
                        {
                            FocuseCustomerDirectorySetting.FileName = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "FileName").ToString();
                        }
                        else
                        {
                            FocuseCustomerDirectorySetting.FileName = "";
                        }
                    }
                }
                #endregion
            }
            else
            {
                FocuseCustomerSetting = new CustomerSetting();
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
                FocuseCustomerDirectorySetting.DirectoryCustomer = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "DirectoryCustomer").ToString();
                FocuseCustomerDirectorySetting.DirectoryNumber = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "DirectoryNumber").ToString();
                FocuseCustomerDirectorySetting.DirectoryName = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "DirectoryName").ToString();
                if (advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "JobTitle") != null)
                {
                    FocuseCustomerDirectorySetting.JobTitle = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "JobTitle").ToString();
                }
                else
                {
                    FocuseCustomerDirectorySetting.JobTitle = "";
                }
                if (advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "Phone") != null)
                {
                    FocuseCustomerDirectorySetting.Phone = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "Phone").ToString();
                }
                else
                {
                    FocuseCustomerDirectorySetting.Phone = "";
                }
                if (advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "MobilePhone") != null)
                {
                    FocuseCustomerDirectorySetting.MobilePhone = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "MobilePhone").ToString();
                }
                else
                {
                    FocuseCustomerDirectorySetting.MobilePhone = "";
                }
                if (advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "Email") != null)
                {
                    FocuseCustomerDirectorySetting.Email = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "Email").ToString();
                }
                else
                {
                    FocuseCustomerDirectorySetting.Email = "";
                }
                if (advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "Remark") != null)
                {
                    FocuseCustomerDirectorySetting.Remark = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "Remark").ToString();
                }
                else
                {
                    FocuseCustomerDirectorySetting.Remark = "";
                }
                if (advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "FileName") != null)
                {
                    FocuseCustomerDirectorySetting.FileName = advBandedGridView2.GetRowCellValue(advBandedGridView2.FocusedRowHandle, "FileName").ToString();
                }
                else
                {
                    FocuseCustomerDirectorySetting.FileName = "";
                }
            }
            else
            {
                FocuseCustomerDirectorySetting = new CustomerDirectorySetting();
            }
        }
        #endregion
        #region 下載檔案功能
        private void SaveFile(byte[] File, int Index)
        {
            if (File != null)
            {
                if (File.Length > 133)
                {
                    saveFileDialog = new SaveFileDialog();
                    if (Index == 0)
                    {
                        saveFileDialog.FileName = FocuseCustomerSetting.FileName;
                    }
                    else
                    {
                        saveFileDialog.FileName = FocuseCustomerDirectorySetting.FileName;
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
            CustomerSettings = apiMethod.Get_Customer();
            if (CustomerSettings != null)
            {
                CustomergridControl.DataSource = CustomerSettings;
                for (int i = 0; i < advBandedGridView1.Columns.Count; i++)
                {
                    advBandedGridView1.Columns[i].BestFit();
                }
            }
        }
        public override void Refresh_Second_GridView(string Number)
        {
            CustomerDirectorySettings = apiMethod.Get_DirectoryCustomer(Number);
            if (CustomerDirectorySettings != null)
            {
                CustomerDirectorygridControl.DataSource = CustomerDirectorySettings;
            }
        }
        public override void Refresh_Token()
        {
            if (Form1.EmployeeSetting.Token != 2)
            {
                btn_Customer_Delete.Visible = false;
                btn_CustomerDirectory_Delete.Visible = false;
            }
            else
            {
                btn_Customer_Delete.Visible = true;
                btn_CustomerDirectory_Delete.Visible = true;
            }
        }
    }
}
