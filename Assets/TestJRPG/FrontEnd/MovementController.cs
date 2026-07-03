using System;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private InputCapturer _inputCapturer;
    [SerializeField] private Rigidbody _rigidbody;

    private Vector3 _velocity;

    [Header("velocity setting")] 
    [SerializeField] private float _maxSpeed = 5f;
    [SerializeField] private float _accelerationRate = 10f;
    [SerializeField] private float _deAccelerateRate = 5f; 
    private void OnEnable()
    {
        _inputCapturer.OnMove += InputOnMoveChanged;
        _inputCapturer.OnJumpPressed += InputOnJumpPressed;
    }

    private void OnDisable()
    {
        _inputCapturer.OnMove -= InputOnMoveChanged;
        _inputCapturer.OnJumpPressed -= InputOnJumpPressed;
    }

    private void Update()
    {
        _velocity.y = _rigidbody.linearVelocity.y;
        _velocity.x = Mathf.MoveTowards(_velocity.x, 0f, _deAccelerateRate * Time.deltaTime);
        _velocity.z = Mathf.MoveTowards(_velocity.z, 0f, _deAccelerateRate * Time.deltaTime);
        _rigidbody.linearVelocity = _velocity;
    }

    private void InputOnMoveChanged(Vector2 velocity)
    {
        _velocity.x = _velocity.x + velocity.x * _accelerationRate * Time.deltaTime;
        _velocity.x = Mathf.Clamp(_velocity.x, -_maxSpeed, _maxSpeed);
        
        _velocity.z = _velocity.z + velocity.y * _accelerationRate * Time.deltaTime;
        _velocity.z = Mathf.Clamp(_velocity.z, -_maxSpeed, _maxSpeed);
    }

    private void InputOnJumpPressed()
    {
        
    }
}
