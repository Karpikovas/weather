using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetWeather_Click(object sender, EventArgs e)
        {
            string key = "79214423-acb6-4c5f-99e0-3f0b5db84b86";
            WeatherLocations.LocationsSoapClient locClient = new WeatherLocations.LocationsSoapClient();
            WeatherLocations.LocationInfoFullResult response = locClient.FindByNameFull(key, txtCity.Text, 1, "RU");
            try
            {
                int cityId = response.data[0].id;

                WeatherData.WeatherSoapClient client = new WeatherData.WeatherSoapClient();
                WeatherData.HHForecastResult weather = client.GetHHForecast(key, cityId);
                txtWeather.Text = "Температура днём: " + string.Format("{0:0.#}", weather.data[0].tod) + "°С" + Environment.NewLine;
                txtWeather.Text += "Температура ночью: " + string.Format("{0:0.#}", weather.data[0].t) + "°С" + Environment.NewLine;
                txtWeather.Text += "Давление: " + string.Format("{0:0}", weather.data[0].p) + Environment.NewLine;
                txtWeather.Text += "Влажность: " + weather.data[0].humidity.ToString();

            } catch (Exception ex) {
                txtWeather.Text = "Город не найден";
            }
        }
    }
}
