using UnityEngine;

namespace Services.Assets
{
    public class AssetsService : IAssetsService
    {
        private const string Tag = nameof(AssetsService);
        public T Load<T>(string path) where T : Object =>
            Resources.Load<T>(path);
    }

    public interface IAssetsService
    {
        T Load<T>(string path) where T : Object;
    }
}