using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraPrinting;
using DevExpress.XtraSplashScreen;
using ERPManagementAPP.Maintain.ProductMaintainForm;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain
{
    public partial class ProductMaintainControl : Field4MaintainControl
    {
        /// <summary>
        /// 聚焦產品資料
        /// </summary>
        private ProductSetting FocuseProductSetting { get; set; } = new ProductSetting();
        /// <summary>
        /// 聚焦產品類別資料
        /// </summary>
        private ProductCategorySetting FocuseProductCategorySetting { get; set; } = new ProductCategorySetting();
        /// <summary>
        /// 聚焦部門類別資料
        /// </summary>
        private ProductDepartmentSetting FocuseProductDepartmentSetting { get; set; } = new ProductDepartmentSetting();
        /// <summary>
        /// 聚焦項目1資料
        /// </summary>
        private ProductItem1Setting FocuseProductItem1Setting { get; set; } = new ProductItem1Setting();
        /// <summary>
        /// 聚焦項目2資料
        /// </summary>
        private ProductItem2Setting FocuseProductItem2Setting { get; set; } = new ProductItem2Setting();
        /// <summary>
        /// 聚焦項目3資料
        /// </summary>
        private ProductItem3Setting FocuseProductItem3Setting { get; set; } = new ProductItem3Setting();
        /// <summary>
        /// 聚焦項目4資料
        /// </summary>
        private ProductItem4Setting FocuseProductItem4Setting { get; set; } = new ProductItem4Setting();
        /// <summary>
        /// 聚焦項目5資料
        /// </summary>
        private ProductItem5Setting FocuseProductItem5Setting { get; set; } = new ProductItem5Setting();
        /// <summary>
        /// 總產品資料
        /// </summary>
        private List<ProductSetting> ProductSettings { get; set; } = new List<ProductSetting>();
        /// <summary>
        /// 總產品類別資料
        /// </summary>
        private List<ProductCategorySetting> ProductCategorySettings { get; set; } = new List<ProductCategorySetting>();
        /// <summary>
        /// 總部門類別資料
        /// </summary>
        private List<ProductDepartmentSetting> ProductDepartmentSettings { get; set; } = new List<ProductDepartmentSetting>();
        /// <summary>
        /// 總項目1資料
        /// </summary>
        private List<ProductItem1Setting> ProductItem1Settings { get; set; } = new List<ProductItem1Setting>();
        /// <summary>
        /// 總項目2資料
        /// </summary>
        private List<ProductItem2Setting> ProductItem2Settings { get; set; } = new List<ProductItem2Setting>();
        /// <summary>
        /// 總項目3資料
        /// </summary>
        private List<ProductItem3Setting> ProductItem3Settings { get; set; } = new List<ProductItem3Setting>();
        /// <summary>
        /// 總項目4資料
        /// </summary>
        private List<ProductItem4Setting> ProductItem4Settings { get; set; } = new List<ProductItem4Setting>();
        /// <summary>
        /// 總項目5資料
        /// </summary>
        private List<ProductItem5Setting> ProductItem5Settings { get; set; } = new List<ProductItem5Setting>();
        /// <summary>
        /// 總廠商資料
        /// </summary>
        private List<CompanySetting> CompanySettings { get; set; }
        public ProductMaintainControl(APIMethod APIMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            apiMethod = APIMethod;
            if (Form1.EmployeeSetting.Token > 0)
            {
                Refresh_Main_GridView();
            }
            action.Commands.Add(FlyoutCommand.Yes);
            Delectaction.Commands.Add(FlyoutCommand.Yes);
            Delectaction.Commands.Add(FlyoutCommand.Cancel);
            Delectaction.Caption = "刪除確認";
            #region 部門類別資料表
            DepartmentgridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 部門類別聚焦功能
            DepartmentgridView.FocusedRowChanged += (s, ex) =>
            {
                FocuseMainGrid(Convert.ToInt32(DepartmentgridControl.Tag.ToString()));
            };
            #endregion
            #region 關鍵字搜尋
            DepartmentgridView.ColumnFilterChanged += (s, e) =>
            {
                FocuseMainGrid(Convert.ToInt32(DepartmentgridControl.Tag.ToString()));
            };
            #endregion
            #region 新增部門類別
            btn_Department_Add.Click += (s, e) =>
            {
                Refresh_API();
                ProductDepartmentEditForm productDepartment = new ProductDepartmentEditForm(ProductDepartmentSettings, null, apiMethod, Form1);
                if (productDepartment.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                    Refresh_Second_GridView("");
                }
            };
            #endregion
            #region 修改部門類別
            btn_Department_Edit.Click += (s, e) =>
            {
                Refresh_API();
                ProductDepartmentEditForm productDepartment = new ProductDepartmentEditForm(ProductDepartmentSettings, FocuseProductDepartmentSetting, apiMethod, Form1);
                if (productDepartment.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                    Refresh_Second_GridView("");
                }
            };
            #endregion
            #region 雙擊修改部門類別
            DepartmentgridControl.DoubleClick += (s, e) =>
            {
                Refresh_API();
                FocuseMainGrid(Convert.ToInt32(DepartmentgridControl.Tag.ToString()));
                ProductDepartmentEditForm productDepartment = new ProductDepartmentEditForm(ProductDepartmentSettings, FocuseProductDepartmentSetting, apiMethod, Form1);
                if (productDepartment.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                    Refresh_Second_GridView("");
                }
            };
            #endregion
            #region 刪除部門類別
            btn_Department_Delete.Click += (s, e) =>
            {
                FocuseMainGrid(Convert.ToInt32(DepartmentgridControl.Tag.ToString()));
                Delectaction.Description = $"刪除名稱 : {FocuseProductDepartmentSetting.DepartmentName}";
                if (FlyoutDialog.Show(Form1, Delectaction) == DialogResult.Yes)
                {
                    string data = JsonConvert.SerializeObject(FocuseProductDepartmentSetting);
                    string response = apiMethod.Delete_ProductDepartment(data);
                    if (response == "200")
                    {
                        Refresh_Main_GridView();
                        action.Caption = "刪除部門類別成功";
                        action.Description = "";
                        FlyoutDialog.Show(Form1, action);
                    }
                    else
                    {
                        action.Caption = "刪除部門類別失敗";
                        action.Description = "";
                        FlyoutDialog.Show(Form1, action);
                    }
                }
            };
            #endregion
            #region 部門類別資料刷新
            btn_Department_Refresh.Click += (s, e) =>
            {
                Refresh_Main_GridView();
            };
            #endregion
            #endregion

            #region 項目1資料表
            Item1gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 項目1字串修改
            Item1gridView.CustomColumnDisplayText += (s, e) =>
            {
                ConversionString(s, e, Item1gridControl);
            };
            #endregion
            #region 項目1聚焦功能
            Item1gridView.FocusedRowChanged += (s, ex) =>
            {
                FocuseMainGrid(Convert.ToInt32(Item1gridControl.Tag.ToString()));
            };
            #endregion
            #region 關鍵字搜尋
            Item1gridView.ColumnFilterChanged += (s, e) =>
            {
                FocuseMainGrid(Convert.ToInt32(Item1gridControl.Tag.ToString()));
            };
            #endregion
            #region 部門類別資料刷新
            btn_Item1_Refresh.Click += (s, e) =>
            {
                Refresh_Main_GridView();
            };
            #endregion
            #region 新增項目1
            btn_Item1_Add.Click += (s, e) =>
            {
                Refresh_API();
                if (ProductDepartmentSettings.Count > 0)
                {
                    ProductItemEditForm itemEditForm = new ProductItemEditForm(1, ProductDepartmentSettings, ProductItem1Settings, ProductItem2Settings, ProductItem3Settings, ProductItem4Settings, ProductItem5Settings, null, null, null, null, null, apiMethod, Form1);
                    if (itemEditForm.ShowDialog() == DialogResult.OK)
                    {
                        Refresh_Main_GridView();
                    }
                }
                else
                {
                    action.Caption = "部門未建立";
                    FlyoutDialog.Show(Form1, action);
                }

            };
            #endregion
            #region 修改項目1
            btn_Item1_Edit.Click += (s, e) =>
            {
                Refresh_API();
                if (ProductDepartmentSettings.Count > 0)
                {
                    ProductItemEditForm itemEditForm = new ProductItemEditForm(1, ProductDepartmentSettings, ProductItem1Settings, ProductItem2Settings, ProductItem3Settings, ProductItem4Settings, ProductItem5Settings, FocuseProductItem1Setting, null, null, null, null, apiMethod, Form1);
                    if (itemEditForm.ShowDialog() == DialogResult.OK)
                    {
                        Refresh_Main_GridView();
                    }
                }
                else
                {
                    action.Caption = "部門未建立";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 雙擊修改項目1
            Item1gridControl.DoubleClick += (s, e) =>
            {
                Refresh_API();
                if (ProductDepartmentSettings.Count > 0)
                {
                    ProductItemEditForm itemEditForm = new ProductItemEditForm(1, ProductDepartmentSettings, ProductItem1Settings, ProductItem2Settings, ProductItem3Settings, ProductItem4Settings, ProductItem5Settings, FocuseProductItem1Setting, null, null, null, null, apiMethod, Form1);
                    if (itemEditForm.ShowDialog() == DialogResult.OK)
                    {
                        Refresh_Main_GridView();
                    }
                }
                else
                {
                    action.Caption = "部門未建立";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 刪除項目1
            btn_Item1_Delete.Click += (s, e) =>
            {
                Delectaction.Description = $"刪除名稱 : {FocuseProductItem1Setting.Item1Name}";
                if (FlyoutDialog.Show(Form1, Delectaction) == DialogResult.Yes)
                {
                    string data = JsonConvert.SerializeObject(FocuseProductItem1Setting);
                    string response = apiMethod.Delete_ProductItem1(data);
                    if (response == "200")
                    {
                        Refresh_Main_GridView();
                        action.Caption = "刪除項目1成功";
                        action.Description = "";
                        FlyoutDialog.Show(Form1, action);
                    }
                    else
                    {
                        action.Caption = "刪除項目1失敗";
                        action.Description = "";
                        FlyoutDialog.Show(Form1, action);
                    }
                }
            };
            #endregion
            #region 部門類別資料刷新
            btn_Item1_Refresh.Click += (s, e) =>
            {
                Refresh_Main_GridView();
            };
            #endregion
            #endregion

            #region 項目2資料表
            Item2gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 項目2字串修改
            Item2gridView.CustomColumnDisplayText += (s, e) =>
            {
                ConversionString(s, e, Item2gridControl);
            };
            #endregion
            #region 項目2聚焦功能
            Item2gridView.FocusedRowChanged += (s, ex) =>
            {
                FocuseMainGrid(Convert.ToInt32(Item2gridControl.Tag.ToString()));
            };
            #endregion
            #region 關鍵字搜尋
            Item2gridView.ColumnFilterChanged += (s, e) =>
            {
                FocuseMainGrid(Convert.ToInt32(Item2gridControl.Tag.ToString()));
            };
            #endregion
            #region 部門類別資料刷新
            btn_Item2_Refresh.Click += (s, e) =>
            {
                Refresh_Main_GridView();
            };
            #endregion
            #region 新增項目2
            btn_Item2_Add.Click += (s, e) =>
            {
                Refresh_API();
                if (ProductDepartmentSettings.Count > 0 && ProductItem1Settings.Count > 0)
                {
                    ProductItemEditForm itemEditForm = new ProductItemEditForm(2, ProductDepartmentSettings, ProductItem1Settings, ProductItem2Settings, ProductItem3Settings, ProductItem4Settings, ProductItem5Settings, null, null, null, null, null, apiMethod, Form1);
                    if (itemEditForm.ShowDialog() == DialogResult.OK)
                    {
                        Refresh_Main_GridView();
                    }
                }
                else
                {
                    action.Caption = "部門或項目1未建立";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 修改項目2
            btn_Item2_Edit.Click += (s, e) =>
            {
                Refresh_API();
                if (ProductDepartmentSettings.Count > 0 && ProductItem1Settings.Count > 0)
                {
                    ProductItemEditForm itemEditForm = new ProductItemEditForm(2, ProductDepartmentSettings, ProductItem1Settings, ProductItem2Settings, ProductItem3Settings, ProductItem4Settings, ProductItem5Settings, null, FocuseProductItem2Setting, null, null, null, apiMethod, Form1);
                    if (itemEditForm.ShowDialog() == DialogResult.OK)
                    {
                        Refresh_Main_GridView();
                    }
                }
                else
                {
                    action.Caption = "部門或項目1未建立";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 雙擊修改項目2
            Item2gridControl.DoubleClick += (s, e) =>
            {
                Refresh_API();
                if (ProductDepartmentSettings.Count > 0 && ProductItem1Settings.Count > 0)
                {
                    ProductItemEditForm itemEditForm = new ProductItemEditForm(2, ProductDepartmentSettings, ProductItem1Settings, ProductItem2Settings, ProductItem3Settings, ProductItem4Settings, ProductItem5Settings, null, FocuseProductItem2Setting, null, null, null, apiMethod, Form1);
                    if (itemEditForm.ShowDialog() == DialogResult.OK)
                    {
                        Refresh_Main_GridView();
                    }
                }
                else
                {
                    action.Caption = "部門或項目1未建立";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 刪除項目2
            btn_Item2_Delete.Click += (s, e) =>
            {
                Delectaction.Description = $"刪除名稱 : {FocuseProductItem2Setting.Item2Name}";
                if (FlyoutDialog.Show(Form1, Delectaction) == DialogResult.Yes)
                {
                    string data = JsonConvert.SerializeObject(FocuseProductItem2Setting);
                    string response = apiMethod.Delete_ProductItem2(data);
                    if (response == "200")
                    {
                        Refresh_Main_GridView();
                        action.Caption = "刪除項目2成功";
                        action.Description = "";
                        FlyoutDialog.Show(Form1, action);
                    }
                    else
                    {
                        action.Caption = "刪除項目2失敗";
                        action.Description = "";
                        FlyoutDialog.Show(Form1, action);
                    }
                }
            };
            #endregion
            #region 部門類別資料刷新
            btn_Item2_Refresh.Click += (s, e) =>
            {
                Refresh_Main_GridView();
            };
            #endregion
            #endregion

            #region 項目3資料表
            Item3gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 項目3字串修改
            Item3gridView.CustomColumnDisplayText += (s, e) =>
            {
                ConversionString(s, e, Item3gridControl);
            };
            #endregion
            #region 項目3聚焦功能
            Item3gridView.FocusedRowChanged += (s, ex) =>
            {
                FocuseMainGrid(Convert.ToInt32(Item3gridControl.Tag.ToString()));
            };
            #endregion
            #region 關鍵字搜尋
            Item3gridView.ColumnFilterChanged += (s, e) =>
            {
                FocuseMainGrid(Convert.ToInt32(Item3gridControl.Tag.ToString()));
            };
            #endregion
            #region 部門類別資料刷新
            btn_Item3_Refresh.Click += (s, e) =>
            {
                Refresh_Main_GridView();
            };
            #endregion
            #region 新增項目3
            btn_Item3_Add.Click += (s, e) =>
            {
                Refresh_API();
                if (ProductDepartmentSettings.Count > 0 && ProductItem1Settings.Count > 0 && ProductItem2Settings.Count > 0)
                {
                    ProductItemEditForm itemEditForm = new ProductItemEditForm(3, ProductDepartmentSettings, ProductItem1Settings, ProductItem2Settings, ProductItem3Settings, ProductItem4Settings, ProductItem5Settings, null, null, null, null, null, apiMethod, Form1);
                    if (itemEditForm.ShowDialog() == DialogResult.OK)
                    {
                        Refresh_Main_GridView();
                    }
                }
                else
                {
                    action.Caption = "部門、項目1或項目2未建立";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 修改項目3
            btn_Item3_Edit.Click += (s, e) =>
            {
                Refresh_API();
                if (ProductDepartmentSettings.Count > 0 && ProductItem1Settings.Count > 0 && ProductItem2Settings.Count > 0)
                {
                    ProductItemEditForm itemEditForm = new ProductItemEditForm(3, ProductDepartmentSettings, ProductItem1Settings, ProductItem2Settings, ProductItem3Settings, ProductItem4Settings, ProductItem5Settings, null, null, FocuseProductItem3Setting, null, null, apiMethod, Form1);
                    if (itemEditForm.ShowDialog() == DialogResult.OK)
                    {
                        Refresh_Main_GridView();
                    }
                }
                else
                {
                    action.Caption = "部門、項目1或項目2未建立";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 雙擊修改項目3
            Item3gridControl.DoubleClick += (s, e) =>
            {
                Refresh_API();
                if (ProductDepartmentSettings.Count > 0 && ProductItem1Settings.Count > 0 && ProductItem2Settings.Count > 0)
                {
                    ProductItemEditForm itemEditForm = new ProductItemEditForm(3, ProductDepartmentSettings, ProductItem1Settings, ProductItem2Settings, ProductItem3Settings, ProductItem4Settings, ProductItem5Settings, null, null, FocuseProductItem3Setting, null, null, apiMethod, Form1);
                    if (itemEditForm.ShowDialog() == DialogResult.OK)
                    {
                        Refresh_Main_GridView();
                    }
                }
                else
                {
                    action.Caption = "部門、項目1或項目2未建立";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 刪除項目3
            btn_Item3_Delete.Click += (s, e) =>
            {
                Delectaction.Description = $"刪除名稱 : {FocuseProductItem3Setting.Item3Name}";
                if (FlyoutDialog.Show(Form1, Delectaction) == DialogResult.Yes)
                {
                    string data = JsonConvert.SerializeObject(FocuseProductItem3Setting);
                    string response = apiMethod.Delete_ProductItem3(data);
                    if (response == "200")
                    {
                        Refresh_Main_GridView();
                        action.Caption = "刪除項目3成功";
                        action.Description = "";
                        FlyoutDialog.Show(Form1, action);
                    }
                    else
                    {
                        action.Caption = "刪除項目3失敗";
                        action.Description = "";
                        FlyoutDialog.Show(Form1, action);
                    }
                }
            };
            #endregion
            #region 部門類別資料刷新
            btn_Item3_Refresh.Click += (s, e) =>
            {
                Refresh_Main_GridView();
            };
            #endregion
            #endregion

            #region 項目4資料表
            Item4gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 項目4字串修改
            Item4gridView.CustomColumnDisplayText += (s, e) =>
            {
                ConversionString(s, e, Item4gridControl);
            };
            #endregion
            #region 項目4聚焦功能
            Item4gridView.FocusedRowChanged += (s, ex) =>
            {
                FocuseMainGrid(Convert.ToInt32(Item4gridControl.Tag.ToString()));
            };
            #endregion
            #region 關鍵字搜尋
            Item4gridView.ColumnFilterChanged += (s, e) =>
            {
                FocuseMainGrid(Convert.ToInt32(Item4gridControl.Tag.ToString()));
            };
            #endregion
            #region 部門類別資料刷新
            btn_Item4_Refresh.Click += (s, e) =>
            {
                Refresh_Main_GridView();
            };
            #endregion
            #region 新增項目4
            btn_Item4_Add.Click += (s, e) =>
            {
                Refresh_API();
                if (ProductDepartmentSettings.Count > 0 && ProductItem1Settings.Count > 0 && ProductItem2Settings.Count > 0 && ProductItem3Settings.Count > 0)
                {
                    ProductItemEditForm itemEditForm = new ProductItemEditForm(4, ProductDepartmentSettings, ProductItem1Settings, ProductItem2Settings, ProductItem3Settings, ProductItem4Settings, ProductItem5Settings, null, null, null, null, null, apiMethod, Form1);
                    if (itemEditForm.ShowDialog() == DialogResult.OK)
                    {
                        Refresh_Main_GridView();
                    }
                }
                else
                {
                    action.Caption = "部門、項目1、項目2或項目3未建立";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 修改項目4
            btn_Item4_Edit.Click += (s, e) =>
            {
                Refresh_API();
                if (ProductDepartmentSettings.Count > 0 && ProductItem1Settings.Count > 0 && ProductItem2Settings.Count > 0 && ProductItem3Settings.Count > 0)
                {
                    ProductItemEditForm itemEditForm = new ProductItemEditForm(4, ProductDepartmentSettings, ProductItem1Settings, ProductItem2Settings, ProductItem3Settings, ProductItem4Settings, ProductItem5Settings, null, null, null, FocuseProductItem4Setting, null, apiMethod, Form1);
                    if (itemEditForm.ShowDialog() == DialogResult.OK)
                    {
                        Refresh_Main_GridView();
                    }
                }
                else
                {
                    action.Caption = "部門、項目1、項目2或項目3未建立";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 雙擊修改項目4
            Item4gridControl.DoubleClick += (s, e) =>
            {
                Refresh_API();
                if (ProductDepartmentSettings.Count > 0 && ProductItem1Settings.Count > 0 && ProductItem2Settings.Count > 0 && ProductItem3Settings.Count > 0)
                {
                    ProductItemEditForm itemEditForm = new ProductItemEditForm(4, ProductDepartmentSettings, ProductItem1Settings, ProductItem2Settings, ProductItem3Settings, ProductItem4Settings, ProductItem5Settings, null, null, null, FocuseProductItem4Setting, null, apiMethod, Form1);
                    if (itemEditForm.ShowDialog() == DialogResult.OK)
                    {
                        Refresh_Main_GridView();
                    }
                }
                else
                {
                    action.Caption = "部門、項目1、項目2或項目3未建立";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 刪除項目4
            btn_Item4_Delete.Click += (s, e) =>
            {
                Delectaction.Description = $"刪除名稱 : {FocuseProductItem4Setting.Item4Name}";
                if (FlyoutDialog.Show(Form1, Delectaction) == DialogResult.Yes)
                {
                    string data = JsonConvert.SerializeObject(FocuseProductItem4Setting);
                    string response = apiMethod.Delete_ProductItem4(data);
                    if (response == "200")
                    {
                        Refresh_Main_GridView();
                        action.Caption = "刪除項目4成功";
                        action.Description = "";
                        FlyoutDialog.Show(Form1, action);
                    }
                    else
                    {
                        action.Caption = "刪除項目4失敗";
                        action.Description = "";
                        FlyoutDialog.Show(Form1, action);
                    }
                }
            };
            #endregion
            #region 部門類別資料刷新
            btn_Item4_Refresh.Click += (s, e) =>
            {
                Refresh_Main_GridView();
            };
            #endregion
            #endregion

            #region 項目5資料表
            Item5gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 項目5字串修改
            Item5gridView.CustomColumnDisplayText += (s, e) =>
            {
                ConversionString(s, e, Item5gridControl);
            };
            #endregion
            #region 項目5聚焦功能
            Item5gridView.FocusedRowChanged += (s, ex) =>
            {
                FocuseMainGrid(Convert.ToInt32(Item5gridControl.Tag.ToString()));
            };
            #endregion
            #region 關鍵字搜尋
            Item5gridView.ColumnFilterChanged += (s, e) =>
            {
                FocuseMainGrid(Convert.ToInt32(Item5gridControl.Tag.ToString()));
            };
            #endregion
            #region 部門類別資料刷新
            btn_Item5_Refresh.Click += (s, e) =>
            {
                Refresh_Main_GridView();
            };
            #endregion
            #region 新增項目5
            btn_Item5_Add.Click += (s, e) =>
            {
                Refresh_API();
                if (ProductDepartmentSettings.Count > 0 && ProductItem1Settings.Count > 0 && ProductItem2Settings.Count > 0 && ProductItem3Settings.Count > 0 && ProductItem4Settings.Count > 0)
                {
                    ProductItemEditForm itemEditForm = new ProductItemEditForm(5, ProductDepartmentSettings, ProductItem1Settings, ProductItem2Settings, ProductItem3Settings, ProductItem4Settings, ProductItem5Settings, null, null, null, null, null, apiMethod, Form1);
                    if (itemEditForm.ShowDialog() == DialogResult.OK)
                    {
                        Refresh_Main_GridView();
                    }
                }
                else
                {
                    action.Caption = "部門、項目1、項目2、項目3或項目4未建立";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 修改項目5
            btn_Item5_Edit.Click += (s, e) =>
            {
                Refresh_API();
                if (ProductDepartmentSettings.Count > 0 && ProductItem1Settings.Count > 0 && ProductItem2Settings.Count > 0 && ProductItem3Settings.Count > 0 && ProductItem4Settings.Count > 0)
                {
                    ProductItemEditForm itemEditForm = new ProductItemEditForm(5, ProductDepartmentSettings, ProductItem1Settings, ProductItem2Settings, ProductItem3Settings, ProductItem4Settings, ProductItem5Settings, null, null, null, null, FocuseProductItem5Setting, apiMethod, Form1);
                    if (itemEditForm.ShowDialog() == DialogResult.OK)
                    {
                        Refresh_Main_GridView();
                    }
                }
                else
                {
                    action.Caption = "部門、項目1、項目2、項目3或項目4未建立";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 雙擊修改項目5
            Item5gridControl.DoubleClick += (s, e) =>
            {
                Refresh_API();
                if (ProductDepartmentSettings.Count > 0 && ProductItem1Settings.Count > 0 && ProductItem2Settings.Count > 0 && ProductItem3Settings.Count > 0 && ProductItem4Settings.Count > 0)
                {
                    ProductItemEditForm itemEditForm = new ProductItemEditForm(5, ProductDepartmentSettings, ProductItem1Settings, ProductItem2Settings, ProductItem3Settings, ProductItem4Settings, ProductItem5Settings, null, null, null, null, FocuseProductItem5Setting, apiMethod, Form1);
                    if (itemEditForm.ShowDialog() == DialogResult.OK)
                    {
                        Refresh_Main_GridView();
                    }
                }
                else
                {
                    action.Caption = "部門、項目1、項目2、項目3或項目4未建立";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 刪除項目5
            btn_Item5_Delete.Click += (s, e) =>
            {
                Delectaction.Description = $"刪除名稱 : {FocuseProductItem5Setting.Item5Name}";
                if (FlyoutDialog.Show(Form1, Delectaction) == DialogResult.Yes)
                {
                    string data = JsonConvert.SerializeObject(FocuseProductItem5Setting);
                    string response = apiMethod.Delete_ProductItem5(data);
                    if (response == "200")
                    {
                        Refresh_Main_GridView();
                        action.Caption = "刪除項目5成功";
                        action.Description = "";
                        FlyoutDialog.Show(Form1, action);
                    }
                    else
                    {
                        action.Caption = "刪除項目5失敗";
                        action.Description = "";
                        FlyoutDialog.Show(Form1, action);
                    }
                }
            };
            #endregion
            #region 部門類別資料刷新
            btn_Item5_Refresh.Click += (s, e) =>
            {
                Refresh_Main_GridView();
            };
            #endregion
            #region 報表匯出
            btn_Item5_Export.Click += (s, e) =>
            {
                if (Item5gridControl != null)
                {
                    using (SaveFileDialog saveFile = new SaveFileDialog())
                    {
                        saveFile.Filter = "*.xlsx | *.xlsx";
                        saveFile.DefaultExt = "xlsx";//設定副檔名預設格式
                        saveFile.AddExtension = true;//設定自動在檔名中新增副檔名
                        saveFile.FileName = "項目分類報表";
                        if (saveFile.ShowDialog() == DialogResult.OK)
                        {
                            var options = new XlsxExportOptions();
                            options.TextExportMode = TextExportMode.Text;
                            Item5gridControl.ExportToXlsx(saveFile.FileName, options);
                        }
                    }
                }
            };
            #endregion
            #endregion

            #region 產品資料表
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 產品資訊報表按鈕
            RepositoryItemButtonEdit Productedit = new RepositoryItemButtonEdit();
            Productedit.ButtonClick += (s, e) =>
            {
                FocuseSecondGrid();
                if (e.Button.Kind == ButtonPredefines.Plus)
                {
                    if (FocuseProductSetting.FileName != null)
                    {
                        if (FocuseProductSetting.FileName != "")
                        {
                            byte[] File = apiMethod.Get_ProductAttachmentFile("string", FocuseProductSetting.ProductName, FocuseProductSetting.FileName);
                            SaveFile(File);
                        }
                    }
                }
            };
            Productedit.Buttons[0].Kind = ButtonPredefines.Plus;
            Productedit.Buttons[0].Caption = "下載";
            Productedit.TextEditStyle = TextEditStyles.DisableTextEditor;
            ProductgridControl.RepositoryItems.Add(Productedit);
            gridView1.Columns["FileName"].ColumnEdit = Productedit;
            gridView1.Columns["FileName"].ShowButtonMode = ShowButtonModeEnum.ShowAlways;
            #endregion
            #region 報表聚焦功能
            gridView1.FocusedRowChanged += (s, ex) =>
            {
                FocuseSecondGrid();
            };
            #endregion
            #region 產品字串修改
            gridView1.CustomColumnDisplayText += (s, e) =>
            {
                if (e.Column.FieldName == "ProductType")
                {
                    string Index = e.DisplayText.ToString();
                    switch (Index)
                    {
                        case "0":
                            {
                                e.DisplayText = "設備";
                            }
                            break;
                        case "1":
                            {
                                e.DisplayText = "零件";
                            }
                            break;
                    }
                }
                else if (e.Column.FieldName == "ProductCompanyNumber")
                {
                    string Index = e.DisplayText.ToString();
                    if (CompanySettings != null)
                    {
                        CompanySetting company = CompanySettings.SingleOrDefault(g => g.CompanyNumber == Index);
                        if (company != null)
                        {
                            e.DisplayText = company.CompanyName;
                        }
                    }
                }
            };
            #endregion
            #region 關鍵字搜尋
            gridView1.ColumnFilterChanged += (s, e) =>
            {
                FocuseSecondGrid();
            };
            #endregion
            #region 新增產品
            btn_Product_Add.Click += (s, e) =>
            {
                ProductEditForm product = new ProductEditForm(ProductSettings, null, CompanySettings, ProductDepartmentSettings, ProductItem1Settings, ProductItem2Settings, ProductItem3Settings, ProductItem4Settings, ProductItem5Settings, apiMethod, Form1);
                if (product.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Second_GridView("");
                }
            };
            #endregion
            #region 修改產品
            btn_Product_Edit.Click += (s, e) =>
            {
                ProductEditForm product = new ProductEditForm(ProductSettings, FocuseProductSetting, CompanySettings, ProductDepartmentSettings, ProductItem1Settings, ProductItem2Settings, ProductItem3Settings, ProductItem4Settings, ProductItem5Settings, apiMethod, Form1);
                if (product.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Second_GridView("");
                }
            };
            #endregion
            #region 雙擊修改產品
            ProductgridControl.DoubleClick += (s, e) =>
            {
                FocuseSecondGrid();
                ProductEditForm product = new ProductEditForm(ProductSettings, FocuseProductSetting, CompanySettings, ProductDepartmentSettings, ProductItem1Settings, ProductItem2Settings, ProductItem3Settings, ProductItem4Settings, ProductItem5Settings, apiMethod, Form1);
                if (product.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Second_GridView("");
                }
            };
            #endregion
            #region 刪除產品
            btn_Product_Delete.Click += (s, e) =>
            {
                FocuseSecondGrid();
                Delectaction.Description = $"刪除編號 : {FocuseProductSetting.ProductNumber}";
                if (FlyoutDialog.Show(Form1, Delectaction) == DialogResult.Yes)
                {
                    string data = JsonConvert.SerializeObject(FocuseProductSetting);
                    string response = apiMethod.Delete_Product(data);
                    if (response == "200")
                    {
                        Refresh_Second_GridView("0");
                        action.Caption = "刪除廠商通訊錄成功";
                        FlyoutDialog.Show(Form1, action);
                    }
                    else
                    {
                        action.Caption = "刪除廠商通訊錄失敗";
                        FlyoutDialog.Show(Form1, action);
                    }
                }
            };
            #endregion
            #region 產品資料刷新
            btn_Product_Refresh.Click += (s, e) =>
              {
                  handle = SplashScreenManager.ShowOverlayForm(FindForm());
                  if (ProductCategorySettings == null)
                  {
                      Refresh_Main_GridView();
                  }
                  Refresh_Second_GridView("");
                  CloseProgressPanel(handle);
              };
            #endregion
            #endregion
        }

        #region 字串修改方法
        private void ConversionString(object s, CustomColumnDisplayTextEventArgs e, GridControl gridControl)
        {
            int gridindex = Convert.ToInt32(gridControl.Tag);
            string Index = "";
            int RowIndex = 0;
            ProductDepartmentSetting productDepartment = null;
            ProductItem1Setting productItem1 = null;
            ProductItem2Setting productItem2 = null;
            ProductItem3Setting productItem3 = null;
            ProductItem4Setting productItem4 = null;
            ProductItem5Setting productItem5 = null;
            if (e.Column.FieldName == "DepartmentNumber")
            {
                Index = e.DisplayText.ToString();
                if (ProductDepartmentSettings != null)
                {
                    productDepartment = ProductDepartmentSettings.SingleOrDefault(g => g.DepartmentNumber == Index);
                    if (productDepartment != null)
                    {
                        e.DisplayText = $"({productDepartment.DepartmentNumber}){productDepartment.DepartmentName}";
                    }
                }
            }
            else if (e.Column.FieldName == "Item1Number" && gridindex > 1)
            {
                Index = e.DisplayText.ToString();
                RowIndex = e.ListSourceRowIndex;
                if (ProductItem1Settings != null)
                {
                    switch (gridindex)
                    {
                        case 2:
                            {
                                productItem2 = ProductItem2Settings[RowIndex];
                                productItem1 = ProductItem1Settings.SingleOrDefault(g => g.DepartmentNumber == productItem2.DepartmentNumber && g.Item1Number == productItem2.Item1Number);
                                if (productItem1 != null)
                                {
                                    e.DisplayText = $"({productItem1.Item1Number}){productItem1.Item1Name}";
                                }
                            }
                            break;
                        case 3:
                            {
                                productItem3 = ProductItem3Settings[RowIndex];
                                productItem1 = ProductItem1Settings.SingleOrDefault(g => g.DepartmentNumber == productItem3.DepartmentNumber && g.Item1Number == productItem3.Item1Number);
                                if (productItem1 != null)
                                {
                                    e.DisplayText = $"({productItem1.Item1Number}){productItem1.Item1Name}";
                                }
                            }
                            break;
                        case 4:
                            {
                                productItem4 = ProductItem4Settings[RowIndex];
                                productItem1 = ProductItem1Settings.SingleOrDefault(g => g.DepartmentNumber == productItem4.DepartmentNumber && g.Item1Number == productItem4.Item1Number);
                                if (productItem1 != null)
                                {
                                    e.DisplayText = $"({productItem1.Item1Number}){productItem1.Item1Name}";
                                }
                            }
                            break;
                        case 5:
                            {
                                productItem5 = ProductItem5Settings[RowIndex];
                                productItem1 = ProductItem1Settings.SingleOrDefault(g => g.DepartmentNumber == productItem5.DepartmentNumber && g.Item1Number == productItem5.Item1Number);
                                if (productItem1 != null)
                                {
                                    e.DisplayText = $"({productItem1.Item1Number}){productItem1.Item1Name}";
                                }
                            }
                            break;
                    }
                }
            }
            else if (e.Column.FieldName == "Item2Number" && gridindex > 2)
            {
                Index = e.DisplayText.ToString();
                RowIndex = e.ListSourceRowIndex;
                if (ProductItem1Settings != null)
                {
                    switch (gridindex)
                    {
                        case 3:
                            {
                                productItem3 = ProductItem3Settings[RowIndex];
                                productItem2 = ProductItem2Settings.SingleOrDefault(g => g.DepartmentNumber == productItem3.DepartmentNumber
                                  && g.Item1Number == productItem3.Item1Number && g.Item2Number == productItem3.Item2Number);
                                if (productItem2 != null)
                                {
                                    e.DisplayText = $"({productItem2.Item2Number}){productItem2.Item2Name}";
                                }
                            }
                            break;
                        case 4:
                            {
                                productItem4 = ProductItem4Settings[RowIndex];
                                productItem2 = ProductItem2Settings.SingleOrDefault(g => g.DepartmentNumber == productItem4.DepartmentNumber
                                 && g.Item1Number == productItem4.Item1Number && g.Item2Number == productItem4.Item2Number);
                                if (productItem2 != null)
                                {
                                    e.DisplayText = $"({productItem2.Item2Number}){productItem2.Item2Name}";
                                }
                            }
                            break;
                        case 5:
                            {
                                productItem5 = ProductItem5Settings[RowIndex];
                                productItem2 = ProductItem2Settings.SingleOrDefault(g => g.DepartmentNumber == productItem5.DepartmentNumber
                                 && g.Item1Number == productItem5.Item1Number && g.Item2Number == productItem5.Item2Number);
                                if (productItem2 != null)
                                {
                                    e.DisplayText = $"({productItem2.Item2Number}){productItem2.Item2Name}";
                                }
                            }
                            break;
                    }
                }
            }
            else if (e.Column.FieldName == "Item3Number" && gridindex > 3)
            {
                Index = e.DisplayText.ToString();
                RowIndex = e.ListSourceRowIndex;
                if (ProductItem1Settings != null)
                {
                    switch (gridindex)
                    {
                        case 4:
                            {
                                productItem4 = ProductItem4Settings[RowIndex];
                                productItem3 = ProductItem3Settings.SingleOrDefault(g => g.DepartmentNumber == productItem4.DepartmentNumber
                                && g.Item1Number == productItem4.Item1Number && g.Item2Number == productItem4.Item2Number && g.Item3Number == productItem4.Item3Number);
                                if (productItem3 != null)
                                {
                                    e.DisplayText = $"({productItem3.Item3Number}){productItem3.Item3Name}";
                                }
                            }
                            break;
                        case 5:
                            {
                                productItem5 = ProductItem5Settings[RowIndex];
                                productItem3 = ProductItem3Settings.SingleOrDefault(g => g.DepartmentNumber == productItem5.DepartmentNumber
                                && g.Item1Number == productItem5.Item1Number && g.Item2Number == productItem5.Item2Number && g.Item3Number == productItem5.Item3Number);
                                if (productItem3 != null)
                                {
                                    e.DisplayText = $"({productItem3.Item3Number}){productItem3.Item3Name}";
                                }
                            }
                            break;
                    }
                }
            }
            else if (e.Column.FieldName == "Item4Number" && gridindex > 4)
            {
                Index = e.DisplayText.ToString();
                RowIndex = e.ListSourceRowIndex;
                if (ProductItem1Settings != null)
                {
                    switch (gridindex)
                    {
                        case 5:
                            {
                                productItem5 = ProductItem5Settings[RowIndex];
                                productItem4 = ProductItem4Settings.SingleOrDefault(g => g.DepartmentNumber == productItem5.DepartmentNumber
                                && g.Item1Number == productItem5.Item1Number && g.Item2Number == productItem5.Item2Number && g.Item3Number == productItem5.Item3Number && g.Item4Number == productItem5.Item4Number);
                                if (productItem4 != null)
                                {
                                    e.DisplayText = $"({productItem4.Item4Number}){productItem4.Item4Name}";
                                }
                            }
                            break;
                    }
                }
            }
        }
        #endregion
        #region 聚焦次資料表功能
        /// <summary>
        /// 聚焦次資料表功能
        /// </summary>
        private void FocuseSecondGrid()
        {
            if (gridView1.FocusedRowHandle > -1 && gridView1.DataRowCount > 0)
            {
                FocuseProductSetting.ProductCompanyNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductCompanyNumber").ToString();
                FocuseProductSetting.ProductNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductNumber").ToString();
                FocuseProductSetting.ProductName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductName").ToString();
                FocuseProductSetting.ProductModel = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductModel").ToString();
                FocuseProductSetting.ProductType = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductType").ToString());
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductCategory") != null)
                {
                    FocuseProductSetting.ProductCategory = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ProductCategory").ToString();
                }
                else
                {
                    FocuseProductSetting.ProductCategory = "";
                }
                FocuseProductSetting.FootPrint = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FootPrint").ToString();
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Remark") != null)
                {
                    FocuseProductSetting.Remark = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Remark").ToString();
                }
                else
                {
                    FocuseProductSetting.Remark = "";
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Explanation") != null)
                {
                    FocuseProductSetting.Explanation = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Explanation").ToString();
                }
                else
                {
                    FocuseProductSetting.Explanation = "";
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FileName") != null)
                {
                    FocuseProductSetting.FileName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FileName").ToString();
                }
                else
                {
                    FocuseProductSetting.FileName = "";
                }
            }
            else
            {
                FocuseProductSetting = new ProductSetting();
            }
        }
        #endregion
        #region 聚焦主資料表功能
        /// <summary>
        /// 聚焦主資料表功能
        /// </summary>
        private void FocuseMainGrid(int Tag)
        {
            switch (Tag)
            {
                case 0://部門
                    {
                        if (DepartmentgridView.FocusedRowHandle > -1 && DepartmentgridView.DataRowCount > 0)
                        {
                            FocuseProductDepartmentSetting.DepartmentNumber = DepartmentgridView.GetRowCellValue(DepartmentgridView.FocusedRowHandle, "DepartmentNumber").ToString();
                            if (DepartmentgridView.GetRowCellValue(DepartmentgridView.FocusedRowHandle, "DepartmentName") != null)
                            {
                                FocuseProductDepartmentSetting.DepartmentName = DepartmentgridView.GetRowCellValue(DepartmentgridView.FocusedRowHandle, "DepartmentName").ToString();
                            }
                            else
                            {
                                FocuseProductDepartmentSetting.DepartmentName = "";
                            }
                        }
                        else
                        {
                            FocuseProductDepartmentSetting = new ProductDepartmentSetting();
                        }
                    }
                    break;
                case 1://項目1
                    {
                        if (Item1gridView.FocusedRowHandle > -1 && Item1gridView.DataRowCount > 0)
                        {
                            FocuseProductItem1Setting.DepartmentNumber = Item1gridView.GetRowCellValue(Item1gridView.FocusedRowHandle, "DepartmentNumber").ToString();
                            FocuseProductItem1Setting.Item1Number = Item1gridView.GetRowCellValue(Item1gridView.FocusedRowHandle, "Item1Number").ToString();
                            if (Item1gridView.GetRowCellValue(Item1gridView.FocusedRowHandle, "Item1Name") != null)
                            {
                                FocuseProductItem1Setting.Item1Name = Item1gridView.GetRowCellValue(Item1gridView.FocusedRowHandle, "Item1Name").ToString();
                            }
                            else
                            {
                                FocuseProductItem1Setting.Item1Name = "";
                            }
                        }
                        else
                        {
                            FocuseProductItem1Setting = new ProductItem1Setting();
                        }
                    }
                    break;
                case 2://項目2
                    {
                        if (Item2gridView.FocusedRowHandle > -1 && Item2gridView.DataRowCount > 0)
                        {
                            FocuseProductItem2Setting.DepartmentNumber = Item2gridView.GetRowCellValue(Item2gridView.FocusedRowHandle, "DepartmentNumber").ToString();
                            FocuseProductItem2Setting.Item1Number = Item2gridView.GetRowCellValue(Item2gridView.FocusedRowHandle, "Item1Number").ToString();
                            FocuseProductItem2Setting.Item2Number = Item2gridView.GetRowCellValue(Item2gridView.FocusedRowHandle, "Item2Number").ToString();
                            if (Item2gridView.GetRowCellValue(Item2gridView.FocusedRowHandle, "Item2Name") != null)
                            {
                                FocuseProductItem2Setting.Item2Name = Item2gridView.GetRowCellValue(Item2gridView.FocusedRowHandle, "Item2Name").ToString();
                            }
                            else
                            {
                                FocuseProductItem2Setting.Item2Name = "";
                            }
                        }
                        else
                        {
                            FocuseProductItem2Setting = new ProductItem2Setting();
                        }
                    }
                    break;
                case 3://項目3
                    {
                        if (Item3gridView.FocusedRowHandle > -1 && Item3gridView.DataRowCount > 0)
                        {
                            FocuseProductItem3Setting.DepartmentNumber = Item3gridView.GetRowCellValue(Item3gridView.FocusedRowHandle, "DepartmentNumber").ToString();
                            FocuseProductItem3Setting.Item1Number = Item3gridView.GetRowCellValue(Item3gridView.FocusedRowHandle, "Item1Number").ToString();
                            FocuseProductItem3Setting.Item2Number = Item3gridView.GetRowCellValue(Item3gridView.FocusedRowHandle, "Item2Number").ToString();
                            FocuseProductItem3Setting.Item3Number = Item3gridView.GetRowCellValue(Item3gridView.FocusedRowHandle, "Item3Number").ToString();
                            if (Item3gridView.GetRowCellValue(Item3gridView.FocusedRowHandle, "Item3Name") != null)
                            {
                                FocuseProductItem3Setting.Item3Name = Item3gridView.GetRowCellValue(Item3gridView.FocusedRowHandle, "Item3Name").ToString();
                            }
                            else
                            {
                                FocuseProductItem3Setting.Item3Name = "";
                            }
                        }
                        else
                        {
                            FocuseProductItem3Setting = new ProductItem3Setting();
                        }
                    }
                    break;
                case 4://項目4
                    {
                        if (Item4gridView.FocusedRowHandle > -1 && Item4gridView.DataRowCount > 0)
                        {
                            FocuseProductItem4Setting.DepartmentNumber = Item4gridView.GetRowCellValue(Item4gridView.FocusedRowHandle, "DepartmentNumber").ToString();
                            FocuseProductItem4Setting.Item1Number = Item4gridView.GetRowCellValue(Item4gridView.FocusedRowHandle, "Item1Number").ToString();
                            FocuseProductItem4Setting.Item2Number = Item4gridView.GetRowCellValue(Item4gridView.FocusedRowHandle, "Item2Number").ToString();
                            FocuseProductItem4Setting.Item3Number = Item4gridView.GetRowCellValue(Item4gridView.FocusedRowHandle, "Item3Number").ToString();
                            FocuseProductItem4Setting.Item4Number = Item4gridView.GetRowCellValue(Item4gridView.FocusedRowHandle, "Item4Number").ToString();
                            if (Item4gridView.GetRowCellValue(Item4gridView.FocusedRowHandle, "Item4Name") != null)
                            {
                                FocuseProductItem4Setting.Item4Name = Item4gridView.GetRowCellValue(Item4gridView.FocusedRowHandle, "Item4Name").ToString();
                            }
                            else
                            {
                                FocuseProductItem4Setting.Item4Name = "";
                            }
                        }
                        else
                        {
                            FocuseProductItem4Setting = new ProductItem4Setting();
                        }
                    }
                    break;
                case 5://項目5
                    {
                        if (Item5gridView.FocusedRowHandle > -1 && Item5gridView.DataRowCount > 0)
                        {
                            FocuseProductItem5Setting.DepartmentNumber = Item5gridView.GetRowCellValue(Item5gridView.FocusedRowHandle, "DepartmentNumber").ToString();
                            FocuseProductItem5Setting.Item1Number = Item5gridView.GetRowCellValue(Item5gridView.FocusedRowHandle, "Item1Number").ToString();
                            FocuseProductItem5Setting.Item2Number = Item5gridView.GetRowCellValue(Item5gridView.FocusedRowHandle, "Item2Number").ToString();
                            FocuseProductItem5Setting.Item3Number = Item5gridView.GetRowCellValue(Item5gridView.FocusedRowHandle, "Item3Number").ToString();
                            FocuseProductItem5Setting.Item4Number = Item5gridView.GetRowCellValue(Item5gridView.FocusedRowHandle, "Item4Number").ToString();
                            FocuseProductItem5Setting.Item5Number = Item5gridView.GetRowCellValue(Item5gridView.FocusedRowHandle, "Item5Number").ToString();
                            if (Item5gridView.GetRowCellValue(Item5gridView.FocusedRowHandle, "Item5Name") != null)
                            {
                                FocuseProductItem5Setting.Item5Name = Item5gridView.GetRowCellValue(Item5gridView.FocusedRowHandle, "Item5Name").ToString();
                            }
                            else
                            {
                                FocuseProductItem5Setting.Item5Name = "";
                            }
                        }
                        else
                        {
                            FocuseProductItem5Setting = new ProductItem5Setting();
                        }
                    }
                    break;
            }
        }
        #endregion
        #region 下載檔案功能
        private void SaveFile(byte[] File)
        {
            if (File != null)
            {
                if (File.Length > 133)
                {
                    saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = FocuseProductSetting.FileName;
                    saveFileDialog.Title = "Save File Path";
                    saveFileDialog.Filter = "All|*.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream data = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                        {
                            data.Write(File, 0, File.Length);
                            data.Close();
                        }
                        action.Caption = "下載檔案成功";
                        action.Description = "";
                        FlyoutDialog.Show(Form1, action);
                    }
                }
                else
                {
                    action.Caption = "下載檔案錯誤";
                    action.Description = "伺服器找不到此檔案";
                    FlyoutDialog.Show(Form1, action);
                }
            }
            else
            {
                apiMethod.ClientFlag = false;
                action.Caption = "下載檔案錯誤";
                action.Description = apiMethod.ErrorStr;
                FlyoutDialog.Show(Form1, action);
            }
        }
        #endregion
        public override void Refresh_Main_GridView()
        {
            handle = SplashScreenManager.ShowOverlayForm(FindForm());
            Refresh_API();
            for (int i = 0; i < length; i++)
            {
                //ProductCategorySettings = apiMethod.Get_ProductGategory(); //不使用
                if (ProductDepartmentSettings != null && ProductItem1Settings != null && ProductItem2Settings != null && ProductItem3Settings != null && ProductItem4Settings != null && ProductItem5Settings != null)
                {
                    DepartmentgridControl.DataSource = ProductDepartmentSettings;
                    Item1gridControl.DataSource = ProductItem1Settings;
                    Item2gridControl.DataSource = ProductItem2Settings;
                    Item3gridControl.DataSource = ProductItem3Settings;
                    Item4gridControl.DataSource = ProductItem4Settings;
                    Item5gridControl.DataSource = ProductItem5Settings;
                    Item5gridView.Columns["DepartmentNumber"].Group();
                    Item5gridView.Columns["Item1Number"].Group();
                    Item5gridView.Columns["Item2Number"].Group();
                    Item5gridView.Columns["Item3Number"].Group();
                    Item5gridView.Columns["Item4Number"].Group();
                    for (int item = 0; item < Item1gridView.Columns.Count; item++)
                    {
                        Item1gridView.Columns[item].BestFit();
                    }
                    for (int item = 0; item < Item2gridView.Columns.Count; item++)
                    {
                        Item2gridView.Columns[item].BestFit();
                    }
                    for (int item = 0; item < Item3gridView.Columns.Count; item++)
                    {
                        Item3gridView.Columns[item].BestFit();
                    }
                    for (int item = 0; item < Item4gridView.Columns.Count; item++)
                    {
                        Item4gridView.Columns[item].BestFit();
                    }
                    //for (int item = 0; item < Item5gridView.Columns.Count; item++)
                    //{
                    //Item5gridView.Columns[item].BestFit();
                    //}
                    Item5gridView.ExpandAllGroups();
                    Refresh_Second_GridView("");
                    break;
                }
            }
            CloseProgressPanel(handle);
        }
        public override void Refresh_Second_GridView(string Number)
        {
            for (int x = 0; x < length; x++)
            {
                ProductSettings = apiMethod.Get_Product();
                if (ProductSettings != null)
                {
                    ProductgridControl.DataSource = ProductSettings;
                    for (int i = 0; i < gridView1.Columns.Count; i++)
                    {
                        gridView1.Columns[i].BestFit();
                    }
                    break;
                }
            }
        }
        private void Refresh_API()
        {
            for (int i = 0; i < length; i++)
            {
                CompanySettings = apiMethod.Get_Company();
                if (CompanySettings != null)
                {
                    break;
                }
            }
            for (int i = 0; i < length; i++)
            {
                ProductDepartmentSettings = apiMethod.Get_ProductDepartment();
                if (ProductDepartmentSettings != null)
                {
                    break;
                }
            }
            for (int i = 0; i < length; i++)
            {
                ProductItem1Settings = apiMethod.Get_ProductItem1();
                if (ProductItem1Settings != null)
                {
                    break;
                }
            }
            for (int i = 0; i < length; i++)
            {
                ProductItem2Settings = apiMethod.Get_ProductItem2();
                if (ProductItem2Settings != null)
                {
                    break;
                }
            }
            for (int i = 0; i < length; i++)
            {
                ProductItem3Settings = apiMethod.Get_ProductItem3();
                if (ProductItem3Settings != null)
                {
                    break;
                }
            }
            for (int i = 0; i < length; i++)
            {
                ProductItem4Settings = apiMethod.Get_ProductItem4();
                if (ProductItem4Settings != null)
                {
                    break;
                }
            }
            for (int i = 0; i < length; i++)
            {
                ProductItem5Settings = apiMethod.Get_ProductItem5();
                if (ProductItem5Settings != null)
                {
                    break;
                }
            }
        }
        public override void Refresh_Token()
        {
            if (Form1.EmployeeSetting.Token != 2)
            {
                btn_Product_Delete.Visible = false;
                btn_Department_Delete.Visible = false;
                btn_Item1_Delete.Visible = false;
                btn_Item2_Delete.Visible = false;
                btn_Item3_Delete.Visible = false;
                btn_Item4_Delete.Visible = false;
                btn_Item5_Delete.Visible = false;
            }
            else
            {
                btn_Product_Delete.Visible = true;
                btn_Department_Delete.Visible = true;
                btn_Item1_Delete.Visible = true;
                btn_Item2_Delete.Visible = true;
                btn_Item3_Delete.Visible = true;
                btn_Item4_Delete.Visible = true;
                btn_Item5_Delete.Visible = true;
            }
        }
    }
}
