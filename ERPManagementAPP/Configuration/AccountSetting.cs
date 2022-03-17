using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPManagementAPP.Configuration
{
    public class AccountSetting
    {
        /// <summary>
        /// 帳號
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 記住帳號/密碼旗標
        /// </summary>
        public bool RememberFlag { get; set; }
    }
}
