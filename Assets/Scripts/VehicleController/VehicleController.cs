using System.Linq;
using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

namespace PixelBru.HeavyD
{
    public class VehicleController : MonoBehaviour
    {
        [Header("SETTINGS")]
        [SerializeField] private float _breakForce = 10000;
        [SerializeField] private float _maxSteerAngle = 35;
        [SerializeField] private float _turnSpeed = 30;
        [SerializeField] private float _motorForce = 2000;

        [Header("WHEEL COLLIDERS")]
        [SerializeField] private WheelCollider[] _wheelColliders;

        [Header("WHEEL TRANSFORMS")]
        [SerializeField] private Transform[] _wheelTransforms;

        private InputAction _moveAction;
        private InputAction _brakeAction;
        private Vector2 _steering;
        private float _currentSteerAngle;
        private float _currentbreakForce;
        private Vector3 _pos;
        private Quaternion _rot;
        private Rigidbody _rb;
        private GameObject _centerGravity;
        private Vector2 _acceleration;  

        private void Start()
        {
            //Input System
            _moveAction = InputSystem.actions.FindAction("move");
            _brakeAction = InputSystem.actions.FindAction("jump");

            //Center of gravity
            _centerGravity = GameObject.Find("CenterGravity");
            _rb = GetComponent<Rigidbody>();
            _rb.centerOfMass = _centerGravity.transform.localPosition;          
        }

        private void Update()
        {
            _steering = _moveAction.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            Accelerate();
            Brake();
            Steer();
        }


        //ACCELERATION
        private void Accelerate()
        {
            _acceleration.y = _steering.y;

            for (int i = 0; i < _wheelColliders.Count(); i++)
            {
                _wheelColliders[i].motorTorque = _acceleration.y * _motorForce;
            }
        }


        //BRAKING
        private void Brake()
        {
            //Brake
            if (_brakeAction.IsPressed())
            {
                _currentbreakForce = _breakForce;

                for (int i = 0; i < _wheelColliders.Count(); i++)
                {
                    _wheelColliders[i].brakeTorque = _currentbreakForce;
                }
            }
        }

        //STEERING
        private void Steer()
        {
            if (_currentSteerAngle + _steering.x < _maxSteerAngle && _currentSteerAngle + _steering.x > -_maxSteerAngle)
            {
                _currentSteerAngle += _steering.x * (Time.deltaTime * _turnSpeed);
            }

            for (int i = 0; i < 2; i++)
            {
                _wheelColliders[i].steerAngle = _currentSteerAngle;
            }
            Wheels();
        }

        //WHEELS
        private void Wheels()
        {
            for (int i = 0; i < _wheelColliders.Count(); i++)
            {
                UpdateWheel(_wheelColliders[i], _wheelTransforms[i]);
            }
        }

        private void UpdateWheel(WheelCollider wheelCollider, Transform wheelTransform)
        {
            wheelCollider.GetWorldPose(out _pos, out _rot);
            wheelTransform.rotation = _rot;
            wheelTransform.position = _pos;
        }
    }
}