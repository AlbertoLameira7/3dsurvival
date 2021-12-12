using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerCamera _playerCamera;
    private InputManager _inputMgr;

    private void Awake()
    {
        _playerCamera = FindObjectOfType<PlayerCamera>();
        _inputMgr = GetComponent<InputManager>();
    }

    private void Update()
    {
        _inputMgr.HandleInput();
    }

    void LateUpdate()
    {
        _playerCamera.CameraMovement();
    }
}
