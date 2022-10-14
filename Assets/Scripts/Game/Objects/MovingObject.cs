using UnityEngine;

namespace Game.Objects
{
    public class MovingObject:MonoBehaviour
    {
        [SerializeField] private Transform _fromTransform;
        [SerializeField] private Transform _toTransform;

        public Transform FromTransform => _fromTransform;
        public Transform ToTransform => _toTransform;

    }
}