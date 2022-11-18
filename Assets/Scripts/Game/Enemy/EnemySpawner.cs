using System;
using Services;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemySpawner : MonoBehaviour,ISaveLoadDataPiece
    {
        public string Id { get; private set; }

        public void SetId(string value)
        {
            Id = value;
        }
        public void Save(PersistenceData data)
        {
            //TODO: Check if enemy dead,then don't spawn
        }

        public void Load(PersistenceData data)
        {
           
        }
    }
}