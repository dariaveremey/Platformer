using UnityEngine;
using UnityEngine.SceneManagement;

namespace P3D.Game
{
    public class DeathZone:MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            //TODO: Refactor in Future
           Reloader.Reload();
        }
    }
}