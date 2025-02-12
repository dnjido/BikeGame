using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private float _zoomSpeed = 2f;
    [SerializeField] private float _minZoom = 5f;
    [SerializeField] private float _maxZoom = 20f;

    void Update() => Scroll();

    private bool ClampZoom(Vector3 zoom)
    {
        return zoom.z < _minZoom && zoom.z > _maxZoom;
    }


    private void Scroll()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput == 0f) return;

        Vector3 newZoom = transform.forward * (scrollInput * _zoomSpeed);

        if (ClampZoom(transform.position + newZoom))
        {
            transform.position += newZoom;
        }
    }
}
