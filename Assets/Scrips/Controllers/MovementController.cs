using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 1000;
    private Rigidbody _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void HandleMovement(float horizontal, float vertical)
    {
        _rb.velocity = new Vector3(horizontal, _rb.velocity.y, vertical) * _playerSpeed * Time.deltaTime;
    }
}
