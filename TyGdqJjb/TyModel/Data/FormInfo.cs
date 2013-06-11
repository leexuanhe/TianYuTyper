using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyModel.Data
{
    public class FormInfo
    {
        public string FormTitle = "极致随心";
        public string FormVersion = "0.03";
        public string FormTitleAndVersion { get { return string.Format("{0}v{1}", FormTitle, FormVersion); } }
        public string LittleVersion = "y3";
    }
}
