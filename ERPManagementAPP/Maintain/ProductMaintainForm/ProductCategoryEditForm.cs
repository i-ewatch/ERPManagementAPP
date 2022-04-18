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
    public partial class ProductCategoryEditForm : BaseEditForm
    {
        public ProductCategoryEditForm(List<ProductCategorySetting> productCategorySettings, ProductCategorySetting productCategorySetting, APIMethod apiMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            action.Commands.Add(FlyoutCommand.Yes);
            if (productCategorySetting != null && productCategorySetting.CategoryNumber != null)//修改
            {
                action.Caption = "產品類別修改錯誤";
                txt_CategoryNumber.Enabled = false;
                txt_CategoryNumber.Text = productCategorySetting.CategoryNumber;
                txt_CategoryName.Text = productCategorySetting.CategoryName;
            }
            else//新增
            {
                action.Caption = "產品類別新增錯誤";
            }
            #region 儲存按鈕
            btn_Save.Click += (s, e) =>
            {
                CheckNumber(productCategorySettings, productCategorySetting, apiMethod);
            };
            #endregion
            #region 取消按鈕
            btn_Cancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
            };
            #endregion
        }
        private void CheckNumber(List<ProductCategorySetting> productCategorySettings, ProductCategorySetting productCategorySetting, APIMethod apiMethod)
        {
            string response = "";
            ProductCategorySetting productcategorysetting = null;
            if (productCategorySettings != null)
            {
                productcategorysetting = productCategorySettings.SingleOrDefault(g => g.CategoryNumber == txt_CategoryNumber.Text);
            }
            if (productCategorySetting != null && productCategorySetting.CategoryNumber != null)
            {
                productCategorySetting.CategoryNumber = txt_CategoryNumber.Text;
                productCategorySetting.CategoryName = txt_CategoryName.Text;
                string value = JsonConvert.SerializeObject(productCategorySetting);
                response = apiMethod.Put_ProductGategory(value);
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
                if (productcategorysetting == null)
                {
                    if (!string.IsNullOrEmpty(txt_CategoryNumber.Text) && !string.IsNullOrEmpty(txt_CategoryName.Text))
                    {
                        ProductCategorySetting setting = new ProductCategorySetting()
                        {
                            CategoryNumber = txt_CategoryNumber.Text,
                            CategoryName = txt_CategoryName.Text,
                        };
                        string value = JsonConvert.SerializeObject(setting);
                        response = apiMethod.Post_ProductGategory(value);
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
                    action.Description = "產品類別編號已被使用";
                    FlyoutDialog.Show(Form1, action);
                }
            }
        }
    }
}