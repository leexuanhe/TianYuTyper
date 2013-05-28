using System;
using TyModel.Data;

namespace TyGdqJjb.TyModels
{
    public delegate void EventTypeHandler(TyInfo tyInfo, DateTime dateTime);

    public interface ITypeState
    {
        event EventTypeHandler TypeStart;
        void Start(TypeState typeState, DateTime dateTime);
        event EventTypeHandler TypeEnd;
        void End(TypeState typeState, DateTime dateTime);
    }

    public class TyInfo
    {
        public TypeState TypeState { set; get; }

        public TyInfo(TypeState typeState)
        {
            this.TypeState = typeState;
        }
    }
}
