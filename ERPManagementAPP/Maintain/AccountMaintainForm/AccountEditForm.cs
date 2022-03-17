using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using ERPManagementAPP.Configuration;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain.AccountMaintainForm
{
    public partial class AccountEditForm : BaseEditForm
    {
        private AccountSetting AccountSetting { get; set; }
        public AccountEditForm(Form1 form1, APIMethod apiMethod)
        {
            InitializeComponent();
            Form1 = form1;
            AccountSetting = InitailMethod.AccountLoad();
            action.Commands.Add(FlyoutCommand.Yes);
            if (AccountSetting != null)
            {
                if (AccountSetting.RememberFlag)
                {
                    txt_Account.Text = AccountSetting.Account;
                    txt_PassWord.Text = AccountSetting.PassWord;
                    ckt_RememberFlag.CheckState = CheckState.Checked;
                }
            }
            btn_ShowPassWord.MouseDown += (s, e) =>
            {
                txt_PassWord.Properties.UseSystemPasswordChar = false;
            };
            btn_ShowPassWord.MouseUp += (s, e) =>
            {
                txt_PassWord.Properties.UseSystemPasswordChar = true;
            };
            btn_Login.Click += (s, e) =>
            {
                if (txt_Account.Text == "Administrator" && txt_PassWord.Text == "d001007")//系統帳號
                {
                    EmployeeSetting employeeSetting = new EmployeeSetting();
                    RememberFunction();
                    employeeSetting.EmployeeName = "Admin";
                    employeeSetting.AccountNo = txt_Account.Text;
                    employeeSetting.PassWord = txt_PassWord.Text;
                    employeeSetting.Token = 2;
                    Form1.EmployeeSetting = employeeSetting;
                    DialogResult = DialogResult.OK;
                }
                else//線上帳號
                {
                    List<EmployeeSetting> EmployeeSetting = apiMethod.Get_Login(txt_Account.Text, txt_PassWord.Text);
                    if (EmployeeSetting != null)
                    {

                        if (EmployeeSetting.Count > 0)
                        {
                            EmployeeSetting[0].Token++;
                            Form1.EmployeeSetting = EmployeeSetting[0];
                            RememberFunction();
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            action.Caption = "登入失敗";
                            action.Description = "請確認帳號密碼是否正確";
                            FlyoutDialog.Show(Form1, action);
                        }
                    }
                    else
                    {
                        action.Caption = "登入失敗";
                        action.Description = "無網路或伺服器未開啟";
                        FlyoutDialog.Show(Form1, action);
                    }
                }
            };
            btn_Cancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
            };
        }
        private void RememberFunction()
        {
            if (ckt_RememberFlag.CheckState == CheckState.Checked)
            {
                AccountSetting.Account = txt_Account.Text;
                AccountSetting.PassWord = txt_PassWord.Text;
                AccountSetting.RememberFlag = true;
                InitailMethod.AccountSave(AccountSetting);
            }
            else
            {
                AccountSetting.Account = txt_Account.Text;
                AccountSetting.PassWord = txt_PassWord.Text;
                AccountSetting.RememberFlag = false;
                InitailMethod.AccountSave(AccountSetting);
            }
        }
    }
}