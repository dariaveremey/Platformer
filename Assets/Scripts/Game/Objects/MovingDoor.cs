using DG.Tweening;
using UnityEngine;
using Sequence = DG.Tweening.Sequence;

namespace P3D.Game
{
    public class MovingDoor : MonoBehaviour
    {
        [SerializeField] private Transform _fromTransform;
        [SerializeField] private Transform _toTransform;

        [Header("Initial Settings")]
        [SerializeField] private bool _needPlayOnStart = true;

        [Header("Animation Settings")]
        [SerializeField] protected float _delayPosition = 1f;

        [SerializeField] protected float _duration = 1f;
        [SerializeField] protected Ease _ease;
        
        private Tween _tween;
        private bool _isDone;
        public Transform FromTransform => _fromTransform;
        public Transform ToTransform => _toTransform;
        

        public void Move(Transform position)
        {
            _tween?.Kill();
            Sequence sequence = DOTween.Sequence();
            sequence.AppendInterval(_delayPosition);
            sequence.Append(transform
                .DOMove(position.position, _duration)
                .SetEase(_ease));
            _tween = sequence;
            Debug.Log("Try");
        }

        public void Shake()
        {
            transform.DOShakePosition(3f, 1, 10, 50, false, false);
        }
    }
}