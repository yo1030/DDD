using DDD.Domain.Entities;
using DDDWinForm.ViewModels;
using DDDWinForm.Views;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DDDWinForm
{
    public partial class WeatherLatestView : Form
    {
        private WeatherLatestViewModel _viewModel = new WeatherLatestViewModel();
        public WeatherLatestView()
        {
            InitializeComponent();

            this.AreasComboBox.DropDownStyle= ComboBoxStyle.DropDownList;
            this.AreasComboBox.DataBindings.Add(
                "SelectedValue", _viewModel, nameof(_viewModel.SelectedAreaId));
            this.AreasComboBox.DataBindings.Add(
                "DataSource", _viewModel, nameof(_viewModel.Areas));
            this.AreasComboBox.ValueMember = nameof(AreaEntity.AreaId);
            this.AreasComboBox.DisplayMember = nameof(AreaEntity.AreaName);

            this.DataDateLabel.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.DataDateText));
            this.ConditionLabel.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.ConditionsText));
            this.TemperatureLabel.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.TemperatureText));
        }

        private void LatestBtn_Click(object sender, EventArgs e)
        {
            _viewModel.Search();
        }

        private void List_Click(object sender, EventArgs e)
        {
            using(Form f = new WeatherListView())
            {
                f.ShowDialog();
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            using (Form f = new WeatherSaveView())
            {
                f.ShowDialog();
            }
        }
    }
}
