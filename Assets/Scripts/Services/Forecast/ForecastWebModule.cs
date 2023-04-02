using System;
using System.Collections;
using Newtonsoft.Json;
using Services.Web;
using UnityEngine;
using UnityEngine.Networking;

namespace Services.Forecast
{
    public class ForecastWebModule : MonoBehaviour
    {
        private const string Tag = nameof(ForecastWebModule);
        private const string Path = "https://api.openweathermap.org/data/2.5/weather";
        private const string ApiKey = "745ef1338e8989a79dd5166eb838122d";
        private Action<bool, ForecastDTO> _completeCallback;

        public void LoadData(Action<bool, ForecastDTO> completedCallback)
        {
            _completeCallback = completedCallback;
            float lat = 53.893009f;
            float lon = 27.567444f;
            Uri uri = new Uri(Path).SetQuery(
                ("lat", lat.ToString()),
                ("lon", lon.ToString()),
                ("appid", ApiKey)
            );
            StartCoroutine(GetRequest(uri));
        }

        IEnumerator GetRequest(Uri uri)
        {
            using UnityWebRequest webRequest = UnityWebRequest.Get(uri);
            // Request and wait for the desired page.
            webRequest.timeout = 5;
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(": Error: " + webRequest.error);
                    _completeCallback?.Invoke(false, null);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(": HTTP Error: " + webRequest.error);
                    _completeCallback?.Invoke(false, null);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);
                    ParseDto(webRequest.downloadHandler.text);
                    break;
            }

            Debug.LogError($"Request ended");
        }

        private void ParseDto(string json)
        {
            var isSuccess = TryDeserializeJson(json, out ForecastDTO dto);
            Debug.LogError($"TryDeserializeJson dto '{dto}'");
            _completeCallback?.Invoke(isSuccess,dto);
        }

        private bool TryDeserializeJson<T>(string json, out T data)
        {
            data = default(T);
            try
            {
                data = JsonConvert.DeserializeObject<T>(json);
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError($"[{Tag}:{nameof(TryDeserializeJson)}]: Fail deserialize to '{typeof(T)}' " +
                    $"from json'{json}' with exception '{e}'");
            }

            return false;
        }
    }
}