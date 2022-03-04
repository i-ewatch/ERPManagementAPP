using ERPManagementAPP.Configuration;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        URL = "http://localhost:60678/api"
                    };
                    setting = Setting;
                    string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
                    File.WriteAllText(SettingPath, output);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, " 跑馬燈資訊設定載入錯誤");
            }
            return setting;
        }
    }
}
