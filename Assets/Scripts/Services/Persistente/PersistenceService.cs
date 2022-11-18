using System;
using UnityEngine;

namespace Services.Persistente
{
    public class PersistenceService : MonoBehaviour
    {
        private const string Tag = nameof(PersistenceService);
        private const string DataSaveKey = "Game/PersistenceData";
        private static PersistenceService _instance;
        public static PersistenceService Instance => _instance;

        public PersistenceData Data { get; private set; }

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
            var json = PlayerPrefs.GetString(DataSaveKey);
            if (string.IsNullOrEmpty(json))
            {
                Data = new PersistenceData();
            }
            else
            {
                try
                {
                    Data = JsonUtility.FromJson<PersistenceData>(json);
                }
                catch (Exception e)
                {
                   Debug.Log($"[{Tag},[{nameof(Bootstrap)}Can't deserialize data.Exception {e}]");
                   Data = new PersistenceData();
                }
            }
        }

        public void Save()
        {
            string json = JsonUtility.ToJson(Data);
            PlayerPrefs.SetString(DataSaveKey, json);
        }
    }
}