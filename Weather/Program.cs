using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net;
using System.Xml.Serialization;

namespace Weather
{
    class Program
    {
        readonly string url = "http://ip-api.com/xml/";
        readonly string key = ConfigurationManager.AppSettings["API-Key"];
        readonly string lang = ConfigurationManager.AppSettings["Language"];
        static void Main(string[] args)
        {
            Console.WriteLine("Choose what you want to Do!");
            Console.WriteLine("1. Get Weather by IP Location");
            Console.WriteLine("2. Get Weather by City Name (Recommended)");
            Console.WriteLine("3. Get Weather by ZIP Code");
            Console.WriteLine("4. Get Weather Forecast");
            Console.WriteLine("5. Show Config");
            Console.WriteLine("Choose (1,2,3,4,5)");
            ConsoleKeyInfo input = Console.ReadKey();
            Program t = new Program();
            switch (input.Key) //Switch on Key enum
            {
                case ConsoleKey.D1:
                    Console.WriteLine();
                    Console.WriteLine("You pressed \"1\"");
                    Console.Clear();
                    t.DeserializeObject(false);
                    break;
                case ConsoleKey.NumPad1:
                    Console.WriteLine();
                    Console.WriteLine("You pressed \"1\"");
                    Console.Clear();
                    t.DeserializeObject(false);
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine();
                    Console.WriteLine("You pressed \"2\"");
                    Console.Clear();
                    t.DeserializeWeather("", "", "city");
                    break;
                case ConsoleKey.NumPad2:
                    Console.WriteLine();
                    Console.WriteLine("You pressed \"2\"");
                    Console.Clear();
                    t.DeserializeWeather("", "", "city");
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine();
                    Console.WriteLine("You pressed \"3\"");
                    Console.Clear();
                    t.DeserializeWeather("", "", "zip");
                    break;
                case ConsoleKey.NumPad3:
                    Console.WriteLine();
                    Console.WriteLine("You pressed \"3\"");
                    Console.Clear();
                    t.DeserializeWeather("", "", "zip");
                    break;
                case ConsoleKey.D4:
                    Console.WriteLine();
                    Console.WriteLine("You pressed \"4\"");
                    Console.Clear();
                    t.Forecast();
                    break;
                case ConsoleKey.NumPad4:
                    Console.WriteLine();
                    Console.WriteLine("You pressed \"4\"");
                    Console.Clear();
                    t.Forecast();
                    break;
                case ConsoleKey.D5:
                    Console.WriteLine();
                    Console.WriteLine("You pressed \"5\"");
                    Console.Clear();
                    t.ShowConfig();
                    break;
                case ConsoleKey.NumPad5:
                    Console.WriteLine();
                    Console.WriteLine("You pressed \"5\"");
                    Console.Clear();
                    t.ShowConfig();
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Not a valid answer");
                    string[] Array = { };
                    Main(Array);
                    break;
            }
        }

        private void Forecast()
        {
            Console.WriteLine("Choose what you want to Do!");
            Console.WriteLine("1. Get Weather Forecast by IP Location");
            Console.WriteLine("2. Get Weather Forecast by City Name (Recommended)");
            Console.WriteLine("3. Get Weather Forecast by ZIP Code");
            Console.WriteLine("Choose (1,2,3)");
            ConsoleKeyInfo input = Console.ReadKey();
            Program t = new Program();
            switch (input.Key) //Switch on Key enum
            {
                case ConsoleKey.D1:
                    Console.WriteLine();
                    Console.WriteLine("You pressed \"1\"");
                    Console.Clear();
                    t.DeserializeObject(true);
                    break;
                case ConsoleKey.NumPad1:
                    Console.WriteLine();
                    Console.WriteLine("You pressed \"1\"");
                    Console.Clear();
                    t.DeserializeObject(true);
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine();
                    Console.WriteLine("You pressed \"2\"");
                    Console.Clear();
                    t.DeserializeWeatherForecast("", "", "city");
                    break;
                case ConsoleKey.NumPad2:
                    Console.WriteLine();
                    Console.WriteLine("You pressed \"2\"");
                    Console.Clear();
                    t.DeserializeWeatherForecast("", "", "city");
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine();
                    Console.WriteLine("You pressed \"3\"");
                    Console.Clear();
                    t.DeserializeWeatherForecast("", "", "zip");
                    break;
                case ConsoleKey.NumPad3:
                    Console.WriteLine();
                    Console.WriteLine("You pressed \"3\"");
                    Console.Clear();
                    t.DeserializeWeatherForecast("", "", "zip");
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Not a valid answer");
                    string[] Array = { };
                    Main(Array);
                    break;
            }
        }

        private void ShowConfig()
        {
            Console.WriteLine("CONFIG:");
            Console.WriteLine("Loaded from App.config:");
            Console.WriteLine("1. API-Key: \"{0}\"", key);
            Console.WriteLine("2. Language: \"{0}\"", lang);
            Console.WriteLine("Do you want to quit? (q)");
            ConsoleKeyInfo input = Console.ReadKey();
            switch (input.Key) //Switch on Key enum
            {
                default:
                    Console.WriteLine();
                    string[] Array = { };
                    Main(Array);
                    break;
            }

        }

        private void DeserializeObject(bool forecast)
        {
            Console.WriteLine("Getting Location");
            // Create an instance of the XmlSerializer.
            XmlSerializer serializer = new XmlSerializer(typeof(Query));

            // Declare an object variable of the type to be deserialized.
            Query i;
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            using (Stream reader = response.GetResponseStream())
            {
                // Call the Deserialize method to restore the object's state.
                i = (Query)serializer.Deserialize(reader);
            }

            // Write out the properties of the object.
            Program t = new Program();

            if (!forecast)
            {
                string lat = i.Lat;
                string lon = i.Lon;
                t.DeserializeWeather(lat, lon, "iploc");
                Console.WriteLine("Done");
            }
            else if (forecast)
            {
                string lat = i.Lat;
                string lon = i.Lon;
                t.DeserializeWeatherForecast(lat, lon, "iploc");
                Console.WriteLine("Done");
            }

        }
        private void DeserializeWeather(string lat, string lon, string method)
        {
            Console.WriteLine("Getting Weather Data");
            string api = "";
            if (method == "iploc")
            {
                api = "https://api.openweathermap.org/data/2.5/weather?lat=" + lat + "&lon=" + lon + "&appid=" + key + "&mode=xml&units=metric";
            }
            else if (method == "city")
            {
                Console.WriteLine("Type in your City. Press Enter when done");
                string input = Console.ReadLine();
                api = "https://api.openweathermap.org/data/2.5/weather?q=" + input + "&appid=" + key + "&mode=xml&units=metric";
            }
            else if (method == "zip")
            {
                Console.WriteLine("Type in your ZIP Code,Country Code. Press Enter when done (Example: 97684,DE)");
                string input = Console.ReadLine();
                api = "https://api.openweathermap.org/data/2.5/weather?zip=" + input + "&appid=" + key + "&mode=xml&units=metric";
            }
            try
            {
                // Create an instance of the XmlSerializer.
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

                // Write out the properties of the object.
                Console.WriteLine("Temperature: {0}°C", i.Temperature.Value);
                Console.WriteLine("Max Temp: {0}°C", i.Temperature.Max);
                Console.WriteLine("Min Temp: {0}°C", i.Temperature.Min);
                Console.WriteLine("Feels Like: {0}°C", i.Feels_like.Value);
                Console.WriteLine("Wind-Speed: {0} m/S - {1}", i.Wind.Speed.Value, i.Wind.Speed.Name);
                Console.WriteLine("Wind-Direction: {0}° - {1}", i.Wind.Direction.Value, i.Wind.Direction.Name);
                Console.WriteLine("Clouds: {0} - {1}", i.Clouds.Value, i.Clouds.Name);
                Console.WriteLine("Raining?: {0}", i.Precipitation.Mode);
                if (i.Precipitation.Mode == "rain")
                {
                    Console.WriteLine("Rained {0}mm last {1}", i.Precipitation.Value, i.Precipitation.Unit);
                }
                Console.WriteLine("Weather: {0}", i.Weather.Value);
                Console.WriteLine("Last Update: {0} (Local Time)", DateTime.Parse(i.Lastupdate.Value, null, DateTimeStyles.AssumeUniversal));
                Console.Write("Press any key to exit . . . ");
                Console.ReadKey(true);
            }
            catch (System.Net.WebException ex)
            {
                Console.WriteLine("Error when trying to get Weather Data! \n{0}", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! \n{0}", ex);
            }
        }
        private void DeserializeWeatherForecast(string lat, string lon, string method)
        {
            Console.WriteLine("Getting Weather Forecast Data");
            string api = "";
            if (method == "iploc")
            {
                api = "https://api.openweathermap.org/data/2.5/forecast?lat=" + lat + "&lon=" + lon + "&lang=" + lang + "&appid=" + key + "&mode=xml&units=metric";
            }
            else if (method == "city")
            {
                Console.WriteLine("Type in your City. Press Enter when done");
                string input = Console.ReadLine();
                api = "https://api.openweathermap.org/data/2.5/forecast?q=" + input + "&lang=" + lang + "&appid=" + key + "&mode=xml&units=metric";
            }
            else if (method == "zip")
            {
                Console.WriteLine("Type in your ZIP Code,Country Code. Press Enter when done (Example: 97684,DE)");
                string input = Console.ReadLine();
                api = "https://api.openweathermap.org/data/2.5/forecast?zip=" + input + "&lang=" + lang + "&appid=" + key + "&mode=xml&units=metric";
            }
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
                }

                // Write out the properties of the object.
                Console.WriteLine("From {0} to {1}", DateTime.Parse(i.Forecast.Time[0].From, null, DateTimeStyles.AssumeUniversal), DateTime.Parse(i.Forecast.Time[0].To, null, DateTimeStyles.AssumeUniversal));
                Console.WriteLine("   Weather: {0}", i.Forecast.Time[0].Symbol.Name);
                Console.WriteLine("   Precipitation: {0}mm {1}. Probability: {2}%", i.Forecast.Time[0].Precipitation.Value, i.Forecast.Time[0].Precipitation.Type, i.Forecast.Time[0].Precipitation.Probability);
                Console.WriteLine("   Wind-Speed: {0} m/s - {1}", i.Forecast.Time[0].WindSpeed.Mps, i.Forecast.Time[0].WindSpeed.Name);
                Console.WriteLine("   Wind-Direction: {0} - {1}", i.Forecast.Time[0].WindDirection.Deg, i.Forecast.Time[0].WindDirection.Name);
                Console.WriteLine("   Temperature: {0}°C. Min: {1}°C. Max: {2}°C", i.Forecast.Time[0].Temperature.Value, i.Forecast.Time[0].Temperature.Min, i.Forecast.Time[0].Temperature.Max);
                Console.WriteLine("   Feels Like: {0}°C", i.Forecast.Time[0].Feels_like.Value);
                Console.WriteLine("   Humidity: {0}%", i.Forecast.Time[0].Humidity.Value);
                Console.WriteLine("   Clouds: {0}% - {1}", i.Forecast.Time[0].Clouds.All, i.Forecast.Time[0].Clouds.Value);


                Console.Write("Press any key to exit . . . ");
                Console.ReadKey(true);
            }
            catch (WebException ex)
            {
                Console.WriteLine("Error when trying to get Weather Data! \n{0}", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! \n{0}", ex);
            }
        }
    }
    [XmlRoot(ElementName = "query")]
    public class Query
    {
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }
        [XmlElement(ElementName = "lat")]
        public string Lat { get; set; }
        [XmlElement(ElementName = "lon")]
        public string Lon { get; set; }
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
    [XmlRoot(ElementName = "lastupdate")]
    public class Lastupdate
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
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
    [XmlRoot(ElementName = "coord")]
    public class Coord
    {
        [XmlAttribute(AttributeName = "lon")]
        public string Lon { get; set; }
        [XmlAttribute(AttributeName = "lat")]
        public string Lat { get; set; }
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
        [XmlAttribute(AttributeName = "mode")]
        public string Mode { get; set; }
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
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "visibility")]
    public class Visibility
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
