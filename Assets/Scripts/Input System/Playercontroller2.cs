using UnityEngine;
using UnityEngine.InputSystem;

// 2nd example of the Input System and using Player Input componant with Messages (OnMove and OnJump) 

public class PlayerController2 : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpStrength = 1;

    private Vector2 _move; 


    void Update()
    {      
        //move player
        transform.position = new Vector3(transform.position.x + (_move.x * Time.deltaTime * _speed), transform.position.y, transform.position.z);
    }  
    
    public void OnMove(InputValue value)
    {
        _move = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            print("Jumping");
            // your jump code
        }       
    }
}
