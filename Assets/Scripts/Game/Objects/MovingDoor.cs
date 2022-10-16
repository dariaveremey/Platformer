using DG.Tweening;
using UnityEngine;

namespace P3D.Game
{
    public class MovingDoor : MonoBehaviour
    {
        private void Awake()
        {
            ButtonArea.OnButtonClicked += Shake;
        }

        private void OnDestroy()
        {
            ButtonArea.OnButtonClicked -= Shake;
        }

        private void Shake()
        {
            transform.DOShakePosition(4f, 1, 10, 90, false, false);
        }
    }
}