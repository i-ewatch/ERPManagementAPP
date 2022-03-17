using System;

namespace ERPManagementAPP.Models
{
    public class PaymentSetting
    {
        /// <summary>
        /// 編號
        /// </summary>
        public string PaymentNumber { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime PaymentDate { get; set; }
        /// <summary>
        /// 發票號碼
        /// </summary>
        public string PaymentInvoiceNo { get; set; }
        /// <summary>
        /// 品項代碼
        /// </summary>
        public string PaymentItemNo { get; set; }
        /// <summary>
        /// 用途
        /// </summary>
        public string PaymentUse { get; set; }
        /// <summary>
        /// 申請人
        /// </summary>
        public string EmployeeNumber { get; set; }
        /// <summary>
        /// 金額
        /// </summary>
        public double PaymentAmount { get; set; }
        /// <summary>
        /// 請款方式
        /// </summary>
        public int PaymentMethod { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 匯款收款日期
        /// </summary>
        public DateTime? TransferDate { get; set; }
        /// <summary>
        /// 附件檔名
        /// </summary>
        public string FileName { get; set; }
    }
}
