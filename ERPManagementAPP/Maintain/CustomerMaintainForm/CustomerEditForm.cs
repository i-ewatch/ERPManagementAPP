using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain.CustomerMaintainForm
{
    public partial class CustomerEditForm : BaseEditForm
    {
        public CustomerEditForm(List<CustomerSetting> customerSettings, CustomerSetting customerSetting, APIMethod apiMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            action.Commands.Add(FlyoutCommand.Yes);
            if (customerSetting != null && customerSetting.CustomerNumber != null)//修改
            {
                action.Caption = "客戶修改錯誤";
                action.Description = "請確認資料是否輸入正確";
                txt_CustomerNumber.Enabled = false;
                txt_CustomerNumber.Text = customerSetting.CustomerNumber;
                txt_CustomerName.Text = customerSetting.CustomerName;
                txt_UniformNumbers.Text = customerSetting.UniformNumbers;
                txt_Phone.Text = customerSetting.Phone;
                txt_Fax.Text = customerSetting.Fax;
                txt_RemittanceAccount.Text = customerSetting.RemittanceAccount;
                txt_ContactName.Text = customerSetting.ContactName;
                txt_ContactEmail.Text = customerSetting.ContactEmail;
                txt_ContactPhone.Text = customerSetting.ContactPhone;
                cbt_CheckoutType.SelectedIndex = Convert.ToInt32(customerSetting.CheckoutType);
            }
            else//新增
            {
                action.Caption = "客戶新增錯誤";
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
                CheckNumber(customerSettings, customerSetting, apiMethod);
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
        /// <param name="customerSettings"></param>
        /// <param name="customerSetting"></param>
        /// <param name="apiMethod"></param>
        private void CheckNumber(List<CustomerSetting> customerSettings, CustomerSetting customerSetting, APIMethod apiMethod)
        {
            string response = "";
            CustomerSetting customersetting = null;
            if (customerSettings != null)
            {
                customersetting = customerSettings.SingleOrDefault(g => g.CustomerNumber == txt_CustomerNumber.Text);
            }
            if (customerSetting != null && customerSetting.CustomerNumber != null)
            {
                customerSetting.CustomerNumber = txt_CustomerNumber.Text;
                customerSetting.CustomerName = txt_CustomerName.Text;
                customerSetting.UniformNumbers = txt_UniformNumbers.Text;
                customerSetting.Phone = txt_Phone.Text;
                customerSetting.Fax = txt_Fax.Text;
                customerSetting.RemittanceAccount = txt_RemittanceAccount.Text;
                customerSetting.ContactName = txt_ContactName.Text;
                customerSetting.ContactEmail = txt_ContactEmail.Text;
                customerSetting.ContactPhone = txt_ContactPhone.Text;
                customerSetting.CheckoutType = cbt_CheckoutType.SelectedIndex;
                string value = JsonConvert.SerializeObject(customerSetting);
                response = apiMethod.Put_Customer(value);
                if (response == "200")
                {
                    if (!string.IsNullOrEmpty(AttachmentFilePath))
                    {
                        Thread.Sleep(80);
                        response = apiMethod.Post_CustomerAttachmentFile(customerSetting.CustomerNumber, customerSetting.CustomerName, AttachmentFilePath);
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
                if (customersetting == null)
                {
                    if (!string.IsNullOrEmpty(txt_CustomerNumber.Text) && !string.IsNullOrEmpty(txt_CustomerName.Text) && !string.IsNullOrEmpty(txt_UniformNumbers.Text) && !string.IsNullOrEmpty(txt_RemittanceAccount.Text) && cbt_CheckoutType.SelectedIndex > -1)
                    {
                        CustomerSetting setting = new CustomerSetting()
                        {
                            CustomerNumber = txt_CustomerNumber.Text,
                            CustomerName = txt_CustomerName.Text,
                            UniformNumbers = txt_UniformNumbers.Text,
                            Phone = txt_Phone.Text,
                            Fax = txt_Fax.Text,
                            RemittanceAccount = txt_RemittanceAccount.Text,
                            ContactName = txt_ContactName.Text,
                            ContactEmail = txt_ContactEmail.Text,
                            ContactPhone = txt_ContactPhone.Text,
                            CheckoutType = cbt_CheckoutType.SelectedIndex
                        };
                        string value = JsonConvert.SerializeObject(setting);
                        response = apiMethod.Post_Customer(value);
                        if (response == "200")
                        {
                            if (!string.IsNullOrEmpty(AttachmentFilePath))
                            {
                                Thread.Sleep(80);
                                response = apiMethod.Post_CustomerAttachmentFile(setting.CustomerNumber, setting.CustomerName, AttachmentFilePath);
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
                else
                {
                    action.Description = "客戶編號已被使用";
                    FlyoutDialog.Show(Form1, action);
                }
            }
        }
    }
}