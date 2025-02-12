using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMapList : MonoBehaviour
{
    [SerializeField] private Transform _canvas;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private MapButtonType _loadType;

    public void Create()
    {
        GameObject button = Instantiate(_prefab, _canvas.transform);
        button.GetComponent<LoadMapList>().Fill(_loadType);
    }
}
