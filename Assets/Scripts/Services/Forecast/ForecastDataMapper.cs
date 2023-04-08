using System;
using Services.Web;

namespace Services.Forecast
{
    public class ForecastDataMapper : BaseDataMapper<ForecastDTO, ForecastData>
    {
        public override ForecastData Map(ForecastDTO dto)
        {
            return new ForecastData()
            {
                CityName = dto.Name,
                TempInCelsius = KelvinToCelsius(dto.MainDto.TempInKelvin),
                SeaLevel = dto.MainDto.SeaLevel,
                WindSpeedInMeters = dto.WindDto.SpeedInMeters,
                Date = DateTime.FromFileTime(dto.DateTimeSince)
            };
        }

        private static float KelvinToCelsius(float dto) =>
            dto - 273.15f;
    }
}