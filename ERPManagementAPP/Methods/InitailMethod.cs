using ERPManagementAPP.Configuration;
using Newtonsoft.Json;
using Serilog;
using System;
using System.IO;
using System.Text;

namespace ERPManagementAPP.Methods
{
    public class InitailMethod
    {
        /// <summary>
        /// 初始路徑
        /// </summary>
        private static string MyWorkPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// 讀取系統設定資訊
        /// </summary>
        /// <returns></returns>
        public static SystemSetting SystemLoad()
        {
            SystemSetting setting = new SystemSetting();
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\System.json";
            try
            {
                if (File.Exists(SettingPath))
                {
                    string json = File.ReadAllText(SettingPath, Encoding.UTF8);
                    setting = JsonConvert.DeserializeObject<SystemSetting>(json);
                }
                else
                {
                    SystemSetting Setting = new SystemSetting()
                    {
                        URL = "http://erpmanagment.azurewebsites.net/api"
                    };
                    setting = Setting;
                    string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
                    File.WriteAllText(SettingPath, output);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, " URL資訊設定載入錯誤");
            }
            return setting;
        }
        /// <summary>
        /// 讀取帳號密碼
        /// </summary>
        /// <returns></returns>
        public static AccountSetting AccountLoad()
        {
            AccountSetting setting = new AccountSetting();
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\Account.json";
            try
            {
                if (File.Exists(SettingPath))
                {
                    string json = File.ReadAllText(SettingPath, Encoding.UTF8);
                    setting = JsonConvert.DeserializeObject<AccountSetting>(json);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, " 帳號密碼資訊設定載入錯誤");
            }
            return setting;
        }
        /// <summary>
        /// 儲存帳號密碼
        /// </summary>
        /// <param name="setting"></param>
        public static void AccountSave(AccountSetting setting)
        {
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\Account.json";
            string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
            File.WriteAllText(SettingPath, output);
        }
    }
}
