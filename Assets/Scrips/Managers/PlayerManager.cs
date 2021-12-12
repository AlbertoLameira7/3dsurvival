using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerCamera _playerCamera;
    private InputManager _inputManager;

    private void Awake()
    {
        _playerCamera = FindObjectOfType<PlayerCamera>();
        _inputManager = GetComponent<InputManager>();
    }

    private void Update()
    {
        _inputManager.HandleInput();
    }

    void LateUpdate()
    {
        _playerCamera.CameraMovement();
    }
}
