using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace Weather_GUI
{
    /// <summary>
    /// Interaktionslogik für Weather.xaml
    /// </summary>
    public partial class Weather_Now : Window
    {
        public Weather_Now()
        {
            InitializeComponent();
            GetWeather();
        }
        private void GetWeather()
        {
            string key = ConfigurationManager.AppSettings["API-Key"];
            string lang = ConfigurationManager.AppSettings["Language"];
            string city = ConfigurationManager.AppSettings["City"];
            string api = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&lang=" + lang + "&appid=" + key + "&mode=xml&units=metric";
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Current));

                // Declare an object variable of the type to be deserialized.
                Current i;
                WebRequest request = WebRequest.Create(api);
                WebResponse response = request.GetResponse();
                using (Stream reader = response.GetResponseStream())
                {
                    // Call the Deserialize method to restore the object's state.
                    i = (Current)serializer.Deserialize(reader);
                }
                City_txt.Text = i.City.Name + " - " + i.City.Country;
                DateTime now = DateTime.Now;
                Date_txt.Text = now.ToString("D");
                Degrees_txt.Text = i.Temperature.Value + "°C";
                Clouds_txt.Text = i.Clouds.Name;
                Weather_txt.Text = "";
                if (i.Precipitation.Mode == "rain" || i.Precipitation.Mode == "snow") {
                    Weather_txt.Text = i.Weather.Value + "\n" + i.Precipitation.Value + "mm last " + i.Precipitation.Unit;
                }   
                Image.Source = new BitmapImage(new Uri(@"/icons/" + i.Weather.Icon + ".png", UriKind.Relative));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception");
            }
        }
        [XmlRoot(ElementName = "coord")]
        public class Coord
        {
            [XmlAttribute(AttributeName = "lon")]
            public string Lon { get; set; }
            [XmlAttribute(AttributeName = "lat")]
            public string Lat { get; set; }
        }

        [XmlRoot(ElementName = "sun")]
        public class Sun
        {
            [XmlAttribute(AttributeName = "rise")]
            public string Rise { get; set; }
            [XmlAttribute(AttributeName = "set")]
            public string Set { get; set; }
        }

        [XmlRoot(ElementName = "city")]
        public class City
        {
            [XmlElement(ElementName = "coord")]
            public Coord Coord { get; set; }
            [XmlElement(ElementName = "country")]
            public string Country { get; set; }
            [XmlElement(ElementName = "timezone")]
            public string Timezone { get; set; }
            [XmlElement(ElementName = "sun")]
            public Sun Sun { get; set; }
            [XmlAttribute(AttributeName = "id")]
            public string Id { get; set; }
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
        }

        [XmlRoot(ElementName = "temperature")]
        public class Temperature
        {
            [XmlAttribute(AttributeName = "value")]
            public string Value { get; set; }
            [XmlAttribute(AttributeName = "min")]
            public string Min { get; set; }
            [XmlAttribute(AttributeName = "max")]
            public string Max { get; set; }
            [XmlAttribute(AttributeName = "unit")]
            public string Unit { get; set; }
        }

        [XmlRoot(ElementName = "feels_like")]
        public class Feels_like
        {
            [XmlAttribute(AttributeName = "value")]
            public string Value { get; set; }
            [XmlAttribute(AttributeName = "unit")]
            public string Unit { get; set; }
        }

        [XmlRoot(ElementName = "humidity")]
        public class Humidity
        {
            [XmlAttribute(AttributeName = "value")]
            public string Value { get; set; }
            [XmlAttribute(AttributeName = "unit")]
            public string Unit { get; set; }
        }

        [XmlRoot(ElementName = "pressure")]
        public class Pressure
        {
            [XmlAttribute(AttributeName = "value")]
            public string Value { get; set; }
            [XmlAttribute(AttributeName = "unit")]
            public string Unit { get; set; }
        }

        [XmlRoot(ElementName = "speed")]
        public class Speed
        {
            [XmlAttribute(AttributeName = "value")]
            public string Value { get; set; }
            [XmlAttribute(AttributeName = "unit")]
            public string Unit { get; set; }
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
        }

        [XmlRoot(ElementName = "direction")]
        public class Direction
        {
            [XmlAttribute(AttributeName = "value")]
            public string Value { get; set; }
            [XmlAttribute(AttributeName = "code")]
            public string Code { get; set; }
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
        }

        [XmlRoot(ElementName = "wind")]
        public class Wind
        {
            [XmlElement(ElementName = "speed")]
            public Speed Speed { get; set; }
            [XmlElement(ElementName = "gusts")]
            public string Gusts { get; set; }
            [XmlElement(ElementName = "direction")]
            public Direction Direction { get; set; }
        }

        [XmlRoot(ElementName = "clouds")]
        public class Clouds
        {
            [XmlAttribute(AttributeName = "value")]
            public string Value { get; set; }
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
        }

        [XmlRoot(ElementName = "visibility")]
#pragma warning disable CS0108
        public class Visibility
#pragma warning restore CS0108
        {
            [XmlAttribute(AttributeName = "value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "precipitation")]
        public class Precipitation
        {
            [XmlAttribute(AttributeName = "value")]
            public string Value { get; set; }
            [XmlAttribute(AttributeName = "mode")]
            public string Mode { get; set; }
            [XmlAttribute(AttributeName = "unit")]
            public string Unit { get; set; }
        }

        [XmlRoot(ElementName = "weather")]
        public class Weather
        {
            [XmlAttribute(AttributeName = "number")]
            public string Number { get; set; }
            [XmlAttribute(AttributeName = "value")]
            public string Value { get; set; }
            [XmlAttribute(AttributeName = "icon")]
            public string Icon { get; set; }
        }

        [XmlRoot(ElementName = "lastupdate")]
        public class Lastupdate
        {
            [XmlAttribute(AttributeName = "value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "current")]
        public class Current
        {
            [XmlElement(ElementName = "city")]
            public City City { get; set; }
            [XmlElement(ElementName = "temperature")]
            public Temperature Temperature { get; set; }
            [XmlElement(ElementName = "feels_like")]
            public Feels_like Feels_like { get; set; }
            [XmlElement(ElementName = "humidity")]
            public Humidity Humidity { get; set; }
            [XmlElement(ElementName = "pressure")]
            public Pressure Pressure { get; set; }
            [XmlElement(ElementName = "wind")]
            public Wind Wind { get; set; }
            [XmlElement(ElementName = "clouds")]
            public Clouds Clouds { get; set; }
            [XmlElement(ElementName = "visibility")]
            public Visibility Visibility { get; set; }
            [XmlElement(ElementName = "precipitation")]
            public Precipitation Precipitation { get; set; }
            [XmlElement(ElementName = "weather")]
            public Weather Weather { get; set; }
            [XmlElement(ElementName = "lastupdate")]
            public Lastupdate Lastupdate { get; set; }
        }
    }
}
