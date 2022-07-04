using ERPManagementAPP.Models;
using ERPManagementAPP.Report;
using System.Collections.Generic;

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
        }
    }
}