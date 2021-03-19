using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Net.Http;
using System.IO;

namespace AccuWeatherAPI.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
   


    class WeatherJSON
    {
        public class Temperature
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Root
        {
            public DateTime DateTime { get; set; }
            public int EpochDateTime { get; set; }
            public int WeatherIcon { get; set; }
            public string IconPhrase { get; set; }
            public bool HasPrecipitation { get; set; }
            public bool IsDaylight { get; set; }
            public Temperature Temperature { get; set; }
            public int PrecipitationProbability { get; set; }
            public string MobileLink { get; set; }
            public string Link { get; set; }
            public string PrecipitationType { get; set; }
            public string PrecipitationIntensity { get; set; }
        }

        public async static Task<List<WeatherJSON>> GetJSON(string url)
        {
            var http = new HttpClient();
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(List<WeatherJSON>));
            var dataStream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var value = serializer.ReadObject(dataStream) as List<WeatherJSON>;

            return value;
        }
    }
}
