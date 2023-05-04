using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDWinForm.Common
{
    public static class CommonFunc
    {
        public static string RoundString(float value, int decimalPoint)
        {
            var temp = Convert.ToSingle(Math.Round(value, decimalPoint));
            return temp.ToString("F" + decimalPoint);
        }
    }
}
