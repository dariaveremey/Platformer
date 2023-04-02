using Newtonsoft.Json;

namespace Services.Forecast
{
    public class ForecastDTO
    {
        [JsonProperty("name")]
        public string Name;
        
        [JsonProperty("dt")]
        public int DateTimeSince;
        
        [JsonProperty("weather")]
        public WeatherDTO[] WeatherArray;
        
        [JsonProperty("main")]
        public MainDTO MainDto;
        
        [JsonProperty("wind")]
        public WindDTO WindDto;

        public override string ToString()
        {
            return $"Name '{Name}',DateTimeSince '{DateTimeSince}',WeatherArray '{WeatherArray}',MainDto '{MainDto}',WindDto '{WindDto}'";
        }
    }
}