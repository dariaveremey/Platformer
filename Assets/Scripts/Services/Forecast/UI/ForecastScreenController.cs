using Services.Assets;
using Services.UI;

namespace Services.Forecast.UI
{
    public class ForecastScreenController : ScreenController<ForecastScreen>
    {
        private readonly IForecastService _forecastService;

        public ForecastScreenController(IAssetsService assetsService, IForecastService forecastService) : base(
            assetsService)
        {
            _forecastService = forecastService;
        }
        protected override void OnShowBegin()
        {
            base.OnShowBegin();
            Screen.SetUp(_forecastService.Data);
        }
    }
}