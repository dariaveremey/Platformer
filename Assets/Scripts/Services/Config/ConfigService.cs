using System.Collections.Generic;
using System.Linq;
using Game.Enemy;
using Services.Assets;
using UnityEngine;

namespace Services.Config
{
    public class ConfigService : MonoBehaviour
    {
        private const string Tag = nameof(ConfigService);
      
        private static ConfigService _instance;

        private Dictionary<EnemyType, EnemyConfig> _enemyConfigsByType;
        private Dictionary<string, LevelConfig> _levelConfigBySceneName;
        public static ConfigService Instance => _instance;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void Bootstrap()
        {
            _enemyConfigsByType = Resources
                .LoadAll<EnemyConfig>(AssetPath.EnemiesConfigsPath)
                .ToDictionary(x => x.EnemyType, x => x);
            _levelConfigBySceneName = Resources
                .LoadAll<LevelConfig>(AssetPath.LevelConfigsPath)
                .ToDictionary(x => x.SceneName, x => x);
        }

        public EnemyConfig GetEnemyConfig(EnemyType enemyType)
        {
            if (!_enemyConfigsByType.ContainsKey(enemyType))
            {
                Debug.LogError($"[{Tag},{nameof(GetEnemyConfig)}] there is no config for {enemyType}");
                return null;
            }

            return _enemyConfigsByType[enemyType];
        }   
        
        public LevelConfig GetLevelConfig(string sceneName)
        {
            if (!_levelConfigBySceneName.ContainsKey(sceneName))
            {
                Debug.LogError($"[{Tag},{nameof(GetLevelConfig)}] there is no config for {sceneName}");
                return null;
            }

            return _levelConfigBySceneName[sceneName];
        }
    }
}