using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain.ProductMaintainForm
{
    public partial class ProductDepartmentEditForm : BaseEditForm
    {
        public ProductDepartmentEditForm(List<ProductDepartmentSetting> productDepartmentSettings, ProductDepartmentSetting productDepartmentSetting, APIMethod apiMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            action.Commands.Add(FlyoutCommand.Yes);
            if (productDepartmentSetting != null && productDepartmentSetting.DepartmentNumber != null)//修改
            {
                action.Caption = "部門修改錯誤";
                txt_DepartmentNumber.Enabled = false;
                txt_DepartmentNumber.Text = productDepartmentSetting.DepartmentNumber;
                txt_DepartmentName.Text = productDepartmentSetting.DepartmentName;
            }
            else//新增
            {
                action.Caption = "部門新增錯誤";
            }
            #region 儲存按鈕
            btn_Save.Click += (s, e) =>
            {
                CheckNumber(productDepartmentSettings, productDepartmentSetting, apiMethod);
            };
            #endregion
            #region 取消按鈕
            btn_Cancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
            };
            #endregion
        }
        private void CheckNumber(List<ProductDepartmentSetting> productDepartmentSettings, ProductDepartmentSetting productDepartmentSetting, APIMethod apiMethod)
        {
            string response = "";
            ProductDepartmentSetting productdepartmentSetting = null;
            if (productDepartmentSettings != null)
            {
                productdepartmentSetting = productDepartmentSettings.SingleOrDefault(g => g.DepartmentNumber == txt_DepartmentNumber.Text);
            }
            if (productDepartmentSetting != null && productDepartmentSetting.DepartmentNumber != null)
            {
                productDepartmentSetting.DepartmentNumber = txt_DepartmentNumber.Text;
                productDepartmentSetting.DepartmentName = txt_DepartmentName.Text;
                string value = JsonConvert.SerializeObject(productDepartmentSetting);
                response = apiMethod.Put_ProductDepartment(value);
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
                if (productdepartmentSetting == null)
                {
                    if (!string.IsNullOrEmpty(txt_DepartmentNumber.Text) && !string.IsNullOrEmpty(txt_DepartmentName.Text))
                    {
                        ProductDepartmentSetting setting = new ProductDepartmentSetting()
                        {
                            DepartmentNumber = txt_DepartmentNumber.Text.PadLeft(2, '0'),
                            DepartmentName = txt_DepartmentName.Text,
                        };
                        string value = JsonConvert.SerializeObject(setting);
                        response = apiMethod.Post_ProductDepartment(value);
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
                        action.Description = "資料未填選完整";
                        FlyoutDialog.Show(Form1, action);
                    }
                }
                else
                {
                    action.Description = "部門編號已被使用";
                    FlyoutDialog.Show(Form1, action);
                }
            }
        }
    }
}