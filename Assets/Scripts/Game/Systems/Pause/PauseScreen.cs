using UnityEngine;
using Zenject;

namespace Game.Systems.Pause
{
    public class PauseScreen:MonoBehaviour
    {
        [SerializeField] private GameObject _innerObGameObject;
        private IPauseService _pauseService;

        [Inject]
        public void Construct(IPauseService pauseService)
        {
            _pauseService = pauseService;
        }
        private void Start()
        {
            _innerObGameObject.SetActive(false);
            _pauseService.OnChanged += PausedChanged;
        }

        private void OnDestroy()
        {
            _pauseService.OnChanged -= PausedChanged;
        }
        
        private void PausedChanged(bool isPaused)
        {
            _innerObGameObject.SetActive(isPaused);
        }
    }
}