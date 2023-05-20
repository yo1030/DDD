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
    public class WeatherLatestViewModel : INotifyPropertyChanged
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
                if (_areaIdText == value)
                {
                    return;
                }
                _areaIdText = value;
                OnPropertyChanged(nameof(AreaIdText));
            }
        }

        private string _dataDateText = string.Empty;
        public string DataDateText
        {
            get { return _dataDateText; }
            set
            {
                if (_dataDateText == value)
                {
                    return;
                }
                _dataDateText = value;
                OnPropertyChanged(nameof(DataDateText));
            }
        }

        private string _conditionsText = string.Empty;
        public string ConditionsText
        {
            get { return _conditionsText; }
            set
            {
                if (_conditionsText == value)
                {
                    return;
                }
                _conditionsText = value;
                OnPropertyChanged(nameof(ConditionsText));
            }
        }

        private string _temperatureText = string.Empty;
        public string TemperatureText
        {
            get { return _temperatureText; }
            set
            {
                if (_temperatureText == value)
                {
                    return;
                }
                _temperatureText = value;
                OnPropertyChanged(nameof(TemperatureText));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

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

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
