using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Zenject;

public class MapEditorClick : MonoBehaviour//, IMapEditorSetPrefab
{
    [SerializeField] private MapObjectsData objectsData;
    [SerializeField] private GameObject _prefab;
    private IMapEditorPrefabChange _prefabChanger;

    private IMapEditorPlaceObject _spawnObject;
    private IMapEditorCursorObject _cursorObject;

    private bool onGUI => EventSystem.current.IsPointerOverGameObject();

    [Inject]
    private void Init(IMapEditorPrefabChange prefabChange)
    {
        _prefabChanger = prefabChange;
    }

    void Awake()
    {
        _cursorObject = new CursorObject(_prefab);
        _spawnObject = new SpawnObject();
        _prefabChanger.PrefabChangeEvent += SetPrefab;
    }

    void Update()
    {
        _cursorObject.SetPosition();
        Click();
        Transform();
    }

    private void Click()
    {
        if (Input.GetMouseButtonDown(0) && !onGUI) _spawnObject.Spawn(_prefab, _cursorObject.prefabTransform);
        if (Input.GetMouseButtonDown(1) && !onGUI) _spawnObject.Remove();
    }

    private void Transform()
    {
        if (Input.GetKey("a")) _cursorObject.SetScale(-1);
        if (Input.GetKey("d")) _cursorObject.SetScale(1);

        if (Input.GetKey("q")) _cursorObject.SetRotate(1);
        if (Input.GetKey("e")) _cursorObject.SetRotate(-1);
    }

    public void SetPrefab(GameObject prefab)
    {
        _prefab = prefab;
        _cursorObject.SpawnObject(prefab);
    }
}
