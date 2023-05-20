using DDDWinForm.ViewModels;
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
            this.AreaIdTextBox.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.AreaIdText));
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
    }
}
