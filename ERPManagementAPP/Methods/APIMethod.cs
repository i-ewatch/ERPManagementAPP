using ERPManagementAPP.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ERPManagementAPP.Methods
{
    public class APIMethod
    {
        /// <summary>
        /// 主要網址
        /// </summary>
        public  string URL { get; set; }
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public string ErrorStr { get; set; } = "無網路或伺服器未開啟!";
        /// <summary>
        /// API回應錯誤訊息
        /// </summary>
        public string ResponseErrorMessage { get; set; } = "";
        /// <summary>
        /// API連結旗標
        /// </summary>
        public bool ClientFlag { get; set; } = false;
        /// <summary>
        /// API連結物件
        /// </summary>
        private RestClient clinet { get; set; }

        public APIMethod(string url)
        {
            URL = url;
            Company_url = $"{URL}/Company";
            CompanyAttachmentFile_url  = $"{URL}/CompanyAttachmentFile";
            CompanyAttachmentFile_url  = $"{URL}/CompanyAttachmentFile";
            CompanyDirectory_url  = $"{URL}/CompanyDirectory";
            CompanyDirectoryNumber_url  = $"{URL}/CompanyDirectoryNumber";
            DirectoryCompany_url  = $"{URL}/DirectoryCompany";
            CompanyDirectoryAttachmentFile_url  = $"{URL}/CompanyDirectoryAttachmentFile";
            Customer_url  = $"{URL}/Customer";
            CustomerNumber_url  = $"{URL}/CustomerNumber";
            CustomerAttachmentFile_url  = $"{URL}/CustomerAttachmentFile";
            CustomerDirectory_url  = $"{URL}/CustomerDirectory";
            CustomerDirectoryNumber_url  = $"{URL}/CompanyDirectoryNumber";
            DirectoryCustomer_url  = $"{URL}/DirectoryCustomer";
            CustomerDirectoryAttachmentFile_url  = $"{URL}/CustomerDirectoryAttachmentFile";
            Employee_url = $"{URL}/Employee";
            EmployeeNumber_url = $"{URL}/EmployeeNumber";
            Product_url = $"{URL}/Product";
            ProductType_url = $"{URL}/ProductNumber/ProductType";
            ProductNumber_url = $"{URL}/ProductNumber";
            ProductAttachmentFile_url = $"{URL}/ProductAttachmentFile";
            ProductGategory_url = $"{URL}/ProductCategory";
        }
        #region 公司資訊
        /// <summary>
        /// 廠商資料(Get、Post、Put)
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
        /// 廠商通訊錄資料(Get、Post、Put)
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
        /// 廠商通訊錄檔案上傳(Post)
        /// </summary>
        private string CompanyDirectoryAttachmentFile_url { get; set; }
        #endregion
        #region 客戶資訊
        /// <summary>
        /// 客戶資料(Get、Post、Put)
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
        /// 客戶通訊錄資料(Get、Post、Put)
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
        /// 客戶通訊錄檔案上傳(Post)
        /// </summary>
        private string CustomerDirectoryAttachmentFile_url { get; set; }
        #endregion
        #region 員工資訊
        /// <summary>
        /// 員工資料(Get、Post、Put)
        /// </summary>
        private string Employee_url { get; set; }
        /// <summary>
        /// 員工編碼查詢(Get)
        /// </summary>
        private string EmployeeNumber_url { get; set; }
        #endregion
        #region 產品資訊
        /// <summary>
        /// 產品資料(Get、Post、Put)
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
        /// 產品檔案上傳(Post)
        /// </summary>
        private string ProductAttachmentFile_url { get; set; }
        /// <summary>
        /// 產品類別資料(Get、Post、Put)
        /// </summary>
        private string ProductGategory_url { get; set; }
        #endregion

        /*以下API功能----------------------------------------------------------------------------------------*/
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                var response = clinet.ExecuteGetAsync<List<CompanySetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<CompanySetting>>(response.Result.Content);
                ClientFlag = true;
                return settings;
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                var response = clinet.ExecuteGetAsync<List<CompanySetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<CompanySetting>>(response.Result.Content);
                ClientFlag = true;
                return settings;
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddBody(companySetting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddBody(customerSetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddBody(customerSetting, ContentType.Json);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddParameter("CompanyNumber", Number, type: ParameterType.QueryString);
                requsest.AddParameter("CompanyName", Name, type: ParameterType.QueryString);
                requsest.AddFile("AttachmentFile", Path);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
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
                MemoryStream File;
                var option = new RestClientOptions(CompanyAttachmentFile_url)
                {
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddParameter("CompanyNumber", Number, type: ParameterType.QueryString);
                requsest.AddParameter("CompanyName", Name, type: ParameterType.QueryString);
                requsest.AddParameter("AttachmentFile", FileName, type: ParameterType.QueryString);
                var response = clinet.DownloadDataAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return response.Result;
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                var response = clinet.ExecuteGetAsync<List<CompanyDirectorySetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<CompanyDirectorySetting>>(response.Result.Content);
                ClientFlag = true;
                return settings;
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                var response = clinet.ExecuteGetAsync<List<CompanyDirectorySetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<CompanyDirectorySetting>>(response.Result.Content);
                ClientFlag = true;
                return settings;
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                var response = clinet.ExecuteGetAsync<List<CompanyDirectorySetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<CompanyDirectorySetting>>(response.Result.Content);
                ClientFlag = true;
                return settings;
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddBody(customerDirectorySetting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddBody(companyDirectorySetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddBody(companyDirectorySetting, ContentType.Json);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddParameter("DirectoryCompany", DirectoryCustomer, type: ParameterType.QueryString);
                requsest.AddParameter("DirectoryNumber", DirectoryNumber, type: ParameterType.QueryString);
                requsest.AddFile("AttachmentFile", Path);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddParameter("DirectoryCompany", DirectoryCustomer, type: ParameterType.QueryString);
                requsest.AddParameter("DirectoryNumber", DirectoryNumber, type: ParameterType.QueryString);
                requsest.AddParameter("AttachmentFile", FileName, type: ParameterType.QueryString);
                var response = clinet.DownloadDataAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return response.Result;
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                var response = clinet.ExecuteGetAsync<List<CustomerSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<CustomerSetting>>(response.Result.Content);
                ClientFlag = true;
                return settings;
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                var response = clinet.ExecuteGetAsync<List<CustomerSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<CustomerSetting>>(response.Result.Content);
                ClientFlag = true;
                return settings;
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddBody(customerSetting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddBody(customerSetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddBody(customerSetting, ContentType.Json);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddParameter("CustomerNumber", Number, type: ParameterType.QueryString);
                requsest.AddParameter("CustomerName", Name, type: ParameterType.QueryString);
                requsest.AddFile("AttachmentFile", Path);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddParameter("CustomerNumber", Number, type: ParameterType.QueryString);
                requsest.AddParameter("CustomerName", Name, type: ParameterType.QueryString);
                requsest.AddParameter("AttachmentFile", File, type: ParameterType.QueryString);
                var response = clinet.DownloadDataAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return response.Result;
            }
            catch (Exception)
            {
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
        public List<CustomerDirectorySetting> Get_CustomerDirectory()
        {
            try
            {
                List<CustomerDirectorySetting> settings = null;
                var option = new RestClientOptions(CustomerDirectory_url)
                {
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                var response = clinet.ExecuteGetAsync<List<CustomerDirectorySetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<CustomerDirectorySetting>>(response.Result.Content);
                ClientFlag = true;
                return settings;
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                var response = clinet.ExecuteGetAsync<List<CustomerDirectorySetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<CustomerDirectorySetting>>(response.Result.Content);
                ClientFlag = true;
                return settings;
            }
            catch (Exception)
            {
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
        public List<CustomerDirectorySetting> Get_CustomerDirectory(string DirectoryNumber)
        {
            try
            {
                List<CustomerDirectorySetting> settings = null;
                var option = new RestClientOptions(CustomerDirectoryNumber_url + $"/{DirectoryNumber}")
                {
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                var response = clinet.ExecuteGetAsync<List<CustomerDirectorySetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<CustomerDirectorySetting>>(response.Result.Content);
                ClientFlag = true;
                return settings;
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddBody(companyDirectorySetting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddBody(customerDirectorySetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddBody(customerDirectorySetting, ContentType.Json);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddParameter("DirectoryCustomer", DirectoryCustomer, type: ParameterType.QueryString);
                requsest.AddParameter("DirectoryNumber", DirectoryNumber, type: ParameterType.QueryString);
                requsest.AddFile("AttachmentFile", Path);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddParameter("DirectoryCustomer", DirectoryCustomer, type: ParameterType.QueryString);
                requsest.AddParameter("DirectoryNumber", DirectoryNumber, type: ParameterType.QueryString);
                requsest.AddParameter("AttachmentFile", File, type: ParameterType.QueryString);
                var response = clinet.DownloadDataAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return response.Result;
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                var response = clinet.ExecuteGetAsync<List<EmployeeSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<EmployeeSetting>>(response.Result.Content);
                ClientFlag = true;
                return settings;
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                var response = clinet.ExecuteGetAsync<List<EmployeeSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<EmployeeSetting>>(response.Result.Content);
                ClientFlag = true;
                return settings;
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddBody(employeeSetting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddBody(employeeSetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddBody(employeeSetting, ContentType.Json);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                var response = clinet.ExecuteGetAsync<List<ProductSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<ProductSetting>>(response.Result.Content);
                ClientFlag = true;
                return settings;
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                var response = clinet.ExecuteGetAsync<List<ProductSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<ProductSetting>>(response.Result.Content);
                ClientFlag = true;
                return settings;
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                var response = clinet.ExecuteGetAsync<List<ProductSetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<ProductSetting>>(response.Result.Content);
                ClientFlag = true;
                return settings;
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddBody(productSetting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddBody(productSetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddBody(productSetting, ContentType.Json);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddParameter("ProductNumber", Number, type: ParameterType.QueryString);
                requsest.AddParameter("ProductName", Name, type: ParameterType.QueryString);
                requsest.AddFile("AttachmentFile", Path);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
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
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                requsest.AddParameter("ProductNumber", Number, type: ParameterType.QueryString);
                requsest.AddParameter("ProductName", Name, type: ParameterType.QueryString);
                requsest.AddParameter("AttachmentFile", File, type: ParameterType.QueryString);
                var response = clinet.DownloadDataAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return response.Result;
            }
            catch (Exception)
            {
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #endregion

        #region 產品類別API
        #region 全部產品類別
        /// <summary>
        /// 全部產品類別
        /// </summary>
        /// <returns></returns>
        public List<ProductCategorySetting> Get_ProductGategory()
        {
            try
            {
                List<ProductCategorySetting> settings = null;
                var option = new RestClientOptions(ProductGategory_url)
                {
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                var response = clinet.ExecuteGetAsync<List<ProductCategorySetting>>(requsest);
                response.Wait();
                settings = JsonConvert.DeserializeObject<List<ProductCategorySetting>>(response.Result.Content);
                ClientFlag = true;
                return settings;
            }
            catch (Exception)
            {
                ErrorStr = "無網路或伺服器未開啟!";
                ClientFlag = false;
                return null;
            }
        }
        #endregion
        #region 新增產品類別資料
        /// <summary>
        /// 新增產品類別資料
        /// </summary>
        /// <param name="productGategorySetting"></param>
        /// <returns></returns>
        public string Post_ProductGategory(string productGategorySetting)
        {
            try
            {
                var option = new RestClientOptions(ProductGategory_url)
                {
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Post);
                requsest.AddBody(productGategorySetting, ContentType.Json);
                var response = clinet.ExecutePostAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 修改產品類別資料
        /// <summary>
        /// 修改產品類別資料
        /// </summary>
        /// <param name="productGategorySetting"></param>
        /// <returns></returns>
        public string Put_ProductGategory(string productGategorySetting)
        {
            try
            {
                var option = new RestClientOptions(ProductGategory_url)
                {
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Put);
                requsest.AddBody(productGategorySetting, ContentType.Json);
                var response = clinet.ExecutePutAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
                ErrorStr = "無網路或伺服器未開啟!";
                return null;
            }
        }
        #endregion
        #region 刪除產品類別資料
        /// <summary>
        /// 刪除產品類別資料
        /// </summary>
        /// <param name="productGategorySetting"></param>
        /// <returns></returns>
        public string Delete_ProductGategory(string productGategorySetting)
        {
            try
            {
                var option = new RestClientOptions(ProductGategory_url)
                {
                    Timeout = 1000
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Delete);
                requsest.AddBody(productGategorySetting, ContentType.Json);
                var response = clinet.DeleteAsync(requsest);
                response.Wait();
                ClientFlag = true;
                return ResponseMessage(response.Result);
            }
            catch (Exception)
            {
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
