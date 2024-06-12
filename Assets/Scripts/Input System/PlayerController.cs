using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5;

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
        transform.position = new Vector3(transform.position.x + (_move.x * Time.deltaTime * speed), transform.position.y, transform.position.z);
        if (_jumpAction.IsPressed())
        {
            _rb.AddForce(Vector3.up * 5);
        }
    }
}
