﻿using Services.Assets;
using Services.Config;
using Services.Coroutine;
using Services.Persistente;
using Services.SceneLoading;
using Zenject;

namespace Infrastructure.Installers
{
    public class ProjectInstaller:MonoInstaller
    {
        public override void InstallBindings()
        {
            PersistenceServiceInstaller.Install(Container);
           ConfigServiceInstaller.Install(Container);
           CoroutineRunnerInstaller.Install(Container);
           SceneLoadingServiceInstaller.Install(Container);
           AssetsServiceInstaller.Install(Container);
        }
    }
}