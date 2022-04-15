using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain.EmployeeMaintainForm
{
    public partial class EmployeeEditForm : BaseEditForm
    {
        public EmployeeEditForm(List<EmployeeSetting> employeeSettings, EmployeeSetting employeeSetting, APIMethod apiMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            action.Commands.Add(FlyoutCommand.Yes);
            if (employeeSetting != null && employeeSetting.EmployeeNumber != null)//修改
            {
                if (Form1.EmployeeSetting.Token == 2)
                {
                    cbt_Token.Enabled = true;
                }
                else
                {
                    cbt_Token.Enabled = false;
                }
                action.Caption = "員工修改錯誤";
                txt_EmployeeNumber.Enabled = false;
                txt_EmployeeNumber.Text = employeeSetting.EmployeeNumber;
                txt_Name.Text = employeeSetting.EmployeeName;
                txt_Phone.Text = employeeSetting.Phone;
                mmt_Address.Text = employeeSetting.Address;
                cbt_Token.SelectedIndex = Convert.ToInt32(employeeSetting.Token);
                txt_Account.Text = employeeSetting.AccountNo;
                txt_PassWord.Text = employeeSetting.PassWord;
            }
            else//新增
            {
                action.Caption = "員工新增錯誤";
            }
            #region 儲存按鈕
            btn_Save.Click += (s, e) =>
            {
                CheckNumber(employeeSettings, employeeSetting, apiMethod);
            };
            #endregion
            #region 取消按鈕
            btn_Cancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
            };
            #endregion
        }
        private void CheckNumber(List<EmployeeSetting> employeeSettings, EmployeeSetting employeeSetting, APIMethod apiMethod)
        {
            string response = "";
            EmployeeSetting employeesetting = null;
            if (employeeSettings != null)
            {
                employeesetting = employeeSettings.SingleOrDefault(g => g.EmployeeNumber == txt_EmployeeNumber.Text);
            }
            if (employeeSetting != null && employeeSetting.EmployeeNumber != null)
            {
                employeeSetting.EmployeeNumber = txt_EmployeeNumber.Text;
                employeeSetting.EmployeeName = txt_Name.Text;
                employeeSetting.Phone = txt_Phone.Text;
                employeeSetting.Address = mmt_Address.Text;
                employeeSetting.Token = cbt_Token.SelectedIndex;
                employeeSetting.AccountNo = txt_Account.Text;
                employeeSetting.PassWord = txt_PassWord.Text;
                string value = JsonConvert.SerializeObject(employeeSetting);
                response = apiMethod.Put_Employee(value);
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
                if (employeesetting == null)
                {
                    if (!string.IsNullOrEmpty(txt_EmployeeNumber.Text) && !string.IsNullOrEmpty(txt_Name.Text) && cbt_Token.SelectedIndex > -1)
                    {
                        EmployeeSetting setting = new EmployeeSetting()
                        {
                            EmployeeNumber = txt_EmployeeNumber.Text,
                            EmployeeName = txt_Name.Text,
                            Phone = txt_Phone.Text,
                            Address = mmt_Address.Text,
                            Token = cbt_Token.SelectedIndex,
                            AccountNo = txt_Account.Text,
                            PassWord = txt_PassWord.Text
                        };
                        string value = JsonConvert.SerializeObject(setting);
                        response = apiMethod.Post_Employee(value);
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
                }
                else
                {
                    action.Description = "員工編號已被使用";
                    FlyoutDialog.Show(Form1, action);
                }
            }
        }
    }
}