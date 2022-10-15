using System;
using UnityEngine;

namespace P3D.Game
{
    public class ButtonArea:MonoBehaviour
    {
        public static Action<bool> OnButtonClicked;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Tags.Player))
                return;

            OnButtonClicked?.Invoke(false);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag(Tags.Player))
                return;
            OnButtonClicked?.Invoke(true);
        }
    }
}