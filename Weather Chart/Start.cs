using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Weather_Chart
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
            try
            {
                string key = ConfigurationManager.AppSettings["API-Key"];
                string lang = ConfigurationManager.AppSettings["Language"];
                string city = ConfigurationManager.AppSettings["City"];
                if (key == "" || city == "")
                {
                    MessageBox.Show("Edit the \"App.config\"-File", "Bad Configuration");
                    string path = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
                    try
                    {
                        System.Diagnostics.Process.Start(path);
                    }
                    catch (Exception es) // throws error if e.g. doesnt find file
                    {
                        MessageBox.Show("Path: " + path + "\n" + "ERROR: " + es);
                    }
                    this.Close();
                }
                SetValues(city, lang, key);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error occured");
            }
        }
        public void SetValues(string city, string lang, string key)
        {
            string api = "https://api.openweathermap.org/data/2.5/forecast?q=" + city + "&lang=" + lang + "&appid=" + key + "&mode=xml&units=metric";
            // System.Diagnostics.Process.Start(api);
            string temperatur = "Temperatur in °C";
            string rain = "Rain in mm";
            try
            {
                // Create an instance of the XmlSerializer.
                XmlSerializer serializer = new XmlSerializer(typeof(Weatherdata));

                // Declare an object variable of the type to be deserialized.
                Weatherdata i;
                WebRequest request = WebRequest.Create(api);
                WebResponse response = request.GetResponse();
                using (Stream reader = response.GetResponseStream())
                {
                    // Call the Deserialize method to restore the object's state.
                    i = (Weatherdata)serializer.Deserialize(reader);
                    const int x_margin = 0;
                    const int y_margin = 2;
                    city_txt.Text = i.Location.Name;
                    Size size = TextRenderer.MeasureText(city_txt.Text, city_txt.Font);
                    city_txt.ClientSize =
                        new Size(size.Width + x_margin, size.Height + y_margin);
                    chart1.Series.Clear();
                    chart1.Series.Add(temperatur);
                    chart1.Series.Add(rain);
                    chart1.ChartAreas[0].AxisY.IsStartedFromZero = true;
                    chart1.ChartAreas[0].AxisY.Maximum = double.NaN;
                    chart1.ChartAreas[0].AxisY.Minimum = double.NaN;
                    chart1.ChartAreas[0].AxisX.Maximum = double.NaN;
                    chart1.ChartAreas[0].AxisX.Maximum = double.NaN;
                    chart1.ChartAreas[0].AxisX.Interval = 5;
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[0].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[0].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[0].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[1].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[1].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[1].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[2].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[2].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[2].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[3].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[3].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[3].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[4].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[4].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[4].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[5].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[5].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[5].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[6].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[6].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[6].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[7].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[7].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[7].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[8].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[8].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[8].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[9].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[9].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[9].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[10].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[10].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[10].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[11].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[11].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[11].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[12].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[12].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[12].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[13].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[13].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[13].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[14].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[14].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[14].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[15].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[15].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[15].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[16].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[16].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[16].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[17].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[17].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[17].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[18].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[18].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[18].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[19].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[19].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[19].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[20].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[20].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[20].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[21].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[21].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[21].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[22].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[22].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[22].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[23].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[23].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[23].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[24].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[24].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[24].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[25].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[25].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[25].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[26].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[26].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[26].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[27].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[27].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[27].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[28].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[28].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[28].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[29].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[29].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[29].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[30].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[30].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[30].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[31].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[31].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[31].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[32].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[32].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[32].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[33].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[33].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[33].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[34].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[34].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[34].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[35].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[35].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[35].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[36].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[36].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[36].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[37].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[37].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[37].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[38].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[38].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[38].Temperature.Value);
                    chart1.Series[temperatur].Points.AddXY(DateTime.Parse(i.Forecast.Time[39].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[39].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[39].Temperature.Value);
                    chart1.Series[temperatur].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[0].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[0].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[0].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[1].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[1].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[1].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[2].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[2].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[2].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[3].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[3].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[3].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[4].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[4].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[4].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[5].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[5].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[5].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[6].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[6].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[6].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[7].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[7].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[7].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[8].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[8].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[8].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[9].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[9].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[9].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[10].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[10].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[10].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[11].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[11].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[11].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[12].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[12].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[12].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[13].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[13].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[13].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[14].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[14].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[14].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[15].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[15].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[15].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[16].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[16].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[16].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[17].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[17].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[17].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[18].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[18].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[18].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[19].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[19].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[19].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[20].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[20].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[20].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[21].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[21].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[21].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[22].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[22].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[22].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[23].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[23].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[23].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[24].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[24].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[24].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[25].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[25].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[25].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[26].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[26].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[26].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[27].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[27].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[27].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[28].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[28].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[28].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[29].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[29].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[29].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[30].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[30].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[30].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[31].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[31].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[31].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[32].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[32].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[32].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[33].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[33].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[33].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[34].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[34].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[34].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[35].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[35].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[35].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[36].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[36].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[36].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[37].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[37].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[37].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[38].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[38].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[38].Precipitation.Value);
                    chart1.Series[rain].Points.AddXY(DateTime.Parse(i.Forecast.Time[39].From, null, DateTimeStyles.AssumeUniversal).ToString("g") + "\n" + DateTime.Parse(i.Forecast.Time[39].To, null, DateTimeStyles.AssumeUniversal).ToString("g"), i.Forecast.Time[39].Precipitation.Value);
                    chart1.Series[rain].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
                    chart1.ChartAreas[0].RecalculateAxesScale();
                    chart1.Update();
                    area_radio.Checked = true;
                    line_radio.Checked = false;
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.ToString(), "WebException");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception");
                this.Close();
            }
        }

        private void chart1_MouseHover(object sender, EventArgs e)
        {
            string temperatur = "Temperatur in °C";
            string rain = "Rain in mm";
            chart1.Series[temperatur].ToolTip = "\nDate: #VALX \nTemperatur: #VAL°C";
            chart1.Series[rain].ToolTip = "\nDate: #VALX \nRain: #VALmm";
        }

        private void area_radio_CheckedChanged(object sender, EventArgs e)
        {
            string temperatur = "Temperatur in °C";
            string rain = "Rain in mm";
            if (area_radio.Checked) 
            {
                chart1.Series[temperatur].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
                chart1.Series[rain].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
                chart1.ChartAreas[0].RecalculateAxesScale();
                chart1.Update();
            }
            else if (line_radio.Checked)
            {
                chart1.Series[temperatur].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.Series[rain].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.ChartAreas[0].RecalculateAxesScale();
                chart1.Update();
            }
            else if (step_radio.Checked)
            {
                chart1.Series[temperatur].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
                chart1.Series[rain].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
                chart1.ChartAreas[0].RecalculateAxesScale();
                chart1.Update();
            }
        }

        private void line_radio_CheckedChanged(object sender, EventArgs e)
        {
            string temperatur = "Temperatur in °C";
            string rain = "Rain in mm";
            if (area_radio.Checked)
            {
                chart1.Series[temperatur].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
                chart1.Series[rain].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
                chart1.ChartAreas[0].RecalculateAxesScale();
                chart1.Update();
            }
            else if (line_radio.Checked)
            {
                chart1.Series[temperatur].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.Series[rain].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.ChartAreas[0].RecalculateAxesScale();
                chart1.Update();
            }
            else if (step_radio.Checked)
            {
                chart1.Series[temperatur].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
                chart1.Series[rain].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
                chart1.ChartAreas[0].RecalculateAxesScale();
                chart1.Update();
            }
        }
    }
    public class Weather_Chart_Values
    {
        public int Id { get; set; }

        public string Range { get; set; }

        public string Weather { get; set; }

        public string Precipitation { get; set; }

        public string Wind_Speed { get; set; }

        public string Wind_Direction { get; set; }

        public string Temperature { get; set; }

        public string Feels_Like { get; set; }

        public string Humidity { get; set; }

        public string Clouds { get; set; }
    }
    [XmlRoot(ElementName = "location")]
    public class Location
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "meta")]
    public class Meta
    {
        [XmlElement(ElementName = "lastupdate")]
        public string Lastupdate { get; set; }
        [XmlElement(ElementName = "calctime")]
        public string Calctime { get; set; }
        [XmlElement(ElementName = "nextupdate")]
        public string Nextupdate { get; set; }
    }

    [XmlRoot(ElementName = "sun")]
    public class Sun
    {
        [XmlAttribute(AttributeName = "rise")]
        public string Rise { get; set; }
        [XmlAttribute(AttributeName = "set")]
        public string Set { get; set; }
    }

    [XmlRoot(ElementName = "symbol")]
    public class Symbol
    {
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "var")]
        public string Var { get; set; }
    }

    [XmlRoot(ElementName = "precipitation")]
    public class Precipitation
    {
        [XmlAttribute(AttributeName = "probability")]
        public string Probability { get; set; }
        [XmlAttribute(AttributeName = "unit")]
        public string Unit { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "windDirection")]
    public class WindDirection
    {
        [XmlAttribute(AttributeName = "deg")]
        public string Deg { get; set; }
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "windSpeed")]
    public class WindSpeed
    {
        [XmlAttribute(AttributeName = "mps")]
        public string Mps { get; set; }
        [XmlAttribute(AttributeName = "unit")]
        public string Unit { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "temperature")]
    public class Temperature
    {
        [XmlAttribute(AttributeName = "unit")]
        public string Unit { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "min")]
        public string Min { get; set; }
        [XmlAttribute(AttributeName = "max")]
        public string Max { get; set; }
    }

    [XmlRoot(ElementName = "feels_like")]
    public class Feels_like
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "unit")]
        public string Unit { get; set; }
    }

    [XmlRoot(ElementName = "pressure")]
    public class Pressure
    {
        [XmlAttribute(AttributeName = "unit")]
        public string Unit { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "humidity")]
    public class Humidity
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "unit")]
        public string Unit { get; set; }
    }

    [XmlRoot(ElementName = "clouds")]
    public class Clouds
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "all")]
        public string All { get; set; }
        [XmlAttribute(AttributeName = "unit")]
        public string Unit { get; set; }
    }

    [XmlRoot(ElementName = "visibility")]
#pragma warning disable CS0108
    public class Visibility
#pragma warning restore CS0108
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "time")]
    public class Time
    {
        [XmlElement(ElementName = "symbol")]
        public Symbol Symbol { get; set; }
        [XmlElement(ElementName = "precipitation")]
        public Precipitation Precipitation { get; set; }
        [XmlElement(ElementName = "windDirection")]
        public WindDirection WindDirection { get; set; }
        [XmlElement(ElementName = "windSpeed")]
        public WindSpeed WindSpeed { get; set; }
        [XmlElement(ElementName = "temperature")]
        public Temperature Temperature { get; set; }
        [XmlElement(ElementName = "feels_like")]
        public Feels_like Feels_like { get; set; }
        [XmlElement(ElementName = "pressure")]
        public Pressure Pressure { get; set; }
        [XmlElement(ElementName = "humidity")]
        public Humidity Humidity { get; set; }
        [XmlElement(ElementName = "clouds")]
        public Clouds Clouds { get; set; }
        [XmlElement(ElementName = "visibility")]
        public Visibility Visibility { get; set; }
        [XmlAttribute(AttributeName = "from")]
        public string From { get; set; }
        [XmlAttribute(AttributeName = "to")]
        public string To { get; set; }
    }

    [XmlRoot(ElementName = "forecast")]
    public class Forecast
    {
        [XmlElement(ElementName = "time")]
        public List<Time> Time { get; set; }
    }

    [XmlRoot(ElementName = "weatherdata")]
    public class Weatherdata
    {
        [XmlElement(ElementName = "location")]
        public Location Location { get; set; }
        [XmlElement(ElementName = "credit")]
        public string Credit { get; set; }
        [XmlElement(ElementName = "meta")]
        public Meta Meta { get; set; }
        [XmlElement(ElementName = "sun")]
        public Sun Sun { get; set; }
        [XmlElement(ElementName = "forecast")]
        public Forecast Forecast { get; set; }
    }
}
