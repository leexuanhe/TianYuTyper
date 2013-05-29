using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TyModel.Model;

namespace TyModel.Data
{
    public class Config
    {
        private Point _location = new Point(200,200);
        private Size _size = new Size(400, 400);

        
        private int _splitDistance = 193;

        /// <summary>
        /// 窗口位置
        /// </summary>
        public Point Location
        {
            set { _location = value; }
            get { return _location; }
        }

        /// <summary>
        /// 窗口大小
        /// </summary>
        public Size Size
        {
            set { _size = value; }
            get { return _size; }
        }

        
        /// <summary>
        /// 用户屏蔽列表
        /// </summary>
        public List<string> UserBlockGroupList { set; get; }

        /// <summary>
        /// 用户白名单
        /// </summary>
        public List<string> UserWhiteGroupList { set; get; }

        public bool IsUseWhiteList
        {
            set { _isUseWhiteList = value; }
            get { return _isUseWhiteList; }
        }

        /// <summary>
        /// 分隔条高度
        /// </summary>
        public int SplitDistance
        {
            set { _splitDistance = value; }
            get { return _splitDistance; }
        }

        public TypeAchievementConfig TypeAchievementConfig = new TypeAchievementConfig();
        private bool _lastErrorNotSend = true;
        private bool _isUseWhiteList = false;

        /// <summary>
        /// 最后一次输入错了，则 触发完成
        /// </summary>
        public bool LastErrorNotSend
        {
            set { _lastErrorNotSend = value; }
            get { return _lastErrorNotSend; }
        }

        //var r = new Regex(@"QQ20\d{2}");
    }
}
