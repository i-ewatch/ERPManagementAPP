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
        private List<ProductDepartmentSetting> ProductDepartmentSettings { get; set; } = new List<ProductDepartmentSetting>();
        private List<ProductItem1Setting> ProductItem1Settings { get; set; } = new List<ProductItem1Setting>();
        private List<ProductItem2Setting> ProductItem2Settings { get; set; } = new List<ProductItem2Setting>();
        private List<ProductItem3Setting> ProductItem3Settings { get; set; } = new List<ProductItem3Setting>();
        private List<ProductItem4Setting> ProductItem4Settings { get; set; } = new List<ProductItem4Setting>();
        private List<ProductItem5Setting> ProductItem5Settings { get; set; } = new List<ProductItem5Setting>();
        /// <summary>
        /// 被選擇的公司資訊
        /// </summary>
        private CompanySetting SelectCompanySetting { get; set; }
        /// <summary>
        /// 被選擇的設備類型資訊
        /// </summary>
        private ProductCategorySetting SelectProductCategorySetting { get; set; }
        private ProductDepartmentSetting SelectProductDepartmentSetting { get; set; }
        private ProductItem1Setting SelectProductItem1Setting { get; set; }
        private ProductItem2Setting SelectProductItem2Setting { get; set; }
        private ProductItem3Setting SelectProductItem3Setting { get; set; }
        private ProductItem4Setting SelectProductItem4Setting { get; set; }
        private ProductItem5Setting SelectProductItem5Setting { get; set; }
        public ProductEditForm(
            List<ProductSetting> productSettings,
            ProductSetting productSetting,
            List<CompanySetting> companySettings,
            List<ProductDepartmentSetting> productDepartmentSettings,
            List<ProductItem1Setting> productItem1Settings,
            List<ProductItem2Setting> productItem2Settings,
            List<ProductItem3Setting> productItem3Settings,
            List<ProductItem4Setting> productItem4Settings,
            List<ProductItem5Setting> productItem5Settings,
            APIMethod apiMethod,
            Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            CompanySettings = companySettings;
            ProductSetting = productSetting;
            ProductDepartmentSettings = productDepartmentSettings;
            ProductItem1Settings = productItem1Settings;
            ProductItem2Settings = productItem2Settings;
            ProductItem3Settings = productItem3Settings;
            ProductItem4Settings = productItem4Settings;
            ProductItem5Settings = productItem5Settings;
            //ProductCategorySettings = productCategorySetting; //不使用 2022/5/5
            action.Commands.Add(FlyoutCommand.Yes);
            Create_slt_PurchasecompanyNumber();
            //Create_ProductCategory_cbt(); //不使用 2022/5/5
            Create_slt_Department();
            if (productSetting != null && productSetting.ProductNumber != null)//修改
            {
                action.Caption = "產品修改錯誤";
                slt_ProductCompanyNumber.Enabled = false;
                Show_ProductCompanyNumber_Index();
                txt_ProductNumber.Enabled = false;
                Show_slt_Department();
                slt_DepartmentNumber.Enabled = false;
                Create_slt_Item1();
                Show_slt_Item1();
                slt_Item1Number.Enabled = false;
                Create_slt_Item2();
                Show_slt_Item2();
                slt_Item2Number.Enabled = false;
                Create_slt_Item3();
                Show_slt_Item3();
                slt_Item3Number.Enabled = false;
                Create_slt_Item4();
                Show_slt_Item4();
                slt_Item4Number.Enabled = false;
                Create_slt_Item5();
                Show_slt_Item5();
                slt_Item5Number.Enabled = false;
                txt_ProductNumber.Text = ProductSetting.ProductNumber;
                txt_ProductName.Text = ProductSetting.ProductName;
                txt_ProductModel.Text = ProductSetting.ProductModel;
                cbt_ProductType.SelectedIndex = ProductSetting.ProductType;
                //Show_ProductCategory_Index(); //不使用 2022/5/5
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
            slt_DepartmentNumber.EditValueChanged += (s, e) =>
            {
                slt_Item1Number.EditValue = "";
                Create_slt_Item1();
                slt_Item2Number.Properties.DataSource = null;
                slt_Item3Number.Properties.DataSource = null;
                slt_Item4Number.Properties.DataSource = null;
                slt_Item5Number.Properties.DataSource = null;
                txt_ProductNumber.Text = "";
                SelectProductItem1Setting = null;
                SelectProductItem2Setting = null;
                SelectProductItem3Setting = null;
                SelectProductItem4Setting = null;
                SelectProductItem5Setting = null;
            };
            slt_Item1Number.EditValueChanged += (s, e) =>
            {
                slt_Item2Number.EditValue = "";
                Create_slt_Item2();
                slt_Item3Number.Properties.DataSource = null;
                slt_Item4Number.Properties.DataSource = null;
                slt_Item5Number.Properties.DataSource = null;
                txt_ProductNumber.Text = "";
                SelectProductItem2Setting = null;
                SelectProductItem3Setting = null;
                SelectProductItem4Setting = null;
                SelectProductItem5Setting = null;
            };
            slt_Item2Number.EditValueChanged += (s, e) =>
            {
                slt_Item3Number.EditValue = "";
                Create_slt_Item3();
                slt_Item4Number.Properties.DataSource = null;
                slt_Item5Number.Properties.DataSource = null;
                txt_ProductNumber.Text = "";
                SelectProductItem3Setting = null;
                SelectProductItem4Setting = null;
                SelectProductItem5Setting = null;
            };
            slt_Item3Number.EditValueChanged += (s, e) =>
            {
                slt_Item4Number.EditValue = "";
                Create_slt_Item4();
                slt_Item5Number.Properties.DataSource = null;
                txt_ProductNumber.Text = "";
                SelectProductItem4Setting = null;
                SelectProductItem5Setting = null;
            };
            slt_Item4Number.EditValueChanged += (s, e) =>
            {
                slt_Item5Number.EditValue = "";
                Create_slt_Item5();
                txt_ProductNumber.Text = "";
                SelectProductItem5Setting = null;
            };
            slt_Item5Number.EditValueChanged += (s, e) =>
            {
                if (string.IsNullOrEmpty(txt_ProductNumber.Text))
                {
                    txt_ProductNumber.Text = $"{SelectProductItem5Setting.DepartmentNumber}{SelectProductItem5Setting.Item1Number}-{SelectProductItem5Setting.Item2Number}{SelectProductItem5Setting.Item3Number}{SelectProductItem5Setting.Item4Number}{SelectProductItem5Setting.Item5Number}-";
                }
            };
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
        #region 產品類別編號 不使用 2022/5/5
        /// <summary>
        /// 創建產品類別編號下拉選單
        /// </summary>
        private void Create_ProductCategory_cbt()
        {
            //slt_ProductCategory.Properties.DataSource = ProductCategorySettings;
            //slt_ProductCategory.Properties.DisplayMember = "CategoryName";
            //slt_ProductCategory.CustomDisplayText += (s, e) =>
            //{
            //    if (ProductSetting != null)
            //    {
            //        if (SelectProductCategorySetting != null)
            //        {
            //            if (e.Value.ToString() != "")
            //            {
            //                SelectCompanySetting = e.Value as CompanySetting;
            //                e.DisplayText = SelectProductCategorySetting.CategoryName;
            //            }
            //            else
            //            {
            //                e.DisplayText = SelectProductCategorySetting.CategoryName;
            //            }
            //        }
            //        else
            //        {
            //            e.DisplayText = "";
            //        }
            //    }
            //    else
            //    {
            //        SelectProductCategorySetting = e.Value as ProductCategorySetting;
            //    }
            //};
        }
        /// <summary>
        /// 顯示產品類別名稱
        /// </summary>
        private void Show_ProductCategory_Index()
        {
            //for (int i = 0; i < ProductCategorySettings.Count; i++)
            //{
            //    if (ProductCategorySettings[i].CategoryNumber == ProductSetting.ProductCategory)
            //    {
            //        SelectProductCategorySetting = ProductCategorySettings[i];
            //        break;
            //    }
            //    else
            //    {
            //        SelectProductCategorySetting = null;
            //    }
            //}
        }
        #endregion
        #region 部門編號功能
        /// <summary>
        /// 創建部門下拉選單
        /// </summary>
        private void Create_slt_Department()
        {
            slt_DepartmentNumber.Properties.DataSource = ProductDepartmentSettings;
            slt_DepartmentNumber.Properties.DisplayMember = "DepartmentName";
            slt_DepartmentNumber.CustomDisplayText += (s, e) =>
            {
                if (ProductSetting != null)
                {
                    if (SelectProductDepartmentSetting != null)
                    {
                        if (e.Value.ToString() != "")
                        {
                            SelectProductDepartmentSetting = e.Value as ProductDepartmentSetting;
                            e.DisplayText = SelectProductDepartmentSetting.DepartmentName;
                        }
                        else
                        {
                            e.DisplayText = SelectProductDepartmentSetting.DepartmentName;
                        }
                    }
                    else
                    {
                        e.DisplayText = "";
                    }
                }
                else
                {
                    SelectProductDepartmentSetting = e.Value as ProductDepartmentSetting;
                }

            };
        }
        /// <summary>
        /// 顯示部門選單項目
        /// </summary>
        private void Show_slt_Department()
        {
            for (int i = 0; i < ProductDepartmentSettings.Count; i++)
            {
                if (ProductDepartmentSettings[i].DepartmentNumber == ProductSetting.ProductNumber.Substring(0, 2))
                {
                    SelectProductDepartmentSetting = ProductDepartmentSettings[i];
                    return;
                }
                else
                {
                    SelectProductDepartmentSetting = null;
                }
            }
        }
        #endregion
        #region 項目1編號功能
        /// <summary>
        /// 創建項目1下拉選單
        /// </summary>
        private void Create_slt_Item1()
        {
            if (SelectProductDepartmentSetting != null && SelectProductDepartmentSetting.DepartmentNumber != null)
            {
                List<ProductItem1Setting> settings = ProductItem1Settings.Where(g => g.DepartmentNumber == SelectProductDepartmentSetting.DepartmentNumber).ToList();
                slt_Item1Number.Properties.DataSource = settings;
                slt_Item1Number.Properties.DisplayMember = "Item1Name";
                slt_Item1Number.CustomDisplayText += (s, e) =>
                {
                    if (ProductSetting != null)
                    {
                        if (SelectProductItem1Setting != null)
                        {
                            if (e.Value.ToString() != "")
                            {
                                SelectProductItem1Setting = e.Value as ProductItem1Setting;
                                e.DisplayText = SelectProductItem1Setting.Item1Name;
                            }
                            else
                            {
                                e.DisplayText = SelectProductItem1Setting.Item1Name;
                            }
                        }
                        else
                        {
                            e.DisplayText = "";
                        }
                    }
                    else
                    {
                        SelectProductItem1Setting = e.Value as ProductItem1Setting;
                    }
                };
            }
            else
            {
                slt_Item1Number.Properties.DataSource = null;
                SelectProductItem1Setting = null;
            }
        }
        /// <summary>
        /// 顯示項目1選單項目
        /// </summary>
        private void Show_slt_Item1()
        {
            if (SelectProductDepartmentSetting != null && SelectProductDepartmentSetting.DepartmentNumber != null)
            {
                List<ProductItem1Setting> settings = ProductItem1Settings.Where(g => g.DepartmentNumber == SelectProductDepartmentSetting.DepartmentNumber).ToList();
                for (int i = 0; i < settings.Count; i++)
                {

                    if (settings[i].Item1Number == ProductSetting.ProductNumber.Substring(2, 2))
                    {
                        SelectProductItem1Setting = settings[i];
                        return;
                    }
                    else
                    {
                        SelectProductItem1Setting = null;
                    }

                }
            }
            else
            {
                slt_Item1Number.Properties.DataSource = null;
                SelectProductItem1Setting = null;
            }
        }
        #endregion
        #region 項目2編號功能
        /// <summary>
        /// 創建項目2下拉選單
        /// </summary>
        private void Create_slt_Item2()
        {
            if (SelectProductDepartmentSetting != null && SelectProductDepartmentSetting.DepartmentNumber != null && SelectProductItem1Setting!=null)
            {
                List<ProductItem2Setting> settings = ProductItem2Settings.Where(g => g.DepartmentNumber == SelectProductDepartmentSetting.DepartmentNumber & g.Item1Number == SelectProductItem1Setting.Item1Number).ToList();
                slt_Item2Number.Properties.DataSource = settings;
                slt_Item2Number.Properties.DisplayMember = "Item2Name";
                slt_Item2Number.CustomDisplayText += (s, e) =>
                {
                    if (ProductSetting != null)
                    {
                        if (SelectProductItem2Setting != null)
                        {
                            if (e.Value.ToString() != "")
                            {
                                SelectProductItem2Setting = e.Value as ProductItem2Setting;
                                e.DisplayText = SelectProductItem2Setting.Item2Name;
                            }
                            else
                            {
                                e.DisplayText = SelectProductItem2Setting.Item2Name;
                            }
                        }
                        else
                        {
                            e.DisplayText = "";
                        }
                    }
                    else
                    {
                        SelectProductItem2Setting = e.Value as ProductItem2Setting;
                    }
                };
            }
            else
            {
                slt_Item2Number.Properties.DataSource = null;
                SelectProductItem2Setting = null;
            }
        }
        /// <summary>
        /// 顯示項目2選單項目
        /// </summary>
        private void Show_slt_Item2()
        {
            if (SelectProductDepartmentSetting != null && SelectProductDepartmentSetting.DepartmentNumber != null)
            {
                List<ProductItem2Setting> settings = ProductItem2Settings.Where(g => g.DepartmentNumber == SelectProductDepartmentSetting.DepartmentNumber).ToList();
                for (int i = 0; i < settings.Count; i++)
                {

                    if (settings[i].Item2Number == ProductSetting.ProductNumber.Substring(5, 2))
                    {
                        SelectProductItem2Setting = settings[i];
                        return;
                    }
                    else
                    {
                        SelectProductItem2Setting = null;
                    }

                }
            }
            else
            {
                slt_Item2Number.Properties.DataSource = null;
                SelectProductItem2Setting = null;
            }
        }
        #endregion
        #region 項目3編號功能
        /// <summary>
        /// 創建項目3下拉選單
        /// </summary>
        private void Create_slt_Item3()
        {
            if (SelectProductDepartmentSetting != null && SelectProductDepartmentSetting.DepartmentNumber != null && SelectProductItem1Setting != null && SelectProductItem2Setting != null)
            {
                List<ProductItem3Setting> settings = ProductItem3Settings.Where(g => g.DepartmentNumber == SelectProductDepartmentSetting.DepartmentNumber
                & g.Item1Number == SelectProductItem1Setting.Item1Number & g.Item2Number == SelectProductItem2Setting.Item2Number).ToList();
                slt_Item3Number.Properties.DataSource = settings;
                slt_Item3Number.Properties.DisplayMember = "Item3Name";
                slt_Item3Number.CustomDisplayText += (s, e) =>
                {
                    if (ProductSetting != null)
                    {
                        if (SelectProductItem3Setting != null)
                        {
                            if (e.Value.ToString() != "")
                            {
                                SelectProductItem3Setting = e.Value as ProductItem3Setting;
                                e.DisplayText = SelectProductItem3Setting.Item3Name;
                            }
                            else
                            {
                                e.DisplayText = SelectProductItem3Setting.Item3Name;
                            }
                        }
                        else
                        {
                            e.DisplayText = "";
                        }
                    }
                    else
                    {
                        SelectProductItem3Setting = e.Value as ProductItem3Setting;
                    }
                };
            }
            else
            {
                slt_Item3Number.Properties.DataSource = null;
                SelectProductItem3Setting = null;
            }
        }
        /// <summary>
        /// 顯示項目3選單項目
        /// </summary>
        private void Show_slt_Item3()
        {
            if (SelectProductDepartmentSetting != null && SelectProductDepartmentSetting.DepartmentNumber != null)
            {
                List<ProductItem3Setting> settings = ProductItem3Settings.Where(g => g.DepartmentNumber == SelectProductDepartmentSetting.DepartmentNumber).ToList();
                for (int i = 0; i < settings.Count; i++)
                {

                    if (settings[i].Item3Number == ProductSetting.ProductNumber.Substring(7, 2))
                    {
                        SelectProductItem3Setting = settings[i];
                        return;
                    }
                    else
                    {
                        SelectProductItem3Setting = null;
                    }

                }
            }
            else
            {
                slt_Item3Number.Properties.DataSource = null;
                SelectProductItem3Setting = null;
            }
        }
        #endregion
        #region 項目4編號功能
        /// <summary>
        /// 創建項目4下拉選單
        /// </summary>
        private void Create_slt_Item4()
        {
            if (SelectProductDepartmentSetting != null && SelectProductDepartmentSetting.DepartmentNumber != null && SelectProductItem1Setting != null && SelectProductItem2Setting != null && SelectProductItem3Setting != null)
            {
                List<ProductItem4Setting> settings = ProductItem4Settings.Where(g => g.DepartmentNumber == SelectProductDepartmentSetting.DepartmentNumber
                & g.Item1Number == SelectProductItem1Setting.Item1Number & g.Item2Number == SelectProductItem2Setting.Item2Number & g.Item3Number == SelectProductItem3Setting.Item3Number).ToList();
                slt_Item4Number.Properties.DataSource = settings;
                slt_Item4Number.Properties.DisplayMember = "Item4Name";
                slt_Item4Number.CustomDisplayText += (s, e) =>
                {
                    if (ProductSetting != null)
                    {
                        if (SelectProductItem4Setting != null)
                        {
                            if (e.Value.ToString() != "")
                            {
                                SelectProductItem4Setting = e.Value as ProductItem4Setting;
                                e.DisplayText = SelectProductItem4Setting.Item4Name;
                            }
                            else
                            {
                                e.DisplayText = SelectProductItem4Setting.Item4Name;
                            }
                        }
                        else
                        {
                            e.DisplayText = "";
                        }
                    }
                    else
                    {
                        SelectProductItem4Setting = e.Value as ProductItem4Setting;
                    }
                };
            }
            else
            {
                slt_Item4Number.Properties.DataSource = null;
                SelectProductItem4Setting = null;
            }
        }
        /// <summary>
        /// 顯示項目4選單項目
        /// </summary>
        private void Show_slt_Item4()
        {
            if (SelectProductDepartmentSetting != null && SelectProductDepartmentSetting.DepartmentNumber != null)
            {
                List<ProductItem4Setting> settings = ProductItem4Settings.Where(g => g.DepartmentNumber == SelectProductDepartmentSetting.DepartmentNumber).ToList();
                for (int i = 0; i < settings.Count; i++)
                {

                    if (settings[i].Item4Number == ProductSetting.ProductNumber.Substring(9, 2))
                    {
                        SelectProductItem4Setting = settings[i];
                        return;
                    }
                    else
                    {
                        SelectProductItem4Setting = null;
                    }

                }
            }
            else
            {
                slt_Item4Number.Properties.DataSource = null;
                SelectProductItem4Setting = null;
            }
        }
        #endregion
        #region 項目5編號功能
        /// <summary>
        /// 創建項目5下拉選單
        /// </summary>
        private void Create_slt_Item5()
        {
            if (SelectProductDepartmentSetting != null && SelectProductDepartmentSetting.DepartmentNumber != null && SelectProductItem1Setting != null && SelectProductItem2Setting != null && SelectProductItem3Setting != null && SelectProductItem4Setting != null)
            {
                List<ProductItem5Setting> settings = ProductItem5Settings.Where(g => g.DepartmentNumber == SelectProductDepartmentSetting.DepartmentNumber
                  & g.Item1Number == SelectProductItem1Setting.Item1Number & g.Item2Number == SelectProductItem2Setting.Item2Number & g.Item3Number == SelectProductItem3Setting.Item3Number & g.Item4Number == SelectProductItem4Setting.Item4Number).ToList();
                slt_Item5Number.Properties.DataSource = settings;
                slt_Item5Number.Properties.DisplayMember = "Item5Name";
                slt_Item5Number.CustomDisplayText += (s, e) =>
                {
                    if (ProductSetting != null)
                    {
                        if (SelectProductItem5Setting != null)
                        {
                            if (e.Value.ToString() != "")
                            {
                                SelectProductItem5Setting = e.Value as ProductItem5Setting;
                                e.DisplayText = SelectProductItem5Setting.Item5Name;
                            }
                            else
                            {
                                e.DisplayText = SelectProductItem5Setting.Item5Name;
                            }
                        }
                        else
                        {
                            e.DisplayText = "";
                        }
                    }
                    else
                    {
                        SelectProductItem5Setting = e.Value as ProductItem5Setting;
                    }
                };
            }
            else
            {
                slt_Item5Number.Properties.DataSource = null;
                SelectProductItem5Setting = null;
            }
        }
        /// <summary>
        /// 顯示項目5選單項目
        /// </summary>
        private void Show_slt_Item5()
        {
            if (SelectProductDepartmentSetting != null && SelectProductDepartmentSetting.DepartmentNumber != null)
            {
                List<ProductItem5Setting> settings = ProductItem5Settings.Where(g => g.DepartmentNumber == SelectProductDepartmentSetting.DepartmentNumber).ToList();
                for (int i = 0; i < settings.Count; i++)
                {

                    if (settings[i].Item5Number == ProductSetting.ProductNumber.Substring(11, 4))
                    {
                        SelectProductItem5Setting = settings[i];
                        return;
                    }
                    else
                    {
                        SelectProductItem5Setting = null;
                    }

                }
            }
            else
            {
                slt_Item5Number.Properties.DataSource = null;
                SelectProductItem5Setting = null;
            }
        }
        #endregion
        #region 檢查資料問題
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
                //productSetting.ProductCategory = SelectProductCategorySetting.CategoryNumber;
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
                    if (SelectCompanySetting != null && !string.IsNullOrEmpty(txt_ProductNumber.Text) && !string.IsNullOrEmpty(txt_ProductName.Text) && cbt_ProductType.SelectedIndex > -1)
                    {
                        ProductSetting setting = new ProductSetting()
                        {
                            ProductCompanyNumber = SelectCompanySetting.CompanyNumber,
                            ProductNumber = txt_ProductNumber.Text,
                            ProductName = txt_ProductName.Text,
                            ProductModel = txt_ProductModel.Text,
                            ProductType = cbt_ProductType.SelectedIndex,
                            //ProductCategory = SelectProductCategorySetting.CategoryNumber,
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
                    else
                    {
                        action.Description = "資料未填選完整";
                        FlyoutDialog.Show(Form1, action);
                    }
                }
                else
                {
                    action.Description = "產品編號已被使用";
                    FlyoutDialog.Show(Form1, action);
                }
            }
        }
        #endregion
    }
}