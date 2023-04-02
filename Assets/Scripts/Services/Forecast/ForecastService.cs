using System;
using UnityEngine;

namespace Services.Forecast
{
    public class ForecastService : IForecastService
    {
        private readonly ForecastWebModule _forecastWebModule;
        private readonly ForecastUiModule _uiModule;

        public ForecastService(ForecastWebModule forecastWebModule, ForecastUiModule uiModule)
        {
            _forecastWebModule = forecastWebModule;
            _uiModule = uiModule;
        }

        public event Action OnReady;
        public bool IsReady { get; private set; }
        private ForecastDTO Dto { get; set; }

        public void LoadData(Action completeCallback)
        {
            _forecastWebModule.LoadData((isSuccess, dto) =>
            {
                //TODO: Map data
                if (isSuccess)
                {
                    //TODO: Map data
                    Dto = dto;
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
            _uiModule.ShowScreen(Dto);
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