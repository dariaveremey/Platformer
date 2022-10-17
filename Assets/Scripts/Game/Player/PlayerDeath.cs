using UnityEngine;

namespace P3D.Game.Player
{
    public class PlayerDeath : MonoBehaviour
    {
        [Header("Particle")]
        [SerializeField] private GameObject _particle;

        private void Awake()
        {
            DeathZone.OnDead += SpawnVfx;
        }

        private void OnDisable()
        {
            DeathZone.OnDead -= SpawnVfx;
        }

        private void SpawnVfx()
        {
            Instantiate(_particle, transform.position, Quaternion.identity);
        }
    }
}