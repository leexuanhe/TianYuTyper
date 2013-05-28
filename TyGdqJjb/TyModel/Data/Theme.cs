using System.Drawing;

namespace TyModel.Data
{
    public class Theme
    {
        private Font _dFont = new Font("宋体",14f);
        private Color _dBgColor = Color.GhostWhite;
        private Font _gFont = new Font("宋体",12f);
        private Color _gBgColor = Color.White;
        private Color _right = Color.DimGray;
        private Color _wrong = Color.Firebrick;
        private Color _progressBgColor = Color.YellowGreen;
        private Color _duanHaoBack = Color.IndianRed;
        private Color _titleBack = Color.Indigo;
        private Color _countBack = Color.Peru;
        private Color _groupBack = Color.Green;

        #region 对照区

        /// <summary>
        /// 对照区字体
        /// </summary>
        public Font DFont
        {
            set { _dFont = value; }
            get { return _dFont; }
        }

        /// <summary>
        /// 对照区底色
        /// </summary>
        public Color DBgColor
        {
            set { _dBgColor = value; }
            get { return _dBgColor; }
        }

        #endregion

        #region 跟打区
        
        /// <summary>
        /// 跟打区底色
        /// </summary>
        public Font GFont
        {
            set { _gFont = value; }
            get { return _gFont; }
        }

        /// <summary>
        /// 跟打区字体
        /// </summary>
        public Color GBgColor
        {
            set { _gBgColor = value; }
            get { return _gBgColor; }
        }

        #endregion

        #region 正误处理
        /// <summary>
        /// 打对色
        /// </summary>
        public Color Right
        {
            set { _right = value; }
            get { return _right; }
        }

        /// <summary>
        /// 打错字
        /// </summary>
        public Color Wrong
        {
            set { _wrong = value; }
            get { return _wrong; }
        }

        #endregion

        #region 顶部栏区域
        public Color DuanHaoBack
        {
            set { _duanHaoBack = value; }
            get { return _duanHaoBack; }
        }

        public Color TitleBack
        {
            set { _titleBack = value; }
            get { return _titleBack; }
        }

        public Color CountBack
        {
            set { _countBack = value; }
            get { return _countBack; }
        }

        public Color GroupBack
        {
            set { _groupBack = value; }
            get { return _groupBack; }
        }

        #endregion

        #region 其它区域
        /// <summary>
        /// 进度条颜色
        /// </summary>
        public Color ProgressBgColor
        {
            set { _progressBgColor = value; }
            get { return _progressBgColor; }
        }

        #endregion

    }
}