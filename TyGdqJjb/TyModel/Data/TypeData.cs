using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TyModel.Model;

namespace TyModel.Data
{
    public class TypeData : IInit
    {
        /// <summary>
        ///     错字集合
        /// </summary>
        public List<char> ErrorWords = new List<char>();

        public TypeData()
        {
            Clear();
            TypeInfo = new TypeInfo();
        }

        public static TypeData Instance { set; get; }
        public TypeInfo TypeInfo { set; get; }
        /// <summary>
        /// 成绩数据
        /// </summary>
        private TypeAchievement _typeAchievement = new TypeAchievement();

        private double _progress;

        public TypeAchievement GetTypeAchievement()
        {
            return _typeAchievement;
        }
      
        /// <summary>
        ///     回改
        /// </summary>
        public int BackTimes { set; get; }

        /// <summary>
        ///     当前跟打器状态
        /// </summary>
        public TypeState TypeState { set; get; }

        /// <summary>
        ///     要跟打的文字
        /// </summary>
        public string TypeText
        {
            set { TypeInfo.Text = value; }
            get { return TypeInfo.Text; }
        }

        public int ImfactTextCount { set; get; }

        /// <summary>
        ///     键数
        /// </summary>
        public int KickTimes { set; get; }

        /// <summary>
        ///     起打时间
        /// </summary>
        public DateTime StartTime { set; get; }

        /// <summary>
        ///     终打时间
        /// </summary>
        public DateTime EndTime { set; get; }

        /// <summary>
        ///     总用时
        /// </summary>
        public TimeSpan TotalUseTime
        {
            get { return EndTime - StartTime; }
        }

        /// <summary>
        ///     初始化
        /// </summary>
        public event EventHandler Init;

        public void InitAll()
        {
            Init(this, new EventArgs());
            TypeState = TypeState.WaitType;
            Clear();
        }

        //文段初始化
        public event EventHandler GetTextInit;

        public void GetTextInitAll(TypeInfo typeInfo)
        {
            InitAll();
            GetTextInit(typeInfo, new EventArgs());
        }

        private void Clear()
        {
            //KickPerWord = 0;
            //KickPerSec = 0;
            //Speed = 0;
            KickTimes = 0;
            BackTimes = 0;
            //Speed2 = 0;
            GetTypeAchievement().Speed2 = 0;
            GetTypeAchievement().Clear();
            ImfactTextCount = 0;
            ErrorWords.Clear();
        }

        public delegate void ChangeProgess(double per);

        /// <summary>
        /// 进度条
        /// </summary>
        public event ChangeProgess ProgressChange;

        public double Progress
        {
            set { _progress = value;
                ProgressChange(value);
            }
            get { return _progress; }
        }
    }

    public enum TypeState
    {
        WaitType,
        Typing,
        Pause,
        TypeOver,
        Wrong
    }
}