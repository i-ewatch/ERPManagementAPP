using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using ERPManagementAPP.Configuration;
using ERPManagementAPP.Emuns;
using ERPManagementAPP.Maintain.AccountMaintainForm;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Models;
using ERPManagementAPP.Modules;
using Serilog;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ERPManagementAPP
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 錯誤泡泡視窗
        /// </summary>
        private FlyoutPanel ErrorflyoutPanel;
        /// <summary>
        /// API功能
        /// </summary>
        private APIMethod APIMethod { get; set; }
        /// <summary>
        /// 系統設定資訊
        /// </summary>
        private SystemSetting SystemSetting { get; set; }
        /// <summary>
        /// 登入員工資料
        /// </summary>
        public EmployeeSetting EmployeeSetting { get; set; } = new EmployeeSetting();
        /// <summary>
        /// 權限
        /// </summary>
        private TokenEnum TokenEnum { get; set; }
        public Form1()
        {
            InitializeComponent();
            #region serialog
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File($"{AppDomain.CurrentDomain.BaseDirectory}\\log\\log-.txt",
                rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();        //宣告Serilog初始化
            #endregion
            var tDll = this.GetType().Assembly.GetName();
            SystemSetting = InitailMethod.SystemLoad();
            APIMethod = new APIMethod(SystemSetting.URL, tDll.Version.ToString());
            LoginbarButtonItem.ImageOptions.Image = LoginimageCollection.Images["login"];
            Registrations.Register(APIMethod, this);
            #region 權限登入
            LoginbarButtonItem.ItemClick += (s, e) =>
            {
                if (EmployeeSetting.AccountNo != null)
                {
                    EmployeeSetting = new EmployeeSetting();
                    TokenChange();
                    HomeShow();
                }
                else
                {
                    AccountEditForm accountEdit = new AccountEditForm(this, APIMethod);
                    if (accountEdit.ShowDialog() == DialogResult.OK)
                    {
                        TokenChange();
                        HomeShow();
                    }
                }
            };
            #endregion
            TokenChange();//權限限制
            HomeShow();
            timer.Interval = 1000;
            timer.Enabled = true;
        }

        #region 權限變更
        /// <summary>
        /// 權限變更
        /// </summary>
        private void TokenChange()
        {
            TokenEnum = (TokenEnum)EmployeeSetting.Token;
            switch (TokenEnum)
            {
                case TokenEnum.None:
                    {
                        timer.Enabled = false;
                        if (TimebarStaticItem.ItemAppearance.Normal.ForeColor == Color.Red)
                        {
                            TimebarStaticItem.ItemAppearance.Normal.ForeColor = Color.White;
                        }
                        TimebarStaticItem.Caption = "請登入使用者";
                        LoginbarButtonItem.Caption = "Login";
                        LoginbarButtonItem.ImageOptions.Image = LoginimageCollection.Images["login"];
                        navBarControl1.Enabled = false;
                        PaymentManagementBarGroup.Visible = false;
                    }
                    break;
                case TokenEnum.user:
                    {
                        LoginbarButtonItem.ImageOptions.Image = LoginimageCollection.Images["employee"];
                        LoginbarButtonItem.Caption = EmployeeSetting.EmployeeName;
                        timer.Interval = 1000;
                        timer.Enabled = true;
                        navBarControl1.Enabled = true;
                        PaymentManagementBarGroup.Visible = false;
                    }
                    break;
                case TokenEnum.adminstrator:
                    {
                        LoginbarButtonItem.ImageOptions.Image = LoginimageCollection.Images["administrator"];
                        LoginbarButtonItem.Caption = EmployeeSetting.EmployeeName;
                        timer.Interval = 1000;
                        timer.Enabled = true;
                        navBarControl1.Enabled = true;
                        PaymentManagementBarGroup.Visible = true;
                    }
                    break;
            }
        }
        #endregion

        #region 返回首頁
        /// <summary>
        /// 返回首頁
        /// </summary>
        private void HomeShow()
        {
            pcl_View.Parent.SuspendLayout();
            pcl_View.SuspendLayout();
            try
            {

                var maintainControl = MaintainModule.SelectItem(0);
                if (maintainControl != null)
                {
                    maintainControl.Dock = DockStyle.Fill;
                    maintainControl.Parent = pcl_View;
                    MaintainModule.CurrentControl.Visible = true;
                }
            }
            finally
            {
                pcl_View.ResumeLayout();
                pcl_View.Parent.ResumeLayout();
            }
            navBarControl1.ActiveGroup = BasicDatanavBarGroup;
            BasicDatanavBarGroup.SelectedLinkIndex = -1;
            AccountingBarGroup.SelectedLinkIndex = -1;
        }
        #endregion

        #region 切換畫面功能
        private void NavBarItem_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (TokenEnum == TokenEnum.adminstrator || TokenEnum == TokenEnum.user)//權限限制
            {
                pcl_View.Parent.SuspendLayout();
                pcl_View.SuspendLayout();
                try
                {
                    int Index = Convert.ToInt32(((NavBarItem)sender).Tag);
                    var maintainControl = MaintainModule.SelectItem(Index);
                    if (maintainControl != null)
                    {
                        maintainControl.Dock = DockStyle.Fill;
                        maintainControl.Parent = pcl_View;
                        maintainControl.Refresh_Main_GridView();
                        maintainControl.Refresh_Token();//權限限制
                        MaintainModule.CurrentControl.Visible = true;
                    }
                }
                finally
                {
                    pcl_View.ResumeLayout();
                    pcl_View.Parent.ResumeLayout();
                }
            }
        }
        #endregion

        #region 執行緒
        private void timer_Tick(object sender, EventArgs e)
        {
            if (APIMethod.ClientFlag)
            {
                if (ErrorflyoutPanel != null)
                {
                    ErrorflyoutPanel.HidePopup();
                    ErrorflyoutPanel = null;
                }
                if (ConnectbarStaticItem.ItemAppearance.Normal.ForeColor == Color.Red)
                {
                    ConnectbarStaticItem.ItemAppearance.Normal.ForeColor = Color.Black;
                }
                TimebarStaticItem.Caption = $"系統時間 : {DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} ";
                ConnectbarStaticItem.Caption = $"最後通訊時間 : {APIMethod.ErrorStr}";
            }
            else
            {
                if (ConnectbarStaticItem.ItemAppearance.Normal.ForeColor == Color.Black)
                {
                    ConnectbarStaticItem.ItemAppearance.Normal.ForeColor = Color.Red;
                }
                TimebarStaticItem.Caption = $"系統時間 : {DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} ";
                ConnectbarStaticItem.Caption = APIMethod.ErrorStr;
                if (ErrorflyoutPanel == null)
                {
                    ErrorflyoutPanel = new FlyoutPanel()
                    {
                        OwnerControl = this,
                        Size = new Size(this.Size.Width, 20)
                    };
                    LabelControl label = new LabelControl() { Dock = DockStyle.Fill };
                    label.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                    label.Appearance.Font = new Font("微軟正黑體", 12, FontStyle.Bold);
                    label.Appearance.ForeColor = Color.White;
                    label.Appearance.BackColor = Color.Red;
                    label.AutoSizeMode = LabelAutoSizeMode.None;
                    label.Text = "無網路或伺服器未開啟!";
                    ErrorflyoutPanel.Controls.Add(label);
                    ErrorflyoutPanel.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Bottom;
                    ErrorflyoutPanel.ShowPopup();
                }
            }

        }
        #endregion

        #region 視窗顯示初始化
        private void Form1_Load(object sender, EventArgs e)
        {
            Location = new Point(0, 0);
            Size = new System.Drawing.Size(1496, 962);
        }
        #endregion

        #region 視窗關閉
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Enabled = false;
            }
        }
        #endregion
    }
}
