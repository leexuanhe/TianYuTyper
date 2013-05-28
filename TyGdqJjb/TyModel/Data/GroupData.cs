using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TyModel.Data
{
    public class GroupData
    {
        /// <summary>
        /// 群列表
        /// </summary>
        public List<ListGroup> GroupList { set; get; }

        public int Flag { set; get; }

        public string Now { set; get; }
    }

    public class ListGroup
    {
        public string Name { set; get; }
        public int Classname { set; get; }
    }
}
