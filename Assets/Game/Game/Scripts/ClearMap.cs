using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearMap : MonoBehaviour
{
    public void Clear()
    {
        MapDataStorage.RemoveData();
    }
}
