using ERPManagementAPP.Maintain;
using ERPManagementAPP.Methods;

namespace ERPManagementAPP.Modules
{
    public class Registrations
    {
        public static void Register(APIMethod apiMethod, Form1 form1)
        {
            HomeMaintainControl homeMaintainControl = new HomeMaintainControl();//首頁
            #region 基本資料管理(群組)
            CompanyMaintainControl companyMaintainControl = new CompanyMaintainControl(apiMethod, form1);//廠商資料
            CustomerMaintainControl customerMaintainControl = new CustomerMaintainControl(apiMethod, form1);//客戶資料
            EmployeeMaintainControl employeeMaintainControl = new EmployeeMaintainControl(apiMethod, form1);//員工資料
            ProductMaintainControl productMaintainControl = new ProductMaintainControl(apiMethod, form1);//設備/零件資料
            ProjectMaintainControl projectMaintainControl = new ProjectMaintainControl(apiMethod, form1);//專案資料
            #endregion

            #region 會計管理(群組)
            OperatingMaintainControl operatingMaintainControl = new OperatingMaintainControl(apiMethod, form1);//營運/營運退出
            PurchaseMaintainControl purchaseMaintainControl = new PurchaseMaintainControl(apiMethod, form1);//進貨/進貨退出
            PickingMaintainControl pickingMaintainControl = new PickingMaintainControl(apiMethod, form1);//領料/領料退回
            SalesMaintainControl salesMaintainControl = new SalesMaintainControl(apiMethod, form1);//銷貨/銷貨退回
            PaymentMiantainControl paymentMiantainControl = new PaymentMiantainControl(apiMethod, form1);//代墊代付費用
            #endregion

            #region 收付款管理(群組)
            PurchasePostingMaintainControl purchasePostingMaintainControl = new PurchasePostingMaintainControl(apiMethod, form1);//進貨營運管理
            SalesPostingMaintainControl salesPostingMaintainControl = new SalesPostingMaintainControl(apiMethod, form1);//銷貨/銷貨退回
            PaymentTransferMaintainControl paymentTransferMaintainControl = new PaymentTransferMaintainControl(apiMethod, form1);//代墊代付費用
            PartnerMaintainControl partnerMaintainControl = new PartnerMaintainControl(apiMethod, form1);//合作夥伴分潤
            #endregion

            MaintainModule.Add(homeMaintainControl);            //0-首頁
            MaintainModule.Add(companyMaintainControl);         //1-基本資料管理(群組)_廠商資料
            MaintainModule.Add(customerMaintainControl);        //2-基本資料管理(群組)_客戶資料
            MaintainModule.Add(employeeMaintainControl);        //3-基本資料管理(群組)_員工資料
            MaintainModule.Add(productMaintainControl);         //4-基本資料管理(群組)_設備/零件資料
            MaintainModule.Add(purchaseMaintainControl);        //5-會計管理(群組)_進貨/進貨退出
            MaintainModule.Add(salesMaintainControl);           //6-會計管理(群組)_銷貨/銷貨退回
            MaintainModule.Add(paymentMiantainControl);         //7-會計管理(群組)_代墊代付費用
            MaintainModule.Add(purchasePostingMaintainControl); //8-收付款管理(群組)_進貨營運管理
            MaintainModule.Add(salesPostingMaintainControl);    //9-收付款管理(群組)_銷貨/銷貨退回
            MaintainModule.Add(paymentTransferMaintainControl); //10-收付款管理(群組)_代墊代付費用
            MaintainModule.Add(partnerMaintainControl);         //11-收付款管理(群組)_合作夥伴分潤
            MaintainModule.Add(projectMaintainControl);         //12-基本資料管理(群組)_專案資料
            MaintainModule.Add(pickingMaintainControl);         //13-會計管理(群組)_領料/領料退回
            MaintainModule.Add(operatingMaintainControl);       //14-會計管理(群組)_營運/營運退出
        }
    }
}
