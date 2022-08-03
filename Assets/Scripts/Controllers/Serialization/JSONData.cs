using System.IO;
using UnityEngine;

namespace Labirint
{
    public class JSONData : ISaveData
    {
        public void SaveData(SObject go)
        {
            string fileJSON = JsonUtility.ToJson(go);
            File.WriteAllText(Path.Combine(Application.dataPath,$"{go.Name}JSONData.json"), fileJSON);
        }

        public SObject LoadData(SObject go)
        {
            SObject result = new SObject();
            
            if (!File.Exists(Path.Combine(Application.dataPath, $"{go.Name}JSONData.json")))
            {
                Debug.Log("Файл не найден");
                return result;
            }
            string json = File.ReadAllText(Path.Combine(Application.dataPath, $"{go.Name}JSONData.json"));
            result = JsonUtility.FromJson<SObject>(json);

            return result;
        }
    }
}
