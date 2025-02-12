using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface ISetCanMove
{
    public bool SetMove(bool canMove);
}

public class PlayerConroller : MonoBehaviour, ISetCanMove
{

    private bool _canMove = true;
    [SerializeField]private PlayerConrollerModel _playerSpeed;

    private bool onGUI => EventSystem.current.IsPointerOverGameObject();
    private Rigidbody _rigidbody => GetComponent<Rigidbody>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && !onGUI) MoveSelector(1);
        if (Input.GetMouseButton(1) && !onGUI) MoveSelector(-1);
    }

    private void MoveSelector(float mult)
    {
        if (IsGrounded()) Run();
        else Rotate(mult);
    }

    private void Run()
    {
        if (_rigidbody.velocity.magnitude >= _playerSpeed.maxSpeed) return;
        _rigidbody.AddForce(transform.right * _playerSpeed.speed);
    }

    private void Rotate(float mult)
    {
        _rigidbody.AddTorque(transform.forward * _playerSpeed.turnSpeed * mult);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f, 1 << 7);
    }

    public bool SetMove(bool canMove) =>
        _canMove = canMove;
}

[System.Serializable]
public class PlayerConrollerModel
{
    [SerializeField] public float speed = 1500f;
    [SerializeField] public float turnSpeed = 1000f;
    [SerializeField] public float maxSpeed = 20f;
}
