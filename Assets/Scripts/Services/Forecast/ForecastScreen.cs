﻿using TMPro;
using UnityEngine;

namespace Services.Forecast
{
    public class ForecastScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _cityLabel;
        [SerializeField] private TextMeshProUGUI _tempLabel;
        [SerializeField] private TextMeshProUGUI _windLabel;
        [SerializeField] private TextMeshProUGUI _dateLabel;
        [SerializeField] private TextMeshProUGUI _seaLevelLabel;

        // public void SetUp(ForecastDTO dto)
        // {
        //   
        // _cityLabel.text=$"{dto.Name}";
        // _tempLabel.text=$"Temp: {dto.MainDto.TempInKelvin} Kelvin";
        // _windLabel.text=$"Wind: {dto.WindDto.SpeedInMeters} m/s";
        // _dateLabel.text=$"Date {dto.DateTimeSince}";
        // _seaLevelLabel.text=  $"Sea level {dto.MainDto.SeaLevel}";
        // }
        
        public void SetUp(ForecastData data)
        {
          
            _cityLabel.text=$"{data.CityName}";
            _tempLabel.text=$"Temp: {data.TempInCelsius} C";
            _windLabel.text=$"Wind: {data.WindSpeedInMeters} m/s";
            _dateLabel.text=$"Date {data.Date}";
            _seaLevelLabel.text=  $"Sea level {data.SeaLevel}";
        }
    }
}