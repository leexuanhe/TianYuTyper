using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using TyModel.Data;

namespace TyModel.Model
{
    public class GroupOprationModel
    {
        private List<string> _blockGroupList = new List<string>()
            {
                "TXMenuWindow",
                "FaceSelector",
                "TXFloatingWnd",
                "腾讯",
                "消息盒子",
                "来自",
                "分类推荐",
                "更换房间头像",
                "网络设置",
                "消息管理器",
                "QQ数据线"
            };

        /// <summary>
        /// 系统群名屏蔽列表
        /// </summary>
        public List<string> BlockGroupList
        {
            set { _blockGroupList = value; }
            get { return _blockGroupList; }
        }

        public int UserBlockCount { set; get; }
        public int SystemBlockCount { set; get; }
        #region Report

        public delegate bool CallBack(int hwnd, int lParam);

        [DllImport("user32.dll")]
        public static extern int EnumWindows(CallBack x, int y);

        [DllImport("user32")]
        public static extern int GetWindowText(int hwnd, StringBuilder lptrString, int nMaxCount);

        [DllImport("user32")]
        public static extern int GetParent(int hwnd);

        [DllImport("user32")]
        public static extern int IsWindowVisible(int hwnd);

        [DllImport("user32.dll")]
        private static extern int GetClassName(int hWnd, StringBuilder lpString, int nMaxCount);

        public bool Report(int hwnd, int lParam)
        {
            int pHwnd;
            pHwnd = GetParent(hwnd);
            if (pHwnd == 0 && IsWindowVisible(hwnd) == 1)
            {
                var sb = new StringBuilder(512);
                var classname = new StringBuilder(512);
                GetClassName(hwnd, classname, classname.Capacity);
                if (classname.ToString().ToLower() == "txguifoundation")
                {
                    GetWindowText(hwnd, sb, sb.Capacity);
                    if (sb.Length > 0 && !BlockGroupList.Exists(o => o == sb.ToString()))
                    {

                        if (GlobalModel.Instance.Config.UserBlockGroupList != null)
                        {
                            if (!GlobalModel.Instance.Config.UserBlockGroupList.Exists(o => o == sb.ToString()))
                            {
                                GlobalModel.Instance.GroupData.GroupList.Add(new ListGroup {Name = sb.ToString(),Classname = hwnd});
                            }
                            else
                            {
                                UserBlockCount++;
                            }
                        }
                        else
                        {
                            GlobalModel.Instance.GroupData.GroupList.Add(new ListGroup { Name = sb.ToString(), Classname = hwnd});
                        }
                    }
                    else
                    {
                        SystemBlockCount++;
                    }
                }
            }
            return true;
        }

        #endregion
        public static GroupOprationModel Instance { set; get; }

        public GroupOprationModel()
        {
            
        }
        public delegate void SetGroupTitle(string title);

        public event SetGroupTitle SetTitle;

        protected virtual void OnSetTitle(string title)
        {
            SetGroupTitle handler = SetTitle;
            if (handler != null) handler(title);
        }

        /// <summary>
        /// 更新群
        /// </summary>
        public void RefreshGroup()
        {
            GlobalModel.Instance.GroupData.GroupList.Clear();
            UserBlockCount = 0;
            SystemBlockCount = 0;
            EnumWindows(this.Report, 0);
            if (GlobalModel.Instance.GroupData.GroupList.Count == 0)
            {
                GlobalModel.Instance.GroupData.Now = null;
                OnSetTitle(GlobalModel.Instance.GroupData.Now);
                return;
            }
            if (GlobalModel.Instance.GroupData.Flag >= GlobalModel.Instance.GroupData.GroupList.Count)
            {
                GlobalModel.Instance.GroupData.Flag = 0;
            }
            GlobalModel.Instance.GroupData.Now =
                GlobalModel.Instance.GroupData.GroupList[GlobalModel.Instance.GroupData.Flag].Name;
            OnSetTitle(GlobalModel.Instance.GroupData.Now);
            GlobalModel.Instance.GroupData.Flag++;
        }

        /// <summary>
        /// 更新群h
        /// </summary>
        public List<ListGroup> UpdateGroup()
        {
            GlobalModel.Instance.GroupData.GroupList.Clear();
            UserBlockCount = 0;
            SystemBlockCount = 0;
            EnumWindows(this.Report, 0);
            return GlobalModel.Instance.GroupData.GroupList;
        }
    }
}
