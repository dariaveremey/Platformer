using System;
using UnityEngine;

namespace Services.Forecast
{
    public class ForecastService : IForecastService
    {
        private readonly ForecastWebModule _forecastWebModule;
        private readonly ForecastUiModule _uiModule;
        private readonly ForecastDataMapper _dataMapper;

        public ForecastService(ForecastWebModule forecastWebModule, ForecastUiModule uiModule, ForecastDataMapper forecastDataMapper)
        {
            _forecastWebModule = forecastWebModule;
            _uiModule = uiModule;
            _dataMapper = forecastDataMapper;
        }

        public event Action OnReady;
        public bool IsReady { get; private set; }
        private ForecastData Data { get; set; }

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

        public void ShowScreen()
        {
            if (!IsReady)
                return;
            _uiModule.ShowScreen(Data);
            {
                Debug.Log($"ShowScreen");
            }
        }

        public void HideScreen()
        {
            if (!IsReady)
                return;
            _uiModule.HideScreen();
            Debug.Log($"HideScreen");
        }
    }
}