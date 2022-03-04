using DevExpress.XtraNavBar;
using ERPManagementAPP.Configuration;
using ERPManagementAPP.Emuns;
using ERPManagementAPP.Maintain;
using ERPManagementAPP.Methods;
using ERPManagementAPP.Modules;
using Serilog;
using System;
using System.Windows.Forms;

namespace ERPManagementAPP
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// API功能
        /// </summary>
        private APIMethod APIMethod { get; set; }
        /// <summary>
        /// 系統設定資訊
        /// </summary>
        private SystemSetting SystemSetting { get; set; }
        /// <summary>
        /// 權限編碼
        /// </summary>
        public int TokenEnumIndex { get; set; } = 0;
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
            SystemSetting = InitailMethod.SystemLoad();
            APIMethod = new APIMethod(SystemSetting.URL);
            LoginbarButtonItem.ImageOptions.Image = LoginimageCollection.Images["login"];
            Registrations.Register(APIMethod, this);
            TokenChange();
            HomeShow();
            timer.Interval = 1000;
            timer.Enabled = true;
            #region 權限登入
            //LoginbarButtonItem.ItemClick += (s, e) =>
            //{
            //    TokenEnum = (TokenEnum)TokenEnumIndex;
            //    if (TokenEnum == TokenEnum.adminstrator || TokenEnum == TokenEnum.user)
            //    {
            //        TokenEnumIndex = 0;
            //        TokenEnum = (TokenEnum)TokenEnumIndex;
            //    }
            //    else
            //    {
            //        TokenEnumIndex = 2;
            //        TokenEnum = (TokenEnum)TokenEnumIndex;
            //    }
            //    TokenChange();
            //    HomeShow();
            //};
            #endregion
        }

        #region 權限變更
        /// <summary>
        /// 權限變更
        /// </summary>
        private void TokenChange()
        {
            switch (TokenEnum)
            {
                case TokenEnum.None:
                    {
                        timer.Enabled = false;
                        TimebarStaticItem.Caption = "請登入使用者";
                        LoginbarButtonItem.ImageOptions.Image = LoginimageCollection.Images["login"];
                    }
                    break;
                case TokenEnum.user:
                    {
                        LoginbarButtonItem.ImageOptions.Image = LoginimageCollection.Images["employee"];
                        timer.Interval = 1000;
                        timer.Enabled = true;
                    }
                    break;
                case TokenEnum.adminstrator:
                    {
                        LoginbarButtonItem.ImageOptions.Image = LoginimageCollection.Images["administrator"];
                        timer.Interval = 1000;
                        timer.Enabled = true;
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
            BasicDatanavBarGroup.SelectedLinkIndex = -1;
        }
        #endregion
        #region 切換畫面功能
        private void NavBarItem_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            //if (TokenEnum == TokenEnum.adminstrator || TokenEnum == TokenEnum.user)
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
        #region 視窗顯示初始化
        private void Form1_Load(object sender, EventArgs e)
        {
            Size = new System.Drawing.Size(1496, 962);
        }
        #endregion
        #region 執行緒
        private void timer_Tick(object sender, EventArgs e)
        {
            if (APIMethod.ClientFlag)
            {
                TimebarStaticItem.Caption = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            }
            else
            {
                TimebarStaticItem.Caption = APIMethod.ErrorStr;
            }

        }
        #endregion
    }
}
