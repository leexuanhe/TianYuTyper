using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TyGdqJjb.TyControls;
using TyModel.Data;
using TyModel.Model;

namespace TyGdqJjb.TyModels
{
    /// <summary>
    /// 此Model用于设置新文段前后的处理操作
    /// </summary>
    public class DgetSourceModel:ITypeState
    {
        private double _progress = 0;
        public MainForm MainForm { set; get; }
        public double Progress
        {
            set { _progress = value; MainForm.Invalidate(_progressRect);}
            get { return _progress; }
        }

        private readonly Rectangle _progressRect;
        /// <summary>
        /// 跟打开始
        /// </summary>
        public event EventTypeHandler TypeStart;

        protected virtual void OnTypeStart(TyInfo tyinfo, DateTime datetime)
        {
            var handler = TypeStart;
            if (handler != null) handler(tyinfo, datetime);
            TypeData.Instance.StartTime = datetime;
            TypeData.Instance.TypeState = tyinfo.TypeState;
        }

        public void Start(TypeState typeState, DateTime dateTime)
        {
            OnTypeStart(new TyInfo(typeState), dateTime);
            TypeData.Instance.TypeState = TypeState.Typing;
            TypeData.Instance.StartTime = dateTime;
            TypeData.Instance.GetTypeAchievement().AchievementDic["字数"].关连值 = TypeData.Instance.TypeText.Length;
        }

        /// <summary>
        /// 跟打结束
        /// </summary>
        public event EventTypeHandler TypeEnd;

        public void End(TypeState typeState, DateTime dateTime)
        {
            OnTypeEnd(new TyInfo(typeState), dateTime);
        }

        /// <summary>
        /// 跟打完成
        /// </summary>
        /// <param name="tyinfo"></param>
        /// <param name="datetime"></param>
        protected virtual void OnTypeEnd(TyInfo tyinfo, DateTime datetime)
        {
            var handler = TypeEnd;
            if (handler != null) handler(tyinfo, datetime);
        }

        public RichTextBoxEx RichTextBoxEx { set; get; }

        public DgetSourceModel(RichTextBoxEx richTextBoxEx,MainForm mainForm)
        {
            this.MainForm = mainForm;
            this._progressRect = new Rectangle(10, 56, MainForm.Width - 36, 2);
            MainForm.Paint += MainForm_Paint;
            this.RichTextBoxEx = richTextBoxEx;
            //this.RichTextBoxEx.TextChanged += RichTextBoxEx_TextChanged;
        }

        /// <summary>
        /// 画进度条
        /// </summary>
        void MainForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(GlobalModel.Instance.Theme.ProgressBgColor), _progressRect.X, _progressRect.Y,
                                            (int)(_progressRect.Width * Progress), _progressRect.Height);
        }

        //void RichTextBoxEx_TextChanged(object sender, EventArgs e)
        //{
        //    TypeData.Instance.TypeText = this.RichTextBoxEx.Text; //填入数据
        //}
    }
}
