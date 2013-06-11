using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TyGdqJjb.TyData
{
    public class TempData
    {
        private int _wordHeight = 20;
        public static TempData Instance { set; get; }
        public TempData()
        {
            
        }

        /// <summary>
        /// 一字高度
        /// </summary>
        public int WordHeight
        {
            set { _wordHeight = value; }
            get { return _wordHeight; }
        }

        /// <summary>
        /// 段号列表
        /// </summary>
        public Dictionary<string,List<string>> DuanList { set; get; }

        public MatchCollection SourceMatches { set; get; }

        //回改报告
        public Dictionary<int,int> BackReport = new Dictionary<int, int>();

        //跟打报告
        public List<TypeReportData> TypeReport = new List<TypeReportData>();

        public Bitmap GetColor(Color color)
        {
            var bmp = new Bitmap(22, 22);
            var g = Graphics.FromImage(bmp);
            g.FillRectangle(new SolidBrush(color), 0, 0, bmp.Width, bmp.Height);
            g.DrawRectangle(new Pen(Color.Black), 0, 0, bmp.Width - 1, bmp.Height - 1);
            return bmp;
        }
    }

    public class TypeReportData
    {
        public string Key { set; get; }
        public int Start { set; get; }
        public string Word { set; get; }
        public int StartKickIndex { set; get; }
        public int Kicks { set; get; }
        public DateTime StartTime { set; get; }
        public TimeSpan UseTime { set; get; }
        public int ReTypeTimes { set; get; }
    }
}
