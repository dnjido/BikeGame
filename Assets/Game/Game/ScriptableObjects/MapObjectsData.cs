using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "MapObjectsData", menuName = "ScriptableObjects/Map Objects Data")]
public class MapObjectsData : ScriptableObject
{
    [SerializeField]public MapObjects[] mapObjects;

    public GameObject GetPrefab(string name)
    {
        try { return mapObjects.FirstOrDefault(c => c.name == name).prefab; }
        catch { return null; }
    }
}

[System.Serializable]
public class MapObjects
{
    [SerializeField] public string name;
    [SerializeField] public GameObject prefab;
    [SerializeField] public bool canTransform, single;
}
