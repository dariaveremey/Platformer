using Game.Systems.Enemy;
using Services.Config;
using Services.Persistente;
using Services.Save;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class TestEntryPoint:MonoBehaviour
    {
        [SerializeField] private EnemyFactory _enemyFactory;
        private void Start()
        {
            Init();
            SpawnAllEnemies();
            LoadDataToAll();
        }
        

        private void Init()
        {
            PersistenceService.Instance.Bootstrap();
            ConfigService.Instance.Bootstrap();
        }
        private void LoadDataToAll()
        {
            SaveLoadService.Instance.Load();
        }
        private void SpawnAllEnemies()
        {
            LevelConfig levelConfig = ConfigService.Instance.GetLevelConfig(SceneManager.GetActiveScene().name);
            foreach (EnemySpawnData enemySpawnData in levelConfig.EnemiesSpawnData)
            {
                _enemyFactory.Create(enemySpawnData.Id, enemySpawnData.Type, enemySpawnData.Position);
            }
        }
    }
}

