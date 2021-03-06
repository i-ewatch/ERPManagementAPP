using ERPManagementAPP.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers;
using Serilog;
using System;
using System.Collections.Generic;

namespace ERPManagementAPP.Methods
{
    public class APIMethod
    {
        private int time = 3000;
        /// <summary>
        /// 主要網址
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public string ErrorStr { get; set; } = "NONE";
        /// <summary>
        /// API回應錯誤訊息
        /// </summary>
        public string ResponseErrorMessage { get; set; } = "";
        /// <summary>
        /// API回應數值
        /// </summary>
        public string ResponseDataMessage { get; set; } = "";
        /// <summary>
        /// API連結旗標
        /// </summary>
        public bool ClientFlag { get; set; } = true;
        /// <summary>
        /// API連結物件
        /// </summary>
        private RestClient clinet { get; set; }

        public string ReleaseNumber { get; set; }
        public APIMethod(string url, string releaseNumber)
        {
            ReleaseNumber = releaseNumber;
            URL = url;
            Login_url = $"{URL}/EmployeeLogin";

            Company_url = $"{URL}/Company";
            CompanyAttachmentFile_url = $"{URL}/CompanyAttachmentFile";
            CompanyAttachmentFile_url = $"{URL}/CompanyAttachmentFile";
            CompanyDirectory_url = $"{URL}/CompanyDirectory";
            CompanyDirectoryNumber_url = $"{URL}/CompanyDirectoryNumber";
            DirectoryCompany_url = $"{URL}/DirectoryCompany";
            CompanyDirectoryAttachmentFile_url = $"{URL}/CompanyDirectoryAttachmentFile";

            Customer_url = $"{URL}/Customer";
            CustomerNumber_url = $"{URL}/CustomerNumber";
            CustomerAttachmentFile_url = $"{URL}/CustomerAttachmentFile";
            CustomerDirectory_url = $"{URL}/CustomerDirectory";
            CustomerDirectoryNumber_url = $"{URL}/CompanyDirectoryNumber";
            DirectoryCustomer_url = $"{URL}/DirectoryCustomer";
            CustomerDirectoryAttachmentFile_url = $"{URL}/CustomerDirectoryAttachmentFile";

            Employee_url = $"{URL}/Employee";
            EmployeeNumber_url = $"{URL}/EmployeeNumber";

            Product_url = $"{URL}/Product";
            ProductType_url = $"{URL}/ProductNumber/ProductType";
            ProductNumber_url = $"{URL}/ProductNumber";
            ProductAttachmentFile_url = $"{URL}/ProductAttachmentFile";
            //ProductGategory_url = $"{URL}/ProductCategory"; //不使用 2022/5/4
            ProductDepartment_url = $"{URL}/ProductDepartment";
            ProductItem1_url = $"{URL}/ProductItem1";
            ProductItem2_url = $"{URL}/ProductItem2";
            ProductItem3_url = $"{URL}/ProductItem3";
            ProductItem4_url = $"{URL}/ProductItem4";
            ProductItem5_url = $"{URL}/ProductItem5";

            Purchase_url = $"{URL}/Purchase";
            PurchaseNumber_url = $"{URL}/Purchase/PurchaseNumber";
            PurchaseAttachmenFile_url = $"{URL}/PurchaseAttachmentFile";
            PurchasePosting_url = $"{URL}/Purchase/PurchasePosting";
            UpdatePurchaseMain_url = $"{URL}/Purchase/UpdatePurchaseMain";

            Sales_url = $"{URL}/Sales";
            SalesNumber_url = $"{URL}/Sales/SalesNumber";
            SalesAttachmenFile_url = $"{URL}/SalesAttachmentFile";
            SalesPosting_url = $"{URL}/Sales/SalesPosting";
            UpdateSalesMain_url = $"{URL}/Sales/UpdateSalesMain";

            Payment_url = $"{URL}/Payment";
            PaymentAttachmenFile_url = $"{URL}/PaymentAttachmentFile";
            PaymentItem_url = $"{URL}/PaymentItem";

            Project_url = $"{URL}/Project";
            ProjectAttachmenFile_url = $"{URL}/ProjectAttachmentFile";

            Picking_url = $"{URL}/Picking";
            PickingNumber_url = $"{URL}/Picking/PickingNumber";
            PickingAttachmenFile_url = $"{URL}/PickingAttachmentFile";
            PickingPosting_url = $"{URL}/Picking/PickingPosting";
            UpdatePickingMain_url = $"{URL}/Picking/UpdatePickingMain";

            Operating_url = $"{URL}/Operating";
            OperatingNumber_url = $"{URL}/Operating/OperatingNumber";
            OperatingAttachmenFile_url = $"{URL}/OperatingAttachmentFile";
            OperatingPosting_url = $"{URL}/Operating/OperatingPosting";
            UpdateOperatingMain_url = $"{URL}/Operating/UpdateOperatingMain";

            Order_url = $"{URL}/Order";
            OrderNumber_url = $"{URL}/Order/OrderNumber";
            OrderAttachmenFile_url = $"{URL}/OrderAttachmentFile";

            Quotation_url = $"{URL}/Quotation";
            QuotationNumber_url = $"{URL}/Quotation/QuotationNumber";
            QuotationAttachmenFile_url = $"{URL}/QuotationAttachmentFile";
        }
        #region 登入資訊
        /// <summary>
        /// 登入資料
        /// </summary>
        private string Login_url { get; set; }
        #endregion
        #region 公司資訊
        /// <summary>
        /// 廠商資料(Get、Post、Put、Delete)
        /// </summary>
        private string Company_url { get; set; }
        /// <summary>
        /// 廠商編碼查詢(Get)
        /// </summary>
        private string CompanyNumber_url { get; set; }
        /// <summary>
        /// 廠商檔案上傳(Post)
        /// </summary>
        private string CompanyAttachmentFile_url { get; set; }
        /// <summary>
        /// 廠商通訊錄資料(Get、Post、Put、Delete)
        /// </summary>
        private string CompanyDirectory_url { get; set; }
        /// <summary>
        /// 廠商通訊錄編碼查詢(Get)
        /// </summary>
        private string CompanyDirectoryNumber_url { get; set; }
        /// <summary>
        /// 廠商通訊錄廠商編碼查詢(Get)
        /// </summary>
        private string DirectoryCompany_url { get; set; }
        /// <summary>
        /// 廠商通訊錄檔案(Post、Get)
        /// </summary>
        private string CompanyDirectoryAttachmentFile_url { get; set; }
        #endregion
        #region 客戶資訊
        /// <summary>
        /// 客戶資料(Get、Post、Put、Delete)
        /// </summary>
        private string Customer_url { get; set; }
        /// <summary>
        /// 客戶編碼查詢(Get)
        /// </summary>
        private string CustomerNumber_url { get; set; }
        /// <summary>
        /// 客戶檔案上傳(Post)
        /// </summary>
        private string CustomerAttachmentFile_url { get; set; }
        /// <summary>
        /// 客戶通訊錄資料(Get、Post、Put、Delete)
        /// </summary>
        private string CustomerDirectory_url { get; set; }
        /// <summary>
        /// 客戶通訊錄編碼查詢(Get)
        /// </summary>
        private string CustomerDirectoryNumber_url { get; set; }
        /// <summary>
        /// 客戶編碼查詢(Get)
        /// </summary>
        private string DirectoryCustomer_url { get; set; }
        /// <summary>
        /// 客戶通訊錄檔案(Post、Get)
        /// </summary>
        private string CustomerDirectoryAttachmentFile_url { get; set; }
        #endregion
        #region 員工資訊
        /// <summary>
        /// 員工資料(Get、Post、Put、Delete)
        /// </summary>
        private string Employee_url { get; set; }
        /// <summary>
        /// 員工編碼查詢(Get)
        /// </summary>
        private string EmployeeNumber_url { get; set; }
        #endregion
        #region 產品資訊
        /// <summary>
        /// 產品資料(Get、Post、Put、Delete)
        /// </summary>
        private string Product_url { get; set; }
        /// <summary>
        /// 產品種類代碼查詢(Get)
        /// </summary>
        private string ProductType_url { get; set; }
        /// <summary>
        /// 產品代碼查詢(Get)
        /// </summary>
        private string ProductNumber_url { get; set; }
        /// <summary>
        /// 產品檔案(Post、Get)
        /// </summary>
        private string ProductAttachmentFile_url { get; set; }
        /// <summary>
        /// 產品類別資料(Get、Post、Put、Delete，不使用 2022/5/4)
        /// </summary>
        private string ProductGategory_url { get; set; }
        /// <summary>
        /// 部門類別資料(Get、Post、Put、Delete)
        /// </summary>
        private string ProductDepartment_url { get; set; }
        /// <summary>
        /// 項目1類別資料(Get、Post、Put、Delete)
        /// </summary>
        private string ProductItem1_url { get; set; }
        /// <summary>
        /// 項目2類別資料(Get、Post、Put、Delete)
        /// </summary>
        private string ProductItem2_url { get; set; }
        /// <summary>
        /// 項目3類別資料(Get、Post、Put、Delete)
        /// </summary>
        private string ProductItem3_url { get; set; }
        /// <summary>
        /// 項目4類別資料(Get、Post、Put、Delete)
        /// </summary>
        private string ProductItem4_url { get; set; }
        /// <summary>
        /// 項目5類別資料(Get、Post、Put、Delete)
        /// </summary>
        private string ProductItem5_url { get; set; }
        #endregion
        #region 訂購資訊
        /// <summary>
        /// 訂購資料(Get、Post、Put、Delete)
        /// </summary>
        private string Order_url { get; set; }
        /// <summary>
        /// 訂購資料查詢(年份)
        /// </summary>
        private string OrderNumber_url { get; set; }
        /// <summary>
        /// 訂購檔案(Post、Get)
        /// </summary>
        private string OrderAttachmenFile_url { get; set; }
        #endregion
        #region 報價資訊
        /// <summary>
        /// 報價資料(Get、Post、Put、Delete)
        /// </summary>
        private string Quotation_url { get; set; }
        /// <summary>
        /// 報價資料查詢(年份)
        /// </summary>
        private string QuotationNumber_url { get; set; }
        /// <summary>
        /// 報價檔案(Post、Get)
        /// </summary>
        private string QuotationAttachmenFile_url { get; set; }
        #endregion
        #region 進貨資訊
        /// <summary>
        /// 進貨資料(Get、Post、Put、Delete)
        /// </summary>
        private string Purchase_url { get; set; }
        /// <summary>
        /// 進貨資料查詢(年月份)
        /// </summary>
        private string PurchaseNumber_url { get; set; }
        /// <summary>
        /// 進貨檔案(Post、Get)
        /// </summary>
        private string PurchaseAttachmenFile_url { get; set; }
        /// <summary>
        /// 未過帳進貨資料(Get)
        /// </summary>
        private string PurchasePosting_url { get; set; }
        /// <summary>
        /// 進貨父更新(Put)
        /// </summary>
        private string UpdatePurchaseMain_url { get; set; }
        #endregion
        #region 銷貨資訊
        /// <summary>
        /// 銷貨資料(Get、Post、Put、Delete)
        /// </summary>
        private string Sales_url { get; set; }
        /// <summary>
        /// 銷貨資料查詢(年月份)
        /// </summary>
        private string SalesNumber_url { get; set; }
        /// <summary>
        /// 銷貨檔案(Post、Get)
        /// </summary>
        private string SalesAttachmenFile_url { get; set; }
        /// <summary>
        /// 未過帳銷貨資料(Get)
        /// </summary>
        private string SalesPosting_url { get; set; }
        /// <summary>
        /// 銷貨父更新(Put)
        /// </summary>
        private string UpdateSalesMain_url { get; set; }
        #endregion
        #region 代墊代付資訊
        /// <summary>
        /// 代墊代付資料(Get、Post、Put、Delete)
        /// </summary>
        private string Payment_url { get; set; }
        /// <summary>
        /// 代墊代付檔案(Post、Put)
        /// </summary>
        private string PaymentAttachmenFile_url { get; set; }
        /// <summary>
        /// 代墊代付請款品項資料(Get、Post、Put、Delete)
        /// </summary>
        private string PaymentItem_url { get; set; }
        #endregion
        #region 專案資訊
        /// <summary>
        /// 專案資料(Get、Post、Put、Delete)
        /// </summary>
        private string Project_url { get; set; }
        /// <summary>
        /// 專案檔案(Post、Put)
        /// </summary>
        private string ProjectAttachmenFile_url { get; set; }
        #endregion
        #region 領料資訊
        /// <summary>
        /// 領料資料(Get、Post、Put、Delete)
        /// </summary>
        private string Picking_url { get; set; }
        /// <summary>
        ///  領料資料查詢(年月份)
        /// </summary>
        private string PickingNumber_url { get; set; }
        /// <summary>
        /// 領料檔案(Post、Get)
        /// </summary>
        private string PickingAttachmenFile_url { get; set; }
        /// <summary>
        /// 未過帳銷貨資料(Get)
        /// </summary>
        private string PickingPosting_url { get; set; }
        /// <summary>
        /// 銷貨父更新(Put)
        /// </summary>
        private string UpdatePickingMain_url { get; set; }
        #endregion
        #region 營運資訊
        /// <summary>
        /// 營運資料(Get、Post、Put、Delete)
        /// </summary>
        private string Operating_url { get; set; }
        /// <summary>
        /// 營運資料查詢(年月份)
        /// </summary>
        private string OperatingNumber_url { get; set; }
        /// <summary>
        /// 營運檔案(Post、Get)
        /// </summary>
        private string OperatingAttachmenFile_url { get; set; }
        /// <summary>
        /// 未過帳營運資料(Get)
        /// </summary>
        private string OperatingPosting_url { get; set; }
        /// <summary>
        /// 營運父更新(Put)
        /// </summary>
        private string UpdateOperatingMain_url { get; set; }
        #endregion

        /*以下API功能----------------------------------------------------------------------------------------*/
        #region 登入API
        /// <summary>
        /// 帳號登入
        /// </summary>
        /// <param name="Account">帳號</param>
        /// <param name="PassWord">密碼</param>
        /// <returns></returns>
        public List<EmployeeSetting> Get_Login(string Account, string PassWord)
        {
            try
            {
                List<EmployeeSetting> setting = null;
                var option = new RestClientOptions(Login_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddParameter("Account", Account, type: ParameterType.QueryString);
                requsest.AddParameter("PassWord", PassWord, type: ParameterType.QueryString);
                var response = clinet.ExecuteGetAsync(requsest);
                response.Wait();
                if (response.Result.Content != null)
                {
                    setting = JsonConvert.DeserializeObject<List<EmployeeSetting>>(response.Result.Content);
                }
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return setting;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "登入失敗");
                ClientFlag = false;
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion

        #region 廠商API
        #region 全部廠商
        /// <summary>
        /// 全部廠商
        /// </summary>
        /// <returns></returns>
        public List<CompanySetting> Get_Company()
        {
            try
            {
                List<CompanySetting> settings = null;
                var option = new RestClientOptions(Company_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<CompanySetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<CompanySetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "查詢全部廠商API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 廠商(廠商編號)
        /// <summary>
        /// 廠商(廠商編號)
        /// </summary>
        /// <param name="CompanyNumber">廠商編號</param>
        /// <returns></returns>
        public List<CompanySetting> Get_CompanyNumber(string CompanyNumber)
        {
            try
            {
                List<CompanySetting> settings = null;
                var option = new RestClientOptions(CompanyNumber_url + $"/{CompanyNumber}")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<CompanySetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<CompanySetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "查詢廠商(廠商編號)API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 新增廠商資料
        /// <summary>
        /// 新增廠商資料
        /// </summary>
        /// <param name="companySetting"></param>
        /// <returns></returns>
        public string Post_Company(string companySetting)
        {
            try
            {
                var option = new RestClientOptions(Company_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(companySetting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "新增廠商資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 修改廠商資料
        /// <summary>
        /// 修改廠商資料
        /// </summary>
        /// <param name="customerSetting"></param>
        /// <returns></returns>
        public string Put_Company(string customerSetting)
        {
            try
            {
                var option = new RestClientOptions(Company_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(customerSetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "修改廠商資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 刪除廠商資料
        /// <summary>
        /// 刪除廠商資料
        /// </summary>
        /// <param name="customerSetting"></param>
        /// <returns></returns>
        public string Delete_Company(string customerSetting)
        {
            try
            {
                var option = new RestClientOptions(Company_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(customerSetting, ContentType.Json);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "刪除廠商資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 廠商上傳檔案
        /// <summary>
        /// 廠商上傳檔案
        /// </summary>
        /// <param name="Number">廠商編號</param>
        /// <param name="Name">廠商名稱</param>
        /// <param name="Path">檔案路徑</param>
        /// <returns></returns>
        public string Post_CompanyAttachmentFile(string Number, string Name, string Path)
        {
            try
            {
                var option = new RestClientOptions(CompanyAttachmentFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("CompanyNumber", Number, type: ParameterType.QueryString);
                requsest.AddParameter("CompanyName", Name, type: ParameterType.QueryString);
                requsest.AddFile("AttachmentFile", Path);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "廠商上傳檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 廠商下載檔案
        /// <summary>
        /// 廠商下載檔案
        /// </summary>
        /// <param name="Number">廠商編號</param>
        /// <param name="Name">廠商名稱</param>
        /// <param name="FileName">檔案名稱</param>
        /// <returns></returns>
        public byte[] Get_CompanyAttachmentFile(string Number, string Name, string FileName)
        {
            try
            {
                var option = new RestClientOptions(CompanyAttachmentFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("CompanyNumber", Number, type: ParameterType.QueryString);
                requsest.AddParameter("CompanyName", Name, type: ParameterType.QueryString);
                requsest.AddParameter("AttachmentFile", FileName, type: ParameterType.QueryString);
                var response = clinet.DownloadDataAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return response.Result;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "廠商下載檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #endregion

        #region 廠商通訊錄API
        #region 全部廠商通訊錄
        /// <summary>
        /// 全部廠商通訊錄
        /// </summary>
        /// <returns></returns>
        public List<CompanyDirectorySetting> Get_CompanyDirectory()
        {
            try
            {
                List<CompanyDirectorySetting> settings = null;
                var option = new RestClientOptions(CompanyDirectory_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<CompanyDirectorySetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<CompanyDirectorySetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "全部廠商通訊錄API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 廠商通訊錄(廠商編號)
        /// <summary>
        /// 廠商通訊錄(廠商編號)
        /// </summary>
        /// <param name="DirectoryCompanyNumber">廠商編號</param>
        /// <returns></returns>
        public List<CompanyDirectorySetting> Get_DirectoryCompany(string DirectoryCompanyNumber)
        {
            try
            {
                List<CompanyDirectorySetting> settings = null;
                var option = new RestClientOptions(DirectoryCompany_url + $"/{DirectoryCompanyNumber}")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<CompanyDirectorySetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<CompanyDirectorySetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "廠商通訊錄(廠商編號)API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 廠商通訊錄(廠商通訊錄編號)
        /// <summary>
        /// 廠商通訊錄(廠商通訊錄編號)
        /// </summary>
        /// <param name="DirectoryNumber">廠商通訊錄編號</param>
        /// <returns></returns>
        public List<CompanyDirectorySetting> Get_CompanyDirectory(string DirectoryNumber)
        {
            try
            {
                List<CompanyDirectorySetting> settings = null;
                var option = new RestClientOptions(CompanyDirectoryNumber_url + $"/{DirectoryNumber}")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<CompanyDirectorySetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<CompanyDirectorySetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "廠商通訊錄(廠商通訊錄編號)API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 新增廠商通訊錄資料
        /// <summary>
        /// 新增廠商通訊錄資料
        /// </summary>
        /// <param name="customerDirectorySetting"></param>
        /// <returns></returns>
        public string Post_CompanyDirectory(string customerDirectorySetting)
        {
            try
            {
                var option = new RestClientOptions(CompanyDirectory_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(customerDirectorySetting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "新增廠商通訊錄資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 修改廠商通訊錄資料
        /// <summary>
        /// 修改廠商通訊錄資料
        /// </summary>
        /// <param name="companyDirectorySetting"></param>
        /// <returns></returns>
        public string Put_CompanyDirectory(string companyDirectorySetting)
        {
            try
            {
                var option = new RestClientOptions(CompanyDirectory_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(companyDirectorySetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "修改廠商通訊錄資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 刪除廠商通訊錄資料
        /// <summary>
        /// 刪除廠商通訊錄資料
        /// </summary>
        /// <param name="companyDirectorySetting"></param>
        /// <returns></returns>
        public string Delete_CompanyDirectory(string companyDirectorySetting)
        {
            try
            {
                var option = new RestClientOptions(CompanyDirectory_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(companyDirectorySetting, ContentType.Json);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "刪除廠商通訊錄資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 廠商通訊錄上傳檔案
        /// <summary>
        /// 廠商通訊錄上傳檔案
        /// </summary>
        /// <param name="DirectoryCustomer">廠商編號</param>
        /// <param name="DirectoryNumber">廠商通訊錄編號</param>
        /// <param name="Path">檔案路徑</param>
        /// <returns></returns>
        public string Post_CompanyDirectoryAttachmentFile(string DirectoryCustomer, string DirectoryNumber, string Path)
        {
            try
            {
                var option = new RestClientOptions(CompanyDirectoryAttachmentFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("DirectoryCompany", DirectoryCustomer, type: ParameterType.QueryString);
                requsest.AddParameter("DirectoryNumber", DirectoryNumber, type: ParameterType.QueryString);
                requsest.AddFile("AttachmentFile", Path);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "廠商通訊錄上傳檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 廠商通訊錄下載檔案
        /// <summary>
        /// 廠商通訊錄下載檔案
        /// </summary>
        /// <param name="DirectoryCustomer">廠商編號</param>
        /// <param name="DirectoryNumber">廠商通訊錄編號</param>
        /// <param name="FileName">檔案路徑</param>
        /// <returns></returns>
        public byte[] Get_CompanyDirectoryAttachmentFile(string DirectoryCustomer, string DirectoryNumber, string FileName)
        {
            try
            {
                var option = new RestClientOptions(CompanyDirectoryAttachmentFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("DirectoryCompany", DirectoryCustomer, type: ParameterType.QueryString);
                requsest.AddParameter("DirectoryNumber", DirectoryNumber, type: ParameterType.QueryString);
                requsest.AddParameter("AttachmentFile", FileName, type: ParameterType.QueryString);
                var response = clinet.DownloadDataAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return response.Result;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "廠商通訊錄下載檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #endregion

        #region 客戶API
        #region 全部客戶
        /// <summary>
        /// 全部客戶
        /// </summary>
        /// <returns></returns>
        public List<CustomerSetting> Get_Customer()
        {
            try
            {
                List<CustomerSetting> settings = null;
                var option = new RestClientOptions(Customer_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<CustomerSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<CustomerSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "全部客戶API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 客戶(客戶編號)
        /// <summary>
        /// 客戶(客戶編號)
        /// </summary>
        /// <param name="CompanyNumber">客戶編號</param>
        /// <returns></returns>
        public List<CustomerSetting> Get_CustomerNumber(string CustomerNumber)
        {
            try
            {
                List<CustomerSetting> settings = null;
                var option = new RestClientOptions(CustomerNumber_url + $"/{CustomerNumber}")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<CustomerSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<CustomerSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "客戶(客戶編號)API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 新增客戶資料
        /// <summary>
        /// 新增客戶資料
        /// </summary>
        /// <param name="customerSetting"></param>
        /// <returns></returns>
        public string Post_Customer(string customerSetting)
        {
            try
            {
                var option = new RestClientOptions(Customer_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddBody(customerSetting, ContentType.Json);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "新增客戶資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 修改客戶資料
        /// <summary>
        /// 修改客戶資料
        /// </summary>
        /// <param name="customerSetting"></param>
        /// <returns></returns>
        public string Put_Customer(string customerSetting)
        {
            try
            {
                var option = new RestClientOptions(Customer_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(customerSetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "修改客戶資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 刪除客戶資料
        /// <summary>
        /// 刪除客戶資料
        /// </summary>
        /// <param name="customerSetting"></param>
        /// <returns></returns>
        public string Delete_Customer(string customerSetting)
        {
            try
            {
                var option = new RestClientOptions(Customer_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(customerSetting, ContentType.Json);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "刪除客戶資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 客戶上傳檔案
        /// <summary>
        /// 客戶上傳檔案
        /// </summary>
        /// <param name="Number">客戶編號</param>
        /// <param name="Name">客戶名稱</param>
        /// <param name="Path">檔案路徑</param>
        /// <returns></returns>
        public string Post_CustomerAttachmentFile(string Number, string Name, string Path)
        {
            try
            {
                var option = new RestClientOptions(CustomerAttachmentFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("CustomerNumber", Number, type: ParameterType.QueryString);
                requsest.AddParameter("CustomerName", Name, type: ParameterType.QueryString);
                requsest.AddFile("AttachmentFile", Path);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "客戶上傳檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 客戶下載檔案
        /// <summary>
        /// 客戶下載檔案
        /// </summary>
        /// <param name="Number">客戶編號</param>
        /// <param name="Name">客戶名稱</param>
        /// <param name="File">檔案路徑</param>
        /// <returns></returns>
        public byte[] Get_CustomerAttachmentFile(string Number, string Name, string File)
        {
            try
            {
                var option = new RestClientOptions(CustomerAttachmentFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("CustomerNumber", Number, type: ParameterType.QueryString);
                requsest.AddParameter("CustomerName", Name, type: ParameterType.QueryString);
                requsest.AddParameter("AttachmentFile", File, type: ParameterType.QueryString);
                var response = clinet.DownloadDataAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return response.Result;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "客戶下載檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #endregion

        #region 客戶通訊錄API
        #region 全部客戶通訊錄
        /// <summary>
        /// 全部客戶通訊錄
        /// </summary>
        /// <returns></returns>
        public List<CustomerSetting> Get_CustomerDirectory()
        {
            try
            {
                List<CustomerSetting> settings = null;
                var option = new RestClientOptions(CustomerDirectory_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<CustomerSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<CustomerSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "全部客戶通訊錄API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 客戶通訊錄(客戶編號)
        /// <summary>
        /// 客戶通訊錄(客戶編號)
        /// </summary>
        /// <param name="DirectoryCustomerNumber">客戶編號</param>
        /// <returns></returns>
        public List<CustomerDirectorySetting> Get_DirectoryCustomer(string DirectoryCustomerNumber)
        {
            try
            {
                List<CustomerDirectorySetting> settings = null;
                var option = new RestClientOptions(DirectoryCustomer_url + $"/{DirectoryCustomerNumber}")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<CustomerDirectorySetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<CustomerDirectorySetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "客戶通訊錄(客戶編號)API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 客戶通訊錄(客戶通訊錄編號)
        /// <summary>
        /// 客戶通訊錄(客戶通訊錄編號)
        /// </summary>
        /// <param name="DirectoryNumber">客戶通訊錄編號</param>
        /// <returns></returns>
        public List<CustomerSetting> Get_CustomerDirectory(string DirectoryNumber)
        {
            try
            {
                List<CustomerSetting> settings = null;
                var option = new RestClientOptions(CustomerDirectoryNumber_url + $"/{DirectoryNumber}")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<CustomerSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<CustomerSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "客戶通訊錄(客戶通訊錄編號)API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 新增客戶通訊錄資料
        /// <summary>
        /// 新增客戶通訊錄資料
        /// </summary>
        /// <param name="companyDirectorySetting"></param>
        /// <returns></returns>
        public string Post_CustomerDirectory(string companyDirectorySetting)
        {
            try
            {
                var option = new RestClientOptions(CustomerDirectory_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(companyDirectorySetting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "新增客戶通訊錄資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 修改客戶通訊錄資料
        /// <summary>
        /// 修改客戶通訊錄資料
        /// </summary>
        /// <param name="customerDirectorySetting"></param>
        /// <returns></returns>
        public string Put_CustomerDirectory(string customerDirectorySetting)
        {
            try
            {
                var option = new RestClientOptions(CustomerDirectory_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(customerDirectorySetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "修改客戶通訊錄資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 刪除客戶通訊錄資料
        /// <summary>
        /// 刪除客戶通訊錄資料
        /// </summary>
        /// <param name="customerDirectorySetting"></param>
        /// <returns></returns>
        public string Delete_CustomerDirectory(string customerDirectorySetting)
        {
            try
            {
                var option = new RestClientOptions(CustomerDirectory_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(customerDirectorySetting, ContentType.Json);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "刪除客戶通訊錄資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 客戶通訊錄上傳檔案
        /// <summary>
        /// 客戶通訊錄上傳檔案
        /// </summary>
        /// <param name="DirectoryCustomer">客戶編號</param>
        /// <param name="DirectoryNumber">客戶通訊錄編號</param>
        /// <param name="Path">檔案路徑</param>
        /// <returns></returns>
        public string Post_CustomerDirectoryAttachmentFile(string DirectoryCustomer, string DirectoryNumber, string Path)
        {
            try
            {
                var option = new RestClientOptions(CustomerDirectoryAttachmentFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("DirectoryCustomer", DirectoryCustomer, type: ParameterType.QueryString);
                requsest.AddParameter("DirectoryNumber", DirectoryNumber, type: ParameterType.QueryString);
                requsest.AddFile("AttachmentFile", Path);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "客戶通訊錄上傳檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 客戶通訊錄下載檔案
        /// <summary>
        /// 客戶通訊錄下載檔案
        /// </summary>
        /// <param name="DirectoryCustomer">客戶編號</param>
        /// <param name="DirectoryNumber">客戶通訊錄編號</param>
        /// <param name="File">檔案路徑</param>
        /// <returns></returns>
        public byte[] Get_CustomerDirectoryAttachmentFile(string DirectoryCustomer, string DirectoryNumber, string File)
        {
            try
            {
                var option = new RestClientOptions(CustomerDirectoryAttachmentFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("DirectoryCustomer", DirectoryCustomer, type: ParameterType.QueryString);
                requsest.AddParameter("DirectoryNumber", DirectoryNumber, type: ParameterType.QueryString);
                requsest.AddParameter("AttachmentFile", File, type: ParameterType.QueryString);
                var response = clinet.DownloadDataAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return response.Result;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "客戶通訊錄下載檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #endregion

        #region 員工API
        #region 全部員工
        /// <summary>
        /// 全部員工
        /// </summary>
        /// <returns></returns>
        public List<EmployeeSetting> Get_Employee()
        {
            try
            {
                List<EmployeeSetting> settings = null;
                var option = new RestClientOptions(Employee_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<EmployeeSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<EmployeeSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "全部員工API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 員工(員工編號)
        /// <summary>
        /// 員工(員工編號)
        /// </summary>
        /// <param name="CompanyNumber">員工編號</param>
        /// <returns></returns>
        public List<EmployeeSetting> Get_Employee(string EmployeeNumber)
        {
            try
            {
                List<EmployeeSetting> settings = null;
                var option = new RestClientOptions(EmployeeNumber_url + $"/{EmployeeNumber}")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<EmployeeSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<EmployeeSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "員工(員工編號)API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 新增員工資料
        /// <summary>
        /// 新增員工資料
        /// </summary>
        /// <param name="employeeSetting"></param>
        /// <returns></returns>
        public string Post_Employee(string employeeSetting)
        {
            try
            {
                var option = new RestClientOptions(Employee_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(employeeSetting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "新增員工資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 修改員工資料
        /// <summary>
        /// 修改員工資料
        /// </summary>
        /// <param name="employeeSetting"></param>
        /// <returns></returns>
        public string Put_Employee(string employeeSetting)
        {
            try
            {
                var option = new RestClientOptions(Employee_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(employeeSetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "修改員工資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 刪除員工資料
        /// <summary>
        /// 刪除員工資料
        /// </summary>
        /// <param name="employeeSetting"></param>
        /// <returns></returns>
        public string Delete_Employee(string employeeSetting)
        {
            try
            {
                var option = new RestClientOptions(Employee_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(employeeSetting, ContentType.Json);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "刪除員工資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #endregion

        #region 產品API
        #region 全部產品
        /// <summary>
        /// 全部產品
        /// </summary>
        /// <returns></returns>
        public List<ProductSetting> Get_Product()
        {
            try
            {
                List<ProductSetting> settings = null;
                var option = new RestClientOptions(Product_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<ProductSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<ProductSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "全部產品API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 產品(產品編號)
        /// <summary>
        /// 產品(產品編號)
        /// </summary>
        /// <param name="ProductNumber">產品編號</param>
        /// <returns></returns>
        public List<ProductSetting> Get_ProductNumber(string ProductNumber)
        {
            try
            {
                List<ProductSetting> settings = null;
                var option = new RestClientOptions(ProductNumber_url + $"/{ProductNumber}")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<ProductSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<ProductSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "產品(產品編號)API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 產品(產品種類代碼)
        /// <summary>
        /// 產品(產品種類代碼)
        /// </summary>
        /// <param name="ProductType">產品種類代碼</param>
        /// <returns></returns>
        public List<ProductSetting> Get_ProductType(string ProductType)
        {
            try
            {
                List<ProductSetting> settings = null;
                var option = new RestClientOptions(ProductType_url + $"/{ProductType}")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<ProductSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<ProductSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "產品(產品種類代碼)API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 新增產品資料
        /// <summary>
        /// 新增產品資料
        /// </summary>
        /// <param name="productSetting"></param>
        /// <returns></returns>
        public string Post_Product(string productSetting)
        {
            try
            {
                var option = new RestClientOptions(Product_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(productSetting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                ResponseDataMessage = response.Result.Content;
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "新增產品資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 修改產品資料
        /// <summary>
        /// 修改產品資料
        /// </summary>
        /// <param name="productSetting"></param>
        /// <returns></returns>
        public string Put_Product(string productSetting)
        {
            try
            {
                var option = new RestClientOptions(Product_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddBody(productSetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "修改產品資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 刪除產品資料
        /// <summary>
        /// 刪除產品資料
        /// </summary>
        /// <param name="productSetting"></param>
        /// <returns></returns>
        public string Delete_Product(string productSetting)
        {
            try
            {
                var option = new RestClientOptions(Product_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(productSetting, ContentType.Json);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "刪除產品資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 產品上傳檔案
        /// <summary>
        /// 產品上傳檔案
        /// </summary>
        /// <param name="Number">產品編號</param>
        /// <param name="Name">產品名稱</param>
        /// <param name="Path">檔案路徑</param>
        /// <returns></returns>
        public string Post_ProductAttachmentFile(string Number, string Name, string Path)
        {
            try
            {
                var option = new RestClientOptions(ProductAttachmentFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("ProductNumber", Number, type: ParameterType.QueryString);
                requsest.AddParameter("ProductName", Name, type: ParameterType.QueryString);
                requsest.AddFile("AttachmentFile", Path);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "產品上傳檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 產品下載檔案
        /// <summary>
        /// 產品下載檔案
        /// </summary>
        /// <param name="Number">產品編號</param>
        /// <param name="Name">產品名稱</param>
        /// <param name="File">檔案名稱</param>
        /// <returns></returns>
        public byte[] Get_ProductAttachmentFile(string Number, string Name, string File)
        {
            try
            {
                var option = new RestClientOptions(ProductAttachmentFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("ProductNumber", Number, type: ParameterType.QueryString);
                requsest.AddParameter("ProductName", Name, type: ParameterType.QueryString);
                requsest.AddParameter("AttachmentFile", File, type: ParameterType.QueryString);
                var response = clinet.DownloadDataAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return response.Result;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "產品下載檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion

        #region 產品類別API (不使用 2022/5/4)
        #region 全部產品類別  
        /// <summary>
        /// 全部產品類別 (不使用)
        /// </summary>
        /// <returns></returns>
        public List<ProductCategorySetting> Get_ProductGategory()
        {
            try
            {
                List<ProductCategorySetting> settings = null;
                var option = new RestClientOptions(ProductGategory_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<ProductCategorySetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<ProductCategorySetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "全部產品類別API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 新增產品類別資料
        /// <summary>
        /// 新增產品類別資料  (不使用)
        /// </summary>
        /// <param name="productGategorySetting"></param>
        /// <returns></returns>
        public string Post_ProductGategory(string productGategorySetting)
        {
            try
            {
                var option = new RestClientOptions(ProductGategory_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(productGategorySetting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "新增產品類別資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 修改產品類別資料
        /// <summary>
        /// 修改產品類別資料 (不使用)
        /// </summary>
        /// <param name="productGategorySetting"></param>
        /// <returns></returns>
        public string Put_ProductGategory(string productGategorySetting)
        {
            try
            {
                var option = new RestClientOptions(ProductGategory_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(productGategorySetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "修改產品類別資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 刪除產品類別資料
        /// <summary>
        /// 刪除產品類別資料 (不使用)
        /// </summary>
        /// <param name="productGategorySetting"></param>
        /// <returns></returns>
        public string Delete_ProductGategory(string productGategorySetting)
        {
            try
            {
                var option = new RestClientOptions(ProductGategory_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(productGategorySetting, ContentType.Json);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "刪除產品類別資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #endregion

        #region 部門類別
        #region 全部部門類別
        /// <summary>
        /// 全部部門類別
        /// </summary>
        /// <returns></returns>
        public List<ProductDepartmentSetting> Get_ProductDepartment()
        {
            try
            {
                List<ProductDepartmentSetting> settings = null;
                var option = new RestClientOptions(ProductDepartment_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<ProductDepartmentSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<ProductDepartmentSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "全部部門類別API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 新增部門類別資料
        /// <summary>
        /// 新增部門類別資料
        /// </summary>
        /// <param name="productDepartmentSetting"></param>
        /// <returns></returns>
        public string Post_ProductDepartment(string productDepartmentSetting)
        {
            try
            {
                var option = new RestClientOptions(ProductDepartment_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(productDepartmentSetting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "新增部門類別資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 修改部門類別資料
        /// <summary>
        /// 修改部門類別資料
        /// </summary>
        /// <param name="productDepartmentSetting"></param>
        /// <returns></returns>
        public string Put_ProductDepartment(string productDepartmentSetting)
        {
            try
            {
                var option = new RestClientOptions(ProductDepartment_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(productDepartmentSetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "修改部門類別資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 刪除部門類別資料
        /// <summary>
        /// 刪除部門類別資料
        /// </summary>
        /// <param name="productDepartmentSetting"></param>
        /// <returns></returns>
        public string Delete_ProductDepartment(string productDepartmentSetting)
        {
            try
            {
                var option = new RestClientOptions(ProductDepartment_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(productDepartmentSetting, ContentType.Json);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "刪除部門類別資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #endregion

        #region 項目1
        #region 全部項目1類別
        /// <summary>
        /// 全部項目1類別
        /// </summary>
        /// <returns></returns>
        public List<ProductItem1Setting> Get_ProductItem1()
        {
            try
            {
                List<ProductItem1Setting> settings = null;
                var option = new RestClientOptions(ProductItem1_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<ProductItem1Setting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<ProductItem1Setting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "全部項目1類別API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 新增項目1類別資料
        /// <summary>
        /// 新增項目1類別資料
        /// </summary>
        /// <param name="productItem1Setting"></param>
        /// <returns></returns>
        public string Post_ProductItem1(string productItem1Setting)
        {
            try
            {
                var option = new RestClientOptions(ProductItem1_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(productItem1Setting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "新增項目1類別資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 修改項目1類別資料
        /// <summary>
        /// 修改項目1類別資料
        /// </summary>
        /// <param name="productItem1Setting"></param>
        /// <returns></returns>
        public string Put_ProductItem1(string productItem1Setting)
        {
            try
            {
                var option = new RestClientOptions(ProductItem1_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(productItem1Setting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "修改項目1類別資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 刪除項目1類別資料
        /// <summary>
        /// 刪除項目1類別資料
        /// </summary>
        /// <param name="productItem1Setting"></param>
        /// <returns></returns>
        public string Delete_ProductItem1(string productItem1Setting)
        {
            try
            {
                var option = new RestClientOptions(ProductItem1_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(productItem1Setting, ContentType.Json);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "刪除項目1類別資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #endregion

        #region 項目2
        #region 全部項目2類別
        /// <summary>
        /// 全部項目2類別
        /// </summary>
        /// <returns></returns>
        public List<ProductItem2Setting> Get_ProductItem2()
        {
            try
            {
                List<ProductItem2Setting> settings = null;
                var option = new RestClientOptions(ProductItem2_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<ProductItem2Setting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<ProductItem2Setting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "全部項目2類別API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 新增項目2類別資料
        /// <summary>
        /// 新增項目2類別資料
        /// </summary>
        /// <param name="productItem2Setting"></param>
        /// <returns></returns>
        public string Post_ProductItem2(string productItem2Setting)
        {
            try
            {
                var option = new RestClientOptions(ProductItem2_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(productItem2Setting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "新增項目2類別資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 修改項目2類別資料
        /// <summary>
        /// 修改項目2類別資料
        /// </summary>
        /// <param name="productItem2Setting"></param>
        /// <returns></returns>
        public string Put_ProductItem2(string productItem2Setting)
        {
            try
            {
                var option = new RestClientOptions(ProductItem2_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(productItem2Setting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "修改項目2類別資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 刪除項目2類別資料
        /// <summary>
        /// 刪除項目2類別資料
        /// </summary>
        /// <param name="productItem2Setting"></param>
        /// <returns></returns>
        public string Delete_ProductItem2(string productItem2Setting)
        {
            try
            {
                var option = new RestClientOptions(ProductItem2_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(productItem2Setting, ContentType.Json);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "刪除項目2類別資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #endregion

        #region 項目3
        #region 全部項目3類別
        /// <summary>
        /// 全部項目3類別
        /// </summary>
        /// <returns></returns>
        public List<ProductItem3Setting> Get_ProductItem3()
        {
            try
            {
                List<ProductItem3Setting> settings = null;
                var option = new RestClientOptions(ProductItem3_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<ProductItem3Setting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<ProductItem3Setting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "全部項目3類別API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 新增項目3類別資料
        /// <summary>
        /// 新增項目3類別資料
        /// </summary>
        /// <param name="productItem3Setting"></param>
        /// <returns></returns>
        public string Post_ProductItem3(string productItem3Setting)
        {
            try
            {
                var option = new RestClientOptions(ProductItem3_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(productItem3Setting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "新增項目3類別資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 修改項目3類別資料
        /// <summary>
        /// 修改項目3類別資料
        /// </summary>
        /// <param name="productItem3Setting"></param>
        /// <returns></returns>
        public string Put_ProductItem3(string productItem3Setting)
        {
            try
            {
                var option = new RestClientOptions(ProductItem3_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(productItem3Setting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "修改項目3類別資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 刪除項目3類別資料
        /// <summary>
        /// 刪除項目3類別資料
        /// </summary>
        /// <param name="productItem3Setting"></param>
        /// <returns></returns>
        public string Delete_ProductItem3(string productItem3Setting)
        {
            try
            {
                var option = new RestClientOptions(ProductItem3_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(productItem3Setting, ContentType.Json);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "刪除項目3類別資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #endregion

        #region 項目4
        #region 全部項目4類別
        /// <summary>
        /// 全部項目4類別
        /// </summary>
        /// <returns></returns>
        public List<ProductItem4Setting> Get_ProductItem4()
        {
            try
            {
                List<ProductItem4Setting> settings = null;
                var option = new RestClientOptions(ProductItem4_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<ProductItem4Setting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<ProductItem4Setting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "全部項目4類別API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 新增項目4類別資料
        /// <summary>
        /// 新增項目4類別資料
        /// </summary>
        /// <param name="productItem4Setting"></param>
        /// <returns></returns>
        public string Post_ProductItem4(string productItem4Setting)
        {
            try
            {
                var option = new RestClientOptions(ProductItem4_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(productItem4Setting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "新增項目4類別資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 修改項目4類別資料
        /// <summary>
        /// 修改項目4類別資料
        /// </summary>
        /// <param name="productItem4Setting"></param>
        /// <returns></returns>
        public string Put_ProductItem4(string productItem4Setting)
        {
            try
            {
                var option = new RestClientOptions(ProductItem4_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(productItem4Setting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "修改項目4類別資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 刪除項目4類別資料
        /// <summary>
        /// 刪除項目4類別資料
        /// </summary>
        /// <param name="productItem4Setting"></param>
        /// <returns></returns>
        public string Delete_ProductItem4(string productItem4Setting)
        {
            try
            {
                var option = new RestClientOptions(ProductItem4_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(productItem4Setting, ContentType.Json);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "刪除項目4類別資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #endregion

        #region 項目5
        #region 全部項目5類別
        /// <summary>
        /// 全部項目5類別
        /// </summary>
        /// <returns></returns>
        public List<ProductItem5Setting> Get_ProductItem5()
        {
            try
            {
                List<ProductItem5Setting> settings = null;
                var option = new RestClientOptions(ProductItem5_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<ProductItem5Setting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<ProductItem5Setting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "全部項目5類別API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 新增項目5類別資料
        /// <summary>
        /// 新增項目5類別資料
        /// </summary>
        /// <param name="productItem5Setting"></param>
        /// <returns></returns>
        public string Post_ProductItem5(string productItem5Setting)
        {
            try
            {
                var option = new RestClientOptions(ProductItem5_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(productItem5Setting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "新增項目5類別資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 修改項目5類別資料
        /// <summary>
        /// 修改項目5類別資料
        /// </summary>
        /// <param name="productItem5Setting"></param>
        /// <returns></returns>
        public string Put_ProductItem5(string productItem5Setting)
        {
            try
            {
                var option = new RestClientOptions(ProductItem5_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(productItem5Setting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "修改項目5類別資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 刪除項目5類別資料
        /// <summary>
        /// 刪除項目5類別資料
        /// </summary>
        /// <param name="productItem5Setting"></param>
        /// <returns></returns>
        public string Delete_ProductItem5(string productItem5Setting)
        {
            try
            {
                var option = new RestClientOptions(ProductItem5_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(productItem5Setting, ContentType.Json);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "刪除項目5類別資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #endregion
        #endregion

        #region 訂購API
        #region 全部訂購單表頭(年份)
        /// <summary>
        /// 全部訂購單表頭(年份)
        /// </summary>
        /// <param name="Year"></param>
        /// <returns></returns>
        public List<OrderMainSetting> Get_Order(string Year)
        {
            try
            {
                List<OrderMainSetting> settings = null;
                var option = new RestClientOptions(Order_url + "/Year")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("Year", Year, type: ParameterType.QueryString);
                var response = clinet.ExecuteGetAsync<List<PurchaseMainSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<OrderMainSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "全部訂購單表頭(年份)API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 查詢單筆訂購單父子資料
        public List<OrderSetting> Get_Order(OrderMainSetting setting)
        {
            try
            {
                List<OrderSetting> settings = null;
                var option = new RestClientOptions(Order_url + $"/{setting.OrderNumber}")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<PurchaseSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<OrderSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "查詢單筆訂購單父子資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 新增訂購資料
        /// <summary>
        /// 新增訂購資料
        /// </summary>
        /// <param name="OrderSetting"></param>
        /// <returns></returns>
        public string Post_Order(string OrderSetting)
        {
            try
            {
                var option = new RestClientOptions(Order_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(OrderSetting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                ResponseDataMessage = response.Result.Content;
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "新增訂購資料API錯誤");
                ResponseDataMessage = "";
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 修改訂購資料
        /// <summary>
        /// 修改訂購資料
        /// </summary>
        /// <param name="OrderSetting"></param>
        /// <returns></returns>
        public string Put_Order(string OrderSetting)
        {
            try
            {
                var option = new RestClientOptions(Order_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(OrderSetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "修改訂購資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 刪除訂購資料
        /// <summary>
        /// 刪除訂購資料
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <returns></returns>
        public string Delete_Order(string OrderNumber)
        {
            try
            {
                var option = new RestClientOptions($"{Order_url}/{OrderNumber}")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "刪除訂購資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 訂購上傳檔案
        /// <summary>
        /// 訂購上傳檔案
        /// </summary>
        /// <param name="OrderDate"></param>
        /// <param name="OrderNumber"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        public string Post_OrderAttachmentFile(DateTime OrderDate, string OrderNumber, string Path)
        {
            try
            {
                var option = new RestClientOptions(OrderAttachmenFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("OrderDate", OrderDate.ToString("yyyy/MM/dd HH:mm:ss"), type: ParameterType.QueryString);
                requsest.AddParameter("OrderNumber", OrderNumber, type: ParameterType.QueryString);
                requsest.AddFile("AttachmentFile", Path);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "訂購上傳檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 訂購下載檔案
        /// <summary>
        /// 訂購下載檔案
        /// </summary>
        /// <param name="OrderNumber"></param>
        /// <param name="File"></param>
        /// <returns></returns>
        public byte[] Get_OrderAttachmentFile(string OrderNumber,string File)
        {
            try
            {
                var option = new RestClientOptions(OrderAttachmenFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("AttachmentFile", File, type: ParameterType.QueryString);
                requsest.AddParameter("OrderNumber", OrderNumber, type: ParameterType.QueryString);
                var response = clinet.DownloadDataAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return response.Result;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "訂購下載檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #endregion

        #region 報價API
        #region 全部報價單表頭(年份)
        /// <summary>
        /// 全部報價單表頭(年份)
        /// </summary>
        /// <param name="Year"></param>
        /// <returns></returns>
        public List<QuotationMainSetting> Get_Quotation(string Year)
        {
            try
            {
                List<QuotationMainSetting> settings = null;
                var option = new RestClientOptions(Quotation_url + "/Year")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("Year", Year, type: ParameterType.QueryString);
                var response = clinet.ExecuteGetAsync<List<PurchaseMainSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<QuotationMainSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "全部報價單表頭(年份)API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 查詢單筆報價單父子資料
        public List<QuotationSetting> Get_Quotation(QuotationMainSetting setting)
        {
            try
            {
                List<QuotationSetting> settings = null;
                var option = new RestClientOptions(Quotation_url + $"/{setting.QuotationNumber}")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<PurchaseSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<QuotationSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "查詢單筆報價單父子資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 新增報價資料
        /// <summary>
        /// 新增報價資料
        /// </summary>
        /// <param name="QuotationSetting"></param>
        /// <returns></returns>
        public string Post_Quotation(string QuotationSetting)
        {
            try
            {
                var option = new RestClientOptions(Quotation_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(QuotationSetting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                ResponseDataMessage = response.Result.Content;
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "新增報價資料API錯誤");
                ResponseDataMessage = "";
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 修改報價資料
        /// <summary>
        /// 修改報價資料
        /// </summary>
        /// <param name="QuotationSetting"></param>
        /// <returns></returns>
        public string Put_Quotation(string QuotationSetting)
        {
            try
            {
                var option = new RestClientOptions(Quotation_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(QuotationSetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "修改報價資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 刪除報價資料
        /// <summary>
        /// 刪除報價資料
        /// </summary>
        /// <param name="QuotationNumber"></param>
        /// <returns></returns>
        public string Delete_Quotation(string QuotationNumber)
        {
            try
            {
                var option = new RestClientOptions($"{Quotation_url}/{QuotationNumber}")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "刪除報價資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 報價上傳檔案
        /// <summary>
        /// 報價上傳檔案
        /// </summary>
        /// <param name="QuotationDate"></param>
        /// <param name="QuotationNumber"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        public string Post_QuotationAttachmentFile(DateTime QuotationDate, string QuotationNumber, string Path)
        {
            try
            {
                var option = new RestClientOptions(QuotationAttachmenFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("QuotationDate", QuotationDate.ToString("yyyy/MM/dd HH:mm:ss"), type: ParameterType.QueryString);
                requsest.AddParameter("QuotationNumber", QuotationNumber, type: ParameterType.QueryString);
                requsest.AddFile("AttachmentFile", Path);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "報價上傳檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 報價下載檔案
        /// <summary>
        /// 報價下載檔案
        /// </summary>
        /// <param name="QuotationNumber"></param>
        /// <param name="File"></param>
        /// <returns></returns>
        public byte[] Get_QuotationAttachmentFile(string QuotationNumber, string File)
        {
            try
            {
                var option = new RestClientOptions(QuotationAttachmenFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("AttachmentFile", File, type: ParameterType.QueryString);
                requsest.AddParameter("QuotationNumber", QuotationNumber, type: ParameterType.QueryString);
                var response = clinet.DownloadDataAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return response.Result;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "報價下載檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #endregion

        #region 進貨API
        #region 全部進貨表頭(年月份)
        /// <summary>
        /// 全部進貨表頭(年月份)
        /// </summary>
        /// <param name="PurchaseNumber">年月份</param>
        /// <returns></returns>
        public List<PurchaseMainSetting> Get_Purchase(string PurchaseNumber)
        {
            try
            {
                List<PurchaseMainSetting> settings = null;
                var option = new RestClientOptions(PurchaseNumber_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("PurchaseNumber", PurchaseNumber, type: ParameterType.QueryString);
                var response = clinet.ExecuteGetAsync<List<PurchaseMainSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<PurchaseMainSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "全部進貨表頭(年月份)API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 查詢單筆【進貨】或【進貨退出】父子資料
        /// <summary>
        /// 查詢單筆【進貨】或【進貨退出】父子資料
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        public List<PurchaseSetting> Get_Purchase(PurchaseMainSetting setting)
        {
            try
            {
                List<PurchaseSetting> settings = null;
                var option = new RestClientOptions(Purchase_url + $"/{setting.PurchaseFlag}/{setting.PurchaseNumber}")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<PurchaseSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<PurchaseSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "查詢單筆【進貨】或【進貨退出】父子資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 查詢未過帳進貨表頭
        /// <summary>
        /// 查詢未過帳進貨表頭
        /// </summary>
        /// <returns></returns>
        public List<PurchaseMainSetting> Get_PurchasePosting()
        {
            try
            {
                List<PurchaseMainSetting> settings = null;
                var option = new RestClientOptions(PurchasePosting_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<PurchaseMainSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<PurchaseMainSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "查詢未過帳進貨表頭API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 新增進貨資料
        /// <summary>
        /// 新增進貨資料
        /// </summary>
        /// <param name="PruchaseSetting"></param>
        /// <returns></returns>
        public string Post_Purchase(string PruchaseSetting)
        {
            try
            {
                var option = new RestClientOptions(Purchase_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(PruchaseSetting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                ResponseDataMessage = response.Result.Content;
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "新增進貨資料API錯誤");
                ResponseDataMessage = "";
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 修改進貨資料
        /// <summary>
        /// 修改進貨資料
        /// </summary>
        /// <param name="PruchaseSetting"></param>
        /// <returns></returns>
        public string Put_Purchase(string PruchaseSetting)
        {
            try
            {
                var option = new RestClientOptions(Purchase_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(PruchaseSetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "修改進貨資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 更新過帳進貨資料
        /// <summary>
        /// 更新過帳進貨資料
        /// </summary>
        /// <param name="PruchaseMainSetting"></param>
        /// <returns></returns>
        public string Put_PurchaseMain(string PruchaseMainSetting)
        {
            try
            {
                var option = new RestClientOptions(UpdatePurchaseMain_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(PruchaseMainSetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "更新過帳進貨資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 刪除進貨資料
        /// <summary>
        /// 刪除進貨資料
        /// </summary>
        /// <param name="PruchaseSetting"></param>
        /// <returns></returns>
        public string Delete_Purchase(int PurchaseFlag, string PurchaseNumber)
        {
            try
            {
                var option = new RestClientOptions($"{Purchase_url}/{PurchaseFlag}/{PurchaseNumber}")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "刪除進貨資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 進貨上傳檔案
        /// <summary>
        /// 進貨上傳檔案
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public string Post_PurchaseAttachmentFile(int PurchaseFlag, DateTime PurchaseDate, string PurchaseNumber, string Path)
        {
            try
            {
                var option = new RestClientOptions(PurchaseAttachmenFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("PurchaseFlag", PurchaseFlag, type: ParameterType.QueryString);
                requsest.AddParameter("PurchaseDate", PurchaseDate.ToString("yyyy/MM/dd HH:mm:ss"), type: ParameterType.QueryString);
                requsest.AddParameter("PurchaseNumber", PurchaseNumber, type: ParameterType.QueryString);
                requsest.AddFile("AttachmentFile", Path);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "進貨上傳檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 進貨下載檔案
        /// <summary>
        /// 進貨下載檔案
        /// </summary>
        /// <param name="File">檔案名稱</param>
        /// <returns></returns>
        public byte[] Get_PurchaseAttachmentFile(string PurchaseNumber, string File)
        {
            try
            {
                var option = new RestClientOptions(PurchaseAttachmenFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("AttachmentFile", File, type: ParameterType.QueryString);
                requsest.AddParameter("PurchaseNumber", PurchaseNumber, type: ParameterType.QueryString);
                var response = clinet.DownloadDataAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return response.Result;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "進貨下載檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #endregion

        #region 銷貨API
        #region 全部銷貨表頭(年月份)
        /// <summary>
        /// 全部銷貨表頭(年月份)
        /// </summary>
        /// <param name="SalesNumber">年月份</param>
        /// <returns></returns>
        public List<SalesMainSetting> Get_Sales(string SalesNumber)
        {
            try
            {
                List<SalesMainSetting> settings = null;
                var option = new RestClientOptions(SalesNumber_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("SalesNumber", SalesNumber, type: ParameterType.QueryString);
                var response = clinet.ExecuteGetAsync<List<SalesMainSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<SalesMainSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "全部銷貨表頭(年月份)API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 查詢單筆【銷貨】或【銷貨退出】父子資料
        /// <summary>
        /// 查詢單筆【銷貨】或【銷貨退出】父子資料
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        public List<SalesSetting> Get_Sales(SalesMainSetting setting)
        {
            try
            {
                List<SalesSetting> settings = null;
                var option = new RestClientOptions(Sales_url + $"/{setting.SalesFlag}/{setting.SalesNumber}")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<SalesSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<SalesSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "查詢單筆【銷貨】或【銷貨退出】父子資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 查詢未過帳銷貨表頭
        /// <summary>
        /// 查詢未過帳銷貨表頭
        /// </summary>
        /// <returns></returns>
        public List<SalesMainSetting> Get_SalesPosting()
        {
            try
            {
                List<SalesMainSetting> settings = null;
                var option = new RestClientOptions(SalesPosting_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<SalesMainSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<SalesMainSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "查詢未過帳銷貨表頭API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 新增銷貨資料
        /// <summary>
        /// 新增銷貨資料
        /// </summary>
        /// <param name="PruchaseSetting"></param>
        /// <returns></returns>
        public string Post_Sales(string PruchaseSetting)
        {
            try
            {
                var option = new RestClientOptions(Sales_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(PruchaseSetting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                ResponseDataMessage = response.Result.Content;
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "新增銷貨資料API錯誤");
                ResponseDataMessage = "";
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 修改銷貨資料
        /// <summary>
        /// 修改銷貨資料
        /// </summary>
        /// <param name="PruchaseSetting"></param>
        /// <returns></returns>
        public string Put_Sales(string PruchaseSetting)
        {
            try
            {
                var option = new RestClientOptions(Sales_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(PruchaseSetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "修改銷貨資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 更新過帳銷貨資料
        /// <summary>
        /// 更新過帳銷貨資料
        /// </summary>
        /// <param name="PruchaseMainSetting"></param>
        /// <returns></returns>
        public string Put_SalesMain(string SalesMainSetting)
        {
            try
            {
                var option = new RestClientOptions(UpdateSalesMain_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(SalesMainSetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "更新過帳銷貨資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 刪除銷貨資料
        /// <summary>
        /// 刪除銷貨資料
        /// </summary>
        /// <param name="PruchaseSetting"></param>
        /// <returns></returns>
        public string Delete_Sales(int SalesFlag, string SalesNumber)
        {
            try
            {
                var option = new RestClientOptions($"{Sales_url}/{SalesFlag}/{SalesNumber}")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "刪除銷貨資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 銷貨上傳檔案
        /// <summary>
        /// 銷貨上傳檔案
        /// </summary>
        /// <param name="PruchaseSetting"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        public string Post_SalesAttachmentFile(int SalesFlag, string SalesCompanyNumber, DateTime SalesDate, string SalesNumber, string Path)
        {
            try
            {
                var option = new RestClientOptions(SalesAttachmenFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("SalesFlag", SalesFlag, type: ParameterType.QueryString);
                requsest.AddParameter("SalesCustomerNumber", SalesCompanyNumber, type: ParameterType.QueryString);
                requsest.AddParameter("SalesDate", SalesDate.ToString("yyyy/MM/dd HH:mm:ss"), type: ParameterType.QueryString);
                requsest.AddParameter("SalesNumber", SalesNumber, type: ParameterType.QueryString);
                requsest.AddFile("AttachmentFile", Path);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "銷貨上傳檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 銷貨下載檔案
        /// <summary>
        /// 銷貨下載檔案
        /// </summary>
        /// <param name="File">檔案名稱</param>
        /// <returns></returns>
        public byte[] Get_SalesAttachmentFile(string SalesCompanyNumber, string File)
        {
            try
            {
                var option = new RestClientOptions(SalesAttachmenFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("AttachmentFile", File, type: ParameterType.QueryString);
                requsest.AddParameter("SalesCustomerNumber", SalesCompanyNumber, type: ParameterType.QueryString);
                var response = clinet.DownloadDataAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return response.Result;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "銷貨下載檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #endregion

        #region 專案API
        #region 查詢全部【專案】父子資料
        /// <summary>
        /// 查詢全部【專案】父子資料
        /// </summary>
        /// <returns></returns>
        public List<ProjectSetting> Get_Project()
        {
            try
            {
                List<ProjectSetting> settings = null;
                var option = new RestClientOptions(Project_url) { Timeout = time };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<ProjectSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<ProjectSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "查詢全部【專案】父子資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 新增專案父子
        /// <summary>
        /// 新增專案父子
        /// </summary>
        /// <param name="projectSetting"></param>
        /// <returns></returns>
        public string Post_Project(string projectSetting)
        {
            try
            {
                var option = new RestClientOptions(Project_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(projectSetting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                ResponseDataMessage = response.Result.Content;
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "新增專案父子資料API錯誤");
                ResponseDataMessage = "";
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 修改專案父子
        public string Put_Project(string ProjectSetting)
        {
            try
            {
                var option = new RestClientOptions(Project_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(ProjectSetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "修改專案父子資料API錯誤");
                ResponseDataMessage = "";
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 刪除專案父子
        public string Delete_Project(string ProjectNumber)
        {
            try
            {
                var option = new RestClientOptions($"{Project_url}/{ProjectNumber}")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "刪除專案父子資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 專案上傳檔案
        /// <summary>
        /// 專案上傳檔案
        /// </summary>
        /// <param name="ProjectNumber"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        public string Post_ProjectAttachmentFile(string ProjectNumber, string Path)
        {
            try
            {
                var option = new RestClientOptions(ProjectAttachmenFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("ProjectNumber", ProjectNumber, type: ParameterType.QueryString);
                requsest.AddFile("AttachmentFile", Path);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "專案上傳檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 專案下載檔案
        public byte[] Get_ProjectAttachmentFile(string ProjectNumber, string File)
        {
            try
            {
                var option = new RestClientOptions(ProjectAttachmenFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("AttachmentFile", File, type: ParameterType.QueryString);
                requsest.AddParameter("ProjectNumber", ProjectNumber, type: ParameterType.QueryString);
                var response = clinet.DownloadDataAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return response.Result;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "專案下載檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #endregion

        #region 代墊代付API
        #region 單一代墊代付資料
        /// <summary>
        /// 單一代墊代付資料
        /// </summary>
        /// <returns></returns>
        public List<PaymentSetting> Get_Payment(string PaymentNumber)
        {
            try
            {
                List<PaymentSetting> settings = null;
                var option = new RestClientOptions(Payment_url+$"/{PaymentNumber}")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<PaymentSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<PaymentSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "單一代墊代付API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 全部未付款代墊代付資料
        /// <summary>
        /// 全部未付款代墊代付資料
        /// </summary>
        /// <returns></returns>
        public List<PaymentSetting> Get_PaymentTransferDate()
        {
            try
            {
                List<PaymentSetting> settings = null;
                var option = new RestClientOptions(Payment_url + "/TransferDate")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<PaymentSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<PaymentSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "全部未付款代墊代付API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 年分代墊代付資料
        /// <summary>
        /// 年分代墊代付資料
        /// </summary>
        /// <param name="Year">yyyy</param>
        /// <returns></returns>
        public List<PaymentSetting> Get_PaymentYear(string Year)
        {
            try
            {
                List<PaymentSetting> settings = null;
                var option = new RestClientOptions(Payment_url + "/YearDate")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("YearDate", Year, type: ParameterType.QueryString);
                var response = clinet.ExecuteGetAsync<List<PaymentSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<PaymentSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "年分代墊代付API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 月份代墊代付資料
        /// <summary>
        /// 月份代墊代付資料
        /// </summary>
        /// <param name="Month">yyyyMM</param>
        /// <returns></returns>
        public List<PaymentSetting> Get_PaymentMonth(string Month)
        {
            try
            {
                List<PaymentSetting> settings = null;
                var option = new RestClientOptions(Payment_url + "/MonthDate")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("MonthDate", Month, type: ParameterType.QueryString);
                var response = clinet.ExecuteGetAsync<List<PaymentSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<PaymentSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "月分代墊代付API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 新增代墊代付資料
        /// <summary>
        /// 新增代墊代付資料
        /// </summary>
        /// <param name="PaymentSetting"></param>
        /// <returns></returns>
        public string Post_Payment(string PaymentSetting)
        {
            try
            {
                var option = new RestClientOptions(Payment_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(PaymentSetting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                ResponseDataMessage = response.Result.Content;
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "新增代墊代付資料API錯誤");
                ResponseDataMessage = "";
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 修改代墊代付資料
        /// <summary>
        /// 修改代墊代付資料
        /// </summary>
        /// <param name="PaymentSetting"></param>
        /// <returns></returns>
        public string Put_Payment(string PaymentSetting)
        {
            try
            {
                var option = new RestClientOptions(Payment_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(PaymentSetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                ResponseDataMessage = response.Result.Content;
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "修改代墊代付資料API錯誤");
                ResponseDataMessage = "";
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 刪除代墊代付資料
        /// <summary>
        /// 刪除代墊代付資料
        /// </summary>
        /// <param name="PaymentSetting"></param>
        /// <returns></returns>
        public string Delete_Payment(string PaymentSetting)
        {
            try
            {
                var option = new RestClientOptions(Payment_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(PaymentSetting, ContentType.Json);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                ResponseDataMessage = response.Result.Content;
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "刪除代墊代付資料API錯誤");
                ResponseDataMessage = "";
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 代墊代付上傳檔案
        public string Post_PaymentAttachmentFile(string PaymentNumber, string Path)
        {
            try
            {
                var option = new RestClientOptions(PaymentAttachmenFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("PaymentNumber", PaymentNumber, type: ParameterType.QueryString);
                requsest.AddFile("AttachmentFile", Path);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "代墊代付上傳檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 代墊代付下載檔案
        public byte[] Get_PaymentAttachmentFile(string PaymentNumber, string File)
        {
            try
            {
                var option = new RestClientOptions(PaymentAttachmenFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("AttachmentFile", File, type: ParameterType.QueryString);
                requsest.AddParameter("PaymentNumber", PaymentNumber, type: ParameterType.QueryString);
                var response = clinet.DownloadDataAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return response.Result;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "代墊代付下載檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #endregion

        #region 代墊代付品項API
        #region 全部代墊代付品項資料
        /// <summary>
        /// 全部代墊代付品項資料
        /// </summary>
        /// <returns></returns>
        public List<PaymentItemSetting> Get_PaymentItem()
        {
            try
            {
                List<PaymentItemSetting> settings = null;
                var option = new RestClientOptions(PaymentItem_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<PaymentItemSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<PaymentItemSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "全部代墊代付品項API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 新增代墊代付品項資料
        /// <summary>
        /// 新增代墊代付品項資料
        /// </summary>
        /// <returns></returns>
        public string Post_PaymentItem(string PaymentItemSetting)
        {
            try
            {
                var option = new RestClientOptions(PaymentItem_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(PaymentItemSetting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                ResponseDataMessage = response.Result.Content;
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "新增代墊代付品項資料API錯誤");
                ResponseDataMessage = "";
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 修改代墊代付品項資料
        /// <summary>
        /// 修改代墊代付品項資料
        /// </summary>
        /// <returns></returns>
        public string Put_PaymentItem(string PaymentItemSetting)
        {
            try
            {
                var option = new RestClientOptions(PaymentItem_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(PaymentItemSetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                ResponseDataMessage = response.Result.Content;
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "修改代墊代付品項資料API錯誤");
                ResponseDataMessage = "";
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 刪除代墊代付品項資料
        /// <summary>
        /// 刪除代墊代付品項資料
        /// </summary>
        /// <returns></returns>
        public string Delete_PaymentItem(string PaymentItemSetting)
        {
            try
            {
                var option = new RestClientOptions(PaymentItem_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(PaymentItemSetting, ContentType.Json);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                ResponseDataMessage = response.Result.Content;
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "刪除代墊代付品項資料API錯誤");
                ResponseDataMessage = "";
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #endregion

        #region 領料API
        #region 全部領料表頭(年月份)
        /// <summary>
        /// 全部領料表頭(年月份)
        /// </summary>
        /// <param name="PickingNumber">年月份</param>
        /// <returns></returns>
        public List<PickingMainSetting> Get_Picking(string PickingNumber)
        {
            try
            {
                List<PickingMainSetting> settings = null;
                var option = new RestClientOptions(PickingNumber_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("PickingNumber", PickingNumber, type: ParameterType.QueryString);
                var response = clinet.ExecuteGetAsync<List<PickingMainSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<PickingMainSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "全部領料表頭(年月份)API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 查詢單筆【領料】或【領料退出】父子資料
        /// <summary>
        /// 查詢單筆【領料】或【領料退出】父子資料
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        public List<PickingSetting> Get_Picking(PickingMainSetting setting)
        {
            try
            {
                List<PickingSetting> settings = null;
                var option = new RestClientOptions(Picking_url + $"/{setting.PickingFlag}/{setting.PickingNumber}")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<PickingSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<PickingSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "查詢單筆【領料】或【領料退出】父子資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 查詢未過帳領料表頭
        /// <summary>
        /// 查詢未過帳領料表頭
        /// </summary>
        /// <returns></returns>
        public List<PickingMainSetting> Get_PickingPosting()
        {
            try
            {
                List<PickingMainSetting> settings = null;
                var option = new RestClientOptions(PickingPosting_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<PickingMainSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<PickingMainSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "查詢未過帳領料表頭API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 新增領料資料
        /// <summary>
        /// 新增領料資料
        /// </summary>
        /// <param name="PruchaseSetting"></param>
        /// <returns></returns>
        public string Post_Picking(string PruchaseSetting)
        {
            try
            {
                var option = new RestClientOptions(Picking_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(PruchaseSetting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                ResponseDataMessage = response.Result.Content;
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "新增領料資料API錯誤");
                ResponseDataMessage = "";
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 修改領料資料
        /// <summary>
        /// 修改領料資料
        /// </summary>
        /// <param name="PruchaseSetting"></param>
        /// <returns></returns>
        public string Put_Picking(string PruchaseSetting)
        {
            try
            {
                var option = new RestClientOptions(Picking_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(PruchaseSetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "修改領料資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 更新過帳領料資料
        /// <summary>
        /// 更新過帳領料資料
        /// </summary>
        /// <param name="PruchaseMainSetting"></param>
        /// <returns></returns>
        public string Put_PickingMain(string PickingMainSetting)
        {
            try
            {
                var option = new RestClientOptions(UpdatePickingMain_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(PickingMainSetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "更新過帳領料資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 刪除領料資料
        /// <summary>
        /// 刪除領料資料
        /// </summary>
        /// <param name="PruchaseSetting"></param>
        /// <returns></returns>
        public string Delete_Picking(int PickingFlag, string PickingNumber)
        {
            try
            {
                var option = new RestClientOptions($"{Picking_url}/{PickingFlag}/{PickingNumber}")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "刪除領料資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 領料上傳檔案
        /// <summary>
        /// 領料上傳檔案
        /// </summary>
        /// <param name="PruchaseSetting"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        public string Post_PickingAttachmentFile(int PickingFlag, string PickingCompanyNumber, DateTime PickingDate, string PickingNumber, string Path)
        {
            try
            {
                var option = new RestClientOptions(PickingAttachmenFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("PickingFlag", PickingFlag, type: ParameterType.QueryString);
                requsest.AddParameter("PickingCustomerNumber", PickingCompanyNumber, type: ParameterType.QueryString);
                requsest.AddParameter("PickingDate", PickingDate.ToString("yyyy/MM/dd HH:mm:ss"), type: ParameterType.QueryString);
                requsest.AddParameter("PickingNumber", PickingNumber, type: ParameterType.QueryString);
                requsest.AddFile("AttachmentFile", Path);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "領料上傳檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 領料下載檔案
        /// <summary>
        /// 領料下載檔案
        /// </summary>
        /// <param name="File">檔案名稱</param>
        /// <returns></returns>
        public byte[] Get_PickingAttachmentFile(string PickingCompanyNumber, string File)
        {
            try
            {
                var option = new RestClientOptions(PickingAttachmenFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("AttachmentFile", File, type: ParameterType.QueryString);
                requsest.AddParameter("PickingCustomerNumber", PickingCompanyNumber, type: ParameterType.QueryString);
                var response = clinet.DownloadDataAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return response.Result;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "領料下載檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #endregion

        #region 營運API
        #region 全部營運表頭(年月份)
        /// <summary>
        /// 全部營運表頭(年月份)
        /// </summary>
        /// <param name="OperatingNumber">年月份</param>
        /// <returns></returns>
        public List<OperatingMainSetting> Get_Operating(string OperatingNumber)
        {
            try
            {
                List<OperatingMainSetting> settings = null;
                var option = new RestClientOptions(OperatingNumber_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("OperatingNumber", OperatingNumber, type: ParameterType.QueryString);
                var response = clinet.ExecuteGetAsync<List<OperatingMainSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<OperatingMainSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "全部營運表頭(年月份)API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 查詢單筆【營運】或【營運退出】父子資料
        /// <summary>
        /// 查詢單筆【營運】或【營運退出】父子資料
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        public List<OperatingSetting> Get_Operating(OperatingMainSetting setting)
        {
            try
            {
                List<OperatingSetting> settings = null;
                var option = new RestClientOptions(Operating_url + $"/{setting.OperatingFlag}/{setting.OperatingNumber}")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<OperatingSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<OperatingSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "查詢單筆【營運】或【營運退出】父子資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 查詢未過帳營運表頭
        /// <summary>
        /// 查詢未過帳營運表頭
        /// </summary>
        /// <returns></returns>
        public List<OperatingMainSetting> Get_OperatingPosting()
        {
            try
            {
                List<OperatingMainSetting> settings = null;
                var option = new RestClientOptions(OperatingPosting_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.ExecuteGetAsync<List<OperatingMainSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<OperatingMainSetting>>(response.Result.Content);
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return settings;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "查詢未過帳營運表頭API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 新增營運資料
        /// <summary>
        /// 新增營運資料
        /// </summary>
        /// <param name="PruchaseSetting"></param>
        /// <returns></returns>
        public string Post_Operating(string PruchaseSetting)
        {
            try
            {
                var option = new RestClientOptions(Operating_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(PruchaseSetting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                ResponseDataMessage = response.Result.Content;
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "新增營運資料API錯誤");
                ResponseDataMessage = "";
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 修改營運資料
        /// <summary>
        /// 修改營運資料
        /// </summary>
        /// <param name="PruchaseSetting"></param>
        /// <returns></returns>
        public string Put_Operating(string PruchaseSetting)
        {
            try
            {
                var option = new RestClientOptions(Operating_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(PruchaseSetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "修改營運資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 更新過帳營運資料
        /// <summary>
        /// 更新過帳營運資料
        /// </summary>
        /// <param name="PruchaseMainSetting"></param>
        /// <returns></returns>
        public string Put_OperatingMain(string PruchaseMainSetting)
        {
            try
            {
                var option = new RestClientOptions(UpdateOperatingMain_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddBody(PruchaseMainSetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "更新過帳營運資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 刪除營運資料
        /// <summary>
        /// 刪除營運資料
        /// </summary>
        /// <param name="PruchaseSetting"></param>
        /// <returns></returns>
        public string Delete_Operating(int OperatingFlag, string OperatingNumber)
        {
            try
            {
                var option = new RestClientOptions($"{Operating_url}/{OperatingFlag}/{OperatingNumber}")
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddHeader("Authorization", ReleaseNumber);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "刪除營運資料API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 營運上傳檔案
        /// <summary>
        /// 營運上傳檔案
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public string Post_OperatingAttachmentFile(int OperatingFlag, DateTime OperatingDate, string OperatingNumber, string Path)
        {
            try
            {
                var option = new RestClientOptions(OperatingAttachmenFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("OperatingFlag", OperatingFlag, type: ParameterType.QueryString);
                requsest.AddParameter("OperatingDate", OperatingDate.ToString("yyyy/MM/dd HH:mm:ss"), type: ParameterType.QueryString);
                requsest.AddParameter("OperatingNumber", OperatingNumber, type: ParameterType.QueryString);
                requsest.AddFile("AttachmentFile", Path);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return ResponseMessage(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "營運上傳檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 營運下載檔案
        /// <summary>
        /// 營運下載檔案
        /// </summary>
        /// <param name="File">檔案名稱</param>
        /// <returns></returns>
        public byte[] Get_OperatingAttachmentFile(string OperatingNumber, string File)
        {
            try
            {
                var option = new RestClientOptions(OperatingAttachmenFile_url)
                {
                    Timeout = time
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddHeader("Authorization", ReleaseNumber);
                requsest.AddParameter("AttachmentFile", File, type: ParameterType.QueryString);
                requsest.AddParameter("OperatingNumber", OperatingNumber, type: ParameterType.QueryString);
                var response = clinet.DownloadDataAsync(requsest);
                response.Wait();
                ClientFlag = true;
                ErrorStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                return response.Result;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "營運下載檔案API錯誤");
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #endregion

        #region 訊息回傳處理
        /// <summary>
        /// 訊息回傳處理
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private string ResponseMessage(RestResponse response)
        {

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ClientFlag = true;
                return "200";
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                ClientFlag = true;
                string error = JObject.Parse(response.Content).SelectToken("errors").Last.ToString();
                ResponseErrorMessage = error.Replace("\r\n", "").Replace("\"", "").Replace(" ", "");
                return ResponseErrorMessage;
            }
            else
            {
                ClientFlag = false;
                return ResponseErrorMessage = response.ErrorMessage;
            }
        }
        #endregion
    }
}
