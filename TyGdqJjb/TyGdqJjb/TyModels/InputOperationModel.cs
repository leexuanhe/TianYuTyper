using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using TyModel.Data;

namespace TyGdqJjb.TyModels
{
    public class InputOperationModel
    {
        #region DLL

        [DllImport("imm32.dll")]
        public static extern IntPtr ImmGetContext(IntPtr hWnd);

        [DllImport("imm32.dll")]
        public static extern bool ImmGetConversionStatus(IntPtr hIMC,
                                                         ref int conversion, ref int sentence);

        [DllImport("imm32.dll")]
        public static extern bool ImmSetConversionStatus(IntPtr hIMC, int conversion, int sentence);
        #endregion

        private IntPtr IntPtr { set; get; }
        public InputOperationModel(IntPtr intPtr)
        {
            this.IntPtr = intPtr;
        }

        public void InputLan()
        {
            var inputL = TypeData.Instance.GetTypeAchievement().AchievementDic["输入法"].TypeData.关连值.ToString();
            if (inputL.Trim().Length == 0) inputL = "五笔";
            foreach (var iL in InputLanguage.InstalledInputLanguages.Cast<InputLanguage>().Where(iL => iL.LayoutName.Contains(inputL)))
            {
                InputLanguage.CurrentInputLanguage = iL;
                break;
            }
            //SetImm(1033,0,IntPtr);
        }

        private void SetImm(int iMode, int iSentence,IntPtr handle)
        {
            var prt = ImmGetContext(handle);
            if (!ImmSetConversionStatus(prt, iMode, iSentence))
            {
                MessageBox.Show("change error");
            }
        }
    }
}
