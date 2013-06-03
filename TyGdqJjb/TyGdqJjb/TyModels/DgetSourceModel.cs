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
        public MainForm MainForm { set; get; }
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
            this.RichTextBoxEx = richTextBoxEx;
            //this.RichTextBoxEx.TextChanged += RichTextBoxEx_TextChanged;
        }
        //void RichTextBoxEx_TextChanged(object sender, EventArgs e)
        //{
        //    TypeData.Instance.TypeText = this.RichTextBoxEx.Text; //填入数据
        //}
    }
}
