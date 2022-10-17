using System;
using UnityEngine;

namespace P3D.Game
{
    [RequireComponent(typeof(Collider))]
    public class StandArea : MonoBehaviour
    {
        [SerializeField] private bool _needTrigger;
        
        private Transform _previousParent;

        public static Action OnStepStood;

        private void Awake()
        {
            Collider col = GetComponent<Collider>();
            col.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Tags.Player))
                return;

            _previousParent = other.transform.parent;
            other.transform.SetParent(transform);
            if (_needTrigger)
                OnStepStood?.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag(Tags.Player))
                return;

            other.transform.SetParent(_previousParent);
            _previousParent = null;
        }
    }
}