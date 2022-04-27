using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using ERPManagementAPP.Methods;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain
{
    public class Field4MaintainControl : XtraUserControl
    {
        /// <summary>
        /// API重複讀取次數
        /// </summary>
        public int length = 3;
        /// <summary>
        /// 主畫面繼承用
        /// </summary>
        public Form1 Form1 { get; set; }
        /// <summary>
        /// API方法
        /// </summary>
        public APIMethod apiMethod { get; set; }
        /// <summary>
        /// 儲存檔案物件
        /// </summary>
        public SaveFileDialog saveFileDialog { get; set; }
        /// <summary>
        /// Loading物件繼承
        /// </summary>
        public IOverlaySplashScreenHandle handle = null;
        /// 關閉Loading視窗
        /// </summary>
        /// <param name="handle"></param>
        public void CloseProgressPanel(IOverlaySplashScreenHandle handle)
        {
            if (handle != null)
                SplashScreenManager.CloseOverlayForm(handle);
        }
        /// <summary>
        /// 錯誤訊息視窗顯示
        /// </summary>
        public FlyoutAction action = new FlyoutAction();
        /// <summary>
        /// 錯誤訊息視窗顯示1
        /// </summary>
        public FlyoutAction action1 = new FlyoutAction();
        /// <summary>
        /// 刷新資料(主要)
        /// </summary>
        public virtual void Refresh_Main_GridView() { }
        /// <summary>
        /// 刷新資料(次要)
        /// </summary>
        public virtual void Refresh_Second_GridView(string Number) { }
        /// <summary>
        /// 刷新權限
        /// </summary>
        public virtual void Refresh_Token() { }
    }
}
