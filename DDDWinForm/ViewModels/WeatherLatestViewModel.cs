﻿using DDD.Domain.Entities;
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
        private IAreasRepository _areas;
        public WeatherLatestViewModel() : this(
            new WeatherMySQL(), new AreasMySQL())
        {

        }
        public WeatherLatestViewModel(
            IWeatherRepository weather,
            IAreasRepository areas)
        {
            _weather = weather;
            _areas = areas;

            foreach(var area in _areas.GetData())
            {
                Areas.Add(new AreaEntity(area.AreaId, area.AreaName));
            }
        }

        private object _selectedAreaId;
        public object SelectedAreaId
        {
            get { return _selectedAreaId; }
            set
            {
                SetProperty(ref _selectedAreaId, value);
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

        public BindingList<AreaEntity> Areas { get; set; }
        = new BindingList<AreaEntity>();

        public void Search()
        {
            WeatherEntity entity = _weather.GetLatest(Convert.ToInt32(_selectedAreaId));
            if (entity == null)
            {
                DataDateText = String.Empty;
                ConditionsText = String.Empty;
                TemperatureText = String.Empty;
            }
            else
            {
                DataDateText = entity.DataDate.ToString();
                ConditionsText = entity.Conditions.displayValue;
                TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;
            }
            //OnPropertyChanged("");
        }
    }
}
