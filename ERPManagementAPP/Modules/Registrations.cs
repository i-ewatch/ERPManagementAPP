using ERPManagementAPP.Maintain;
using ERPManagementAPP.Methods;

namespace ERPManagementAPP.Modules
{
    public class Registrations
    {
        public static void Register(APIMethod apiMethod, Form1 form1)
        {
            HomeMaintainControl homeMaintainControl = new HomeMaintainControl();
            CompanyMaintainControl companyMaintainControl = new CompanyMaintainControl(apiMethod, form1);
            CustomerMaintainControl customerMaintainControl = new CustomerMaintainControl(apiMethod, form1);
            EmployeeMaintainControl employeeMaintainControl = new EmployeeMaintainControl(apiMethod, form1);
            ProductMaintainControl productMaintainControl = new ProductMaintainControl(apiMethod, form1);
            PurchaseMaintainControl purchaseMaintainControl = new PurchaseMaintainControl(apiMethod, form1);
            MaintainModule.Add(homeMaintainControl);
            MaintainModule.Add(companyMaintainControl);
            MaintainModule.Add(customerMaintainControl);
            MaintainModule.Add(employeeMaintainControl);
            MaintainModule.Add(productMaintainControl);
            MaintainModule.Add(purchaseMaintainControl);
        }
    }
}
