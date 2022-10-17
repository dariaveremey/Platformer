using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace P3D.Game
{
    public class ButtonArea : MonoBehaviour
    {
        [SerializeField] private MovingObject _movingGameObject;
        [SerializeField] private float _pushingButton = 0.21f;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Tags.Player))
                return;

            SwitchOn();
            StartCoroutine(WaitCoroutine());
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag(Tags.Player))
                return;

            SwitchOff();
        }

        private IEnumerator WaitCoroutine()
        {
            _movingGameObject.Shake();

            yield return new WaitForSeconds(2);

            _movingGameObject.Move();
        }

        private void SwitchOn()
        {
            transform.DOMoveY(transform.position.y - (_pushingButton), 1);
        }

        private void SwitchOff()
        {
            transform.DOMoveY(transform.position.y + (_pushingButton), 1);
        }
    }
}