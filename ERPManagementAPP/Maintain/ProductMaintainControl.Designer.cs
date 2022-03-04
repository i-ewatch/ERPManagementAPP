
namespace ERPManagementAPP.Maintain
{
    partial class ProductMaintainControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductMaintainControl));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.ProductCategorygroupControl = new DevExpress.XtraEditors.GroupControl();
            this.ProductCategorygridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCategoryNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductCategorypanelControl = new DevExpress.XtraEditors.PanelControl();
            this.btn_ProductGategory_Refresh = new DevExpress.XtraEditors.SimpleButton();
            this.btn_ProductGategory_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_ProductGategory_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_ProductGategory_Add = new DevExpress.XtraEditors.SimpleButton();
            this.ProductgroupControl = new DevExpress.XtraEditors.GroupControl();
            this.ProductgridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProductCompanyNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductModel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFootPrint = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExplanation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProductpanelControl = new DevExpress.XtraEditors.PanelControl();
            this.btn_Product_Refresh = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Product_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Product_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Product_Add = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductCategorygroupControl)).BeginInit();
            this.ProductCategorygroupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductCategorygridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductCategorypanelControl)).BeginInit();
            this.ProductCategorypanelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductgroupControl)).BeginInit();
            this.ProductgroupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductgridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductpanelControl)).BeginInit();
            this.ProductpanelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.ProductCategorygroupControl);
            this.layoutControl1.Controls.Add(this.ProductgroupControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1325, 551, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1278, 846);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // ProductCategorygroupControl
            // 
            this.ProductCategorygroupControl.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ProductCategorygroupControl.AppearanceCaption.Options.UseForeColor = true;
            this.ProductCategorygroupControl.Controls.Add(this.ProductCategorygridControl);
            this.ProductCategorygroupControl.Controls.Add(this.ProductCategorypanelControl);
            this.ProductCategorygroupControl.Location = new System.Drawing.Point(881, 12);
            this.ProductCategorygroupControl.Name = "ProductCategorygroupControl";
            this.ProductCategorygroupControl.Size = new System.Drawing.Size(385, 822);
            this.ProductCategorygroupControl.TabIndex = 5;
            this.ProductCategorygroupControl.Text = "產品類別";
            // 
            // ProductCategorygridControl
            // 
            this.ProductCategorygridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductCategorygridControl.Location = new System.Drawing.Point(2, 66);
            this.ProductCategorygridControl.MainView = this.gridView2;
            this.ProductCategorygridControl.Name = "ProductCategorygridControl";
            this.ProductCategorygridControl.Size = new System.Drawing.Size(381, 754);
            this.ProductCategorygridControl.TabIndex = 1;
            this.ProductCategorygridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCategoryNumber,
            this.colCategoryName});
            this.gridView2.GridControl = this.ProductCategorygridControl;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colCategoryNumber
            // 
            this.colCategoryNumber.Caption = "產品類別編號";
            this.colCategoryNumber.FieldName = "CategoryNumber";
            this.colCategoryNumber.Name = "colCategoryNumber";
            this.colCategoryNumber.Visible = true;
            this.colCategoryNumber.VisibleIndex = 0;
            // 
            // colCategoryName
            // 
            this.colCategoryName.Caption = "產品類別名稱";
            this.colCategoryName.FieldName = "CategoryName";
            this.colCategoryName.Name = "colCategoryName";
            this.colCategoryName.Visible = true;
            this.colCategoryName.VisibleIndex = 1;
            // 
            // ProductCategorypanelControl
            // 
            this.ProductCategorypanelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ProductCategorypanelControl.Controls.Add(this.btn_ProductGategory_Refresh);
            this.ProductCategorypanelControl.Controls.Add(this.btn_ProductGategory_Delete);
            this.ProductCategorypanelControl.Controls.Add(this.btn_ProductGategory_Edit);
            this.ProductCategorypanelControl.Controls.Add(this.btn_ProductGategory_Add);
            this.ProductCategorypanelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProductCategorypanelControl.Location = new System.Drawing.Point(2, 23);
            this.ProductCategorypanelControl.Name = "ProductCategorypanelControl";
            this.ProductCategorypanelControl.Size = new System.Drawing.Size(381, 43);
            this.ProductCategorypanelControl.TabIndex = 0;
            // 
            // btn_ProductGategory_Refresh
            // 
            this.btn_ProductGategory_Refresh.AllowFocus = false;
            this.btn_ProductGategory_Refresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_ProductGategory_Refresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ProductGategory_Refresh.ImageOptions.Image")));
            this.btn_ProductGategory_Refresh.Location = new System.Drawing.Point(255, 0);
            this.btn_ProductGategory_Refresh.Name = "btn_ProductGategory_Refresh";
            this.btn_ProductGategory_Refresh.Size = new System.Drawing.Size(85, 43);
            this.btn_ProductGategory_Refresh.TabIndex = 8;
            this.btn_ProductGategory_Refresh.Text = "Refresh";
            // 
            // btn_ProductGategory_Delete
            // 
            this.btn_ProductGategory_Delete.AllowFocus = false;
            this.btn_ProductGategory_Delete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_ProductGategory_Delete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ProductGategory_Delete.ImageOptions.Image")));
            this.btn_ProductGategory_Delete.Location = new System.Drawing.Point(170, 0);
            this.btn_ProductGategory_Delete.Name = "btn_ProductGategory_Delete";
            this.btn_ProductGategory_Delete.Size = new System.Drawing.Size(85, 43);
            this.btn_ProductGategory_Delete.TabIndex = 7;
            this.btn_ProductGategory_Delete.Text = "Delete";
            // 
            // btn_ProductGategory_Edit
            // 
            this.btn_ProductGategory_Edit.AllowFocus = false;
            this.btn_ProductGategory_Edit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_ProductGategory_Edit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ProductGategory_Edit.ImageOptions.Image")));
            this.btn_ProductGategory_Edit.Location = new System.Drawing.Point(85, 0);
            this.btn_ProductGategory_Edit.Name = "btn_ProductGategory_Edit";
            this.btn_ProductGategory_Edit.Size = new System.Drawing.Size(85, 43);
            this.btn_ProductGategory_Edit.TabIndex = 6;
            this.btn_ProductGategory_Edit.Text = "Edit";
            // 
            // btn_ProductGategory_Add
            // 
            this.btn_ProductGategory_Add.AllowFocus = false;
            this.btn_ProductGategory_Add.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_ProductGategory_Add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ProductGategory_Add.ImageOptions.Image")));
            this.btn_ProductGategory_Add.Location = new System.Drawing.Point(0, 0);
            this.btn_ProductGategory_Add.Name = "btn_ProductGategory_Add";
            this.btn_ProductGategory_Add.Size = new System.Drawing.Size(85, 43);
            this.btn_ProductGategory_Add.TabIndex = 5;
            this.btn_ProductGategory_Add.Text = "Add";
            // 
            // ProductgroupControl
            // 
            this.ProductgroupControl.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ProductgroupControl.AppearanceCaption.Options.UseForeColor = true;
            this.ProductgroupControl.Controls.Add(this.ProductgridControl);
            this.ProductgroupControl.Controls.Add(this.ProductpanelControl);
            this.ProductgroupControl.Location = new System.Drawing.Point(12, 12);
            this.ProductgroupControl.Name = "ProductgroupControl";
            this.ProductgroupControl.Size = new System.Drawing.Size(853, 822);
            this.ProductgroupControl.TabIndex = 4;
            this.ProductgroupControl.Text = "產品資料";
            // 
            // ProductgridControl
            // 
            this.ProductgridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductgridControl.Location = new System.Drawing.Point(2, 66);
            this.ProductgridControl.MainView = this.gridView1;
            this.ProductgridControl.Name = "ProductgridControl";
            this.ProductgridControl.Size = new System.Drawing.Size(849, 754);
            this.ProductgridControl.TabIndex = 1;
            this.ProductgridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProductCompanyNumber,
            this.colProductNumber,
            this.colProductName,
            this.colProductModel,
            this.colProductType,
            this.colProductCategory,
            this.colFootPrint,
            this.colRemark,
            this.colExplanation,
            this.colFileName});
            this.gridView1.GridControl = this.ProductgridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colProductCompanyNumber
            // 
            this.colProductCompanyNumber.Caption = "廠商編號";
            this.colProductCompanyNumber.FieldName = "ProductCompanyNumber";
            this.colProductCompanyNumber.Name = "colProductCompanyNumber";
            this.colProductCompanyNumber.OptionsColumn.AllowEdit = false;
            this.colProductCompanyNumber.Visible = true;
            this.colProductCompanyNumber.VisibleIndex = 0;
            // 
            // colProductNumber
            // 
            this.colProductNumber.Caption = "產品編號";
            this.colProductNumber.FieldName = "ProductNumber";
            this.colProductNumber.Name = "colProductNumber";
            this.colProductNumber.OptionsColumn.AllowEdit = false;
            this.colProductNumber.Visible = true;
            this.colProductNumber.VisibleIndex = 1;
            // 
            // colProductName
            // 
            this.colProductName.Caption = "產品名稱";
            this.colProductName.FieldName = "ProductName";
            this.colProductName.Name = "colProductName";
            this.colProductName.OptionsColumn.AllowEdit = false;
            this.colProductName.Visible = true;
            this.colProductName.VisibleIndex = 2;
            // 
            // colProductModel
            // 
            this.colProductModel.Caption = "產品型號";
            this.colProductModel.FieldName = "ProductModel";
            this.colProductModel.Name = "colProductModel";
            this.colProductModel.OptionsColumn.AllowEdit = false;
            this.colProductModel.Visible = true;
            this.colProductModel.VisibleIndex = 3;
            // 
            // colProductType
            // 
            this.colProductType.Caption = "產品種類";
            this.colProductType.FieldName = "ProductType";
            this.colProductType.Name = "colProductType";
            this.colProductType.OptionsColumn.AllowEdit = false;
            this.colProductType.Visible = true;
            this.colProductType.VisibleIndex = 4;
            // 
            // colProductCategory
            // 
            this.colProductCategory.Caption = "產品類別編號";
            this.colProductCategory.FieldName = "ProductCategory";
            this.colProductCategory.Name = "colProductCategory";
            this.colProductCategory.OptionsColumn.AllowEdit = false;
            this.colProductCategory.Visible = true;
            this.colProductCategory.VisibleIndex = 5;
            // 
            // colFootPrint
            // 
            this.colFootPrint.Caption = "FootPrint";
            this.colFootPrint.FieldName = "FootPrint";
            this.colFootPrint.Name = "colFootPrint";
            this.colFootPrint.OptionsColumn.AllowEdit = false;
            this.colFootPrint.Visible = true;
            this.colFootPrint.VisibleIndex = 6;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "備註";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.OptionsColumn.AllowEdit = false;
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 7;
            // 
            // colExplanation
            // 
            this.colExplanation.Caption = "說明";
            this.colExplanation.FieldName = "Explanation";
            this.colExplanation.Name = "colExplanation";
            this.colExplanation.OptionsColumn.AllowEdit = false;
            this.colExplanation.Visible = true;
            this.colExplanation.VisibleIndex = 8;
            // 
            // colFileName
            // 
            this.colFileName.Caption = "附件名稱";
            this.colFileName.FieldName = "FileName";
            this.colFileName.Name = "colFileName";
            this.colFileName.Visible = true;
            this.colFileName.VisibleIndex = 9;
            // 
            // ProductpanelControl
            // 
            this.ProductpanelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ProductpanelControl.Controls.Add(this.btn_Product_Refresh);
            this.ProductpanelControl.Controls.Add(this.btn_Product_Delete);
            this.ProductpanelControl.Controls.Add(this.btn_Product_Edit);
            this.ProductpanelControl.Controls.Add(this.btn_Product_Add);
            this.ProductpanelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProductpanelControl.Location = new System.Drawing.Point(2, 23);
            this.ProductpanelControl.Name = "ProductpanelControl";
            this.ProductpanelControl.Size = new System.Drawing.Size(849, 43);
            this.ProductpanelControl.TabIndex = 0;
            // 
            // btn_Product_Refresh
            // 
            this.btn_Product_Refresh.AllowFocus = false;
            this.btn_Product_Refresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Product_Refresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Product_Refresh.ImageOptions.Image")));
            this.btn_Product_Refresh.Location = new System.Drawing.Point(255, 0);
            this.btn_Product_Refresh.Name = "btn_Product_Refresh";
            this.btn_Product_Refresh.Size = new System.Drawing.Size(85, 43);
            this.btn_Product_Refresh.TabIndex = 7;
            this.btn_Product_Refresh.Text = "Refresh";
            // 
            // btn_Product_Delete
            // 
            this.btn_Product_Delete.AllowFocus = false;
            this.btn_Product_Delete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Product_Delete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Product_Delete.ImageOptions.Image")));
            this.btn_Product_Delete.Location = new System.Drawing.Point(170, 0);
            this.btn_Product_Delete.Name = "btn_Product_Delete";
            this.btn_Product_Delete.Size = new System.Drawing.Size(85, 43);
            this.btn_Product_Delete.TabIndex = 6;
            this.btn_Product_Delete.Text = "Delete";
            // 
            // btn_Product_Edit
            // 
            this.btn_Product_Edit.AllowFocus = false;
            this.btn_Product_Edit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Product_Edit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Product_Edit.ImageOptions.Image")));
            this.btn_Product_Edit.Location = new System.Drawing.Point(85, 0);
            this.btn_Product_Edit.Name = "btn_Product_Edit";
            this.btn_Product_Edit.Size = new System.Drawing.Size(85, 43);
            this.btn_Product_Edit.TabIndex = 5;
            this.btn_Product_Edit.Text = "Edit";
            // 
            // btn_Product_Add
            // 
            this.btn_Product_Add.AllowFocus = false;
            this.btn_Product_Add.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Product_Add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Product_Add.ImageOptions.Image")));
            this.btn_Product_Add.Location = new System.Drawing.Point(0, 0);
            this.btn_Product_Add.Name = "btn_Product_Add";
            this.btn_Product_Add.Size = new System.Drawing.Size(85, 43);
            this.btn_Product_Add.TabIndex = 4;
            this.btn_Product_Add.Text = "Add";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.splitterItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1278, 846);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.ProductgroupControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(857, 826);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.ProductCategorygroupControl;
            this.layoutControlItem2.Location = new System.Drawing.Point(869, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(389, 826);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.Location = new System.Drawing.Point(857, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(12, 826);
            // 
            // ProductMaintainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ProductMaintainControl";
            this.Size = new System.Drawing.Size(1278, 846);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductCategorygroupControl)).EndInit();
            this.ProductCategorygroupControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductCategorygridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductCategorypanelControl)).EndInit();
            this.ProductCategorypanelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductgroupControl)).EndInit();
            this.ProductgroupControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductgridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductpanelControl)).EndInit();
            this.ProductpanelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.GroupControl ProductCategorygroupControl;
        private DevExpress.XtraEditors.GroupControl ProductgroupControl;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraEditors.PanelControl ProductCategorypanelControl;
        private DevExpress.XtraEditors.PanelControl ProductpanelControl;
        private DevExpress.XtraEditors.SimpleButton btn_Product_Refresh;
        private DevExpress.XtraEditors.SimpleButton btn_Product_Delete;
        private DevExpress.XtraEditors.SimpleButton btn_Product_Edit;
        private DevExpress.XtraEditors.SimpleButton btn_Product_Add;
        private DevExpress.XtraEditors.SimpleButton btn_ProductGategory_Refresh;
        private DevExpress.XtraEditors.SimpleButton btn_ProductGategory_Delete;
        private DevExpress.XtraEditors.SimpleButton btn_ProductGategory_Edit;
        private DevExpress.XtraEditors.SimpleButton btn_ProductGategory_Add;
        private DevExpress.XtraGrid.GridControl ProductCategorygridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryName;
        private DevExpress.XtraGrid.GridControl ProductgridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colProductCompanyNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colProductNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colProductName;
        private DevExpress.XtraGrid.Columns.GridColumn colProductModel;
        private DevExpress.XtraGrid.Columns.GridColumn colProductType;
        private DevExpress.XtraGrid.Columns.GridColumn colProductCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colFootPrint;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colExplanation;
        private DevExpress.XtraGrid.Columns.GridColumn colFileName;
    }
}
