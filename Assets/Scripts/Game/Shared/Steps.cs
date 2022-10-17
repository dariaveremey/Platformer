using UnityEngine;

namespace P3D.Game
{   
    [RequireComponent(typeof(BoxCollider))] 
    public class Steps:MonoBehaviour
    {
        [SerializeField] private MovingObject _movingGameObject;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Tags.Player))
                return;

            _movingGameObject.Move();
        }
    }
}