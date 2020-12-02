using Newtonsoft.Json;
using Serilog;
using System;
using System.IO;
using System.Text;
using TurnkeySystemV2.Configuration;

namespace TurnkeySystemV2.Controller
{
    public static class InitialMethod
    {
        /// <summary>
        /// 初始路徑
        /// </summary>
        private static string MyWorkPath = AppDomain.CurrentDomain.BaseDirectory;
        #region 資料庫JSON建置與讀取
        /// <summary>
        /// 資料庫JSON建置與讀取
        /// </summary>
        /// <returns></returns>
        public static SqlDBSetting SqlDB()
        {
            SqlDBSetting setting = new SqlDBSetting();
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\SqlDB.json";
            try
            {
                if (File.Exists(SettingPath))
                {
                    string json = File.ReadAllText(SettingPath, Encoding.UTF8);
                    setting = JsonConvert.DeserializeObject<SqlDBSetting>(json);
                }
                else
                {
                    SqlDBSetting Setting = new SqlDBSetting()
                    {
                        DataSource = "127.0.0.1",
                        InitialCatalog = "Turnkeydb",
                        UserID = "sa",
                        Password = "1234"
                    };
                    setting = Setting;
                    string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
                    File.WriteAllText(SettingPath, output);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "System setting initial 資料庫JSON failed.");
            }
            return setting;
        }
        #endregion
        #region 移動報表資料夾路徑JSON建置與讀取
        /// <summary>
        /// 移動報表資料夾路徑JSON建置與讀取
        /// </summary>
        /// <returns></returns>
        public static RemoveReportPathSetting RemoveReportPath()
        {
            RemoveReportPathSetting setting = new RemoveReportPathSetting();
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\RemoveReportPath.json";
            try
            {
                if (File.Exists(SettingPath))
                {
                    string json = File.ReadAllText(SettingPath, Encoding.UTF8);
                    setting = JsonConvert.DeserializeObject<RemoveReportPathSetting>(json);
                }
                else
                {
                    RemoveReportPathSetting Setting = new RemoveReportPathSetting()
                    {
                        A0101Path = "D:\\EINVTurnkey\\UPCast\\B2BEXCHANGE\\A0101\\SRC",
                        A0102Path = "D:\\EINVTurnkey\\UPCast\\B2BEXCHANGE\\A0102\\SRC",
                        A0201Path = "D:\\EINVTurnkey\\UPCast\\B2BEXCHANGE\\A0201\\SRC",
                        A0202Path = "D:\\EINVTurnkey\\UPCast\\B2BEXCHANGE\\A0202\\SRC",
                        A0301Path = "D:\\EINVTurnkey\\UPCast\\B2BEXCHANGE\\A0301\\SRC",
                        A0302Path = "D:\\EINVTurnkey\\UPCast\\B2BEXCHANGE\\A0302\\SRC",
                        A0401Path = "D:\\EINVTurnkey\\UPCast\\B2BSTORAGE\\A0401\\SRC",
                        A0501Path = "D:\\EINVTurnkey\\UPCast\\B2BSTORAGE\\A0501\\SRC",
                        B0101Path = "D:\\EINVTurnkey\\UPCast\\B2BEXCHANGE\\B0101\\SRC",
                        B0102Path = "D:\\EINVTurnkey\\UPCast\\B2BEXCHANGE\\B0102\\SRC",
                        B0201Path = "D:\\EINVTurnkey\\UPCast\\B2BEXCHANGE\\B0201\\SRC",
                        B0202Path = "D:\\EINVTurnkey\\UPCast\\B2BEXCHANGE\\B0202\\SRC",
                        B0401Path = "D:\\EINVTurnkey\\UPCast\\B2BSTORAGE\\B0401\\SRC",
                        B0501Path = "D:\\EINVTurnkey\\UPCast\\B2BSTORAGE\\B0501\\SRC",
                        E0402Path = "D:\\EINVTurnkey\\UpCast\\B2PMESSAGE\\E0402\\SRC",
                    };
                    setting = Setting;
                    string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
                    File.WriteAllText(SettingPath, output);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "System setting initial 移動報表資料夾路徑JSON failed.");
            }
            return setting;
        }
        #endregion
    }
}
