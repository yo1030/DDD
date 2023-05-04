using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ValueObjects
{
    public sealed class Conditions : ValueObject<Conditions>
    {
        /// <summary>
        /// 不明
        /// </summary>
        public static readonly Conditions None = new Conditions(0);
        /// <summary>
        /// 晴れ
        /// </summary>
        public static readonly Conditions Sunny = new Conditions(1);
        /// <summary>
        /// 曇り
        /// </summary>
        public static readonly Conditions Cloudy = new Conditions(2);
        /// <summary>
        /// 雨
        /// </summary>
        public static readonly Conditions Rain = new Conditions(3);
        public Conditions(int value)
        {
            Value = value;
        }
        public int Value { get; }
        public string displayValue
        {
            get
            {
                if (this == Sunny)
                {
                    return "晴れ";
                }
                if (this == Cloudy)
                {
                    return "曇り";
                }
                if (this == Rain)
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
