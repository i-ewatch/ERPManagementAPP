namespace ERPManagementAPP.Models
{
    public class ProjectEmployeeSetting
    {
        /// <summary>
        /// 專案代碼
        /// </summary>
        public string ProjectNumber { get; set; }
        /// <summary>
        /// 員工編號
        /// </summary>
        public string EmployeeNumber { get; set; }
        /// <summary>
        /// 獎金比率
        /// </summary>
        public double BonusRatio { get; set; }
    }
}
