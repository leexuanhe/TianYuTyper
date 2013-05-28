using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using TyModel.Data;

namespace TyModel.Model
{
    public class ConfigModel
    {
        private string _savePath = "";

        private ConfigType _configType = ConfigType.FormInfo;
        //保存地点
        private string SaveConfigPath { get
        {
            switch (_configType)
            {
                case ConfigType.FormInfo:
                    return SavePath + "\\Config";
                case ConfigType.Theme:
                    return SavePath + "\\Theme";
                default:
                    return SavePath + "\\Config";
            }
        } }
        //保存路径
        public string SavePath
        {
            get { return _savePath; }
            set
            {
                _savePath = value;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }
                if (File.Exists(SavePath)) return;
                //using (File.Create(SaveConfigPath)) { }
            }
        }

        /// <summary>
        /// 根据类型区别
        /// </summary>
        private object ObjectClass { get
        {
            switch (this._configType)
            {
                case ConfigType.FormInfo:
                    return GlobalModel.Instance.Config;
                case ConfigType.Theme:
                    return GlobalModel.Instance.Theme;
                default:
                    return GlobalModel.Instance.Config;
            }
        }}
        private string GetConfigStr { get; set; }

        public ConfigModel()
        {
            
        }

        public void ConfigSave(ConfigType cType)
        {
            var serializer = new JsonSerializer();
            using (var sw = new StringWriter())
            {
                this._configType = cType;
                serializer.Serialize(new JsonTextWriter(sw), ObjectClass);
                WriteFile(sw.GetStringBuilder().ToString());
            }
        }

        public void ConfigRead(ConfigType cType)
        {
            this._configType = cType;
            GetConfigStr = ReadFile(SaveConfigPath);
            if (GetConfigStr == null) return;
            var sr = new StringReader(GetConfigStr);
            var serializer = new JsonSerializer();
            try
            {
                switch (_configType)
                {
                    case ConfigType.FormInfo:
                        var config = (Config) serializer.Deserialize(new JsonTextReader(sr), typeof (Config));
                        GlobalModel.Instance.Config = config;
                        break;
                    case ConfigType.Theme:
                        var configTheme = (Theme) serializer.Deserialize(new JsonTextReader(sr), typeof (Theme));
                        GlobalModel.Instance.Theme = configTheme;
                        break;
                }
            }
            catch (Exception err)
            {
                TyLogModel.Instance.WriteLog(LogType.ConfigError, err.Message);
            }
        }

        private string ReadFile(string path)
        {
            if (!File.Exists(path)) return null;
            using (var streamReader = new StreamReader(path, Encoding.UTF8))
            {
                var v  = streamReader.ReadToEnd();
                return v;
            }
        }
        private void WriteFile(string gS)
        {
            using (var streamWriter = new StreamWriter(SaveConfigPath,false,Encoding.UTF8))
            {
                streamWriter.Write(gS);
            }
        }
    }

    public enum ConfigType
    {
        FormInfo,
        Theme
    }
}
