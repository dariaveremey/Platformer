using Game.Systems.Enemy;
using Services.Config;
using Services.Persistente;
using Services.Save;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class TestEntryPoint : MonoBehaviour
    {
        [SerializeField] private EnemyFactory _enemyFactory;

        private void Start()
        {
            Init();
            CreateEnemySpawners();
            LoadDataToAll();
        }

        private void Init()
        {
            PersistenceService.Instance.Bootstrap();
            ConfigService.Instance.Bootstrap();
        }

        private void CreateEnemySpawners()
        {
            LevelConfig levelConfig = ConfigService.Instance.GetLevelConfig(SceneManager.GetActiveScene().name);
            foreach (EnemySpawnData enemySpawnData in levelConfig.EnemiesSpawnData)
            {
                _enemyFactory.CreateSpawner(enemySpawnData.Id, enemySpawnData.Type, enemySpawnData.Position);
            }
        }

        private void LoadDataToAll()
        {
            SaveLoadService.Instance.Load();
        }
    }
}