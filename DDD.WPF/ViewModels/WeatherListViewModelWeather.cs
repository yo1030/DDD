using DDD.Domain.Entities;
using System;

namespace WPF.ViewModels
{
    public sealed class WeatherListViewModelWeather
    {
        private WeatherEntity _entity;
        public WeatherListViewModelWeather(WeatherEntity entity)
        {
            _entity = entity;
        }

        public string AreaId => _entity.AreaId.DisplayValue;
        public string AreaName => _entity.AreaName;
        public string DataDate => _entity.DataDate.ToString();
        public string Condition => _entity.Conditions.DisplayValue;
        public string Temperature => _entity.Temperature.DisplayValueWithUnitSpace;
    }
}
