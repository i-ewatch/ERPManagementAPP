using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPManagementAPP.Models
{
    public class PurchaseSubSetting
    {
        /// <summary>
        /// 進貨旗標 
        /// </summary>
        public int PurchaseFlag { get; set; }
        /// <summary>
        /// 進貨單號
        /// </summary>
        public string PurchaseNumber { get; set; }
        /// <summary>
        /// 進貨明細序號
        /// </summary>
        public int PurchaseNo { get; set; }
        /// <summary>
        /// 產品編號
        /// </summary>
        public string ProductNumber { get; set; }
        /// <summary>
        /// 產品名稱
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 產品單位
        /// </summary>
        public string ProductUnit { get; set; }
        /// <summary>
        /// 產品數量
        /// </summary>
        public double ProductQty { get; set; }
        /// <summary>
        /// 產品單價
        /// </summary>
        public double ProductPrice { get; set; }
        /// <summary>
        /// 產品小計
        /// </summary>
        public double ProductTotal { get; set; }
    }
}
