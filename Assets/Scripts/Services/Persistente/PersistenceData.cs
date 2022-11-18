using System;
using System.Collections.Generic;
using Services.Persistente;
using UnityEngine;

namespace Services
{
    [Serializable]
    public class PersistenceData
    {
        public string SceneName;
        public List<PersistenceEnemyData> EnemiesData = new List<PersistenceEnemyData>();
        
    }
}