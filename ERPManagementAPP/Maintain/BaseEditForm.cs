using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace ERPManagementAPP.Maintain
{
    public class BaseEditForm: XtraForm
    {
        /// <summary>
        /// 檔案路徑
        /// </summary>
        public string AttachmentFilePath = "";
        /// <summary>
        /// 開啟檔案瀏覽
        /// </summary>
        public OpenFileDialog openFileDialog = new OpenFileDialog();
        /// <summary>
        /// 主畫面繼承用
        /// </summary>
        public Form1 Form1 { get; set; }
        /// <summary>
        /// 錯誤訊息視窗顯示
        /// </summary>
        public FlyoutAction action = new FlyoutAction();
    }
}
