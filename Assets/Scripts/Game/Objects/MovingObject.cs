using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using Sequence = DG.Tweening.Sequence;

namespace P3D.Game
{
    public class MovingObject : MonoBehaviour
    {
        [SerializeField] private List<Transform> _points;

        [Header("Initial Settings")]
        [SerializeField] private bool _needPlayOnStart = true;
        [SerializeField] private bool _isLoop = true;

        [Header("Animation Settings")]
        [SerializeField] protected float _delayInPosition = 1f;
        [SerializeField] protected float _duration = 1f;
        [SerializeField] protected int _animationIndex = -1;
        [SerializeField] protected Ease _ease;

        private Tween _tween;
        private Tween _tweenButton;

        public List<Transform> Points => _points;

        private void Awake()
        {
            if (!IsValid())
                return;

            transform.position = _points.First().position;
        }

        private void Start()
        {
            if (!IsValid())
                return;

            if (_needPlayOnStart && _isLoop)
                Move();
        }

        private bool IsValid() =>
            _points != null && _points.Count > 1;

        public void Move()
        {
            _tween?.Kill(true);

            Sequence sequence = DOTween.Sequence();

            for (int i = 1; i < _points.Count; i++)
            {
                Transform point = _points[i];
                sequence.AppendInterval(_delayInPosition);
                sequence.Append(transform
                    .DOMove(point.position, _duration)
                    .SetEase(_ease));
            }

            sequence.AppendInterval(_delayInPosition);
            sequence.Append(transform
                .DOMove(_points.First().position, _duration)
                .SetEase(_ease));

            sequence
                .SetUpdate(UpdateType.Fixed);

            sequence.SetLoops(_animationIndex);
            _tween = sequence;
        }

        public void Shake()
        {
            transform.DOShakePosition(3f, 1, 10, 50, false, false);
        }
    }
}