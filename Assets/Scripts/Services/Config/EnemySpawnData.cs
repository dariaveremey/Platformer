using System;
using System.Numerics;
using Game.Enemy;
using Vector3 = UnityEngine.Vector3;

namespace Services.Config
{
    [Serializable]
    public class EnemySpawnData
    {
        public string Id;
        public Vector3 Position;
        public EnemyType Type;

        public EnemySpawnData(string id, Vector3 position, EnemyType type)
        {
            Id = id;
            Position = position;
            Type = type;
        }
    }
}