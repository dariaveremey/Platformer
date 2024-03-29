﻿using Services.Config;
using Services.Forecast;
using Services.Location;
using Services.Persistente;
using Services.SceneLoading;
using Zenject;

namespace Infrastructure.Launcher
{
    public class BootstrapLauncher : BaseLauncher
    {
        private IPersistenceService _persistenceService;
        private IConfigService _configService;
        private ISceneLoadingService _sceneLoadingService;
        private IForecastService _forecastService;
        private ILocationService _locationService;

        [Inject]
        public void Construct(IPersistenceService persistenceService, IConfigService configService,
            ISceneLoadingService sceneLoadingService, IForecastService forecastService, ILocationService locationService)
        {
            _persistenceService = persistenceService;
            _configService = configService;
            _sceneLoadingService = sceneLoadingService;
            _forecastService = forecastService;
            _locationService = locationService;
        }

        protected override void Launch()
        {
            _persistenceService.Bootstrap();
            _configService.Bootstrap();
            _locationService.Bootstrap(() =>
            {
                _forecastService.LoadData();
                OnForecastLoaded();
            });
            
        }

        private void OnForecastLoaded()
        {
            _sceneLoadingService.Load(MenuLauncher.SceneName);
        }
    }
}