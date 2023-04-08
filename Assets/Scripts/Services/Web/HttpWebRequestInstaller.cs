using System;
using UnityEngine.Networking;
using Zenject;

namespace Services.Web
{
    public class HttpWebRequestInstaller : Installer<HttpWebRequestInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IHttpRequestFactory>()
                .To<UnityHttpWebRequestFactory>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }
    }
}