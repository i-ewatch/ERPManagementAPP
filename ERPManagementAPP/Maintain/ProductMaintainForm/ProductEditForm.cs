using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain.ProductMaintainForm
{
    public partial class ProductEditForm : BaseEditForm
    {
        private List<CompanySetting> CompanySettings { get; set; }
        private ProductSetting ProductSetting { get; set; }
        private List<ProductCategorySetting> ProductCategorySettings { get; set; }
        /// <summary>
        /// 被選擇的公司資訊
        /// </summary>
        private CompanySetting SelectCompanySetting { get; set; }
        /// <summary>
        /// 被選擇的設備類型資訊
        /// </summary>
        private ProductCategorySetting SelectProductCategorySetting { get; set; }
        public ProductEditForm(List<ProductSetting> productSettings, ProductSetting productSetting, List<CompanySetting> companySettings, List<ProductCategorySetting> productCategorySetting, APIMethod apiMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            CompanySettings = companySettings;
            ProductSetting = productSetting;
            ProductCategorySettings = productCategorySetting;
            action.Commands.Add(FlyoutCommand.Yes);
            Create_slt_PurchasecompanyNumber();
            Create_ProductCategory_cbt();
            if (productSetting != null && productSetting.ProductNumber != null)//修改
            {
                action.Caption = "產品修改錯誤";
                slt_ProductCompanyNumber.Enabled = false;
                Show_ProductCompanyNumber_Index();
                txt_ProductNumber.Enabled = false;
                txt_ProductNumber.Text = ProductSetting.ProductNumber;
                txt_ProductName.Text = ProductSetting.ProductName;
                txt_ProductModel.Text = ProductSetting.ProductModel;
                cbt_ProductType.SelectedIndex = ProductSetting.ProductType;
                Show_ProductCategory_Index();
                mmt_FootPrint.Text = ProductSetting.FootPrint;
                if (ProductSetting.Remark != null)
                {
                    mmt_Remark.Text = ProductSetting.Remark;
                }
                else
                {
                    mmt_Remark.Text = "";
                }
                if (ProductSetting.Explanation != null)
                {
                    mmt_Explanation.Text = ProductSetting.Explanation;
                }
                else
                {
                    mmt_Explanation.Text = "";
                }
            }
            else
            {
                action.Caption = "產品新增錯誤";
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
                CheckNumber(productSettings, productSetting, apiMethod);
            };
            #endregion
            #region 取消按鈕
            btn_Cancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
            };
            #endregion
        }
        #region 廠商編號功能
        /// <summary>
        /// 創建廠商下拉選單
        /// </summary>
        private void Create_slt_PurchasecompanyNumber()
        {
            slt_ProductCompanyNumber.Properties.DataSource = CompanySettings;
            slt_ProductCompanyNumber.Properties.DisplayMember = "CompanyName";
            slt_ProductCompanyNumber.CustomDisplayText += (s, e) =>
            {
                if (ProductSetting != null)
                {
                    if (SelectCompanySetting != null)
                    {
                        if (e.Value.ToString() != "")
                        {
                            SelectCompanySetting = e.Value as CompanySetting;
                            e.DisplayText = SelectCompanySetting.CompanyName;
                        }
                        else
                        {
                            e.DisplayText = SelectCompanySetting.CompanyName;
                        }
                    }
                    else
                    {
                        e.DisplayText = "";
                    }
                }
                else
                {
                    SelectCompanySetting = e.Value as CompanySetting;
                }
            };
        }
        /// <summary>
        /// 顯示廠商選單項目
        /// </summary>
        private void Show_ProductCompanyNumber_Index()
        {
            for (int i = 0; i < CompanySettings.Count; i++)
            {
                if (CompanySettings[i].CompanyNumber == ProductSetting.ProductCompanyNumber)
                {
                    SelectCompanySetting = CompanySettings[i];
                    break;
                }
                else
                {
                    SelectCompanySetting = null;
                }
            }
        }
        #endregion
        #region 產品類別編號
        /// <summary>
        /// 創建產品類別編號下拉選單
        /// </summary>
        private void Create_ProductCategory_cbt()
        {
            slt_ProductCategory.Properties.DataSource = ProductCategorySettings;
            slt_ProductCategory.Properties.DisplayMember = "CategoryName";
            slt_ProductCategory.CustomDisplayText += (s, e) =>
            {
                if (ProductSetting != null)
                {
                    if (SelectProductCategorySetting != null)
                    {
                        if (e.Value.ToString() != "")
                        {
                            SelectCompanySetting = e.Value as CompanySetting;
                            e.DisplayText = SelectProductCategorySetting.CategoryName;
                        }
                        else
                        {
                            e.DisplayText = SelectProductCategorySetting.CategoryName;
                        }
                    }
                    else
                    {
                        e.DisplayText = "";
                    }
                }
                else
                {
                    SelectProductCategorySetting = e.Value as ProductCategorySetting;
                }
            };
        }
        /// <summary>
        /// 顯示產品類別名稱
        /// </summary>
        private void Show_ProductCategory_Index()
        {
            for (int i = 0; i < ProductCategorySettings.Count; i++)
            {
                if (ProductCategorySettings[i].CategoryNumber == ProductSetting.ProductCategory)
                {
                    SelectProductCategorySetting = ProductCategorySettings[i];
                    break;
                }
                else
                {
                    SelectProductCategorySetting = null;
                }
            }
        }
        #endregion
        /// <summary>
        /// 檢查資料問題
        /// </summary>
        /// <param name="productSettings"></param>
        /// <param name="productSetting"></param>
        /// <param name="apiMethod"></param>
        private void CheckNumber(List<ProductSetting> productSettings, ProductSetting productSetting, APIMethod apiMethod)
        {
            string response = "";
            ProductSetting productsetting = null;
            if (productSettings != null)
            {
                productsetting = productSettings.SingleOrDefault(g => g.ProductNumber == txt_ProductNumber.Text);
            }
            if (productSetting != null && productsetting.ProductNumber != null)
            {
                productSetting.ProductCompanyNumber = SelectCompanySetting.CompanyNumber;
                productSetting.ProductNumber = txt_ProductNumber.Text;
                productSetting.ProductName = txt_ProductName.Text;
                productSetting.ProductModel = txt_ProductModel.Text;
                productSetting.ProductType = cbt_ProductType.SelectedIndex;
                productSetting.ProductCategory = SelectProductCategorySetting.CategoryNumber;
                productSetting.FootPrint = mmt_FootPrint.Text;
                productSetting.Remark = mmt_Remark.Text;
                productSetting.Explanation = mmt_Explanation.Text;
                string value = JsonConvert.SerializeObject(productSetting);
                response = apiMethod.Put_Product(value);
                if (response == "200")
                {
                    if (!string.IsNullOrEmpty(AttachmentFilePath))
                    {
                        response = apiMethod.Post_ProductAttachmentFile(productSetting.ProductNumber, productSetting.ProductName, AttachmentFilePath);
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
                if (productsetting == null)
                {
                    if (SelectCompanySetting != null && !string.IsNullOrEmpty(txt_ProductNumber.Text) && !string.IsNullOrEmpty(txt_ProductName.Text) && !string.IsNullOrEmpty(txt_ProductModel.Text) && cbt_ProductType.SelectedIndex > -1)
                    {
                        ProductSetting setting = new ProductSetting()
                        {
                            ProductCompanyNumber = SelectCompanySetting.CompanyNumber,
                            ProductNumber = txt_ProductNumber.Text,
                            ProductName = txt_ProductName.Text,
                            ProductModel = txt_ProductModel.Text,
                            ProductType = cbt_ProductType.SelectedIndex,
                            ProductCategory = SelectProductCategorySetting.CategoryNumber,
                            FootPrint = mmt_FootPrint.Text,
                            Remark = mmt_Remark.Text,
                            Explanation = mmt_Explanation.Text
                        };
                        string value = JsonConvert.SerializeObject(setting);
                        response = apiMethod.Post_Product(value);
                        if (response == "200")
                        {
                            if (!string.IsNullOrEmpty(AttachmentFilePath))
                            {
                                response = apiMethod.Post_ProductAttachmentFile(productSetting.ProductNumber, productSetting.ProductName, AttachmentFilePath);
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
                    action.Description = "產品編號已被使用";
                    FlyoutDialog.Show(Form1, action);
                }
            }
        }
    }
}