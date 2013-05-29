using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TyModel.Model
{
    public class TyLogModel
    {
        public static TyLogModel Instance { set; get; }
        private string SavePath { set; get; }
        public TyLogModel(string path)
        {
            this.SavePath = path;
        }

        public void WriteLog(LogType logType,string msg)
        {
            StreamWriter sw = null;
            try
            {
                if (!Directory.Exists(SavePath))
                    Directory.CreateDirectory(SavePath);
                //同一天同一类日志以追加形式保存
                var filepath = SavePath + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".Log";
                if (!File.Exists(filepath)) File.Create(filepath);
                sw = File.AppendText(filepath);
                sw.WriteLine(logType + "#" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss: ") + msg + "\n");
            }
            catch
            { }
            finally
            {
                if (sw != null) sw.Close();
            }
        }

    }

    public enum LogType
    {
        ClipboardError,
        ConfigError,
        Error,
        Info
    }
}
