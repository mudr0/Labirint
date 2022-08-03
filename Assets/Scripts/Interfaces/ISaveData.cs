using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labirint
{
    public interface ISaveData
    {
        void SaveData(SObject gameObject);

        SObject LoadData(SObject gameObject);
    }
}
