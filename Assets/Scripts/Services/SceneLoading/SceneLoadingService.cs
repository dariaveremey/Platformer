using System.Collections;
using Infrastructure.Launcher;
using Services.Coroutine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services.SceneLoading
{
    public class SceneLoadingService : ISceneLoadingService
    {
        private ICoroutineRunner _coroutineRunner;
        private BaseLauncher _launcher;

        public SceneLoadingService(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string sceneName)
        {
            _coroutineRunner.StartCoroutine(LoadAsync((sceneName)));
        }

        public void SetLauncher(BaseLauncher launcher) =>
            _launcher = launcher;

        private IEnumerator LoadAsync(string sceneName)
        {
            //TODO:Show loading screen
            AsyncOperation loaAsyncOperation = SceneManager.LoadSceneAsync(sceneName);
            while (!loaAsyncOperation.isDone)
                yield return null;
  
            
            while (!_launcher.IsReady)
                yield return null;


            //TODO:Hide loading screen
        }
    }
}