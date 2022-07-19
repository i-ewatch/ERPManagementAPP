using DevExpress.XtraPrinting;
using ERPManagementAPP.Models;
using ERPManagementAPP.Report;
using System.Collections.Generic;
using System.Text;

namespace ERPManagementAPP.Maintain.OrderMaintainForm
{
    public partial class OrderReportForm : BaseEditForm
    {
        public OrderReportForm(List<CompanySetting> companySettings, CompanyDirectorySetting companyDirectorySetting, EmployeeSetting employeeSetting, ProjectSetting projectSetting, OrderSetting orderSetting)
        {
            InitializeComponent();
            OrderReport orderReport = new OrderReport();
            orderReport.Create_View(companySettings, companyDirectorySetting, employeeSetting, projectSetting, orderSetting);
            orderReport.CreateDocument();
            documentViewer1.DocumentSource = orderReport;
            #region 取消按鈕
            btn_Close.Click += (s, e) =>
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            };
            #endregion
            PrintingSystemBase ps = orderReport.PrintingSystem;
            ExportOptions options = ps.ExportOptions;
            //options.PrintPreview.ShowOptionsBeforeExport = false; //隱藏匯出詢問視窗
            options.Csv.Encoding = Encoding.UTF8;
            options.Html.CharacterSet = "UTF-8";
            options.Mht.CharacterSet = "UTF-8";
            options.Text.Encoding = Encoding.UTF8;
            options.Xls.ShowGridLines = true;
            options.Xlsx.ShowGridLines = true;
        }
    }
}