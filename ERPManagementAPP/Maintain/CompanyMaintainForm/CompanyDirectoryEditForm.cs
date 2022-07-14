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

namespace ERPManagementAPP.Maintain.CompanyMaintainForm
{
    public partial class CompanyDirectoryEditForm : BaseEditForm
    {
        /// <summary>
        /// 廠商編碼
        /// </summary>
        private string CompanyNumber = "";
        public CompanyDirectoryEditForm(string companyNumber, List<CompanyDirectorySetting> companyDirectorySettings, CompanyDirectorySetting companyDirectorySetting, APIMethod apiMethod, Form1 form1)
        {
            InitializeComponent();
            CompanyNumber = companyNumber;
            Form1 = form1;
            action.Commands.Add(FlyoutCommand.Yes);
            if (companyDirectorySetting != null && companyDirectorySetting.DirectoryCompany != null)//修改
            {
                action.Caption = "廠商通訊錄修改錯誤";
                txt_DirectoryNumber.Enabled = false;
                txt_DirectoryNumber.Text = companyDirectorySetting.DirectoryNumber;
                txt_Name.Text = companyDirectorySetting.DirectoryName;
                if (companyDirectorySetting.JobTitle != null)
                {
                    txt_JobTitle.Text = companyDirectorySetting.JobTitle;
                }
                if (companyDirectorySetting.Phone != null)
                {
                    txt_Phone.Text = companyDirectorySetting.Phone;
                }
                if (companyDirectorySetting.MobilePhone != null)
                {
                    txt_MobilePhone.Text = companyDirectorySetting.MobilePhone;
                }
                if (companyDirectorySetting.Email != null)
                {
                    txt_Email.Text = companyDirectorySetting.Email;
                }
                if (companyDirectorySetting.Remark != null)
                {
                    mmt_Remark.Text = companyDirectorySetting.Remark;
                }

            }
            else
            {
                action.Caption = "廠商通訊錄新增錯誤";
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
                CheckNumber(companyDirectorySettings, companyDirectorySetting, apiMethod);
            };
            #endregion
            #region 取消按鈕
            btn_Cancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
            };
            #endregion
        }
        private void CheckNumber(List<CompanyDirectorySetting> companyDirectorySettings, CompanyDirectorySetting companyDirectorySetting, APIMethod apiMethod)
        {
            string response = "";
            CompanyDirectorySetting companydirectorysetting = null;
            if (companyDirectorySettings != null)
            {
                companydirectorysetting = companyDirectorySettings.SingleOrDefault(g => g.DirectoryCompany == CompanyNumber && g.DirectoryNumber == txt_DirectoryNumber.Text);
            }
            if (companyDirectorySetting != null)
            {
                companyDirectorySetting.DirectoryCompany = CompanyNumber;
                companyDirectorySetting.DirectoryNumber = txt_DirectoryNumber.Text;
                companyDirectorySetting.DirectoryName = txt_Name.Text;
                companyDirectorySetting.JobTitle = txt_JobTitle.Text;
                companyDirectorySetting.Phone = txt_Phone.Text;
                companyDirectorySetting.MobilePhone = txt_MobilePhone.Text;
                companyDirectorySetting.Email = txt_Email.Text;
                companyDirectorySetting.Remark = mmt_Remark.Text;
                string value = JsonConvert.SerializeObject(companyDirectorySetting);
                response = apiMethod.Put_CompanyDirectory(value);
                if (response == "200")
                {
                    if (!string.IsNullOrEmpty(AttachmentFilePath))
                    {
                        Thread.Sleep(80);
                        response = apiMethod.Post_CompanyDirectoryAttachmentFile(companyDirectorySetting.DirectoryCompany, companyDirectorySetting.DirectoryNumber, AttachmentFilePath);
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
                if (companydirectorysetting == null)
                {
                    if (!string.IsNullOrEmpty(txt_DirectoryNumber.Text) && !string.IsNullOrEmpty(txt_Name.Text))
                    {
                        CompanyDirectorySetting setting = new CompanyDirectorySetting()
                        {
                            DirectoryCompany = CompanyNumber,
                            DirectoryNumber = txt_DirectoryNumber.Text,
                            DirectoryName = txt_Name.Text,
                            JobTitle = txt_JobTitle.Text,
                            Phone = txt_Phone.Text,
                            MobilePhone = txt_MobilePhone.Text,
                            Email = txt_Email.Text,
                            Remark = mmt_Remark.Text
                        };
                        string value = JsonConvert.SerializeObject(setting);
                        response = apiMethod.Post_CompanyDirectory(value);
                        if (response == "200")
                        {
                            if (!string.IsNullOrEmpty(AttachmentFilePath))
                            {
                                Thread.Sleep(80);
                                response = apiMethod.Post_CompanyDirectoryAttachmentFile(companyDirectorySetting.DirectoryCompany, companyDirectorySetting.DirectoryNumber, AttachmentFilePath);
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
                    action.Description = "廠商通訊錄編號已被使用";
                    FlyoutDialog.Show(Form1, action);
                }
            }
        }
    }
}