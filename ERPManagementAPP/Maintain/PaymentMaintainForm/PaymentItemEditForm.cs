using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain.PaymentMaintainForm
{
    public partial class PaymentItemEditForm : BaseEditForm
    {
        public PaymentItemEditForm(List<PaymentItemSetting> paymentItemSettings, PaymentItemSetting paymentItemSetting, APIMethod apiMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            action.Commands.Add(FlyoutCommand.Yes);
            if (paymentItemSetting != null && paymentItemSetting.PaymentItemNo != null)//修改
            {
                action.Caption = "品項類別修改錯誤";
                txt_PaymentItemNo.Enabled = false;
                txt_PaymentItemNo.Text = paymentItemSetting.PaymentItemNo;
                txt_PaymentItemName.Text = paymentItemSetting.PaymentItemName;
            }
            else//新增
            {
                action.Caption = "品項類別新增錯誤";
            }
            #region 儲存按鈕
            btn_Save.Click += (s, e) =>
            {
                CheckNumber(paymentItemSettings, paymentItemSetting, apiMethod);
            };
            #endregion
            #region 取消按鈕
            btn_Cancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
            };
            #endregion
        }
        private void CheckNumber(List<PaymentItemSetting> paymentItemSettings, PaymentItemSetting paymentItemSetting, APIMethod apiMethod)
        {
            string response = "";
            PaymentItemSetting paymentItemsetting = null;
            if (paymentItemSetting != null)
            {
                paymentItemsetting = paymentItemSettings.SingleOrDefault(g => g.PaymentItemNo == txt_PaymentItemNo.Text);
            }
            if (paymentItemSetting != null && paymentItemSetting.PaymentItemNo != null)
            {
                paymentItemSetting.PaymentItemNo = txt_PaymentItemNo.Text;
                paymentItemSetting.PaymentItemName = txt_PaymentItemName.Text;
                string value = JsonConvert.SerializeObject(paymentItemSetting);
                response = apiMethod.Put_PaymentItem(value);
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
                if (paymentItemsetting == null)
                {
                    if (!string.IsNullOrEmpty(txt_PaymentItemNo.Text) && !string.IsNullOrEmpty(txt_PaymentItemName.Text))
                    {
                        PaymentItemSetting setting = new PaymentItemSetting()
                        {
                            PaymentItemNo = txt_PaymentItemNo.Text,
                            PaymentItemName = txt_PaymentItemName.Text
                        };
                        string value = JsonConvert.SerializeObject(setting);
                        response = apiMethod.Post_PaymentItem(value);
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
                    action.Description = "產品類別編號已被使用";
                    FlyoutDialog.Show(Form1, action);
                }
            }
        }
    }
}