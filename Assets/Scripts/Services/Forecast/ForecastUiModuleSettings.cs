using UnityEngine;

namespace Services.Forecast
{
    [CreateAssetMenu(fileName = nameof(ForecastUiModuleSettings),menuName = "Ui/ForecastUiModuleSettings")]
    public class ForecastUiModuleSettings : ScriptableObject
    {
        [SerializeField] private ForecastScreen _screenPrefab;

        public ForecastScreen ScreenPrefab => _screenPrefab;
    }
}