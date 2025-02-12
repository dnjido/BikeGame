using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public static class MakeObject
{
    public static DiContainer _container { get; private set; }

    public static void SetContainer(DiContainer container)
    {
        _container = container;
    }

    public static GameObject Instantiate(GameObject prefab)
    {
        return _container.InstantiatePrefab(prefab);
    }

    public static GameObject Instantiate(GameObject prefab, Transform transform)
    {
        GameObject obj = _container.InstantiatePrefab(prefab);
        obj.transform.parent = transform;
        return obj;
    }

    public static GameObject Instantiate(GameObject prefab, Vector3 position)
    {
        GameObject obj = _container.InstantiatePrefab(prefab);
        obj.transform.position = position;
        return obj;
    }

    public static GameObject Instantiate(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        GameObject obj = _container.InstantiatePrefab(prefab);
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        return obj;
    }
}
