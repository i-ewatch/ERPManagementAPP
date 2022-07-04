
namespace ERPManagementAPP
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MainbarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.LoginbarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.TimebarStaticItem = new DevExpress.XtraBars.BarStaticItem();
            this.ConnectbarStaticItem = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.BasicDatanavBarGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.CompanynavBarItem = new DevExpress.XtraNavBar.NavBarItem();
            this.CustermernavBarItem = new DevExpress.XtraNavBar.NavBarItem();
            this.EmployeenavBarItem = new DevExpress.XtraNavBar.NavBarItem();
            this.Device_PartsnavBarItem = new DevExpress.XtraNavBar.NavBarItem();
            this.ProjectBarItem = new DevExpress.XtraNavBar.NavBarItem();
            this.AccountingBarGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.OperatingBarItem = new DevExpress.XtraNavBar.NavBarItem();
            this.PurchasenavBarItem = new DevExpress.XtraNavBar.NavBarItem();
            this.PickingBarItem = new DevExpress.XtraNavBar.NavBarItem();
            this.SalesnavBarItem = new DevExpress.XtraNavBar.NavBarItem();
            this.PaymentnavBarItem = new DevExpress.XtraNavBar.NavBarItem();
            this.PaymentManagementBarGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.PurchasePostingnavBarItem = new DevExpress.XtraNavBar.NavBarItem();
            this.SalesPostingnavBarItem = new DevExpress.XtraNavBar.NavBarItem();
            this.PaymentTransferDatenavBarItem = new DevExpress.XtraNavBar.NavBarItem();
            this.PartnernavBarItem = new DevExpress.XtraNavBar.NavBarItem();
            this.LoginimageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pcl_View = new DevExpress.XtraEditors.PanelControl();
            this.OrderBarItem = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.MainbarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginimageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcl_View)).BeginInit();
            this.SuspendLayout();
            // 
            // MainbarManager
            // 
            this.MainbarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.MainbarManager.DockControls.Add(this.barDockControlTop);
            this.MainbarManager.DockControls.Add(this.barDockControlBottom);
            this.MainbarManager.DockControls.Add(this.barDockControlLeft);
            this.MainbarManager.DockControls.Add(this.barDockControlRight);
            this.MainbarManager.Form = this;
            this.MainbarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticItem1,
            this.TimebarStaticItem,
            this.LoginbarButtonItem,
            this.ConnectbarStaticItem});
            this.MainbarManager.MainMenu = this.bar2;
            this.MainbarManager.MaxItemId = 4;
            this.MainbarManager.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatLocation = new System.Drawing.Point(242, 144);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.LoginbarButtonItem)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // LoginbarButtonItem
            // 
            this.LoginbarButtonItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.LoginbarButtonItem.AllowHtmlText = DevExpress.Utils.DefaultBoolean.False;
            this.LoginbarButtonItem.Caption = "Login";
            this.LoginbarButtonItem.Id = 2;
            this.LoginbarButtonItem.Name = "LoginbarButtonItem";
            this.LoginbarButtonItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.TimebarStaticItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.ConnectbarStaticItem)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // TimebarStaticItem
            // 
            this.TimebarStaticItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.TimebarStaticItem.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.TimebarStaticItem.Caption = "Online Time";
            this.TimebarStaticItem.Id = 1;
            this.TimebarStaticItem.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Black;
            this.TimebarStaticItem.ItemAppearance.Normal.Options.UseForeColor = true;
            this.TimebarStaticItem.Name = "TimebarStaticItem";
            // 
            // ConnectbarStaticItem
            // 
            this.ConnectbarStaticItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ConnectbarStaticItem.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ConnectbarStaticItem.Caption = "Connection";
            this.ConnectbarStaticItem.Id = 3;
            this.ConnectbarStaticItem.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Black;
            this.ConnectbarStaticItem.ItemAppearance.Normal.Options.UseForeColor = true;
            this.ConnectbarStaticItem.Name = "ConnectbarStaticItem";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.MainbarManager;
            this.barDockControlTop.Size = new System.Drawing.Size(1486, 23);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 904);
            this.barDockControlBottom.Manager = this.MainbarManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1486, 26);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 23);
            this.barDockControlLeft.Manager = this.MainbarManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 881);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1486, 23);
            this.barDockControlRight.Manager = this.MainbarManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 881);
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.barStaticItem1.Caption = "AccountName";
            this.barStaticItem1.Id = 0;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.BasicDatanavBarGroup;
            this.navBarControl1.AllowDrop = false;
            this.navBarControl1.Appearance.GroupHeaderActive.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.navBarControl1.Appearance.GroupHeaderActive.Options.UseFont = true;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.BasicDatanavBarGroup,
            this.AccountingBarGroup,
            this.PaymentManagementBarGroup});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.CompanynavBarItem,
            this.CustermernavBarItem,
            this.EmployeenavBarItem,
            this.Device_PartsnavBarItem,
            this.PurchasenavBarItem,
            this.PaymentnavBarItem,
            this.SalesnavBarItem,
            this.PurchasePostingnavBarItem,
            this.SalesPostingnavBarItem,
            this.PaymentTransferDatenavBarItem,
            this.PartnernavBarItem,
            this.ProjectBarItem,
            this.PickingBarItem,
            this.OperatingBarItem,
            this.OrderBarItem});
            this.navBarControl1.LinkSelectionMode = DevExpress.XtraNavBar.LinkSelectionModeType.OneInControl;
            this.navBarControl1.Location = new System.Drawing.Point(0, 23);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 184;
            this.navBarControl1.OptionsNavPane.ShowOverflowPanel = false;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl1.Size = new System.Drawing.Size(184, 881);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Tag = "";
            this.navBarControl1.Text = "navBarControl1";
            // 
            // BasicDatanavBarGroup
            // 
            this.BasicDatanavBarGroup.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.BasicDatanavBarGroup.Appearance.Options.UseFont = true;
            this.BasicDatanavBarGroup.AppearanceBackground.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.BasicDatanavBarGroup.AppearanceBackground.Options.UseFont = true;
            this.BasicDatanavBarGroup.AppearanceHotTracked.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.BasicDatanavBarGroup.AppearanceHotTracked.Options.UseFont = true;
            this.BasicDatanavBarGroup.AppearancePressed.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.BasicDatanavBarGroup.AppearancePressed.Options.UseFont = true;
            this.BasicDatanavBarGroup.Caption = "基本資料管理";
            this.BasicDatanavBarGroup.Expanded = true;
            this.BasicDatanavBarGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.BasicDatanavBarGroup.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BasicDatanavBarGroup.ImageOptions.LargeImage")));
            this.BasicDatanavBarGroup.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("BasicDatanavBarGroup.ImageOptions.SmallImage")));
            this.BasicDatanavBarGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.CompanynavBarItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.CustermernavBarItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.EmployeenavBarItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.Device_PartsnavBarItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.ProjectBarItem)});
            this.BasicDatanavBarGroup.Name = "BasicDatanavBarGroup";
            // 
            // CompanynavBarItem
            // 
            this.CompanynavBarItem.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.CompanynavBarItem.Appearance.Options.UseFont = true;
            this.CompanynavBarItem.Caption = "廠商資料";
            this.CompanynavBarItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("CompanynavBarItem.ImageOptions.LargeImage")));
            this.CompanynavBarItem.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("CompanynavBarItem.ImageOptions.SmallImage")));
            this.CompanynavBarItem.Name = "CompanynavBarItem";
            this.CompanynavBarItem.Tag = 1;
            this.CompanynavBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NavBarItem_LinkClicked);
            // 
            // CustermernavBarItem
            // 
            this.CustermernavBarItem.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.CustermernavBarItem.Appearance.Options.UseFont = true;
            this.CustermernavBarItem.Caption = "客戶資料";
            this.CustermernavBarItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("CustermernavBarItem.ImageOptions.LargeImage")));
            this.CustermernavBarItem.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("CustermernavBarItem.ImageOptions.SmallImage")));
            this.CustermernavBarItem.Name = "CustermernavBarItem";
            this.CustermernavBarItem.Tag = "2";
            this.CustermernavBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NavBarItem_LinkClicked);
            // 
            // EmployeenavBarItem
            // 
            this.EmployeenavBarItem.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.EmployeenavBarItem.Appearance.Options.UseFont = true;
            this.EmployeenavBarItem.Caption = "員工資料";
            this.EmployeenavBarItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("EmployeenavBarItem.ImageOptions.LargeImage")));
            this.EmployeenavBarItem.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("EmployeenavBarItem.ImageOptions.SmallImage")));
            this.EmployeenavBarItem.Name = "EmployeenavBarItem";
            this.EmployeenavBarItem.Tag = "3";
            this.EmployeenavBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NavBarItem_LinkClicked);
            // 
            // Device_PartsnavBarItem
            // 
            this.Device_PartsnavBarItem.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.Device_PartsnavBarItem.Appearance.Options.UseFont = true;
            this.Device_PartsnavBarItem.Caption = "設備/零件資料";
            this.Device_PartsnavBarItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("Device_PartsnavBarItem.ImageOptions.LargeImage")));
            this.Device_PartsnavBarItem.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("Device_PartsnavBarItem.ImageOptions.SmallImage")));
            this.Device_PartsnavBarItem.Name = "Device_PartsnavBarItem";
            this.Device_PartsnavBarItem.Tag = "4";
            this.Device_PartsnavBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NavBarItem_LinkClicked);
            // 
            // ProjectBarItem
            // 
            this.ProjectBarItem.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.ProjectBarItem.Appearance.Options.UseFont = true;
            this.ProjectBarItem.AppearanceDisabled.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.ProjectBarItem.AppearanceDisabled.Options.UseFont = true;
            this.ProjectBarItem.AppearanceHotTracked.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.ProjectBarItem.AppearanceHotTracked.Options.UseFont = true;
            this.ProjectBarItem.AppearancePressed.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.ProjectBarItem.AppearancePressed.Options.UseFont = true;
            this.ProjectBarItem.Caption = "專案資料";
            this.ProjectBarItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("ProjectBarItem.ImageOptions.LargeImage")));
            this.ProjectBarItem.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("ProjectBarItem.ImageOptions.SmallImage")));
            this.ProjectBarItem.Name = "ProjectBarItem";
            this.ProjectBarItem.Tag = "12";
            this.ProjectBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NavBarItem_LinkClicked);
            // 
            // AccountingBarGroup
            // 
            this.AccountingBarGroup.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.AccountingBarGroup.Appearance.Options.UseFont = true;
            this.AccountingBarGroup.AppearanceBackground.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.AccountingBarGroup.AppearanceBackground.Options.UseFont = true;
            this.AccountingBarGroup.AppearanceHotTracked.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.AccountingBarGroup.AppearanceHotTracked.Options.UseFont = true;
            this.AccountingBarGroup.AppearancePressed.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.AccountingBarGroup.AppearancePressed.Options.UseFont = true;
            this.AccountingBarGroup.Caption = "會計管理";
            this.AccountingBarGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.AccountingBarGroup.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("AccountingBarGroup.ImageOptions.LargeImage")));
            this.AccountingBarGroup.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("AccountingBarGroup.ImageOptions.SmallImage")));
            this.AccountingBarGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.OrderBarItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.OperatingBarItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.PurchasenavBarItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.PickingBarItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.SalesnavBarItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.PaymentnavBarItem)});
            this.AccountingBarGroup.Name = "AccountingBarGroup";
            this.AccountingBarGroup.SelectedLinkIndex = 0;
            // 
            // OperatingBarItem
            // 
            this.OperatingBarItem.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.OperatingBarItem.Appearance.Options.UseFont = true;
            this.OperatingBarItem.AppearanceDisabled.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.OperatingBarItem.AppearanceDisabled.Options.UseFont = true;
            this.OperatingBarItem.AppearanceHotTracked.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.OperatingBarItem.AppearanceHotTracked.Options.UseFont = true;
            this.OperatingBarItem.AppearancePressed.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.OperatingBarItem.AppearancePressed.Options.UseFont = true;
            this.OperatingBarItem.Caption = "營運/營運退出";
            this.OperatingBarItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("OperatingBarItem.ImageOptions.LargeImage")));
            this.OperatingBarItem.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("OperatingBarItem.ImageOptions.SmallImage")));
            this.OperatingBarItem.Name = "OperatingBarItem";
            this.OperatingBarItem.Tag = "14";
            this.OperatingBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NavBarItem_LinkClicked);
            // 
            // PurchasenavBarItem
            // 
            this.PurchasenavBarItem.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.PurchasenavBarItem.Appearance.Options.UseFont = true;
            this.PurchasenavBarItem.Caption = "進貨/進貨退出";
            this.PurchasenavBarItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("PurchasenavBarItem.ImageOptions.LargeImage")));
            this.PurchasenavBarItem.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("PurchasenavBarItem.ImageOptions.SmallImage")));
            this.PurchasenavBarItem.Name = "PurchasenavBarItem";
            this.PurchasenavBarItem.Tag = "5";
            this.PurchasenavBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NavBarItem_LinkClicked);
            // 
            // PickingBarItem
            // 
            this.PickingBarItem.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.PickingBarItem.Appearance.Options.UseFont = true;
            this.PickingBarItem.Caption = "領料/領料退回";
            this.PickingBarItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("PickingBarItem.ImageOptions.LargeImage")));
            this.PickingBarItem.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("PickingBarItem.ImageOptions.SmallImage")));
            this.PickingBarItem.Name = "PickingBarItem";
            this.PickingBarItem.Tag = "13";
            this.PickingBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NavBarItem_LinkClicked);
            // 
            // SalesnavBarItem
            // 
            this.SalesnavBarItem.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.SalesnavBarItem.Appearance.Options.UseFont = true;
            this.SalesnavBarItem.Caption = "銷貨/銷貨退回";
            this.SalesnavBarItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("SalesnavBarItem.ImageOptions.LargeImage")));
            this.SalesnavBarItem.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("SalesnavBarItem.ImageOptions.SmallImage")));
            this.SalesnavBarItem.Name = "SalesnavBarItem";
            this.SalesnavBarItem.Tag = "6";
            this.SalesnavBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NavBarItem_LinkClicked);
            // 
            // PaymentnavBarItem
            // 
            this.PaymentnavBarItem.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.PaymentnavBarItem.Appearance.Options.UseFont = true;
            this.PaymentnavBarItem.Caption = "代墊代付費用";
            this.PaymentnavBarItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("PaymentnavBarItem.ImageOptions.LargeImage")));
            this.PaymentnavBarItem.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("PaymentnavBarItem.ImageOptions.SmallImage")));
            this.PaymentnavBarItem.Name = "PaymentnavBarItem";
            this.PaymentnavBarItem.Tag = "7";
            this.PaymentnavBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NavBarItem_LinkClicked);
            // 
            // PaymentManagementBarGroup
            // 
            this.PaymentManagementBarGroup.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.PaymentManagementBarGroup.Appearance.Options.UseFont = true;
            this.PaymentManagementBarGroup.AppearanceHotTracked.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.PaymentManagementBarGroup.AppearanceHotTracked.Options.UseFont = true;
            this.PaymentManagementBarGroup.AppearancePressed.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.PaymentManagementBarGroup.AppearancePressed.Options.UseFont = true;
            this.PaymentManagementBarGroup.Caption = "收付款管理";
            this.PaymentManagementBarGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.PaymentManagementBarGroup.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("PaymentManagementBarGroup.ImageOptions.LargeImage")));
            this.PaymentManagementBarGroup.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("PaymentManagementBarGroup.ImageOptions.SmallImage")));
            this.PaymentManagementBarGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.PurchasePostingnavBarItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.SalesPostingnavBarItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.PaymentTransferDatenavBarItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.PartnernavBarItem)});
            this.PaymentManagementBarGroup.Name = "PaymentManagementBarGroup";
            this.PaymentManagementBarGroup.Visible = false;
            // 
            // PurchasePostingnavBarItem
            // 
            this.PurchasePostingnavBarItem.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.PurchasePostingnavBarItem.Appearance.Options.UseFont = true;
            this.PurchasePostingnavBarItem.Caption = "進貨營運總覽";
            this.PurchasePostingnavBarItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.PurchasePostingnavBarItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("PurchasePostingnavBarItem.ImageOptions.LargeImage")));
            this.PurchasePostingnavBarItem.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("PurchasePostingnavBarItem.ImageOptions.SmallImage")));
            this.PurchasePostingnavBarItem.Name = "PurchasePostingnavBarItem";
            this.PurchasePostingnavBarItem.Tag = "8";
            this.PurchasePostingnavBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NavBarItem_LinkClicked);
            // 
            // SalesPostingnavBarItem
            // 
            this.SalesPostingnavBarItem.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.SalesPostingnavBarItem.Appearance.Options.UseFont = true;
            this.SalesPostingnavBarItem.Caption = "銷貨/銷貨退回";
            this.SalesPostingnavBarItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.SalesPostingnavBarItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("SalesPostingnavBarItem.ImageOptions.LargeImage")));
            this.SalesPostingnavBarItem.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("SalesPostingnavBarItem.ImageOptions.SmallImage")));
            this.SalesPostingnavBarItem.Name = "SalesPostingnavBarItem";
            this.SalesPostingnavBarItem.Tag = "9";
            this.SalesPostingnavBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NavBarItem_LinkClicked);
            // 
            // PaymentTransferDatenavBarItem
            // 
            this.PaymentTransferDatenavBarItem.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.PaymentTransferDatenavBarItem.Appearance.Options.UseFont = true;
            this.PaymentTransferDatenavBarItem.Caption = "代墊代付費用";
            this.PaymentTransferDatenavBarItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.PaymentTransferDatenavBarItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("PaymentTransferDatenavBarItem.ImageOptions.LargeImage")));
            this.PaymentTransferDatenavBarItem.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("PaymentTransferDatenavBarItem.ImageOptions.SmallImage")));
            this.PaymentTransferDatenavBarItem.Name = "PaymentTransferDatenavBarItem";
            this.PaymentTransferDatenavBarItem.Tag = "10";
            this.PaymentTransferDatenavBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NavBarItem_LinkClicked);
            // 
            // PartnernavBarItem
            // 
            this.PartnernavBarItem.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.PartnernavBarItem.Appearance.Options.UseFont = true;
            this.PartnernavBarItem.AppearanceHotTracked.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.PartnernavBarItem.AppearanceHotTracked.Options.UseFont = true;
            this.PartnernavBarItem.Caption = "合作夥伴分潤";
            this.PartnernavBarItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("PartnernavBarItem.ImageOptions.LargeImage")));
            this.PartnernavBarItem.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("PartnernavBarItem.ImageOptions.SmallImage")));
            this.PartnernavBarItem.Name = "PartnernavBarItem";
            this.PartnernavBarItem.Tag = "11";
            this.PartnernavBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NavBarItem_LinkClicked);
            // 
            // LoginimageCollection
            // 
            this.LoginimageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("LoginimageCollection.ImageStream")));
            this.LoginimageCollection.Images.SetKeyName(0, "Login");
            this.LoginimageCollection.Images.SetKeyName(1, "administrator");
            this.LoginimageCollection.Images.SetKeyName(2, "employee");
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // pcl_View
            // 
            this.pcl_View.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcl_View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcl_View.Location = new System.Drawing.Point(184, 23);
            this.pcl_View.Name = "pcl_View";
            this.pcl_View.Size = new System.Drawing.Size(1302, 881);
            this.pcl_View.TabIndex = 14;
            // 
            // OrderBarItem
            // 
            this.OrderBarItem.Caption = "訂購單";
            this.OrderBarItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("OrderBarItem.ImageOptions.LargeImage")));
            this.OrderBarItem.Name = "OrderBarItem";
            this.OrderBarItem.Tag = "15";
            this.OrderBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NavBarItem_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1486, 930);
            this.Controls.Add(this.pcl_View);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "ERPManagementAPP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainbarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginimageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcl_View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager MainbarManager;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup BasicDatanavBarGroup;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem TimebarStaticItem;
        private DevExpress.XtraNavBar.NavBarItem CompanynavBarItem;
        private DevExpress.XtraNavBar.NavBarItem CustermernavBarItem;
        private DevExpress.XtraNavBar.NavBarItem EmployeenavBarItem;
        private DevExpress.XtraNavBar.NavBarItem Device_PartsnavBarItem;
        private DevExpress.XtraBars.BarButtonItem LoginbarButtonItem;
        private DevExpress.Utils.ImageCollection LoginimageCollection;
        private System.Windows.Forms.Timer timer;
        private DevExpress.XtraEditors.PanelControl pcl_View;
        private DevExpress.XtraNavBar.NavBarGroup AccountingBarGroup;
        private DevExpress.XtraNavBar.NavBarItem PurchasenavBarItem;
        private DevExpress.XtraNavBar.NavBarItem PaymentnavBarItem;
        private DevExpress.XtraNavBar.NavBarItem SalesnavBarItem;
        private DevExpress.XtraNavBar.NavBarGroup PaymentManagementBarGroup;
        private DevExpress.XtraNavBar.NavBarItem PurchasePostingnavBarItem;
        private DevExpress.XtraNavBar.NavBarItem SalesPostingnavBarItem;
        private DevExpress.XtraNavBar.NavBarItem PaymentTransferDatenavBarItem;
        private DevExpress.XtraBars.BarStaticItem ConnectbarStaticItem;
        private DevExpress.XtraNavBar.NavBarItem PartnernavBarItem;
        private DevExpress.XtraNavBar.NavBarItem ProjectBarItem;
        private DevExpress.XtraNavBar.NavBarItem PickingBarItem;
        private DevExpress.XtraNavBar.NavBarItem OperatingBarItem;
        private DevExpress.XtraNavBar.NavBarItem OrderBarItem;
    }
}

