
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
            this.LoginimageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pcl_View = new DevExpress.XtraEditors.PanelControl();
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
            this.LoginbarButtonItem});
            this.MainbarManager.MainMenu = this.bar2;
            this.MainbarManager.MaxItemId = 3;
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
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.TimebarStaticItem)});
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
            this.TimebarStaticItem.Name = "TimebarStaticItem";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.MainbarManager;
            this.barDockControlTop.Size = new System.Drawing.Size(1462, 25);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 868);
            this.barDockControlBottom.Manager = this.MainbarManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1462, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 25);
            this.barDockControlLeft.Manager = this.MainbarManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 843);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1462, 25);
            this.barDockControlRight.Manager = this.MainbarManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 843);
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
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.BasicDatanavBarGroup});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.CompanynavBarItem,
            this.CustermernavBarItem,
            this.EmployeenavBarItem,
            this.Device_PartsnavBarItem});
            this.navBarControl1.LinkSelectionMode = DevExpress.XtraNavBar.LinkSelectionModeType.OneInControl;
            this.navBarControl1.Location = new System.Drawing.Point(0, 25);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 184;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl1.Size = new System.Drawing.Size(184, 843);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Tag = "";
            this.navBarControl1.Text = "navBarControl1";
            // 
            // BasicDatanavBarGroup
            // 
            this.BasicDatanavBarGroup.Caption = "基本資料管理";
            this.BasicDatanavBarGroup.Expanded = true;
            this.BasicDatanavBarGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.BasicDatanavBarGroup.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BasicDatanavBarGroup.ImageOptions.LargeImage")));
            this.BasicDatanavBarGroup.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("BasicDatanavBarGroup.ImageOptions.SmallImage")));
            this.BasicDatanavBarGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.CompanynavBarItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.CustermernavBarItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.EmployeenavBarItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.Device_PartsnavBarItem)});
            this.BasicDatanavBarGroup.Name = "BasicDatanavBarGroup";
            this.BasicDatanavBarGroup.SelectedLinkIndex = 0;
            // 
            // CompanynavBarItem
            // 
            this.CompanynavBarItem.Caption = "廠商資料";
            this.CompanynavBarItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("CompanynavBarItem.ImageOptions.LargeImage")));
            this.CompanynavBarItem.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("CompanynavBarItem.ImageOptions.SmallImage")));
            this.CompanynavBarItem.Name = "CompanynavBarItem";
            this.CompanynavBarItem.Tag = 1;
            this.CompanynavBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NavBarItem_LinkClicked);
            // 
            // CustermernavBarItem
            // 
            this.CustermernavBarItem.Caption = "客戶資料";
            this.CustermernavBarItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("CustermernavBarItem.ImageOptions.LargeImage")));
            this.CustermernavBarItem.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("CustermernavBarItem.ImageOptions.SmallImage")));
            this.CustermernavBarItem.Name = "CustermernavBarItem";
            this.CustermernavBarItem.Tag = "2";
            this.CustermernavBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NavBarItem_LinkClicked);
            // 
            // EmployeenavBarItem
            // 
            this.EmployeenavBarItem.Caption = "員工資料";
            this.EmployeenavBarItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("EmployeenavBarItem.ImageOptions.LargeImage")));
            this.EmployeenavBarItem.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("EmployeenavBarItem.ImageOptions.SmallImage")));
            this.EmployeenavBarItem.Name = "EmployeenavBarItem";
            this.EmployeenavBarItem.Tag = "3";
            this.EmployeenavBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NavBarItem_LinkClicked);
            // 
            // Device_PartsnavBarItem
            // 
            this.Device_PartsnavBarItem.Caption = "設備/零件資料";
            this.Device_PartsnavBarItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("Device_PartsnavBarItem.ImageOptions.LargeImage")));
            this.Device_PartsnavBarItem.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("Device_PartsnavBarItem.ImageOptions.SmallImage")));
            this.Device_PartsnavBarItem.Name = "Device_PartsnavBarItem";
            this.Device_PartsnavBarItem.Tag = "4";
            this.Device_PartsnavBarItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.NavBarItem_LinkClicked);
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
            this.pcl_View.Location = new System.Drawing.Point(184, 25);
            this.pcl_View.Name = "pcl_View";
            this.pcl_View.Size = new System.Drawing.Size(1278, 843);
            this.pcl_View.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1462, 895);
            this.Controls.Add(this.pcl_View);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "ERPManagementAPP";
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
    }
}

