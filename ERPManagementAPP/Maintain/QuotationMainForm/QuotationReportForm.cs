using ERPManagementAPP.Models;
using ERPManagementAPP.Report;
using System.Collections.Generic;

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
            #endregion
        }
    }
}