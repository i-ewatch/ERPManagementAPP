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

namespace ERPManagementAPP.Maintain.PaymentMaintainForm
{
    public partial class PaymentEditForm : BaseEditForm
    {
        private List<EmployeeSetting> EmployeeSettings { get; set; }
        private List<PaymentItemSetting> PaymentItemSettings { get; set; }
        private PaymentSetting PaymentSetting { get; set; }
        public PaymentEditForm(List<PaymentSetting> paymentSettings, PaymentSetting paymentSetting, List<EmployeeSetting> employeeSettings, List<PaymentItemSetting> paymentItemSettings, APIMethod apiMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            PaymentSetting = paymentSetting;
            EmployeeSettings = employeeSettings;
            PaymentItemSettings = paymentItemSettings;
            action.Commands.Add(FlyoutCommand.Yes);
            Create_PaymentItemNo_cbt();
            Create_EmployeeNumber_cbt();
            if (paymentSetting != null && paymentSetting.PaymentNumber != null)//修改
            {
                action.Caption = "代墊代付修改錯誤";
                txt_PaymentNumber.Enabled = false;
                txt_PaymentNumber.Text = paymentSetting.PaymentNumber;
                det_PaymentDate.Enabled = false;
                det_PaymentDate.EditValue = paymentSetting.PaymentDate;
                txt_PaymentInvoiceNo.Text = paymentSetting.PaymentInvoiceNo;
                Show_PaymentItemNo_Index();
                Show_EmployeeNumber_Index();
                txt_PaymentAmoumt.EditValue = paymentSetting.PaymentAmount;
                cbt_PaymentMethod.SelectedIndex = paymentSetting.PaymentMethod;
                mmt_PaymentUse.Text = paymentSetting.PaymentUse;
                mmt_Remark.Text = paymentSetting.Remark;
                det_TransferDate.EditValue = paymentSetting.TransferDate;
            }
            else//新增
            {
                action.Caption = "代墊代付新增錯誤";
                det_PaymentDate.EditValue = DateTime.Now;
                if (Form1.EmployeeSetting != null)
                {
                    Show_EmployeeNumber_Index(Form1.EmployeeSetting.EmployeeName);
                }
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
                CheckNumber(paymentSettings, paymentSetting, apiMethod);
            };
            #endregion
            #region 取消按鈕
            btn_Cancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
            };
            #endregion
        }
        #region 品項代碼功能
        /// <summary>
        /// 創建品項代碼下拉選單
        /// </summary>
        private void Create_PaymentItemNo_cbt()
        {
            if (cbt_PaymentItemNo.Properties.Items.Count > 0)
            {
                cbt_PaymentItemNo.Properties.Items.Clear();
            }
            if (PaymentItemSettings != null)
            {
                foreach (var item in PaymentItemSettings)
                {
                    cbt_PaymentItemNo.Properties.Items.Add(item.PaymentItemName);
                }
            }
        }
        /// <summary>
        /// 取得品項代碼
        /// </summary>
        /// <returns></returns>
        private string Get_PaymentItemNo_No()
        {
            string value = "";
            if (PaymentItemSettings != null)
            {
                if (PaymentItemSettings.Count > 0)
                {
                    value = PaymentItemSettings[cbt_PaymentItemNo.SelectedIndex].PaymentItemNo;
                }
            }
            return value;
        }
        /// <summary>
        /// 顯示品項代碼
        /// </summary>
        private void Show_PaymentItemNo_Index()
        {
            int Index = -1;
            if (PaymentItemSettings != null)
            {
                foreach (var item in PaymentItemSettings)
                {
                    if (item.PaymentItemNo == PaymentSetting.PaymentItemNo)
                    {
                        Index++;
                        cbt_PaymentItemNo.SelectedIndex = Index;
                    }
                    else
                    {
                        Index++;
                    }
                }
            }
        }
        #endregion
        #region 申請人功能
        /// <summary>
        /// 創建申請人下拉選單
        /// </summary>
        private void Create_EmployeeNumber_cbt()
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
        /// 取得品項代碼
        /// </summary>
        /// <returns></returns>
        private string Get_EmployeeNumber_Number()
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
        /// <summary>
        /// 顯示品項代碼
        /// </summary>
        private void Show_EmployeeNumber_Index()
        {
            int Index = -1;
            if (EmployeeSettings != null)
            {
                foreach (var item in EmployeeSettings)
                {
                    if (item.EmployeeNumber == PaymentSetting.EmployeeNumber)
                    {
                        Index++;
                        cbt_EmployeeNumber.SelectedIndex = Index;
                    }
                    else
                    {
                        Index++;
                    }
                }
            }
        }
        /// <summary>
        /// 顯示品項代碼
        /// </summary>
        /// <param name="Name"></param>
        private void Show_EmployeeNumber_Index(string Name)
        {
            int Index = -1;
            if (EmployeeSettings != null)
            {
                foreach (var item in EmployeeSettings)
                {
                    if (item.EmployeeName == Name)
                    {
                        Index++;
                        cbt_EmployeeNumber.SelectedIndex = Index;
                    }
                    else
                    {
                        Index++;
                    }
                }
            }
        }
        #endregion
        /// <summary>
        /// 檢查資料問題
        /// </summary>
        /// <param name="paymentSettings"></param>
        /// <param name="paymentSetting"></param>
        /// <param name="apiMethod"></param>
        private void CheckNumber(List<PaymentSetting> paymentSettings, PaymentSetting paymentSetting, APIMethod apiMethod)
        {
            string response = "";
            PaymentSetting paymentsetting = null;
            if (paymentSettings != null)
            {
                paymentsetting = paymentSettings.SingleOrDefault(g => g.PaymentNumber == txt_PaymentNumber.Text);
            }
            if (paymentSetting != null && paymentSetting.PaymentNumber != null)
            {
                paymentSetting.PaymentInvoiceNo = txt_PaymentInvoiceNo.Text;
                paymentsetting.PaymentItemNo = Get_PaymentItemNo_No();
                paymentsetting.EmployeeNumber = Get_EmployeeNumber_Number();
                paymentsetting.PaymentAmount = Convert.ToDouble(txt_PaymentAmoumt.EditValue);
                paymentsetting.PaymentMethod = cbt_PaymentMethod.SelectedIndex;
                paymentsetting.PaymentUse = mmt_PaymentUse.Text;
                paymentsetting.Remark = mmt_Remark.Text;
                if (!string.IsNullOrEmpty(det_TransferDate.Text))
                {
                    paymentsetting.TransferDate = Convert.ToDateTime(det_TransferDate.EditValue);
                }
                string value = JsonConvert.SerializeObject(paymentsetting);
                response = apiMethod.Put_Payment(value);
                if (response == "200")
                {
                    if (!string.IsNullOrEmpty(AttachmentFilePath))
                    {
                        response = apiMethod.Post_PaymentAttachmentFile(paymentsetting.PaymentNumber, AttachmentFilePath);
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
                if (!string.IsNullOrEmpty(det_PaymentDate.Text) && cbt_PaymentItemNo.SelectedIndex > -1 && !string.IsNullOrEmpty(mmt_PaymentUse.Text) && cbt_EmployeeNumber.SelectedIndex > -1 && !string.IsNullOrEmpty(txt_PaymentAmoumt.Text) && cbt_PaymentMethod.SelectedIndex > -1)
                {
                    PaymentSetting setting = new PaymentSetting()
                    {
                        PaymentDate = Convert.ToDateTime(det_PaymentDate.EditValue),
                        PaymentInvoiceNo = txt_PaymentInvoiceNo.Text,
                        PaymentItemNo = Get_PaymentItemNo_No(),
                        EmployeeNumber = Get_EmployeeNumber_Number(),
                        PaymentAmount = Convert.ToDouble(txt_PaymentAmoumt.EditValue),
                        PaymentMethod = cbt_PaymentMethod.SelectedIndex,
                        PaymentUse = mmt_PaymentUse.Text,
                        Remark = mmt_Remark.Text
                    };
                    if (!string.IsNullOrEmpty(det_TransferDate.Text))
                    {
                        setting.TransferDate = Convert.ToDateTime(det_TransferDate.EditValue);
                    }
                    else
                    {
                        setting.TransferDate = null;
                    }
                    string value = JsonConvert.SerializeObject(setting);
                    response = apiMethod.Post_Payment(value);
                    if (response == "200")
                    {
                        if (!string.IsNullOrEmpty(AttachmentFilePath) && !string.IsNullOrEmpty(apiMethod.ResponseDataMessage))
                        {
                            List<PaymentSetting> settings = JsonConvert.DeserializeObject<List<PaymentSetting>>(apiMethod.ResponseDataMessage);
                            response = apiMethod.Post_PaymentAttachmentFile(settings[0].PaymentNumber, AttachmentFilePath);
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
        }
    }
}