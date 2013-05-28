using System.Collections.Generic;
using TyModel.Data;

namespace TyModel.Model
{
    public class GlobalModel
    {
        public static GlobalModel Instance { set; get; }
        public FormInfo FormInfo { set; get; }

        /// <summary>
        /// 主题信息
        /// </summary>
        public Theme Theme { set; get; }

        /// <summary>
        /// 保存配置
        /// </summary>
        public ConfigModel ConfigModel { set; get; }

        /// <summary>
        /// 群数据
        /// </summary>
        public GroupData GroupData { set; get; }
        /// <summary>
        /// 配置信息
        /// </summary>
        public Config Config { set; get; }

        /// <summary>
        /// 从QQ获取数据
        /// </summary>
        public GetData GetData { set; get; }
        public GlobalModel()
        {
            this.FormInfo = new FormInfo();
            this.ConfigModel = new ConfigModel();
            this.Config = new Config();
            this.Theme = new Theme();
            this.GroupData = new GroupData {GroupList = new List<ListGroup>()};
            GetData = new GetData();
        }


    }
}
