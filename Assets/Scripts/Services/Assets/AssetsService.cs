using UnityEngine;

namespace Services.Assets
{
    public class AssetsService : MonoBehaviour
    {
        private const string Tag = nameof(AssetsService);
        private static AssetsService _instance;

        public static AssetsService Instance => _instance;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public T Load<T>(string path) where T : Object =>
            Resources.Load<T>(path);
    }
}