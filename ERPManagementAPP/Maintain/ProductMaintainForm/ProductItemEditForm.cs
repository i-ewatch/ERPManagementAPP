using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain.ProductMaintainForm
{
    public partial class ProductItemEditForm : BaseEditForm
    {
        /// <summary>
        /// 項目類別
        /// </summary>
        private int ItemIndex = 0;
        private List<ProductDepartmentSetting> ProductDepartmentSettings { get; set; } = new List<ProductDepartmentSetting>();
        private List<ProductItem1Setting> ProductItem1Settings { get; set; } = new List<ProductItem1Setting>();
        private List<ProductItem2Setting> ProductItem2Settings { get; set; } = new List<ProductItem2Setting>();
        private List<ProductItem3Setting> ProductItem3Settings { get; set; } = new List<ProductItem3Setting>();
        private List<ProductItem4Setting> ProductItem4Settings { get; set; } = new List<ProductItem4Setting>();
        private List<ProductItem5Setting> ProductItem5Settings { get; set; } = new List<ProductItem5Setting>();
        private ProductItem1Setting ProductItem1Setting { get; set; } = new ProductItem1Setting();
        private ProductItem2Setting ProductItem2Setting { get; set; } = new ProductItem2Setting();
        private ProductItem3Setting ProductItem3Setting { get; set; } = new ProductItem3Setting();
        private ProductItem4Setting ProductItem4Setting { get; set; } = new ProductItem4Setting();
        private ProductItem5Setting ProductItem5Setting { get; set; } = new ProductItem5Setting();
        private ProductDepartmentSetting SelectProductDepartmentSetting { get; set; }
        private ProductItem1Setting SelectProductItem1Setting { get; set; }
        private ProductItem2Setting SelectProductItem2Setting { get; set; }
        private ProductItem3Setting SelectProductItem3Setting { get; set; }
        private ProductItem4Setting SelectProductItem4Setting { get; set; }
        public ProductItemEditForm(
            int Tag,
            List<ProductDepartmentSetting> productDepartmentSettings,
            List<ProductItem1Setting> productItem1Settings,
            List<ProductItem2Setting> productItem2Settings,
            List<ProductItem3Setting> productItem3Settings,
            List<ProductItem4Setting> productItem4Settings,
            List<ProductItem5Setting> productItem5Settings,
            ProductItem1Setting productItem1Setting,
            ProductItem2Setting productItem2Setting,
            ProductItem3Setting productItem3Setting,
            ProductItem4Setting productItem4Setting,
            ProductItem5Setting productItem5Setting,
            APIMethod apiMethod,
            Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            action.Commands.Add(FlyoutCommand.Yes);
            ItemIndex = Tag;
            ProductDepartmentSettings = productDepartmentSettings;
            ProductItem1Settings = productItem1Settings;
            ProductItem2Settings = productItem2Settings;
            ProductItem3Settings = productItem3Settings;
            ProductItem4Settings = productItem4Settings;
            ProductItem5Settings = productItem5Settings;
            ProductItem1Setting = productItem1Setting;
            ProductItem2Setting = productItem2Setting;
            ProductItem3Setting = productItem3Setting;
            ProductItem4Setting = productItem4Setting;
            ProductItem5Setting = productItem5Setting;
            Create_slt_Department();
            switch (ItemIndex)
            {
                case 1://項目1
                    {
                        Size = new Size(674, 205);
                        layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        if (productItem1Setting != null && productItem1Setting.Item1Number != null)
                        {
                            action.Caption = $"項目{ItemIndex}修改錯誤";
                            Show_slt_Department();
                            slt_DepartmentNumber.Enabled = false;
                            txt_Item1Number.Text = productItem1Setting.Item1Number;
                            txt_Item1Number.Enabled = false;
                            txt_Item1Name.Text = productItem1Setting.Item1Name;
                        }
                        else
                        {
                            ProductItem1Setting = null;
                            action.Caption = $"項目{ItemIndex}新增錯誤";
                        }
                    }
                    break;
                case 2://項目2
                    {
                        Size = new Size(674, 233);
                        layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        layoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        if (productItem2Setting != null && productItem2Setting.Item2Number != null)
                        {
                            action.Caption = $"項目{ItemIndex}修改錯誤";
                            Show_slt_Department();
                            slt_DepartmentNumber.Enabled = false;
                            Create_slt_Item1();
                            Show_slt_Item1();
                            slt_Item1Number.Enabled = false;
                            txt_Item2Number.Text = productItem2Setting.Item2Number;
                            txt_Item2Number.Enabled = false;
                            txt_Item2Name.Text = productItem2Setting.Item2Name;
                        }
                        else
                        {
                            ProductItem2Setting = null;
                            action.Caption = $"項目{ItemIndex}新增錯誤";
                        }
                    }
                    break;
                case 3://項目3
                    {
                        Size = new Size(674, 274);
                        layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        layoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        layoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        if (productItem3Setting != null && productItem3Setting.Item3Number != null)
                        {
                            action.Caption = $"項目{ItemIndex}修改錯誤";
                            Show_slt_Department();
                            slt_DepartmentNumber.Enabled = false;
                            Create_slt_Item1();
                            Show_slt_Item1();
                            slt_Item1Number.Enabled = false;
                            Create_slt_Item2();
                            Show_slt_Item2();
                            slt_Item2Number.Enabled = false;
                            txt_Item3Number.Text = productItem3Setting.Item3Number;
                            txt_Item3Number.Enabled = false;
                            txt_Item3Name.Text = productItem3Setting.Item3Name;
                        }
                        else
                        {
                            ProductItem3Setting = null;
                            action.Caption = $"項目{ItemIndex}新增錯誤";
                        }
                    }
                    break;
                case 4://項目4
                    {
                        Size = new Size(674, 294);
                        layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        layoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        layoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        layoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        if (productItem4Setting != null && productItem4Setting.Item4Number != null)
                        {
                            action.Caption = $"項目{ItemIndex}修改錯誤";
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
                            txt_Item4Number.Text = productItem4Setting.Item4Number;
                            txt_Item4Number.Enabled = false;
                            txt_Item4Name.Text = productItem4Setting.Item4Name;
                        }
                        else
                        {
                            ProductItem4Setting = null;
                            action.Caption = $"項目{ItemIndex}新增錯誤";
                        }
                    }
                    break;
                case 5://項目5
                    {
                        Size = new Size(674, 324);
                        layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        layoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        layoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        layoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        layoutControlItem16.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        if (productItem5Setting != null && productItem5Setting.Item5Number != null)
                        {
                            action.Caption = $"項目{ItemIndex}修改錯誤";
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
                            txt_Item5Number.Text = productItem5Setting.Item5Number;
                            txt_Item5Number.Enabled = false;
                            txt_Item5Name.Text = productItem5Setting.Item5Name;
                        }
                        else
                        {
                            ProductItem5Setting = null;
                            action.Caption = $"項目{ItemIndex}新增錯誤";
                        }
                    }
                    break;
            }
            slt_DepartmentNumber.EditValueChanged += (s, e) =>
            {
                slt_Item1Number.EditValue = "";
                Create_slt_Item1();
                slt_Item2Number.Properties.DataSource = null;
                slt_Item3Number.Properties.DataSource = null;
                slt_Item4Number.Properties.DataSource = null;
                SelectProductItem1Setting = null;
                SelectProductItem2Setting = null;
                SelectProductItem3Setting = null;
                SelectProductItem4Setting = null;
            };
            slt_Item1Number.EditValueChanged += (s, e) =>
            {
                slt_Item2Number.EditValue = "";
                Create_slt_Item2();
                slt_Item3Number.Properties.DataSource = null;
                slt_Item4Number.Properties.DataSource = null;
                SelectProductItem2Setting = null;
                SelectProductItem3Setting = null;
                SelectProductItem4Setting = null;
            };
            slt_Item2Number.EditValueChanged += (s, e) =>
            {
                slt_Item3Number.EditValue = "";
                Create_slt_Item3();
                slt_Item4Number.Properties.DataSource = null;
                SelectProductItem3Setting = null;
                SelectProductItem4Setting = null;
            };
            slt_Item3Number.EditValueChanged += (s, e) =>
            {
                slt_Item4Number.EditValue = "";
                Create_slt_Item4();
                SelectProductItem4Setting = null;
            };
            #region 儲存按鈕
            btn_Save.Click += (s, e) =>
            {
                CheckNumber(apiMethod);
            };
            #endregion
            #region 取消按鈕
            btn_Cancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
            };
            #endregion
        }
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
                switch (ItemIndex)
                {
                    case 1://項目1
                        {
                            if (ProductItem1Setting != null)
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
                        }
                        break;
                    case 2://項目2
                        {
                            if (ProductItem2Setting != null)
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
                        }
                        break;
                    case 3://項目3
                        {
                            if (ProductItem3Setting != null)
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
                        }
                        break;
                    case 4://項目4
                        {
                            if (ProductItem4Setting != null)
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
                        }
                        break;
                    case 5://項目5
                        {
                            if (ProductItem5Setting != null)
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
                        }
                        break;
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
                switch (ItemIndex)
                {
                    case 1://項目1
                        {
                            if (ProductDepartmentSettings[i].DepartmentNumber == ProductItem1Setting.DepartmentNumber)
                            {
                                SelectProductDepartmentSetting = ProductDepartmentSettings[i];
                                return;
                            }
                            else
                            {
                                SelectProductDepartmentSetting = null;
                            }
                        }
                        break;
                    case 2://項目2
                        {
                            if (ProductDepartmentSettings[i].DepartmentNumber == ProductItem2Setting.DepartmentNumber)
                            {
                                SelectProductDepartmentSetting = ProductDepartmentSettings[i];
                                return;
                            }
                            else
                            {
                                SelectProductDepartmentSetting = null;
                            }
                        }
                        break;
                    case 3://項目3
                        {
                            if (ProductDepartmentSettings[i].DepartmentNumber == ProductItem3Setting.DepartmentNumber)
                            {
                                SelectProductDepartmentSetting = ProductDepartmentSettings[i];
                                return;
                            }
                            else
                            {
                                SelectProductDepartmentSetting = null;
                            }
                        }
                        break;
                    case 4://項目4
                        {
                            if (ProductDepartmentSettings[i].DepartmentNumber == ProductItem4Setting.DepartmentNumber)
                            {
                                SelectProductDepartmentSetting = ProductDepartmentSettings[i];
                                return;
                            }
                            else
                            {
                                SelectProductDepartmentSetting = null;
                            }
                        }
                        break;
                    case 5://項目5
                        {
                            if (ProductDepartmentSettings[i].DepartmentNumber == ProductItem5Setting.DepartmentNumber)
                            {
                                SelectProductDepartmentSetting = ProductDepartmentSettings[i];
                                return;
                            }
                            else
                            {
                                SelectProductDepartmentSetting = null;
                            }
                        }
                        break;
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
                    switch (ItemIndex)
                    {
                        case 1://項目1
                            {
                                if (ProductItem1Setting != null)
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
                            }
                            break;
                        case 2://項目2
                            {
                                if (ProductItem2Setting != null)
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
                            }
                            break;
                        case 3://項目3
                            {
                                if (ProductItem3Setting != null)
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
                            }
                            break;
                        case 4://項目4
                            {
                                if (ProductItem4Setting != null)
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
                            }
                            break;
                        case 5://項目5
                            {
                                if (ProductItem5Setting != null)
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
                            }
                            break;
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
                    switch (ItemIndex)
                    {
                        case 1://項目1
                            {
                                if (settings[i].Item1Number == ProductItem1Setting.Item1Number)
                                {
                                    SelectProductItem1Setting = settings[i];
                                    return;
                                }
                                else
                                {
                                    SelectProductItem1Setting = null;
                                }
                            }
                            break;
                        case 2://項目2
                            {
                                if (settings[i].Item1Number == ProductItem2Setting.Item1Number)
                                {
                                    SelectProductItem1Setting = settings[i];
                                    return;
                                }
                                else
                                {
                                    SelectProductItem1Setting = null;
                                }
                            }
                            break;
                        case 3://項目3
                            {
                                if (settings[i].Item1Number == ProductItem3Setting.Item1Number)
                                {
                                    SelectProductItem1Setting = settings[i];
                                    return;
                                }
                                else
                                {
                                    SelectProductItem1Setting = null;
                                }
                            }
                            break;
                        case 4://項目4
                            {
                                if (settings[i].Item1Number == ProductItem4Setting.Item1Number)
                                {
                                    SelectProductItem1Setting = settings[i];
                                    return;
                                }
                                else
                                {
                                    SelectProductItem1Setting = null;
                                }
                            }
                            break;
                        case 5://項目5
                            {
                                if (settings[i].Item1Number == ProductItem5Setting.Item1Number)
                                {
                                    SelectProductItem1Setting = settings[i];
                                    return;
                                }
                                else
                                {
                                    SelectProductItem1Setting = null;
                                }
                            }
                            break;
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
            if (SelectProductDepartmentSetting != null && SelectProductDepartmentSetting.DepartmentNumber != null && SelectProductItem1Setting != null)
            {
                List<ProductItem2Setting> settings = ProductItem2Settings.Where(g => g.DepartmentNumber == SelectProductDepartmentSetting.DepartmentNumber & g.Item1Number == SelectProductItem1Setting.Item1Number).ToList();
                slt_Item2Number.Properties.DataSource = settings;
                slt_Item2Number.Properties.DisplayMember = "Item2Name";
                slt_Item2Number.CustomDisplayText += (s, e) =>
                {
                    switch (ItemIndex)
                    {
                        case 2://項目2
                            {
                                if (ProductItem2Setting != null)
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
                            }
                            break;
                        case 3://項目3
                            {
                                if (ProductItem3Setting != null)
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
                            }
                            break;
                        case 4://項目4
                            {
                                if (ProductItem4Setting != null)
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
                            }
                            break;
                        case 5://項目5
                            {
                                if (ProductItem5Setting != null)
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
                            }
                            break;
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
                List<ProductItem2Setting> settings = ProductItem2Settings.Where(g => g.DepartmentNumber == SelectProductDepartmentSetting.DepartmentNumber & g.Item1Number == SelectProductItem1Setting.Item1Number).ToList();
                for (int i = 0; i < settings.Count; i++)
                {
                    switch (ItemIndex)
                    {
                        case 2://項目2
                            {
                                if (settings[i].Item2Number == ProductItem2Setting.Item2Number)
                                {
                                    SelectProductItem2Setting = settings[i];
                                    return;
                                }
                                else
                                {
                                    SelectProductItem2Setting = null;
                                }
                            }
                            break;
                        case 3://項目3
                            {
                                if (settings[i].Item2Number == ProductItem3Setting.Item2Number)
                                {
                                    SelectProductItem2Setting = settings[i];
                                    return;
                                }
                                else
                                {
                                    SelectProductItem2Setting = null;
                                }
                            }
                            break;
                        case 4://項目4
                            {
                                if (settings[i].Item2Number == ProductItem4Setting.Item2Number)
                                {
                                    SelectProductItem2Setting = settings[i];
                                    return;
                                }
                                else
                                {
                                    SelectProductItem2Setting = null;
                                }
                            }
                            break;
                        case 5://項目5
                            {
                                if (settings[i].Item2Number == ProductItem5Setting.Item2Number)
                                {
                                    SelectProductItem2Setting = settings[i];
                                    return;
                                }
                                else
                                {
                                    SelectProductItem2Setting = null;
                                }
                            }
                            break;
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
                List<ProductItem3Setting> settings = ProductItem3Settings.Where(g => g.DepartmentNumber == SelectProductDepartmentSetting.DepartmentNumber & g.Item1Number == SelectProductItem1Setting.Item1Number & g.Item2Number == SelectProductItem2Setting.Item2Number).ToList();
                slt_Item3Number.Properties.DataSource = settings;
                slt_Item3Number.Properties.DisplayMember = "Item3Name";
                slt_Item3Number.CustomDisplayText += (s, e) =>
                {
                    switch (ItemIndex)
                    {
                        case 3://項目3
                            {
                                if (ProductItem3Setting != null)
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
                            }
                            break;
                        case 4://項目4
                            {
                                if (ProductItem4Setting != null)
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
                            }
                            break;
                        case 5://項目5
                            {
                                if (ProductItem5Setting != null)
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
                            }
                            break;
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
                List<ProductItem3Setting> settings = ProductItem3Settings.Where(g => g.DepartmentNumber == SelectProductDepartmentSetting.DepartmentNumber & g.Item1Number == SelectProductItem1Setting.Item1Number & g.Item2Number == SelectProductItem2Setting.Item2Number).ToList();
                for (int i = 0; i < settings.Count; i++)
                {
                    switch (ItemIndex)
                    {
                        case 3://項目3
                            {
                                if (settings[i].Item3Number == ProductItem3Setting.Item3Number)
                                {
                                    SelectProductItem3Setting = settings[i];
                                    return;
                                }
                                else
                                {
                                    SelectProductItem3Setting = null;
                                }
                            }
                            break;
                        case 4://項目4
                            {
                                if (settings[i].Item3Number == ProductItem4Setting.Item3Number)
                                {
                                    SelectProductItem3Setting = settings[i];
                                    return;
                                }
                                else
                                {
                                    SelectProductItem3Setting = null;
                                }
                            }
                            break;
                        case 5://項目5
                            {
                                if (settings[i].Item3Number == ProductItem5Setting.Item3Number)
                                {
                                    SelectProductItem3Setting = settings[i];
                                    return;
                                }
                                else
                                {
                                    SelectProductItem3Setting = null;
                                }
                            }
                            break;
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
                List<ProductItem4Setting> settings = ProductItem4Settings.Where(g => g.DepartmentNumber == SelectProductDepartmentSetting.DepartmentNumber & g.Item1Number == SelectProductItem1Setting.Item1Number & g.Item2Number == SelectProductItem2Setting.Item2Number & g.Item3Number == SelectProductItem3Setting.Item3Number).ToList();
                slt_Item4Number.Properties.DataSource = settings;
                slt_Item4Number.Properties.DisplayMember = "Item4Name";
                slt_Item4Number.CustomDisplayText += (s, e) =>
                {
                    switch (ItemIndex)
                    {
                        case 4://項目4
                            {
                                if (ProductItem4Setting != null)
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
                            }
                            break;
                        case 5://項目5
                            {
                                if (ProductItem5Setting != null)
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
                            }
                            break;
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
                List<ProductItem4Setting> settings = ProductItem4Settings.Where(g => g.DepartmentNumber == SelectProductDepartmentSetting.DepartmentNumber & g.Item1Number == SelectProductItem1Setting.Item1Number & g.Item2Number == SelectProductItem2Setting.Item2Number & g.Item3Number == SelectProductItem3Setting.Item3Number).ToList();
                for (int i = 0; i < settings.Count; i++)
                {
                    switch (ItemIndex)
                    {
                        case 4://項目4
                            {
                                if (settings[i].Item4Number == ProductItem4Setting.Item4Number)
                                {
                                    SelectProductItem4Setting = settings[i];
                                    return;
                                }
                                else
                                {
                                    SelectProductItem4Setting = null;
                                }
                            }
                            break;
                        case 5://項目5
                            {
                                if (settings[i].Item4Number == ProductItem5Setting.Item4Number)
                                {
                                    SelectProductItem4Setting = settings[i];
                                    return;
                                }
                                else
                                {
                                    SelectProductItem4Setting = null;
                                }
                            }
                            break;
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

        #region 檢查上傳
        /// <summary>
        /// 檢查上傳
        /// </summary>
        /// <param name="apiMethod"></param>
        private void CheckNumber(APIMethod apiMethod)
        {
            string response = "";
            if (SelectProductDepartmentSetting != null)
            {
                switch (ItemIndex)
                {
                    case 1://項目1
                        {
                            ProductItem1Setting productItem1 = null;
                            if (ProductItem1Settings != null)
                            {
                                productItem1 = ProductItem1Settings.SingleOrDefault(g => g.Item1Number == txt_Item1Number.Text.PadLeft(2, '0') & g.DepartmentNumber == SelectProductDepartmentSetting.DepartmentNumber);
                            }
                            if (ProductItem1Setting != null && ProductItem1Setting.Item1Number != null)
                            {
                                ProductItem1Setting.Item1Name = txt_Item1Name.Text;
                                string value = JsonConvert.SerializeObject(ProductItem1Setting);
                                response = apiMethod.Put_ProductItem1(value);
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
                                if (productItem1 == null)
                                {
                                    if (!string.IsNullOrEmpty(txt_Item1Number.Text) && !string.IsNullOrEmpty(txt_Item1Name.Text))
                                    {
                                        ProductItem1Setting setting = new ProductItem1Setting()
                                        {
                                            DepartmentNumber = SelectProductDepartmentSetting.DepartmentNumber,
                                            Item1Number = txt_Item1Number.Text.PadLeft(2, '0'),
                                            Item1Name = txt_Item1Name.Text
                                        };
                                        string value = JsonConvert.SerializeObject(setting);
                                        response = apiMethod.Post_ProductItem1(value);
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
                                    action.Description = "項目1編號已被使用";
                                    FlyoutDialog.Show(Form1, action);
                                }
                            }
                        }
                        break;
                    case 2://項目2
                        {
                            ProductItem2Setting productItem2 = null;
                            if (ProductItem2Settings != null && SelectProductItem1Setting != null)
                            {
                                productItem2 = ProductItem2Settings.SingleOrDefault(g => g.Item2Number == txt_Item2Number.Text.PadLeft(2, '0') & g.DepartmentNumber == SelectProductDepartmentSetting.DepartmentNumber
                                & g.Item1Number == SelectProductItem1Setting.Item1Number);
                            }
                            else
                            {
                                action.Description = "資料未填寫完整";
                                FlyoutDialog.Show(Form1, action);
                                return;
                            }
                            if (ProductItem2Setting != null && ProductItem2Setting.Item2Number != null)
                            {
                                ProductItem2Setting.Item2Name = txt_Item2Name.Text;
                                string value = JsonConvert.SerializeObject(ProductItem2Setting);
                                response = apiMethod.Put_ProductItem2(value);
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
                                if (productItem2 == null)
                                {
                                    if (!string.IsNullOrEmpty(txt_Item2Number.Text) && !string.IsNullOrEmpty(txt_Item2Name.Text))
                                    {
                                        ProductItem2Setting setting = new ProductItem2Setting()
                                        {
                                            DepartmentNumber = SelectProductDepartmentSetting.DepartmentNumber,
                                            Item1Number = SelectProductItem1Setting.Item1Number,
                                            Item2Number = txt_Item2Number.Text.PadLeft(2, '0'),
                                            Item2Name = txt_Item2Name.Text
                                        };
                                        string value = JsonConvert.SerializeObject(setting);
                                        response = apiMethod.Post_ProductItem2(value);
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
                                    action.Description = "項目2編號已被使用";
                                    FlyoutDialog.Show(Form1, action);
                                }
                            }
                        }
                        break;
                    case 3://項目3
                        {
                            ProductItem3Setting productItem3 = null;
                            if (ProductItem3Settings != null && SelectProductItem1Setting != null && SelectProductItem2Setting != null)
                            {
                                productItem3 = ProductItem3Settings.SingleOrDefault(g => g.Item3Number == txt_Item3Number.Text.PadLeft(2, '0') & g.DepartmentNumber == SelectProductDepartmentSetting.DepartmentNumber
                                & g.Item1Number == SelectProductItem1Setting.Item1Number & g.Item2Number == SelectProductItem2Setting.Item2Number);
                            }
                            else
                            {
                                action.Description = "資料未填寫完整";
                                FlyoutDialog.Show(Form1, action);
                                return;
                            }
                            if (ProductItem3Setting != null && ProductItem3Setting.Item3Number != null)
                            {
                                ProductItem3Setting.Item3Name = txt_Item3Name.Text;
                                string value = JsonConvert.SerializeObject(ProductItem3Setting);
                                response = apiMethod.Put_ProductItem3(value);
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
                                if (productItem3 == null)
                                {
                                    if (!string.IsNullOrEmpty(txt_Item3Number.Text) && !string.IsNullOrEmpty(txt_Item3Name.Text))
                                    {
                                        ProductItem3Setting setting = new ProductItem3Setting()
                                        {
                                            DepartmentNumber = SelectProductDepartmentSetting.DepartmentNumber,
                                            Item1Number = SelectProductItem1Setting.Item1Number,
                                            Item2Number = SelectProductItem2Setting.Item2Number,
                                            Item3Number = txt_Item3Number.Text.PadLeft(2, '0'),
                                            Item3Name = txt_Item3Name.Text
                                        };
                                        string value = JsonConvert.SerializeObject(setting);
                                        response = apiMethod.Post_ProductItem3(value);
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
                                    action.Description = "項目3編號已被使用";
                                    FlyoutDialog.Show(Form1, action);
                                }
                            }
                        }
                        break;
                    case 4://項目4
                        {
                            ProductItem4Setting productItem4 = null;
                            if (ProductItem4Settings != null && SelectProductItem1Setting != null && SelectProductItem2Setting != null && SelectProductItem3Setting != null)
                            {
                                productItem4 = ProductItem4Settings.SingleOrDefault(g => g.Item4Number == txt_Item4Number.Text.PadLeft(2, '0') & g.DepartmentNumber == SelectProductDepartmentSetting.DepartmentNumber
                                & g.Item1Number == SelectProductItem1Setting.Item1Number & g.Item2Number == SelectProductItem2Setting.Item2Number & g.Item3Number == SelectProductItem3Setting.Item3Number);
                            }
                            else
                            {
                                action.Description = "資料未填寫完整";
                                FlyoutDialog.Show(Form1, action);
                                return;
                            }
                            if (ProductItem4Setting != null && ProductItem4Setting.Item4Number != null)
                            {
                                ProductItem4Setting.Item4Name = txt_Item4Name.Text;
                                string value = JsonConvert.SerializeObject(ProductItem4Setting);
                                response = apiMethod.Put_ProductItem4(value);
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
                                if (productItem4 == null)
                                {
                                    if (!string.IsNullOrEmpty(txt_Item4Number.Text) && !string.IsNullOrEmpty(txt_Item4Name.Text))
                                    {
                                        ProductItem4Setting setting = new ProductItem4Setting()
                                        {
                                            DepartmentNumber = SelectProductDepartmentSetting.DepartmentNumber,
                                            Item1Number = SelectProductItem1Setting.Item1Number,
                                            Item2Number = SelectProductItem2Setting.Item2Number,
                                            Item3Number = SelectProductItem3Setting.Item3Number,
                                            Item4Number = txt_Item4Number.Text.PadLeft(2, '0'),
                                            Item4Name = txt_Item4Name.Text
                                        };
                                        string value = JsonConvert.SerializeObject(setting);
                                        response = apiMethod.Post_ProductItem4(value);
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
                                    action.Description = "項目4編號已被使用";
                                    FlyoutDialog.Show(Form1, action);
                                }
                            }
                        }
                        break;
                    case 5://項目5
                        {
                            ProductItem5Setting productItem5 = null;
                            if (ProductItem5Settings != null && SelectProductItem1Setting != null && SelectProductItem2Setting != null && SelectProductItem3Setting != null && SelectProductItem4Setting != null)
                            {
                                productItem5 = ProductItem5Settings.SingleOrDefault(g => g.Item5Number == txt_Item5Number.Text.PadLeft(4, '0') & g.DepartmentNumber == SelectProductDepartmentSetting.DepartmentNumber
                                & g.Item1Number == SelectProductItem1Setting.Item1Number & g.Item2Number == SelectProductItem2Setting.Item2Number & g.Item3Number == SelectProductItem3Setting.Item3Number & g.Item4Number == SelectProductItem4Setting.Item4Number);
                            }
                            else
                            {
                                action.Description = "資料未填寫完整";
                                FlyoutDialog.Show(Form1, action);
                                return;
                            }
                            if (ProductItem5Setting != null && ProductItem5Setting.Item5Number != null)
                            {
                                ProductItem5Setting.Item5Name = txt_Item5Name.Text;
                                string value = JsonConvert.SerializeObject(ProductItem5Setting);
                                response = apiMethod.Put_ProductItem5(value);
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
                                if (productItem5 == null)
                                {
                                    if (!string.IsNullOrEmpty(txt_Item5Number.Text) && !string.IsNullOrEmpty(txt_Item5Name.Text))
                                    {
                                        ProductItem5Setting setting = new ProductItem5Setting()
                                        {
                                            DepartmentNumber = SelectProductDepartmentSetting.DepartmentNumber,
                                            Item1Number = SelectProductItem1Setting.Item1Number,
                                            Item2Number = SelectProductItem2Setting.Item2Number,
                                            Item3Number = SelectProductItem3Setting.Item3Number,
                                            Item4Number = SelectProductItem4Setting.Item4Number,
                                            Item5Number = txt_Item5Number.Text.PadLeft(4, '0'),
                                            Item5Name = txt_Item5Name.Text
                                        };
                                        string value = JsonConvert.SerializeObject(setting);
                                        response = apiMethod.Post_ProductItem5(value);
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
                                    action.Description = "項目5編號已被使用";
                                    FlyoutDialog.Show(Form1, action);
                                }
                            }
                        }
                        break;
                }
            }
            else
            {
                action.Description = "資料未填寫完整";
                FlyoutDialog.Show(Form1, action);
            }
        }
        #endregion
    }
}