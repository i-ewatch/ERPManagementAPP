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
            SalesMaintainControl salesMaintainControl = new SalesMaintainControl(apiMethod, form1);
            PaymentMiantainControl paymentMiantainControl = new PaymentMiantainControl(apiMethod, form1);
            PurchasePostingMaintainControl purchasePostingMaintainControl = new PurchasePostingMaintainControl(apiMethod, form1);
            SalesPostingMaintainControl salesPostingMaintainControl = new SalesPostingMaintainControl(apiMethod, form1);
            PaymentTransferMaintainControl paymentTransferMaintainControl = new PaymentTransferMaintainControl(apiMethod, form1);
            PartnerMaintainControl partnerMaintainControl = new PartnerMaintainControl(apiMethod, form1);

            MaintainModule.Add(homeMaintainControl);
            MaintainModule.Add(companyMaintainControl);
            MaintainModule.Add(customerMaintainControl);
            MaintainModule.Add(employeeMaintainControl);
            MaintainModule.Add(productMaintainControl);
            MaintainModule.Add(purchaseMaintainControl);
            MaintainModule.Add(salesMaintainControl);
            MaintainModule.Add(paymentMiantainControl);
            MaintainModule.Add(purchasePostingMaintainControl);
            MaintainModule.Add(salesPostingMaintainControl);
            MaintainModule.Add(paymentTransferMaintainControl);
            MaintainModule.Add(partnerMaintainControl);
        }
    }
}
