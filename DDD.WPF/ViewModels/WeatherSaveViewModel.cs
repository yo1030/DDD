using DDD.Domain.Entities;
using DDD.Domain.Helpers;
using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;
using DDD.Infrastructure.MySQL;
using DDD.WPF.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DDD.WPF.ViewModels
{
    public class WeatherSaveViewModel : ViewModelBase, IDialogAware
    {
        private IWeatherRepository _weather;
        private IAreasRepository _areasRepository;
        private IMessageService _messageService;
        public WeatherSaveViewModel()
            : this(new WeatherMySQL(), new AreasMySQL(), new MessageService())
        {
        }
        public WeatherSaveViewModel(
            IWeatherRepository weather,
            IAreasRepository areasRepository,
            IMessageService messageService)
        {
            _weather = weather;
            _areasRepository = areasRepository;
            _messageService = messageService;

            DataDateValue = GetDateTime();
            SelectedCondition = Condition.Sunny;
            TemperatureText = string.Empty;

            foreach (var area in _areasRepository.GetData())
            {
                Areas.Add(new AreaEntity(area.AreaId, area.AreaName));
            }

            SaveButton = new DelegateCommand(SaveButtonExecute);
        }

        public string Title => "登録画面";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }

        public object SelectedAreaId { get; set; }
        private AreaEntity _selectedArea;
        public AreaEntity SelectedArea
        {
            get { return _selectedArea; }
            set
            {
                SetProperty(ref _selectedArea, value);
            }
        }

        public DateTime? DataDateValue { get; set; }

        private Condition _selectedCondition;
        public Condition SelectedCondition
        {
            get { return _selectedCondition; }
            set
            {
                SetProperty(ref _selectedCondition, value);
            }
        }

        private string _temperatureText;
        public string TemperatureText
        {
            get { return _temperatureText; }
            set
            {
                SetProperty(ref _temperatureText, value);
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

        private ObservableCollection<Condition> _conditions = new ObservableCollection<Condition>(Condition.ToList());
        public ObservableCollection<Condition> Conditions
        {
            get { return _conditions; }
            set
            {
                SetProperty(ref _conditions, value);
            }
        }

        public string TemperatureUnitName => Temperature.UnitName;

        public DelegateCommand SaveButton { get; }

        private void SaveButtonExecute()
        {
            // 入力チェック
            Guard.IsNull(SelectedArea, "エリアを選択してください");
            Guard.IsNull(DataDateValue, "日時を入力してください");
            float temperature = Guard.IsFloat(TemperatureText, "温度の入力に誤りがあります");

            if (_messageService.Question("保存しますか？") != System.Windows.MessageBoxResult.OK)
            {
                return;
            }

            var entity = new WeatherEntity(
                SelectedArea.AreaId,
                DataDateValue.Value,
                SelectedCondition.Value,
                temperature);

            _weather.Save(entity);

            _messageService.ShowDialog("保存しました");
        }
    }
}
