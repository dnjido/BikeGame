using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public interface IMapEditorCursorObject
{
    public Transform prefabTransform { get; }

    public GameObject SpawnObject(GameObject prefab);
    public void SetPosition();
    public void SetScale(int mult);
    public void SetRotate(int mult);
}

public class CursorObject : IMapEditorCursorObject
{
    private GameObject _cursorObject;

    private Vector3 cursorPos => CursorPosition.SidePosition();
    public Transform prefabTransform => _cursorObject.transform;

    public CursorObject(GameObject prefab) => SpawnObject(prefab);

    public GameObject SpawnObject(GameObject prefab)
    {
        if(_cursorObject) Object.Destroy(_cursorObject);
        GameObject obj = Object.Instantiate(prefab, cursorPos, prefab.transform.rotation);
        obj.tag = "Untagged";
        _cursorObject = obj;

        return obj;
    }

    public void SetPosition()
    {
        Vector3 pos = cursorPos;
        Vector3 rounded = new( 
            Round(pos.x, .25f), 
            Round(pos.y, .25f), 
            Round(pos.z, .25f) );

        _cursorObject.transform.position = rounded;
    }

    public void SetScale(int mult)
    {
        Vector3 scale = _cursorObject.transform.localScale;
        scale.x += .1f * mult * Time.deltaTime * 100;
        //scale.x = Round(scale.x, .25f);
        scale.x = Mathf.Clamp(scale.x, .1f, 10);

        _cursorObject.transform.localScale = scale;
    }

    public void SetRotate(int mult)
    {
        Vector3 rotate = _cursorObject.transform.rotation.eulerAngles;
        rotate.z += 1f * mult * Time.deltaTime * 100;
        //rotate.z = Round(rotate.z, 1);

        _cursorObject.transform.eulerAngles = rotate;
    }

    private float Round(float number, float round) => Mathf.Round(number / round) * round;
}
