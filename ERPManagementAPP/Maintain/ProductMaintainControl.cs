using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using ERPManagementAPP.Maintain.ProductMaintainForm;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        /// 總產品資料
        /// </summary>
        private List<ProductSetting> ProductSettings { get; set; } = new List<ProductSetting>();
        /// <summary>
        /// 總產品類別資料
        /// </summary>
        private List<ProductCategorySetting> ProductCategorySettings { get; set; } = new List<ProductCategorySetting>();
        /// <summary>
        /// 總廠商資料
        /// </summary>
        private List<CompanySetting> CompanySettings { get; set; }
        public ProductMaintainControl(APIMethod APIMethod, Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            apiMethod = APIMethod;
            if (Form1.TokenEnumIndex > 0)
            {
                Refresh_Main_GridView();
            }
            action.Commands.Add(FlyoutCommand.Yes);
            #region 產品類別資料表
            gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            #region 產品類別聚焦功能
            gridView2.FocusedRowChanged += (s, ex) =>
            {
                FocuseMainGrid();
            };
            #endregion
            #region 關鍵字搜尋
            gridView2.ColumnFilterChanged += (s, e) =>
            {
                FocuseMainGrid();
            };
            #endregion
            #region 新增產品類別
            btn_ProductGategory_Add.Click += (s, e) =>
            {
                Refresh_API();
                ProductCategoryEditForm productCategory = new ProductCategoryEditForm(ProductCategorySettings, null, apiMethod, Form1);
                if (productCategory.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                    Refresh_Second_GridView("");
                }
            };
            #endregion
            #region 修改產品類別
            btn_ProductGategory_Edit.Click += (s, e) =>
            {
                Refresh_API();
                ProductCategoryEditForm productCategory = new ProductCategoryEditForm(ProductCategorySettings, FocuseProductCategorySetting, apiMethod, Form1);
                if (productCategory.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                    Refresh_Second_GridView("");
                }
            };
            #endregion
            #region 雙擊修改產品類別
            ProductCategorygridControl.DoubleClick += (s, e) =>
            {
                Refresh_API();
                FocuseMainGrid();
                ProductCategoryEditForm productCategory = new ProductCategoryEditForm(ProductCategorySettings, FocuseProductCategorySetting, apiMethod, Form1);
                if (productCategory.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Main_GridView();
                    Refresh_Second_GridView("");
                }
            };
            #endregion
            #region 刪除產品類別
            btn_ProductGategory_Delete.Click += (s, e) =>
            {
                FocuseMainGrid();
                string data = JsonConvert.SerializeObject(FocuseProductCategorySetting);
                string response = apiMethod.Delete_ProductGategory(data);
                if (response == "200")
                {
                    Refresh_Main_GridView();
                    action.Caption = "刪除廠商通訊錄成功";
                    action.Description = "";
                    FlyoutDialog.Show(Form1, action);
                }
                else
                {
                    action.Caption = "刪除廠商通訊錄失敗";
                    action.Description = "";
                    FlyoutDialog.Show(Form1, action);
                }
            };
            #endregion
            #region 產品類別資料刷新
            btn_ProductGategory_Refresh.Click += (s, e) =>
            {
                Refresh_Main_GridView();
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
            #region 關鍵字搜尋
            gridView1.ColumnFilterChanged += (s, e) =>
            {
                FocuseSecondGrid();
            };
            #endregion
            #region 新增產品
            btn_Product_Add.Click += (s, e) =>
            {
                ProductEditForm product = new ProductEditForm(ProductSettings, null, CompanySettings, ProductCategorySettings, apiMethod, Form1);
                if (product.ShowDialog() == DialogResult.OK)
                {
                    Refresh_Second_GridView("");
                }
            };
            #endregion
            #region 修改產品
            btn_Product_Edit.Click += (s, e) =>
            {
                ProductEditForm product = new ProductEditForm(ProductSettings, FocuseProductSetting, CompanySettings, ProductCategorySettings, apiMethod, Form1);
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
                ProductEditForm product = new ProductEditForm(ProductSettings, FocuseProductSetting, CompanySettings, ProductCategorySettings, apiMethod, Form1);
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
            };
            #endregion
            #region 產品資料刷新
            btn_Product_Refresh.Click += (s, e) =>
              {
                  Refresh_Second_GridView("");
              };
            #endregion
            #endregion
        }
        #region 產品字串修改
        /// <summary>
        /// 產品字串修改
        /// </summary>
        private void ChangeGridStr()
        {
            gridView1.CustomDrawCell += (s, e) =>
            {
                if (e.Column.FieldName == "ProductType")
                {
                    e.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                    string Index = e.CellValue.ToString();
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
                else if (e.Column.FieldName == "ProductCategory")
                {
                    if (e.CellValue != null)
                    {
                        string Index = e.CellValue.ToString();
                        foreach (var item in ProductCategorySettings)
                        {
                            if (item.CategoryNumber == Index)
                            {
                                e.DisplayText = item.CategoryName;
                            }
                        }
                    }
                }
            };
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
        private void FocuseMainGrid()
        {
            if (gridView2.FocusedRowHandle > -1 && gridView2.DataRowCount > 0)
            {
                FocuseProductCategorySetting.CategoryNumber = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "CategoryNumber").ToString();
                if (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "CategoryName") != null)
                {
                    FocuseProductCategorySetting.CategoryName = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "CategoryName").ToString();
                }
                else
                {
                    FocuseProductCategorySetting.CategoryName = "";
                }
            }
            else
            {
                FocuseProductCategorySetting = new ProductCategorySetting();
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
            Refresh_API();
            ProductCategorySettings = apiMethod.Get_ProductGategory();
            ProductCategorygridControl.DataSource = ProductCategorySettings;
            Refresh_Second_GridView("");
        }
        public override void Refresh_Second_GridView(string Number)
        {
            ProductSettings = apiMethod.Get_Product();
            ProductgridControl.DataSource = ProductSettings;
            ChangeGridStr();
        }
        private void Refresh_API()
        {
            CompanySettings = apiMethod.Get_Company();
        }
    }
}
