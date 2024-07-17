using UnityEngine;
using UnityEngine.InputSystem;

// 1st example of the Input System and using Input Actions

public class PlayerController1 : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpStrength = 15;

    //Assign Input Action variables
    private InputAction _moveAction;
    private InputAction _jumpAction;

    private Vector2 _move;
    private Rigidbody _rb;
    private bool _isJumping;

    void Start()
    {
        //Assign your Input Action references
        _moveAction = InputSystem.actions.FindAction("Move");
        _jumpAction = InputSystem.actions.FindAction("Jump");

        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Read the player move input
        _move = _moveAction.ReadValue<Vector2>();

        //Move the player left or right on the X axis
        transform.position = new Vector3(transform.position.x + (_move.x * Time.deltaTime * _speed), transform.position.y, transform.position.z);

        if (_jumpAction.IsPressed())
        {
            _isJumping = true;
        }
        else
        {
            _isJumping = false;
        }
    }

    //Jump by adding up force to the RigidBody
    private void FixedUpdate()
    {
        if (_isJumping)
        {
            _rb.AddForce(Vector3.up * _jumpStrength);
        }
    }
}
