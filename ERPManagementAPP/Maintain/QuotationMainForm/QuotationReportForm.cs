using DevExpress.XtraPrinting;
using ERPManagementAPP.Models;
using ERPManagementAPP.Report;
using System.Collections.Generic;
using System.Text;

namespace ERPManagementAPP.Maintain.QuotationMainForm
{
    public partial class QuotationReportForm : BaseEditForm
    {
        public QuotationReportForm(CustomerSetting customerSetting, EmployeeSetting employeeSetting, ProjectSetting projectSetting, QuotationSetting quotationSetting)
        {
            InitializeComponent();
            QutationReport qutationReport = new QutationReport();
            qutationReport.Create_View(customerSetting, employeeSetting, projectSetting, quotationSetting);
            qutationReport.CreateDocument();
            documentViewer1.DocumentSource = qutationReport;
            #region 取消按鈕
            btn_Close.Click += (s, e) =>
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            };
            PrintingSystemBase ps = qutationReport.PrintingSystem;
            ExportOptions options = ps.ExportOptions;
            //options.PrintPreview.ShowOptionsBeforeExport = false; //隱藏匯出詢問視窗
            options.Csv.Encoding = Encoding.UTF8;
            options.Html.CharacterSet = "UTF-8";
            options.Mht.CharacterSet = "UTF-8";
            options.Text.Encoding = Encoding.UTF8;
            options.Xls.ShowGridLines = true;
            options.Xlsx.ShowGridLines = true;
            #endregion
        }
    }
}