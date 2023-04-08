using System;
using Services.Location;
using Services.Web;
using UnityEngine;

namespace Services.Forecast
{
    public class ForecastWebModule 
    {
        private const string Tag = nameof(ForecastWebModule);
        private const string Path = "https://api.openweathermap.org/data/2.5/weather";
        private const string ApiKey = "745ef1338e8989a79dd5166eb838122d";

        private readonly ILocationService _locationService;
        private readonly IHttpRequestFactory _httpRequestFactory;
        
        public ForecastWebModule(ILocationService locationService, IHttpRequestFactory httpRequestFactory)
        {
            _locationService = locationService;
            _httpRequestFactory = httpRequestFactory;
        }

        public void LoadData(Action<bool, ForecastDTO> completedCallback)
        {
            Debug.LogError($"Forecast");
            if (!_locationService.IsValid)
            {
                completedCallback?.Invoke(false, null);
                return;
            }

            Coords coords = _locationService.Coords;
            Uri uri = new Uri(Path).SetQuery(
                ("lat", coords.Latitude.ToString()),
                ("lon", coords.Longitude.ToString()),
                ("appid", ApiKey)
            );
            _httpRequestFactory.Get<ForecastDTO>(uri,
                response => { completedCallback?.Invoke(response.IsSuccess, response.Dto); });
        }
    }
}