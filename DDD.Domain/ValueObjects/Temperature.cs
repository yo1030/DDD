using DDDWinForm.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ValueObjects
{
    public sealed class Temperature
    {
        public const string UnitName = "℃";
        public const int DecimalPoint = 2;
        public Temperature(float value)
        {
            Value = value;
        }
        public float Value { get; }
        public string DisplayValue {
            get
            {
                return CommonFunc.RoundString(Value, DecimalPoint) + UnitName;
            }
        }

        public override bool Equals(object obj)
        {
            Temperature vo = obj as Temperature;
            if (vo == null)
            {
                return false;
            }
            return vo.Value == Value;
        }

        public static bool operator == (Temperature x, Temperature y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(Temperature x, Temperature y)
        {
            return !Equals(x, y);
        }
    }
}
