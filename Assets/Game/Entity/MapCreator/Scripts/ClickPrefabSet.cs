using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapEditorPrefabSelect
{
    public void SetPrefab(GameObject prefab);
}

public interface IMapEditorPrefabChange
{
    public delegate void PrefabChangeDelegate(GameObject prefab);
    public event PrefabChangeDelegate PrefabChangeEvent;
}

public class ClickPrefabSet : IMapEditorPrefabChange, IMapEditorPrefabSelect
{
    public event IMapEditorPrefabChange.PrefabChangeDelegate PrefabChangeEvent;

    public void SetPrefab(GameObject prefab)
    {
        PrefabChangeEvent.Invoke(prefab);
    }
}
