using DDD.Domain.Entities;
using DDD.Domain.ValueObjects;
using DDDWinForm.ViewModels;
using System;
using System.Windows.Forms;

namespace DDDWinForm.Views
{
    public partial class WeatherSaveView : Form
    {
        private WeatherSaveViewModel _viewModel
            = new WeatherSaveViewModel();
        public WeatherSaveView()
        {
            InitializeComponent();

            this.AreaIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.AreaIdComboBox.DataBindings.Add(
                "SelectedValue", _viewModel, nameof(_viewModel.SelectedAreaId));
            this.AreaIdComboBox.DataBindings.Add(
                "DataSource", _viewModel, nameof(_viewModel.Areas));
            this.AreaIdComboBox.ValueMember = nameof(AreaEntity.AreaId);
            this.AreaIdComboBox.DisplayMember = nameof(AreaEntity.AreaName);

            DateTimeTextBox.DataBindings.Add(
                "Value", _viewModel, nameof(_viewModel.DataDateValue));


            this.ConditionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ConditionComboBox.DataBindings.Add(
                "SelectedValue", _viewModel, nameof(_viewModel.SelectedCondition));
            this.ConditionComboBox.DataBindings.Add(
                "DataSource", _viewModel, nameof(_viewModel.Conditions_));
            this.ConditionComboBox.ValueMember = nameof(Conditions.Value);
            this.ConditionComboBox.DisplayMember = nameof(Conditions.displayValue);

            TemperatureTextBox.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.TemperatureText));

            UnitLabel.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.TemperatureUnitName));

            SaveButton.Click += (_, __) =>
            {
                try
                {
                    _viewModel.Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            };
        }
    }
}
