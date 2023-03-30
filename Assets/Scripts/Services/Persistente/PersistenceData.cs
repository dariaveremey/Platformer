using System;
using System.Collections.Generic;
using Services.Persistente;

namespace Services
{
    [Serializable]
    public class PersistenceData
    {
        public string SceneName;
        public List<PersistenceEnemyData> EnemiesData = new List<PersistenceEnemyData>();
        
    }
}