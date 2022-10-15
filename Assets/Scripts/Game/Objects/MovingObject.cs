﻿using System;
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
        [SerializeField] private bool _isButtonClicked = true;
        [SerializeField] private bool _isLoop = true;

        [Header("Animation Settings")]
        [SerializeField] private float _delayInPosition = 1f;
        [SerializeField] private float _duration = 1f;
        [SerializeField] private Ease _ease;

        private Tween _tween;

        public List<Transform> Points => _points;
        
        private void Awake()
        {
            ButtonArea.OnButtonClicked += IsButtonClicked;

            if (!IsValid())
                return;

            transform.position = _points.First().position;
        }

        private void Start()
        {
            if (!IsValid())
                return;

            if (_needPlayOnStart)
                Move();
        }
        

        private void OnDestroy()
        {
            ButtonArea.OnButtonClicked -= IsButtonClicked;
        }
        
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

            if (_isLoop)
                sequence.SetLoops(-1);

            if (!_isButtonClicked)
                sequence.SetLoops(1);
            
            _tween = sequence;
        }

        private bool IsValid() =>
            _points != null && _points.Count > 1;

        private void IsButtonClicked(bool currentState)
        {
            _isButtonClicked = currentState;
            
            if(!_isButtonClicked)
                Move();
        }
    }
}