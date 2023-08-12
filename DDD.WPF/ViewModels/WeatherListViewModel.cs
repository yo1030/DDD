﻿using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.Infrastructure.MySQL;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using WPF.ViewModels;

namespace DDD.WPF.ViewModels
{
    public class WeatherListViewModel : ViewModelBase
    {
        private IWeatherRepository _weather;
        private MainWindowViewModel _mainWindowViewModel;

        public WeatherListViewModel(MainWindowViewModel mainWindowViewModel)
            : this(new WeatherMySQL(), mainWindowViewModel)
        {
        }
        public WeatherListViewModel(
            IWeatherRepository weather,
            MainWindowViewModel mainWindowViewModel)
        {
            _weather = weather;
            _mainWindowViewModel = mainWindowViewModel;

            foreach (var entity in _weather.GetData())
            {
                Weathers.Add(new WeatherListViewModelWeather(entity));
            }
            UpdateButton = new DelegateCommand(UpdateButtonExecute);
            DataGridSelectionChanged = new DelegateCommand(DataGridSelectionChangedExecute);
            DataGridMouseDoubleClick = new DelegateCommand(DataGridMouseDoubleClickExecute);
        }

        private ObservableCollection<WeatherListViewModelWeather> _weathers = new ObservableCollection<WeatherListViewModelWeather>();
        public ObservableCollection<WeatherListViewModelWeather> Weathers
        {
            get { return _weathers; }
            set
            {
                SetProperty(ref _weathers, value);
            }
        }

        //SelectedWeather
        private WeatherListViewModelWeather _selectedWeather;
        public WeatherListViewModelWeather SelectedWeather
        {
            get { return _selectedWeather; }
            set { SetProperty(ref _selectedWeather, value); }
        }

        public DelegateCommand UpdateButton { get; }
        public DelegateCommand DataGridSelectionChanged { get; }
        public DelegateCommand DataGridMouseDoubleClick { get; }

        private void UpdateButtonExecute()
        {
            _mainWindowViewModel.StatusLabel = "検索しました";
        }

        private void DataGridSelectionChangedExecute()
        {

        }

        private void DataGridMouseDoubleClickExecute()
        {

        }
    }
}
