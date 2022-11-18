﻿using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace P3D.Game
{
    public class ButtonArea : MonoBehaviour
    {
        [SerializeField] private MovingObject _movingGameObject;
        [SerializeField] private float _movingButtonYDelta = 0.21f;

        private Tween _animation;
        private float _startPosition;
        private float _endPosition;

        private void Awake()
        {
            _startPosition = transform.position.y;
            _endPosition = _startPosition - _movingButtonYDelta;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Tags.Player))
                return;

            _animation?.Kill();
            _animation = transform.DOMoveY(_endPosition, 1);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag(Tags.Player))
                return;

            _animation?.Kill();
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOMoveY(_startPosition, 1));
            sequence.AppendInterval(3);
            //sequence.OnComplete(() => _movingGameObject.MoveInverse());
            _animation = sequence;
        }

        private IEnumerator WaitCoroutine()
        {
            _movingGameObject.Shake();

            yield return new WaitForSeconds(2);

            _movingGameObject.Move();
        }
    }
}