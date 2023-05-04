using DDDWinForm.Common;
using DDDWinForm.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDDWinForm
{
    public partial class WeatherLatestView : Form
    {
        public WeatherLatestView()
        {
            InitializeComponent();
        }

        private void LatestBtn_Click(object sender, EventArgs e)
        {
            DataTable dt = WeatherMySQL.GetLatest(Convert.ToInt32(AreaIdTextBox.Text));
            if (dt.Rows.Count > 0)
            {
                DataDateLabel.Text = dt.Rows[0]["DataDate"].ToString();
                ConditionLabel.Text = dt.Rows[0]["Conditions"].ToString();
                //TemperatureLabel.Text = CommonFunc.RoundString(
                //    Convert.ToSingle(dt.Rows[0]["Temperature"]),
                //    CommonConst.TemperatureDecimalPoint)
                //    + CommonConst.TemperatureUnitName;
            }
        }
    }
}
