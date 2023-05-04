using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Entities
{
    public sealed class WeatherEntity
    {
        // 完全コンストラクタパターン
        public WeatherEntity(
            int areaId,
            DateTime dateTime,
            int condition,
            float temperature)
        {
            AreaId = areaId;
            DataDate= dateTime;
            Conditions= condition;
            Temperature= temperature;
        }

        public int AreaId { get; }
        public DateTime DataDate { get; }
        public int Conditions { get; }
        public float Temperature { get; }
    }
}
