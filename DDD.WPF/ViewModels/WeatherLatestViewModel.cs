using DDD.Domain.Entities;
using DDD.Domain.Exceptions;
using DDD.Domain.Repositories;
using DDD.Infrastructure.MySQL;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DDD.WPF.ViewModels
{
    public class WeatherLatestViewModel : ViewModelBase
    {
        private IWeatherRepository _weather;
        private IAreasRepository _areasRepository;
        public WeatherLatestViewModel() : this(
            new WeatherMySQL(), new AreasMySQL())
        {

        }
        public WeatherLatestViewModel(
            IWeatherRepository weather,
            IAreasRepository areasRepository)
        {
            _weather = weather;
            _areasRepository = areasRepository;

            foreach (var area in _areasRepository.GetData())
            {
                Areas.Add(new AreaEntity(area.AreaId, area.AreaName));
            }

            LatestButton = new DelegateCommand(LatestButtonExecute);
        }

        private AreaEntity _selectedArea;
        public AreaEntity SelectedArea
        {
            get { return _selectedArea; }
            set
            {
                SetProperty(ref _selectedArea, value);
            }
        }

        private ObservableCollection<AreaEntity> _areas = new ObservableCollection<AreaEntity>();
        public ObservableCollection<AreaEntity> Areas
        {
            get { return _areas; }
            set
            {
                SetProperty(ref _areas, value);
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

        public DelegateCommand LatestButton { get; }


        private void LatestButtonExecute()
        {
            if (SelectedArea == null)
            {
                throw new InputException("地域を選択してください");
            }
            WeatherEntity entity = _weather.GetLatest(SelectedArea.AreaId);
            if (entity == null)
            {
                DataDateText = String.Empty;
                ConditionsText = String.Empty;
                TemperatureText = String.Empty;
            }
            else
            {
                DataDateText = entity.DataDate.ToString();
                ConditionsText = entity.Conditions.DisplayValue;
                TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;
            }
            //OnPropertyChanged("");
        }
    }
}
