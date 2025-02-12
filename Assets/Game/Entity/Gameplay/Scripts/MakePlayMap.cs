using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using UnityEngine;
using Zenject;

public class MakePlayMap : MakeMap
{
    [SerializeField] private GameObject _playerPrefab;

    private GameObject _startPoint => FindObjectOfType<StartPoint>().gameObject;
    // Start is called before the first frame update
    void Awake() => Load();

    protected override void Load()
    {
        try
        {
            base.Load();
            Vector3 startPoint = _startPoint.transform.position + Vector3.up;
            MakeObject.Instantiate(_playerPrefab, startPoint);
        }
        catch { Debug.LogWarning("Start object not found"); }
    }
}