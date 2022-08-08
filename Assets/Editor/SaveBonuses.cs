using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Xml.Serialization;

namespace Labirint
{
    [CustomEditor(typeof(SaveBonusesView))]
    public class SaveBonuses : Editor
    {
        public static XmlSerializer serializer;
        public List<SVect3> SavingBonusesT = new List<SVect3>();

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            SaveBonusesView saveBonusesView = (SaveBonusesView)target;

            if(serializer == null)
            {
                serializer = new XmlSerializer(typeof(SVect3[]));
            }

            if (GUILayout.Button("Save"))
            {
                if(saveBonusesView.bonuses.Count > 0)
                {
                    foreach (Transform item in saveBonusesView.bonuses)
                    {
                        if (!SavingBonusesT.Contains(item.position))
                        {
                            SavingBonusesT.Add(item.position);
                        }
                    }
                }

                using (FileStream fs = new FileStream(saveBonusesView.SavingPath, FileMode.Create))
                {
                    serializer.Serialize(fs, SavingBonusesT.ToArray());
                }
            }
        }
    }
}