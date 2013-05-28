using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TyGdqJjb.TyData;
using TyModel.Data;
using TyModel.Model;

namespace TyGdqJjb
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm
                {
                    Text = GlobalModel.Instance.FormInfo.FormTitleAndVersion,
                    Size = GlobalModel.Instance.Config.Size,
                    Location = GlobalModel.Instance.Config.Location
                });
        }

        private static void Init()
        {
            //MessageBox.Show(typeof (double).ToString());
            TyLogModel.Instance = new TyLogModel(Application.StartupPath + "\\Log");
            GlobalModel.Instance = new GlobalModel
                {
                    ConfigModel = {SavePath = Application.StartupPath + "\\Config"}
                };
            GlobalModel.Instance.ConfigModel.ConfigRead(ConfigType.FormInfo);
            GlobalModel.Instance.ConfigModel.ConfigRead(ConfigType.Theme);
            TypeData.Instance = new TypeData();//跟打文字数据
            TypeData.Instance.GetTypeAchievement().Init();//初始化
            GroupOprationModel.Instance = new GroupOprationModel();
            TempData.Instance = new TempData();
        }
    }
}
