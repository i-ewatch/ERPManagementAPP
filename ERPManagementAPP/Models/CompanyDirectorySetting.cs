namespace ERPManagementAPP.Models
{
    public  class CompanyDirectorySetting
    {
        /// <summary>
        /// 廠商編號
        /// </summary>
        public string DirectoryCompany { get; set; }
        /// <summary>
        /// 編號
        /// </summary>
        public string DirectoryNumber { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string DirectoryName { get; set; }
        /// <summary>
        /// 職稱
        /// </summary>
        public string JobTitle { get; set; }
        /// <summary>
        /// 電話
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 手機
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 附件檔案
        /// </summary>
        //public byte[] AttachmentFile { get; set; }
        /// <summary>
        /// 附件名稱
        /// </summary>
        public string FileName { get; set; }
    }
}
