using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;
using DDD.Infrastructure.MySQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDWinForm.ViewModels
{
    public class WeatherLatestViewModel : ViewModelBase
    {
        private IWeatherRepository _weather;
        public WeatherLatestViewModel() : this(new WeatherMySQL())
        {

        }
        public WeatherLatestViewModel(IWeatherRepository weather)
        {
            _weather= weather;
        }

        private string _areaIdText = string.Empty;
        public string AreaIdText
        {
            get { return _areaIdText; }
            set
            {
                SetProperty(ref _areaIdText, value);
            }
        }

        private string _dataDateText = string.Empty;
        public string DataDateText
        {
            get { return _dataDateText; }
            set
            {
                SetProperty(ref _dataDateText, value);
            }
        }

        private string _conditionsText = string.Empty;
        public string ConditionsText
        {
            get { return _conditionsText; }
            set
            {
                SetProperty(ref _conditionsText, value);
            }
        }

        private string _temperatureText = string.Empty;
        public string TemperatureText
        {
            get { return _temperatureText; }
            set
            {
                SetProperty(ref _temperatureText, value);
            }
        }

        public void Search()
        {
            WeatherEntity entity = _weather.GetLatest(Convert.ToInt32(AreaIdText));
            if (entity != null)
            {
                DataDateText = entity.DataDate.ToString();
                ConditionsText = entity.Conditions.displayValue;
                TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;
            }
            //OnPropertyChanged("");
        }
    }
}
