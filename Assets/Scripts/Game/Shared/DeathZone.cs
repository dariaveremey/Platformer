using System;
using System.Collections;
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

            StartCoroutine(WaitCoroutine());
        }

        IEnumerator WaitCoroutine()
        {
            OnDead?.Invoke();

            yield return new WaitForSeconds(1);

            Reloader.Reload();
        }
    }
}