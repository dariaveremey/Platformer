using Game.Enemy;
using Services.Assets;
using Services.Config;
using Services.Save;
using UnityEngine;

namespace Game.Systems.Enemy
{
    public class EnemyFactory : MonoBehaviour
    {
        public GameObject CreateEnemy(EnemyType enemyType, Vector3 position)
        {
            EnemyConfig enemyConfig = ConfigService.Instance.GetEnemyConfig(enemyType);
            GameObject enemy = Instantiate(enemyConfig.Prefab, position, Quaternion.identity);
            EnemyHp enemyHp = enemy.GetComponent<EnemyHp>();
            enemyHp.Current = enemyConfig.CurrentHp;
            enemyHp.Max = enemyConfig.MaxHp;
            return enemy;
        }

        public GameObject CreateSpawner(string id, EnemyType enemyType, Vector3 position)
        {
            GameObject spawnerPrefab = AssetsService.Instance.Load<GameObject>(AssetPath.EnemySpawner);
            EnemySpawner spawner = Instantiate(spawnerPrefab, position, Quaternion.identity).GetComponent<EnemySpawner>();
            spawner.Construct(this);
            spawner.SetId(id);
            spawner.SetEnemyType(enemyType);
            Register(spawner.gameObject);
            return spawner.gameObject;
        }

        private void Register(GameObject go)
        {
            ISaveLoadDataPiece[] saveLoadDataPieces = go.GetComponentsInChildren<ISaveLoadDataPiece>();

            foreach (ISaveLoadDataPiece saveLoadDataPiece in saveLoadDataPieces)
            {
                SaveLoadService.Instance.AddSaveLoadPiece(saveLoadDataPiece);
            }
        }
    }
}