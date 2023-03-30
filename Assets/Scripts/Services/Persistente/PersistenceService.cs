using System;
using UnityEngine;

namespace Services.Persistente
{
    public class PersistenceService : IPersistenceService
    {
        private const string Tag = nameof(PersistenceService);
        private const string DataSaveKey = "Game/PersistenceData";
        public PersistenceData Data { get; private set; }

        public PersistenceService()
        {
            Debug.LogError($"Persistant Service");
        }

        public void Bootstrap()
        {
            Debug.LogError($"Persistant Bootstrap");
            string json = PlayerPrefs.GetString(DataSaveKey);
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