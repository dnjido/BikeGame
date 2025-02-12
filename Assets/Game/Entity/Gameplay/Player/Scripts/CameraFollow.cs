using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISetCameraTarget
{
    public void SetTarget(GameObject target);
}

public class CameraFollow : MonoBehaviour, ISetCameraTarget
{
    [SerializeField] private GameObject _object;

    private float _zPos => transform.position.z;
    private Vector3 _objectPos => _object.transform.position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!_object) return;
        transform.position = new(_objectPos.x, _objectPos.y, _zPos);
    }

    public void SetTarget(GameObject target) => 
        _object = target;
}
