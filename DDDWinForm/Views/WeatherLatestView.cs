using DDDWinForm.Common;
using DDDWinForm.Data;
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
        }

        private void LatestBtn_Click(object sender, EventArgs e)
        {
            //DataTable dt = WeatherMySQL.GetLatest(Convert.ToInt32(AreaIdTextBox.Text));
            //if (dt.Rows.Count > 0)
            //{
            //    DataDateLabel.Text = dt.Rows[0]["DataDate"].ToString();
            //    ConditionLabel.Text = dt.Rows[0]["Conditions"].ToString();
                //TemperatureLabel.Text = CommonFunc.RoundString(
                //    Convert.ToSingle(dt.Rows[0]["Temperature"]),
                //    CommonConst.TemperatureDecimalPoint)
                //    + CommonConst.TemperatureUnitName;
            //}
        }
    }
}
