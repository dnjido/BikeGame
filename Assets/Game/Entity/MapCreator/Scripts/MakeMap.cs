using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;
using static Zenject.CheatSheet;

public class MakeMap : MonoBehaviour
{
    [SerializeField] private MapObjectsData objectsData;

    // Start is called before the first frame update
    void Awake() => Load();

    protected virtual void Load()
    {
        if (MapDataStorage.mapData == null) return;

        foreach (GameObject obj in FindObjectsOfType<GameObject>())
        {
            if (obj.tag != "MapObject") continue;
            Destroy(obj);
        }

        foreach (MapObjectData data in MapDataStorage.mapData.objectDataList)
        {
            GameObject prefab = objectsData.GetPrefab(data.type);

            if (prefab == null) continue;

            GameObject obj = MakeObject.Instantiate(prefab);

            obj.transform.position = data.position;
            obj.transform.rotation = data.rotation;
            obj.transform.localScale = data.scale;

            obj.name = data.type;
        }
    }
}