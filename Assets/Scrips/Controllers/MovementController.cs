using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _playerSpeed = 1000;
    [SerializeField] private float _rotationSpeed = 4f;

    private Rigidbody _rb;
    private Quaternion _playerRotation;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void HandleMovement(float horizontal, float vertical)
    {
        _playerRotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, _cameraTransform.eulerAngles.y, 0), _rotationSpeed * Time.deltaTime);

        if (horizontal != 0 || vertical != 0)
        {
            transform.rotation = _playerRotation;
        }

        _rb.velocity = ((transform.forward * vertical) + (transform.right * horizontal)) * _playerSpeed * Time.deltaTime;
    }
}
