using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net;
using System.Windows;
using System.Xml.Serialization;

namespace Weather_GUI
{
    ///List<User> users = new List<User>();
    //users.Add(new User() { Id = 1, Name = "09.12.2020 21:45\n10.12.2020 00:45", Temperature = "Value: 5°C Max: 5*C Min: 8*C", Clouds = "55 - Bedeckt" });
    //users.Add(new User() { Id = 2, Name = "Jane Doe", Temperature = "8°C", Clouds = "Windy" });
    //users.Add(new User() { Id = 3, Name = "Sammy Doe", Temperature = "-3°C", Clouds = "Windy" });
    //Weather.ItemsSource = users;
    public partial class MainWindow : Window
    {
        public MainWindow()
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
                    var path = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
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
                DeserializeWeatherForecast(city, lang, key);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),"Error occured");
            }
        }
        private void DeserializeWeatherForecast(string city, string lang, string key)
        {
            Console.WriteLine("Getting Weather Forecast Data");
            string api = "https://api.openweathermap.org/data/2.5/forecast?q=" + city + "&lang=" + lang + "&appid=" + key + "&mode=xml&units=metric";
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
                    List<Weather_Grid_Entrys> gui = new List<Weather_Grid_Entrys>
                    {
                        // 40 Times
                        new Weather_Grid_Entrys() { Id = 0, Range = DateTime.Parse(i.Forecast.Time[0].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[0].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[0].Symbol.Name, Precipitation = i.Forecast.Time[0].Precipitation.Value + "mm " + i.Forecast.Time[0].Precipitation.Type + "\nProbability: " + i.Forecast.Time[0].Precipitation.Probability, Wind_Speed = i.Forecast.Time[0].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[0].WindSpeed.Name, Wind_Direction = i.Forecast.Time[0].WindDirection.Deg + "°\n" + i.Forecast.Time[0].WindDirection.Name, Temperature = i.Forecast.Time[0].Temperature.Value + "°C\nMin: " + i.Forecast.Time[0].Temperature.Min + "°C Max: " + i.Forecast.Time[0].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[0].Feels_like.Value, Humidity = i.Forecast.Time[0].Humidity.Value + "%", Clouds =  i.Forecast.Time[0].Clouds.All + "%\n" + i.Forecast.Time[0].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 1, Range = DateTime.Parse(i.Forecast.Time[1].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[1].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[1].Symbol.Name, Precipitation = i.Forecast.Time[1].Precipitation.Value + "mm " + i.Forecast.Time[1].Precipitation.Type + "\nProbability: " + i.Forecast.Time[1].Precipitation.Probability, Wind_Speed = i.Forecast.Time[1].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[1].WindSpeed.Name, Wind_Direction = i.Forecast.Time[1].WindDirection.Deg + "°\n" + i.Forecast.Time[1].WindDirection.Name, Temperature = i.Forecast.Time[1].Temperature.Value + "°C\nMin: " + i.Forecast.Time[1].Temperature.Min + "°C Max: " + i.Forecast.Time[1].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[1].Feels_like.Value, Humidity = i.Forecast.Time[1].Humidity.Value + "%", Clouds =  i.Forecast.Time[1].Clouds.All + "%\n" + i.Forecast.Time[1].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 2, Range = DateTime.Parse(i.Forecast.Time[2].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[2].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[2].Symbol.Name, Precipitation = i.Forecast.Time[2].Precipitation.Value + "mm " + i.Forecast.Time[2].Precipitation.Type + "\nProbability: " + i.Forecast.Time[2].Precipitation.Probability, Wind_Speed = i.Forecast.Time[2].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[2].WindSpeed.Name, Wind_Direction = i.Forecast.Time[2].WindDirection.Deg + "°\n" + i.Forecast.Time[2].WindDirection.Name, Temperature = i.Forecast.Time[2].Temperature.Value + "°C\nMin: " + i.Forecast.Time[2].Temperature.Min + "°C Max: " + i.Forecast.Time[2].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[2].Feels_like.Value, Humidity = i.Forecast.Time[2].Humidity.Value + "%", Clouds =  i.Forecast.Time[2].Clouds.All + "%\n" + i.Forecast.Time[2].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 3, Range = DateTime.Parse(i.Forecast.Time[3].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[3].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[3].Symbol.Name, Precipitation = i.Forecast.Time[3].Precipitation.Value + "mm " + i.Forecast.Time[3].Precipitation.Type + "\nProbability: " + i.Forecast.Time[3].Precipitation.Probability, Wind_Speed = i.Forecast.Time[3].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[3].WindSpeed.Name, Wind_Direction = i.Forecast.Time[3].WindDirection.Deg + "°\n" + i.Forecast.Time[3].WindDirection.Name, Temperature = i.Forecast.Time[3].Temperature.Value + "°C\nMin: " + i.Forecast.Time[3].Temperature.Min + "°C Max: " + i.Forecast.Time[3].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[3].Feels_like.Value, Humidity = i.Forecast.Time[3].Humidity.Value + "%", Clouds =  i.Forecast.Time[3].Clouds.All + "%\n" + i.Forecast.Time[3].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 4, Range = DateTime.Parse(i.Forecast.Time[4].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[4].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[4].Symbol.Name, Precipitation = i.Forecast.Time[4].Precipitation.Value + "mm " + i.Forecast.Time[4].Precipitation.Type + "\nProbability: " + i.Forecast.Time[4].Precipitation.Probability, Wind_Speed = i.Forecast.Time[4].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[4].WindSpeed.Name, Wind_Direction = i.Forecast.Time[4].WindDirection.Deg + "°\n" + i.Forecast.Time[4].WindDirection.Name, Temperature = i.Forecast.Time[4].Temperature.Value + "°C\nMin: " + i.Forecast.Time[4].Temperature.Min + "°C Max: " + i.Forecast.Time[4].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[4].Feels_like.Value, Humidity = i.Forecast.Time[4].Humidity.Value + "%", Clouds =  i.Forecast.Time[4].Clouds.All + "%\n" + i.Forecast.Time[4].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 5, Range = DateTime.Parse(i.Forecast.Time[5].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[5].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[5].Symbol.Name, Precipitation = i.Forecast.Time[5].Precipitation.Value + "mm " + i.Forecast.Time[5].Precipitation.Type + "\nProbability: " + i.Forecast.Time[5].Precipitation.Probability, Wind_Speed = i.Forecast.Time[5].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[5].WindSpeed.Name, Wind_Direction = i.Forecast.Time[5].WindDirection.Deg + "°\n" + i.Forecast.Time[5].WindDirection.Name, Temperature = i.Forecast.Time[5].Temperature.Value + "°C\nMin: " + i.Forecast.Time[5].Temperature.Min + "°C Max: " + i.Forecast.Time[5].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[5].Feels_like.Value, Humidity = i.Forecast.Time[5].Humidity.Value + "%", Clouds =  i.Forecast.Time[5].Clouds.All + "%\n" + i.Forecast.Time[5].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 6, Range = DateTime.Parse(i.Forecast.Time[6].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[6].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[6].Symbol.Name, Precipitation = i.Forecast.Time[6].Precipitation.Value + "mm " + i.Forecast.Time[6].Precipitation.Type + "\nProbability: " + i.Forecast.Time[6].Precipitation.Probability, Wind_Speed = i.Forecast.Time[6].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[6].WindSpeed.Name, Wind_Direction = i.Forecast.Time[6].WindDirection.Deg + "°\n" + i.Forecast.Time[6].WindDirection.Name, Temperature = i.Forecast.Time[6].Temperature.Value + "°C\nMin: " + i.Forecast.Time[6].Temperature.Min + "°C Max: " + i.Forecast.Time[6].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[6].Feels_like.Value, Humidity = i.Forecast.Time[6].Humidity.Value + "%", Clouds =  i.Forecast.Time[6].Clouds.All + "%\n" + i.Forecast.Time[6].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 7, Range = DateTime.Parse(i.Forecast.Time[7].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[7].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[7].Symbol.Name, Precipitation = i.Forecast.Time[7].Precipitation.Value + "mm " + i.Forecast.Time[7].Precipitation.Type + "\nProbability: " + i.Forecast.Time[7].Precipitation.Probability, Wind_Speed = i.Forecast.Time[7].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[7].WindSpeed.Name, Wind_Direction = i.Forecast.Time[7].WindDirection.Deg + "°\n" + i.Forecast.Time[7].WindDirection.Name, Temperature = i.Forecast.Time[7].Temperature.Value + "°C\nMin: " + i.Forecast.Time[7].Temperature.Min + "°C Max: " + i.Forecast.Time[7].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[7].Feels_like.Value, Humidity = i.Forecast.Time[7].Humidity.Value + "%", Clouds =  i.Forecast.Time[7].Clouds.All + "%\n" + i.Forecast.Time[7].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 8, Range = DateTime.Parse(i.Forecast.Time[8].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[8].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[8].Symbol.Name, Precipitation = i.Forecast.Time[8].Precipitation.Value + "mm " + i.Forecast.Time[8].Precipitation.Type + "\nProbability: " + i.Forecast.Time[8].Precipitation.Probability, Wind_Speed = i.Forecast.Time[8].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[8].WindSpeed.Name, Wind_Direction = i.Forecast.Time[8].WindDirection.Deg + "°\n" + i.Forecast.Time[8].WindDirection.Name, Temperature = i.Forecast.Time[8].Temperature.Value + "°C\nMin: " + i.Forecast.Time[8].Temperature.Min + "°C Max: " + i.Forecast.Time[8].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[8].Feels_like.Value, Humidity = i.Forecast.Time[8].Humidity.Value + "%", Clouds =  i.Forecast.Time[8].Clouds.All + "%\n" + i.Forecast.Time[8].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 9, Range = DateTime.Parse(i.Forecast.Time[9].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[9].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[9].Symbol.Name, Precipitation = i.Forecast.Time[9].Precipitation.Value + "mm " + i.Forecast.Time[9].Precipitation.Type + "\nProbability: " + i.Forecast.Time[9].Precipitation.Probability, Wind_Speed = i.Forecast.Time[9].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[9].WindSpeed.Name, Wind_Direction = i.Forecast.Time[9].WindDirection.Deg + "°\n" + i.Forecast.Time[9].WindDirection.Name, Temperature = i.Forecast.Time[9].Temperature.Value + "°C\nMin: " + i.Forecast.Time[9].Temperature.Min + "°C Max: " + i.Forecast.Time[9].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[9].Feels_like.Value, Humidity = i.Forecast.Time[9].Humidity.Value + "%", Clouds =  i.Forecast.Time[9].Clouds.All + "%\n" + i.Forecast.Time[9].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 10, Range = DateTime.Parse(i.Forecast.Time[10].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[10].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[10].Symbol.Name, Precipitation = i.Forecast.Time[10].Precipitation.Value + "mm " + i.Forecast.Time[10].Precipitation.Type + "\nProbability: " + i.Forecast.Time[10].Precipitation.Probability, Wind_Speed = i.Forecast.Time[10].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[10].WindSpeed.Name, Wind_Direction = i.Forecast.Time[10].WindDirection.Deg + "°\n" + i.Forecast.Time[10].WindDirection.Name, Temperature = i.Forecast.Time[10].Temperature.Value + "°C\nMin: " + i.Forecast.Time[10].Temperature.Min + "°C Max: " + i.Forecast.Time[10].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[10].Feels_like.Value, Humidity = i.Forecast.Time[10].Humidity.Value + "%", Clouds =  i.Forecast.Time[10].Clouds.All + "%\n" + i.Forecast.Time[10].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 11, Range = DateTime.Parse(i.Forecast.Time[11].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[11].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[11].Symbol.Name, Precipitation = i.Forecast.Time[11].Precipitation.Value + "mm " + i.Forecast.Time[11].Precipitation.Type + "\nProbability: " + i.Forecast.Time[11].Precipitation.Probability, Wind_Speed = i.Forecast.Time[11].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[11].WindSpeed.Name, Wind_Direction = i.Forecast.Time[11].WindDirection.Deg + "°\n" + i.Forecast.Time[11].WindDirection.Name, Temperature = i.Forecast.Time[11].Temperature.Value + "°C\nMin: " + i.Forecast.Time[11].Temperature.Min + "°C Max: " + i.Forecast.Time[11].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[11].Feels_like.Value, Humidity = i.Forecast.Time[11].Humidity.Value + "%", Clouds =  i.Forecast.Time[11].Clouds.All + "%\n" + i.Forecast.Time[11].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 12, Range = DateTime.Parse(i.Forecast.Time[12].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[12].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[12].Symbol.Name, Precipitation = i.Forecast.Time[12].Precipitation.Value + "mm " + i.Forecast.Time[12].Precipitation.Type + "\nProbability: " + i.Forecast.Time[12].Precipitation.Probability, Wind_Speed = i.Forecast.Time[12].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[12].WindSpeed.Name, Wind_Direction = i.Forecast.Time[12].WindDirection.Deg + "°\n" + i.Forecast.Time[12].WindDirection.Name, Temperature = i.Forecast.Time[12].Temperature.Value + "°C\nMin: " + i.Forecast.Time[12].Temperature.Min + "°C Max: " + i.Forecast.Time[12].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[12].Feels_like.Value, Humidity = i.Forecast.Time[12].Humidity.Value + "%", Clouds =  i.Forecast.Time[12].Clouds.All + "%\n" + i.Forecast.Time[12].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 13, Range = DateTime.Parse(i.Forecast.Time[13].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[13].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[13].Symbol.Name, Precipitation = i.Forecast.Time[13].Precipitation.Value + "mm " + i.Forecast.Time[13].Precipitation.Type + "\nProbability: " + i.Forecast.Time[13].Precipitation.Probability, Wind_Speed = i.Forecast.Time[13].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[13].WindSpeed.Name, Wind_Direction = i.Forecast.Time[13].WindDirection.Deg + "°\n" + i.Forecast.Time[13].WindDirection.Name, Temperature = i.Forecast.Time[13].Temperature.Value + "°C\nMin: " + i.Forecast.Time[13].Temperature.Min + "°C Max: " + i.Forecast.Time[13].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[13].Feels_like.Value, Humidity = i.Forecast.Time[13].Humidity.Value + "%", Clouds =  i.Forecast.Time[13].Clouds.All + "%\n" + i.Forecast.Time[13].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 14, Range = DateTime.Parse(i.Forecast.Time[14].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[14].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[14].Symbol.Name, Precipitation = i.Forecast.Time[14].Precipitation.Value + "mm " + i.Forecast.Time[14].Precipitation.Type + "\nProbability: " + i.Forecast.Time[14].Precipitation.Probability, Wind_Speed = i.Forecast.Time[14].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[14].WindSpeed.Name, Wind_Direction = i.Forecast.Time[14].WindDirection.Deg + "°\n" + i.Forecast.Time[14].WindDirection.Name, Temperature = i.Forecast.Time[14].Temperature.Value + "°C\nMin: " + i.Forecast.Time[14].Temperature.Min + "°C Max: " + i.Forecast.Time[14].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[14].Feels_like.Value, Humidity = i.Forecast.Time[14].Humidity.Value + "%", Clouds =  i.Forecast.Time[14].Clouds.All + "%\n" + i.Forecast.Time[14].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 15, Range = DateTime.Parse(i.Forecast.Time[15].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[15].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[15].Symbol.Name, Precipitation = i.Forecast.Time[15].Precipitation.Value + "mm " + i.Forecast.Time[15].Precipitation.Type + "\nProbability: " + i.Forecast.Time[15].Precipitation.Probability, Wind_Speed = i.Forecast.Time[15].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[15].WindSpeed.Name, Wind_Direction = i.Forecast.Time[15].WindDirection.Deg + "°\n" + i.Forecast.Time[15].WindDirection.Name, Temperature = i.Forecast.Time[15].Temperature.Value + "°C\nMin: " + i.Forecast.Time[15].Temperature.Min + "°C Max: " + i.Forecast.Time[15].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[15].Feels_like.Value, Humidity = i.Forecast.Time[15].Humidity.Value + "%", Clouds =  i.Forecast.Time[15].Clouds.All + "%\n" + i.Forecast.Time[15].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 16, Range = DateTime.Parse(i.Forecast.Time[16].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[16].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[16].Symbol.Name, Precipitation = i.Forecast.Time[16].Precipitation.Value + "mm " + i.Forecast.Time[16].Precipitation.Type + "\nProbability: " + i.Forecast.Time[16].Precipitation.Probability, Wind_Speed = i.Forecast.Time[16].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[16].WindSpeed.Name, Wind_Direction = i.Forecast.Time[16].WindDirection.Deg + "°\n" + i.Forecast.Time[16].WindDirection.Name, Temperature = i.Forecast.Time[16].Temperature.Value + "°C\nMin: " + i.Forecast.Time[16].Temperature.Min + "°C Max: " + i.Forecast.Time[16].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[16].Feels_like.Value, Humidity = i.Forecast.Time[16].Humidity.Value + "%", Clouds =  i.Forecast.Time[16].Clouds.All + "%\n" + i.Forecast.Time[16].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 17, Range = DateTime.Parse(i.Forecast.Time[17].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[17].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[17].Symbol.Name, Precipitation = i.Forecast.Time[17].Precipitation.Value + "mm " + i.Forecast.Time[17].Precipitation.Type + "\nProbability: " + i.Forecast.Time[17].Precipitation.Probability, Wind_Speed = i.Forecast.Time[17].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[17].WindSpeed.Name, Wind_Direction = i.Forecast.Time[17].WindDirection.Deg + "°\n" + i.Forecast.Time[17].WindDirection.Name, Temperature = i.Forecast.Time[17].Temperature.Value + "°C\nMin: " + i.Forecast.Time[17].Temperature.Min + "°C Max: " + i.Forecast.Time[17].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[17].Feels_like.Value, Humidity = i.Forecast.Time[17].Humidity.Value + "%", Clouds =  i.Forecast.Time[17].Clouds.All + "%\n" + i.Forecast.Time[17].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 18, Range = DateTime.Parse(i.Forecast.Time[18].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[18].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[18].Symbol.Name, Precipitation = i.Forecast.Time[18].Precipitation.Value + "mm " + i.Forecast.Time[18].Precipitation.Type + "\nProbability: " + i.Forecast.Time[18].Precipitation.Probability, Wind_Speed = i.Forecast.Time[18].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[18].WindSpeed.Name, Wind_Direction = i.Forecast.Time[18].WindDirection.Deg + "°\n" + i.Forecast.Time[18].WindDirection.Name, Temperature = i.Forecast.Time[18].Temperature.Value + "°C\nMin: " + i.Forecast.Time[18].Temperature.Min + "°C Max: " + i.Forecast.Time[18].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[18].Feels_like.Value, Humidity = i.Forecast.Time[18].Humidity.Value + "%", Clouds =  i.Forecast.Time[18].Clouds.All + "%\n" + i.Forecast.Time[18].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 19, Range = DateTime.Parse(i.Forecast.Time[19].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[19].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[19].Symbol.Name, Precipitation = i.Forecast.Time[19].Precipitation.Value + "mm " + i.Forecast.Time[19].Precipitation.Type + "\nProbability: " + i.Forecast.Time[19].Precipitation.Probability, Wind_Speed = i.Forecast.Time[19].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[19].WindSpeed.Name, Wind_Direction = i.Forecast.Time[19].WindDirection.Deg + "°\n" + i.Forecast.Time[19].WindDirection.Name, Temperature = i.Forecast.Time[19].Temperature.Value + "°C\nMin: " + i.Forecast.Time[19].Temperature.Min + "°C Max: " + i.Forecast.Time[19].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[19].Feels_like.Value, Humidity = i.Forecast.Time[19].Humidity.Value + "%", Clouds =  i.Forecast.Time[19].Clouds.All + "%\n" + i.Forecast.Time[19].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 20, Range = DateTime.Parse(i.Forecast.Time[20].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[20].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[20].Symbol.Name, Precipitation = i.Forecast.Time[20].Precipitation.Value + "mm " + i.Forecast.Time[20].Precipitation.Type + "\nProbability: " + i.Forecast.Time[20].Precipitation.Probability, Wind_Speed = i.Forecast.Time[20].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[20].WindSpeed.Name, Wind_Direction = i.Forecast.Time[20].WindDirection.Deg + "°\n" + i.Forecast.Time[20].WindDirection.Name, Temperature = i.Forecast.Time[20].Temperature.Value + "°C\nMin: " + i.Forecast.Time[20].Temperature.Min + "°C Max: " + i.Forecast.Time[20].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[20].Feels_like.Value, Humidity = i.Forecast.Time[20].Humidity.Value + "%", Clouds =  i.Forecast.Time[20].Clouds.All + "%\n" + i.Forecast.Time[20].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 21, Range = DateTime.Parse(i.Forecast.Time[21].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[21].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[21].Symbol.Name, Precipitation = i.Forecast.Time[21].Precipitation.Value + "mm " + i.Forecast.Time[21].Precipitation.Type + "\nProbability: " + i.Forecast.Time[21].Precipitation.Probability, Wind_Speed = i.Forecast.Time[21].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[21].WindSpeed.Name, Wind_Direction = i.Forecast.Time[21].WindDirection.Deg + "°\n" + i.Forecast.Time[21].WindDirection.Name, Temperature = i.Forecast.Time[21].Temperature.Value + "°C\nMin: " + i.Forecast.Time[21].Temperature.Min + "°C Max: " + i.Forecast.Time[21].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[21].Feels_like.Value, Humidity = i.Forecast.Time[21].Humidity.Value + "%", Clouds =  i.Forecast.Time[21].Clouds.All + "%\n" + i.Forecast.Time[21].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 22, Range = DateTime.Parse(i.Forecast.Time[22].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[22].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[22].Symbol.Name, Precipitation = i.Forecast.Time[22].Precipitation.Value + "mm " + i.Forecast.Time[22].Precipitation.Type + "\nProbability: " + i.Forecast.Time[22].Precipitation.Probability, Wind_Speed = i.Forecast.Time[22].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[22].WindSpeed.Name, Wind_Direction = i.Forecast.Time[22].WindDirection.Deg + "°\n" + i.Forecast.Time[22].WindDirection.Name, Temperature = i.Forecast.Time[22].Temperature.Value + "°C\nMin: " + i.Forecast.Time[22].Temperature.Min + "°C Max: " + i.Forecast.Time[22].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[22].Feels_like.Value, Humidity = i.Forecast.Time[22].Humidity.Value + "%", Clouds =  i.Forecast.Time[22].Clouds.All + "%\n" + i.Forecast.Time[22].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 23, Range = DateTime.Parse(i.Forecast.Time[23].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[23].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[23].Symbol.Name, Precipitation = i.Forecast.Time[23].Precipitation.Value + "mm " + i.Forecast.Time[23].Precipitation.Type + "\nProbability: " + i.Forecast.Time[23].Precipitation.Probability, Wind_Speed = i.Forecast.Time[23].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[23].WindSpeed.Name, Wind_Direction = i.Forecast.Time[23].WindDirection.Deg + "°\n" + i.Forecast.Time[23].WindDirection.Name, Temperature = i.Forecast.Time[23].Temperature.Value + "°C\nMin: " + i.Forecast.Time[23].Temperature.Min + "°C Max: " + i.Forecast.Time[23].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[23].Feels_like.Value, Humidity = i.Forecast.Time[23].Humidity.Value + "%", Clouds =  i.Forecast.Time[23].Clouds.All + "%\n" + i.Forecast.Time[23].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 24, Range = DateTime.Parse(i.Forecast.Time[24].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[24].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[24].Symbol.Name, Precipitation = i.Forecast.Time[24].Precipitation.Value + "mm " + i.Forecast.Time[24].Precipitation.Type + "\nProbability: " + i.Forecast.Time[24].Precipitation.Probability, Wind_Speed = i.Forecast.Time[24].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[24].WindSpeed.Name, Wind_Direction = i.Forecast.Time[24].WindDirection.Deg + "°\n" + i.Forecast.Time[24].WindDirection.Name, Temperature = i.Forecast.Time[24].Temperature.Value + "°C\nMin: " + i.Forecast.Time[24].Temperature.Min + "°C Max: " + i.Forecast.Time[24].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[24].Feels_like.Value, Humidity = i.Forecast.Time[24].Humidity.Value + "%", Clouds =  i.Forecast.Time[24].Clouds.All + "%\n" + i.Forecast.Time[24].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 25, Range = DateTime.Parse(i.Forecast.Time[25].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[25].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[25].Symbol.Name, Precipitation = i.Forecast.Time[25].Precipitation.Value + "mm " + i.Forecast.Time[25].Precipitation.Type + "\nProbability: " + i.Forecast.Time[25].Precipitation.Probability, Wind_Speed = i.Forecast.Time[25].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[25].WindSpeed.Name, Wind_Direction = i.Forecast.Time[25].WindDirection.Deg + "°\n" + i.Forecast.Time[25].WindDirection.Name, Temperature = i.Forecast.Time[25].Temperature.Value + "°C\nMin: " + i.Forecast.Time[25].Temperature.Min + "°C Max: " + i.Forecast.Time[25].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[25].Feels_like.Value, Humidity = i.Forecast.Time[25].Humidity.Value + "%", Clouds =  i.Forecast.Time[25].Clouds.All + "%\n" + i.Forecast.Time[25].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 26, Range = DateTime.Parse(i.Forecast.Time[26].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[26].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[26].Symbol.Name, Precipitation = i.Forecast.Time[26].Precipitation.Value + "mm " + i.Forecast.Time[26].Precipitation.Type + "\nProbability: " + i.Forecast.Time[26].Precipitation.Probability, Wind_Speed = i.Forecast.Time[26].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[26].WindSpeed.Name, Wind_Direction = i.Forecast.Time[26].WindDirection.Deg + "°\n" + i.Forecast.Time[26].WindDirection.Name, Temperature = i.Forecast.Time[26].Temperature.Value + "°C\nMin: " + i.Forecast.Time[26].Temperature.Min + "°C Max: " + i.Forecast.Time[26].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[26].Feels_like.Value, Humidity = i.Forecast.Time[26].Humidity.Value + "%", Clouds =  i.Forecast.Time[26].Clouds.All + "%\n" + i.Forecast.Time[26].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 27, Range = DateTime.Parse(i.Forecast.Time[27].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[27].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[27].Symbol.Name, Precipitation = i.Forecast.Time[27].Precipitation.Value + "mm " + i.Forecast.Time[27].Precipitation.Type + "\nProbability: " + i.Forecast.Time[27].Precipitation.Probability, Wind_Speed = i.Forecast.Time[27].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[27].WindSpeed.Name, Wind_Direction = i.Forecast.Time[27].WindDirection.Deg + "°\n" + i.Forecast.Time[27].WindDirection.Name, Temperature = i.Forecast.Time[27].Temperature.Value + "°C\nMin: " + i.Forecast.Time[27].Temperature.Min + "°C Max: " + i.Forecast.Time[27].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[27].Feels_like.Value, Humidity = i.Forecast.Time[27].Humidity.Value + "%", Clouds =  i.Forecast.Time[27].Clouds.All + "%\n" + i.Forecast.Time[27].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 28, Range = DateTime.Parse(i.Forecast.Time[28].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[28].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[28].Symbol.Name, Precipitation = i.Forecast.Time[28].Precipitation.Value + "mm " + i.Forecast.Time[28].Precipitation.Type + "\nProbability: " + i.Forecast.Time[28].Precipitation.Probability, Wind_Speed = i.Forecast.Time[28].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[28].WindSpeed.Name, Wind_Direction = i.Forecast.Time[28].WindDirection.Deg + "°\n" + i.Forecast.Time[28].WindDirection.Name, Temperature = i.Forecast.Time[28].Temperature.Value + "°C\nMin: " + i.Forecast.Time[28].Temperature.Min + "°C Max: " + i.Forecast.Time[28].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[28].Feels_like.Value, Humidity = i.Forecast.Time[28].Humidity.Value + "%", Clouds =  i.Forecast.Time[28].Clouds.All + "%\n" + i.Forecast.Time[28].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 29, Range = DateTime.Parse(i.Forecast.Time[29].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[29].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[29].Symbol.Name, Precipitation = i.Forecast.Time[29].Precipitation.Value + "mm " + i.Forecast.Time[29].Precipitation.Type + "\nProbability: " + i.Forecast.Time[29].Precipitation.Probability, Wind_Speed = i.Forecast.Time[29].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[29].WindSpeed.Name, Wind_Direction = i.Forecast.Time[29].WindDirection.Deg + "°\n" + i.Forecast.Time[29].WindDirection.Name, Temperature = i.Forecast.Time[29].Temperature.Value + "°C\nMin: " + i.Forecast.Time[29].Temperature.Min + "°C Max: " + i.Forecast.Time[29].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[29].Feels_like.Value, Humidity = i.Forecast.Time[29].Humidity.Value + "%", Clouds =  i.Forecast.Time[29].Clouds.All + "%\n" + i.Forecast.Time[29].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 30, Range = DateTime.Parse(i.Forecast.Time[30].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[30].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[30].Symbol.Name, Precipitation = i.Forecast.Time[30].Precipitation.Value + "mm " + i.Forecast.Time[30].Precipitation.Type + "\nProbability: " + i.Forecast.Time[30].Precipitation.Probability, Wind_Speed = i.Forecast.Time[30].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[30].WindSpeed.Name, Wind_Direction = i.Forecast.Time[30].WindDirection.Deg + "°\n" + i.Forecast.Time[30].WindDirection.Name, Temperature = i.Forecast.Time[30].Temperature.Value + "°C\nMin: " + i.Forecast.Time[30].Temperature.Min + "°C Max: " + i.Forecast.Time[30].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[30].Feels_like.Value, Humidity = i.Forecast.Time[30].Humidity.Value + "%", Clouds =  i.Forecast.Time[30].Clouds.All + "%\n" + i.Forecast.Time[30].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 31, Range = DateTime.Parse(i.Forecast.Time[31].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[31].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[31].Symbol.Name, Precipitation = i.Forecast.Time[31].Precipitation.Value + "mm " + i.Forecast.Time[31].Precipitation.Type + "\nProbability: " + i.Forecast.Time[31].Precipitation.Probability, Wind_Speed = i.Forecast.Time[31].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[31].WindSpeed.Name, Wind_Direction = i.Forecast.Time[31].WindDirection.Deg + "°\n" + i.Forecast.Time[31].WindDirection.Name, Temperature = i.Forecast.Time[31].Temperature.Value + "°C\nMin: " + i.Forecast.Time[31].Temperature.Min + "°C Max: " + i.Forecast.Time[31].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[31].Feels_like.Value, Humidity = i.Forecast.Time[31].Humidity.Value + "%", Clouds =  i.Forecast.Time[31].Clouds.All + "%\n" + i.Forecast.Time[31].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 32, Range = DateTime.Parse(i.Forecast.Time[32].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[32].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[32].Symbol.Name, Precipitation = i.Forecast.Time[32].Precipitation.Value + "mm " + i.Forecast.Time[32].Precipitation.Type + "\nProbability: " + i.Forecast.Time[32].Precipitation.Probability, Wind_Speed = i.Forecast.Time[32].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[32].WindSpeed.Name, Wind_Direction = i.Forecast.Time[32].WindDirection.Deg + "°\n" + i.Forecast.Time[32].WindDirection.Name, Temperature = i.Forecast.Time[32].Temperature.Value + "°C\nMin: " + i.Forecast.Time[32].Temperature.Min + "°C Max: " + i.Forecast.Time[32].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[32].Feels_like.Value, Humidity = i.Forecast.Time[32].Humidity.Value + "%", Clouds =  i.Forecast.Time[32].Clouds.All + "%\n" + i.Forecast.Time[32].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 33, Range = DateTime.Parse(i.Forecast.Time[33].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[33].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[33].Symbol.Name, Precipitation = i.Forecast.Time[33].Precipitation.Value + "mm " + i.Forecast.Time[33].Precipitation.Type + "\nProbability: " + i.Forecast.Time[33].Precipitation.Probability, Wind_Speed = i.Forecast.Time[33].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[33].WindSpeed.Name, Wind_Direction = i.Forecast.Time[33].WindDirection.Deg + "°\n" + i.Forecast.Time[33].WindDirection.Name, Temperature = i.Forecast.Time[33].Temperature.Value + "°C\nMin: " + i.Forecast.Time[33].Temperature.Min + "°C Max: " + i.Forecast.Time[33].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[33].Feels_like.Value, Humidity = i.Forecast.Time[33].Humidity.Value + "%", Clouds =  i.Forecast.Time[33].Clouds.All + "%\n" + i.Forecast.Time[33].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 34, Range = DateTime.Parse(i.Forecast.Time[34].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[34].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[34].Symbol.Name, Precipitation = i.Forecast.Time[34].Precipitation.Value + "mm " + i.Forecast.Time[34].Precipitation.Type + "\nProbability: " + i.Forecast.Time[34].Precipitation.Probability, Wind_Speed = i.Forecast.Time[34].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[34].WindSpeed.Name, Wind_Direction = i.Forecast.Time[34].WindDirection.Deg + "°\n" + i.Forecast.Time[34].WindDirection.Name, Temperature = i.Forecast.Time[34].Temperature.Value + "°C\nMin: " + i.Forecast.Time[34].Temperature.Min + "°C Max: " + i.Forecast.Time[34].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[34].Feels_like.Value, Humidity = i.Forecast.Time[34].Humidity.Value + "%", Clouds =  i.Forecast.Time[34].Clouds.All + "%\n" + i.Forecast.Time[34].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 35, Range = DateTime.Parse(i.Forecast.Time[35].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[35].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[35].Symbol.Name, Precipitation = i.Forecast.Time[35].Precipitation.Value + "mm " + i.Forecast.Time[35].Precipitation.Type + "\nProbability: " + i.Forecast.Time[35].Precipitation.Probability, Wind_Speed = i.Forecast.Time[35].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[35].WindSpeed.Name, Wind_Direction = i.Forecast.Time[35].WindDirection.Deg + "°\n" + i.Forecast.Time[35].WindDirection.Name, Temperature = i.Forecast.Time[35].Temperature.Value + "°C\nMin: " + i.Forecast.Time[35].Temperature.Min + "°C Max: " + i.Forecast.Time[35].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[35].Feels_like.Value, Humidity = i.Forecast.Time[35].Humidity.Value + "%", Clouds =  i.Forecast.Time[35].Clouds.All + "%\n" + i.Forecast.Time[35].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 36, Range = DateTime.Parse(i.Forecast.Time[36].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[36].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[36].Symbol.Name, Precipitation = i.Forecast.Time[36].Precipitation.Value + "mm " + i.Forecast.Time[36].Precipitation.Type + "\nProbability: " + i.Forecast.Time[36].Precipitation.Probability, Wind_Speed = i.Forecast.Time[36].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[36].WindSpeed.Name, Wind_Direction = i.Forecast.Time[36].WindDirection.Deg + "°\n" + i.Forecast.Time[36].WindDirection.Name, Temperature = i.Forecast.Time[36].Temperature.Value + "°C\nMin: " + i.Forecast.Time[36].Temperature.Min + "°C Max: " + i.Forecast.Time[36].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[36].Feels_like.Value, Humidity = i.Forecast.Time[36].Humidity.Value + "%", Clouds =  i.Forecast.Time[36].Clouds.All + "%\n" + i.Forecast.Time[36].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 37, Range = DateTime.Parse(i.Forecast.Time[37].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[37].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[37].Symbol.Name, Precipitation = i.Forecast.Time[37].Precipitation.Value + "mm " + i.Forecast.Time[37].Precipitation.Type + "\nProbability: " + i.Forecast.Time[37].Precipitation.Probability, Wind_Speed = i.Forecast.Time[37].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[37].WindSpeed.Name, Wind_Direction = i.Forecast.Time[37].WindDirection.Deg + "°\n" + i.Forecast.Time[37].WindDirection.Name, Temperature = i.Forecast.Time[37].Temperature.Value + "°C\nMin: " + i.Forecast.Time[37].Temperature.Min + "°C Max: " + i.Forecast.Time[37].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[37].Feels_like.Value, Humidity = i.Forecast.Time[37].Humidity.Value + "%", Clouds =  i.Forecast.Time[37].Clouds.All + "%\n" + i.Forecast.Time[37].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 38, Range = DateTime.Parse(i.Forecast.Time[38].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[38].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[38].Symbol.Name, Precipitation = i.Forecast.Time[38].Precipitation.Value + "mm " + i.Forecast.Time[38].Precipitation.Type + "\nProbability: " + i.Forecast.Time[38].Precipitation.Probability, Wind_Speed = i.Forecast.Time[38].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[38].WindSpeed.Name, Wind_Direction = i.Forecast.Time[38].WindDirection.Deg + "°\n" + i.Forecast.Time[38].WindDirection.Name, Temperature = i.Forecast.Time[38].Temperature.Value + "°C\nMin: " + i.Forecast.Time[38].Temperature.Min + "°C Max: " + i.Forecast.Time[38].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[38].Feels_like.Value, Humidity = i.Forecast.Time[38].Humidity.Value + "%", Clouds =  i.Forecast.Time[38].Clouds.All + "%\n" + i.Forecast.Time[38].Clouds.Value },
                        new Weather_Grid_Entrys() { Id = 39, Range = DateTime.Parse(i.Forecast.Time[39].From, null, DateTimeStyles.AssumeUniversal) + "\n" + DateTime.Parse(i.Forecast.Time[39].To, null, DateTimeStyles.AssumeUniversal), Weather = i.Forecast.Time[39].Symbol.Name, Precipitation = i.Forecast.Time[39].Precipitation.Value + "mm " + i.Forecast.Time[39].Precipitation.Type + "\nProbability: " + i.Forecast.Time[39].Precipitation.Probability, Wind_Speed = i.Forecast.Time[39].WindSpeed.Mps + " m/s\n" + i.Forecast.Time[39].WindSpeed.Name, Wind_Direction = i.Forecast.Time[39].WindDirection.Deg + "°\n" + i.Forecast.Time[39].WindDirection.Name, Temperature = i.Forecast.Time[39].Temperature.Value + "°C\nMin: " + i.Forecast.Time[39].Temperature.Min + "°C Max: " + i.Forecast.Time[39].Temperature.Max + "°C", Feels_Like = i.Forecast.Time[39].Feels_like.Value, Humidity = i.Forecast.Time[39].Humidity.Value + "%", Clouds =  i.Forecast.Time[39].Clouds.All + "%\n" + i.Forecast.Time[39].Clouds.Value },

                    };
                    Weather_Grid.ItemsSource = gui;

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

        public class Weather_Grid_Entrys
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
            [XmlAttribute(AttributeName = "altitude")]
            public string Altitude { get; set; }
            [XmlAttribute(AttributeName = "latitude")]
            public string Latitude { get; set; }
            [XmlAttribute(AttributeName = "longitude")]
            public string Longitude { get; set; }
            [XmlAttribute(AttributeName = "geobase")]
            public string Geobase { get; set; }
            [XmlAttribute(AttributeName = "geobaseid")]
            public string Geobaseid { get; set; }
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
}
