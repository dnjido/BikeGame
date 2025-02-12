using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _edgeThickness = 10f;

    void Update() => Move();

    private void Move()
    {
        Vector3 mov = Vector3.zero;
        Vector3 pos = Input.mousePosition;

        if (pos.x <= _edgeThickness)
            mov.x = -1;
        else if (pos.x >= Screen.width - _edgeThickness)
            mov.x = 1;
        if (pos.y <= _edgeThickness)
            mov.y = -1;
        else if (pos.y >= Screen.height - _edgeThickness)
            mov.y = 1;

        transform.position += mov * _moveSpeed * Time.deltaTime;
    }
}