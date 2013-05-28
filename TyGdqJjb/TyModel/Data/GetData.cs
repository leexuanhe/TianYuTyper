using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TyModel.Data
{
    public class GetData
    {
        public Regex FindAllDuan = new Regex(@".+\s.+\s-----第\d+段.+", RegexOptions.RightToLeft);
        public Regex FindDuanHao = new Regex(@"(?<=第)\d+(?=段)");
        public Regex FindTitle = new Regex(@".+(?=\s)");
        public GetData()
        {
            
        }
    }
}
