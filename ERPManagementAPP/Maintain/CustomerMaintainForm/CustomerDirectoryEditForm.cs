using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain.CustomerMaintainForm
{
    public partial class CustomerDirectoryEditForm : BaseEditForm
    {
        /// <summary>
        /// 客戶編碼
        /// </summary>
        private string CustomerNumber = "";
        public CustomerDirectoryEditForm(string customerNumber, List<CustomerDirectorySetting> customerDirectorySettings, CustomerDirectorySetting customerDirectorySetting, APIMethod apiMethod, Form1 form1)
        {
            InitializeComponent();
            CustomerNumber = customerNumber;
            Form1 = form1;
            action.Commands.Add(FlyoutCommand.Yes);
            if (customerDirectorySetting != null && customerDirectorySetting.DirectoryCustomer != null)//修改
            {
                action.Caption = "客戶通訊錄修改錯誤";
                txt_DirectoryNumber.Enabled = false;
                txt_DirectoryNumber.Text = customerDirectorySetting.DirectoryNumber;
                txt_Name.Text = customerDirectorySetting.DirectoryName;
                if (customerDirectorySetting.JobTitle != null)
                {
                    txt_JobTitle.Text = customerDirectorySetting.JobTitle;
                }
                if (customerDirectorySetting.Phone != null)
                {
                    txt_Phone.Text = customerDirectorySetting.Phone;
                }
                if (customerDirectorySetting.MobilePhone != null)
                {
                    txt_MobilePhone.Text = customerDirectorySetting.MobilePhone;
                }
                if (customerDirectorySetting.Email != null)
                {
                    txt_Email.Text = customerDirectorySetting.Email;
                }
                if (customerDirectorySetting.Remark != null)
                {
                    mmt_Remark.Text = customerDirectorySetting.Remark;
                }

            }
            else
            {
                action.Caption = "客戶通訊錄新增錯誤";
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
                CheckNumber(customerDirectorySettings, customerDirectorySetting, apiMethod);
            };
            #endregion
            #region 取消按鈕
            btn_Cancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
            };
            #endregion
        }
        private void CheckNumber(List<CustomerDirectorySetting> customerDirectorySettings, CustomerDirectorySetting customerDirectorySetting, APIMethod apiMethod)
        {
            string response = "";
            CustomerDirectorySetting customerdirectorysetting = null;
            if (customerDirectorySettings != null)
            {
                customerdirectorysetting = customerDirectorySettings.SingleOrDefault(g => g.DirectoryCustomer == CustomerNumber && g.DirectoryNumber == txt_DirectoryNumber.Text);
            }
            if (customerDirectorySetting != null)
            {
                customerDirectorySetting.DirectoryCustomer = CustomerNumber;
                customerDirectorySetting.DirectoryNumber = txt_DirectoryNumber.Text;
                customerDirectorySetting.DirectoryName = txt_Name.Text;
                customerDirectorySetting.JobTitle = txt_JobTitle.Text;
                customerDirectorySetting.Phone = txt_Phone.Text;
                customerDirectorySetting.MobilePhone = txt_MobilePhone.Text;
                customerDirectorySetting.Email = txt_Email.Text;
                customerDirectorySetting.Remark = mmt_Remark.Text;
                string value = JsonConvert.SerializeObject(customerDirectorySetting);
                response = apiMethod.Put_CustomerDirectory(value);
                if (response == "200")
                {
                    if (!string.IsNullOrEmpty(AttachmentFilePath))
                    {
                        Thread.Sleep(80);
                        response = apiMethod.Post_CustomerDirectoryAttachmentFile(customerDirectorySetting.DirectoryCustomer, customerDirectorySetting.DirectoryNumber, AttachmentFilePath);
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
                if (customerdirectorysetting == null)
                {
                    if (!string.IsNullOrEmpty(txt_DirectoryNumber.Text) && !string.IsNullOrEmpty(txt_Name.Text))
                    {
                        CustomerDirectorySetting setting = new CustomerDirectorySetting()
                        {
                            DirectoryCustomer = CustomerNumber,
                            DirectoryNumber = txt_DirectoryNumber.Text,
                            DirectoryName = txt_Name.Text,
                            JobTitle = txt_JobTitle.Text,
                            Phone = txt_Phone.Text,
                            MobilePhone = txt_MobilePhone.Text,
                            Email = txt_Email.Text,
                            Remark = mmt_Remark.Text
                        };
                        string value = JsonConvert.SerializeObject(setting);
                        response = apiMethod.Post_CustomerDirectory(value);
                        if (response == "200")
                        {
                            if (!string.IsNullOrEmpty(AttachmentFilePath))
                            {
                                Thread.Sleep(80);
                                response = apiMethod.Post_CustomerDirectoryAttachmentFile(customerDirectorySetting.DirectoryCustomer, customerDirectorySetting.DirectoryNumber, AttachmentFilePath);
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
                    action.Description = "客戶通訊錄編號已被使用";
                    FlyoutDialog.Show(Form1, action);
                }
            }
        }
    }
}