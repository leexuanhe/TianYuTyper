using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TyModel.Model;

namespace TyModel.Data
{
    public class TypeInfo
    {
        private string _text = "测试内容。。。";
        private string _id = "1234";

        /// <summary>
        /// 文段号
        /// </summary>
        public string Id
        {
            set { _id = value; }
            get { return _id; }
        }

        public string DuanHao {get { return "第" + Id + "段"; }}
        /// <summary>
        /// 文章标题
        /// </summary>
        public string Title { set; get; }

        /// <summary>
        /// 文章内容
        /// </summary>
        public string Text
        {
            set { _text = value; }
            get { return _text; }
        }
    }
}
