using System;
using System.Linq;
using Game.Systems.Pause;
using Services;
using Services.Persistente;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Game.Enemy
{
    public class EnemyHp : MonoBehaviour, ISaveLoadDataPiece
    {
        [SerializeField] private int _max;
        [SerializeField] private int _current;

        public int Current
        {
            get => _current;
            set => _current = value;
        }

        public int Max { get; private set; }
        public string Id { get; private set; }

        private void Awake()
        {
            Max = _max;
            Current = Max;
        }

        public void Save(PersistenceData data)
        {
            PersistenceEnemyData persistenceEnemyData = data.EnemiesData.FirstOrDefault(x => x.Id == Id);
            if (persistenceEnemyData == null)
            {
                Debug.LogWarning($"{name} no  data  loaded");
                return;
            }

            Current = persistenceEnemyData.Hp;
        }

        public void Load(PersistenceData data)
        {
            PersistenceEnemyData persistenceEnemyData = data.EnemiesData.FirstOrDefault(x => x.Id == Id);
            if (persistenceEnemyData == null)
            {
                persistenceEnemyData = new PersistenceEnemyData()
                {
                    Id = Id
                };
                data.EnemiesData.Add(persistenceEnemyData);
            }

            persistenceEnemyData.Hp = Current;
        }

        public void SetId(string id) =>
            Id = id;

    }
}

