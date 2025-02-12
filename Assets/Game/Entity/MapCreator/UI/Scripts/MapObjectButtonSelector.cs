using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MapObjectButtonSelector : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private IMapEditorPrefabSelect _prefabChanger;
    // Start is called before the first frame update


    [Inject]
    private void Init(IMapEditorPrefabSelect prefabChange)
    {
        _prefabChanger = prefabChange;
    }

    // Update is called once per frame
    public void Click()
    {
        _prefabChanger.SetPrefab(_prefab);
    }
}
