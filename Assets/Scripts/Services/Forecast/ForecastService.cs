using System;
using UnityEngine;

namespace Services.Forecast
{
    public class ForecastService : IForecastService
    {
        private readonly ForecastWebModule _forecastWebModule;
        private readonly ForecastDataMapper _dataMapper;

        public ForecastService(ForecastWebModule forecastWebModule, ForecastDataMapper forecastDataMapper)
        {
            _forecastWebModule = forecastWebModule;
            _dataMapper = forecastDataMapper;
        }

        public event Action OnReady;
        public bool IsReady { get; private set; }
        public ForecastData Data { get; private set; }

        public void LoadData(Action completeCallback)
        {
            _forecastWebModule.LoadData((isSuccess, dto) =>
            {
                //TODO: Map data
                if (isSuccess)
                {
                    //TODO: Map data
                    Data = _dataMapper.Map(dto);
                    IsReady = true;
                    OnReady?.Invoke();
                }

                completeCallback?.Invoke();
            });
        }
        
    }
}