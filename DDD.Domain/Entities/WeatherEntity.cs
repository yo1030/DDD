using DDD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            Conditions= new Conditions(condition);
            Temperature= new Temperature(temperature);
        }

        public int AreaId { get; }
        public DateTime DataDate { get; }
        public Conditions Conditions { get; }
        public Temperature Temperature { get; }

        public bool IsHeatWeave()
        {
            if(Conditions == Conditions.Sunny)
            {
                if (Temperature.Value > 30)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsOK()
        {
            if (DataDate < DateTime.Now.AddMonths(-1))
            {
                if (Temperature.Value < 10)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
