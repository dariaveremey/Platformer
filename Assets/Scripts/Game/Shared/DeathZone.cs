using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Shared
{
    public class DeathZone:MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            //TODO: Refactor in Future
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}