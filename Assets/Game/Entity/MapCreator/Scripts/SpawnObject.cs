using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public interface IMapEditorPlaceObject
{
    public void Spawn(GameObject prefab, Transform transform);
    public void Remove();
}

public class SpawnObject : IMapEditorPlaceObject
{
    private Vector3 cursorPos => CursorPosition.RayEnd();
    private GameObject obejctHit => CursorPosition.RayObject();

    public void Spawn(GameObject prefab, Transform transform)
    {
        GameObject obj = Object.Instantiate(prefab, cursorPos, prefab.transform.rotation);

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.transform.localScale = transform.localScale;

        obj.name = prefab.name;
    }

    public void Remove()
    {
        if (obejctHit.tag != "MapObject") return;

        Object.Destroy(obejctHit);
    }
}
