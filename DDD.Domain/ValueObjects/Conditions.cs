using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ValueObjects
{
    public sealed class Conditions : ValueObject<Conditions>
    {
        public Conditions(int value)
        {
            Value = value;
        }
        public int Value { get; }
        public string displayValue
        {
            get
            {
                if (Value == 1)
                {
                    return "晴れ";
                }
                if (Value == 2)
                {
                    return "曇り";
                }
                if (Value == 3)
                {
                    return "雨";
                }
                return "不明";
            }
        }
        protected override bool EqualsCore(Conditions other)
        {
            return Value == other.Value;
        }
    }
}
