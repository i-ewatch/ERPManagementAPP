
namespace ERPManagementAPP.Maintain.PaymentMaintainForm
{
    partial class PaymentItemEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentItemEditForm));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.txt_PaymentItemNo = new DevExpress.XtraEditors.TextEdit();
            this.txt_PaymentItemName = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PaymentItemNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PaymentItemName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.panelControl4);
            this.layoutControl1.Controls.Add(this.txt_PaymentItemNo);
            this.layoutControl1.Controls.Add(this.txt_PaymentItemName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(664, 136);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.btn_Save);
            this.panelControl4.Controls.Add(this.btn_Cancel);
            this.panelControl4.Location = new System.Drawing.Point(12, 89);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(640, 35);
            this.panelControl4.TabIndex = 20;
            // 
            // btn_Save
            // 
            this.btn_Save.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.ImageOptions.Image")));
            this.btn_Save.Location = new System.Drawing.Point(452, 0);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(94, 35);
            this.btn_Save.TabIndex = 1;
            this.btn_Save.Text = "Save";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Cancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.ImageOptions.Image")));
            this.btn_Cancel.Location = new System.Drawing.Point(546, 0);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(94, 35);
            this.btn_Cancel.TabIndex = 0;
            this.btn_Cancel.Text = "Cancel";
            // 
            // txt_PaymentItemNo
            // 
            this.txt_PaymentItemNo.Location = new System.Drawing.Point(86, 12);
            this.txt_PaymentItemNo.Name = "txt_PaymentItemNo";
            this.txt_PaymentItemNo.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_PaymentItemNo.Properties.Appearance.Options.UseFont = true;
            this.txt_PaymentItemNo.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txt_PaymentItemNo.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txt_PaymentItemNo.Properties.MaxLength = 24;
            this.txt_PaymentItemNo.Size = new System.Drawing.Size(566, 26);
            this.txt_PaymentItemNo.StyleController = this.layoutControl1;
            this.txt_PaymentItemNo.TabIndex = 4;
            // 
            // txt_PaymentItemName
            // 
            this.txt_PaymentItemName.Location = new System.Drawing.Point(86, 42);
            this.txt_PaymentItemName.Name = "txt_PaymentItemName";
            this.txt_PaymentItemName.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_PaymentItemName.Properties.Appearance.Options.UseFont = true;
            this.txt_PaymentItemName.Properties.MaxLength = 50;
            this.txt_PaymentItemName.Size = new System.Drawing.Size(566, 26);
            this.txt_PaymentItemName.StyleController = this.layoutControl1;
            this.txt_PaymentItemName.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(664, 136);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txt_PaymentItemNo;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(644, 30);
            this.layoutControlItem1.Text = "品項代碼*";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(71, 20);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 60);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(644, 17);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.txt_PaymentItemName;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem2.CustomizationFormText = "品項名稱";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(644, 30);
            this.layoutControlItem2.Text = "品項名稱";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(71, 20);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.panelControl4;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 77);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(644, 39);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // PaymentItemEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 136);
            this.ControlBox = false;
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentItemEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PaymentItemEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_PaymentItemNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PaymentItemName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraEditors.TextEdit txt_PaymentItemNo;
        private DevExpress.XtraEditors.TextEdit txt_PaymentItemName;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}