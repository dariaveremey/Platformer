using System;
using System.Collections;
using P3D.Game.Player;
using UnityEngine;

namespace P3D.Game
{
    public class DeathZone : MonoBehaviour
    {
        public static Action OnDead;

        private void OnTriggerEnter(Collider other)
        {
            //TODO: Refactor in Future
            if (!other.CompareTag(Tags.Player))
                return;

            StartCoroutine(WaitCoroutine(other.GetComponent<PlayerDeath>()));
        }

        IEnumerator WaitCoroutine(PlayerDeath playerDeath)
        {

            playerDeath.Dead();
            
            yield return new WaitForSeconds(1);

            Reloader.Reload();
        }
    }
}