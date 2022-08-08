using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

#if UNITY_EDITOR
    public class SaveBonusesView : MonoBehaviour
    {
        public List<Transform> bonuses = new List<Transform>();
        private string _savePath;
        public string DirectoryName;
        public string SceneName;

        public string SavingPath { get => _savePath; set => _savePath = value; }

        private void OnDrawGizmos()
        {
            SceneName = EditorSceneManager.GetActiveScene().name;
            DirectoryName = "Bonuses Data";
            SavingPath = Path.Combine(Application.dataPath + "/" + DirectoryName, "BonusesData_" + SceneName + ".xml");
        }
    }
#endif
