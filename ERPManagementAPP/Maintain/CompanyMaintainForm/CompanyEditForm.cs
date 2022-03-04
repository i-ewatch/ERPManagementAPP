using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain.CompanyMaintainForm
{
    public partial class CompanyEditForm : BaseEditForm
    {
        public CompanyEditForm(List<CompanySetting> companySettings, CompanySetting companySetting, APIMethod apiMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            action.Commands.Add(FlyoutCommand.Yes);
            if (companySetting != null && companySetting.CompanyNumber != null)//修改
            {
                action.Caption = "廠商修改錯誤";
                txt_ComapnyNumber.Enabled = false;
                txt_ComapnyNumber.Text = companySetting.CompanyNumber;
                txt_CompanyName.Text = companySetting.CompanyName;
                if (companySetting.CompanyShortName != null)
                {
                    txt_CompanyShortName.Text = companySetting.CompanyShortName;
                }
                txt_UniformNumbers.Text = companySetting.UniformNumbers;
                txt_Phone.Text = companySetting.Phone;
                txt_Fax.Text = companySetting.Fax;
                txt_RemittanceAccount.Text = companySetting.RemittanceAccount;
                txt_ContactName.Text = companySetting.ContactName;
                txt_ContactEmail.Text = companySetting.ContactEmail;
                txt_ContactPhone.Text = companySetting.ContactPhone;
                if (companySetting.Remark != null)
                {
                    mmt_Remark.Text = companySetting.Remark;
                }
                cbt_CheckoutType.SelectedIndex = Convert.ToInt32(companySetting.CheckoutType);
            }
            else//新增
            {
                action.Caption = "廠商新增錯誤";
            }
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
            #region 儲存按鈕
            btn_Save.Click += (s, e) =>
            {
                CheckNumber(companySettings, companySetting, apiMethod);
            };
            #endregion
            #region 取消按鈕
            btn_Cancel.Click += (s, e) =>
              {
                  DialogResult = DialogResult.Cancel;
              };
            #endregion
        }
        /// <summary>
        /// 檢查資料問題
        /// </summary>
        /// <param name="companySettings"></param>
        /// <param name="companySetting"></param>
        /// <param name="apiMethod"></param>
        private void CheckNumber(List<CompanySetting> companySettings, CompanySetting companySetting, APIMethod apiMethod)
        {
            string response = "";
            CompanySetting companysetting = null;
            if (companySettings != null)
            {
                companysetting = companySettings.SingleOrDefault(g => g.CompanyNumber == txt_ComapnyNumber.Text);
            }
            if (companySetting != null && companySetting.CompanyNumber != null)
            {
                companySetting.CompanyNumber = txt_ComapnyNumber.Text;
                companySetting.CompanyName = txt_CompanyName.Text;
                companySetting.CompanyShortName = txt_CompanyShortName.Text;
                companySetting.UniformNumbers = txt_UniformNumbers.Text;
                companySetting.Phone = txt_Phone.Text;
                companySetting.Fax = txt_Fax.Text;
                companySetting.RemittanceAccount = txt_RemittanceAccount.Text;
                companySetting.ContactName = txt_ContactName.Text;
                companySetting.ContactEmail = txt_ContactEmail.Text;
                companySetting.ContactPhone = txt_ContactPhone.Text;
                companySetting.Remark = mmt_Remark.Text;
                companySetting.CheckoutType = cbt_CheckoutType.SelectedIndex;
                string value = JsonConvert.SerializeObject(companySetting);
                response = apiMethod.Put_Company(value);
                if (response == "200")
                {
                    if (!string.IsNullOrEmpty(AttachmentFilePath))
                    {
                        response = apiMethod.Post_CompanyAttachmentFile(companySetting.CompanyNumber, companySetting.CompanyName, AttachmentFilePath);
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
                if (companysetting == null)
                {
                    if (!string.IsNullOrEmpty(txt_ComapnyNumber.Text) && !string.IsNullOrEmpty(txt_CompanyName.Text) && !string.IsNullOrEmpty(txt_UniformNumbers.Text) && !string.IsNullOrEmpty(txt_RemittanceAccount.Text) && cbt_CheckoutType.SelectedIndex > -1)
                    {
                        CompanySetting setting = new CompanySetting()
                        {
                            CompanyNumber = txt_ComapnyNumber.Text,
                            CompanyName = txt_CompanyName.Text,
                            CompanyShortName = txt_CompanyShortName.Text,
                            UniformNumbers = txt_UniformNumbers.Text,
                            Phone = txt_Phone.Text,
                            Fax = txt_Fax.Text,
                            RemittanceAccount = txt_RemittanceAccount.Text,
                            ContactName = txt_ContactName.Text,
                            ContactEmail = txt_ContactEmail.Text,
                            ContactPhone = txt_ContactPhone.Text,
                            Remark = mmt_Remark.Text,
                            CheckoutType = cbt_CheckoutType.SelectedIndex
                        };
                        string value = JsonConvert.SerializeObject(setting);
                        response = apiMethod.Post_Company(value);
                        if (response == "200")
                        {
                            if (!string.IsNullOrEmpty(AttachmentFilePath))
                            {
                                response = apiMethod.Post_CompanyAttachmentFile(companySetting.CompanyNumber, companySetting.CompanyName, AttachmentFilePath);
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
                }
                else
                {
                    action.Description = "廠商編號已被使用";
                    FlyoutDialog.Show(Form1, action);
                }
            }
        }
    }
}