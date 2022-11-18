using UnityEngine;

namespace Game.Systems.Pause
{
    public class PauseScreen:MonoBehaviour
    {
        [SerializeField] private GameObject _innerObGameObject;

        private void Start()
        {
            _innerObGameObject.SetActive(false);
            PauseService.Instanse.OnChanged += PausedChanged;
        }

        private void OnDestroy()
        {
            PauseService.Instanse.OnChanged -= PausedChanged;
        }
        
        private void PausedChanged(bool isPaused)
        {
            _innerObGameObject.SetActive(isPaused);
        }
    }
}