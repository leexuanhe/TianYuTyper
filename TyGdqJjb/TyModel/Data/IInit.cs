using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TyModel.Data
{
    public interface IInit
    {
        event EventHandler Init;
        void InitAll();
        event EventHandler GetTextInit;
        void GetTextInitAll(TypeInfo typeInfo);
    }
}
