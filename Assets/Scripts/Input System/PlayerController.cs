using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpStrength = 15;

    private InputAction _moveAction;
    private InputAction _jumpAction;
    private Vector2 _move;
    private Rigidbody _rb;

    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("move");
        _jumpAction = InputSystem.actions.FindAction("jump");
        _rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        _move = _moveAction.ReadValue<Vector2>();
        transform.position = new Vector3(transform.position.x + (_move.x * Time.deltaTime * _speed), transform.position.y, transform.position.z);

    }

    private void FixedUpdate()
    {
        if (_jumpAction.IsPressed())
        {
            _rb.AddForce(Vector3.up * _jumpStrength);
        }       
    }
}
