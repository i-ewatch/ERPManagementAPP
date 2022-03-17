using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using ERPManagementAPP.Methods;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain
{
    public class Field4MaintainControl : XtraUserControl
    {
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
        /// 錯誤訊息視窗顯示
        /// </summary>
        public FlyoutAction action = new FlyoutAction();
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
