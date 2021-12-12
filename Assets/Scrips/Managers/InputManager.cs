using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls _playerControls;
    AnimatorManager _animatorMgr;
    MovementController _movementCtrl;

    private Vector2 _movementInput;
    private Vector2 _cameraInput;

    private void Awake()
    {
        _animatorMgr = GetComponent<AnimatorManager>();
        _movementCtrl = GetComponent<MovementController>();
    }

    private void OnEnable()
    {
        if (_playerControls == null)
        {
            _playerControls = new PlayerControls();

            _playerControls.PlayerMovement.Movement.performed += i => _movementInput = i.ReadValue<Vector2>();
            _playerControls.PlayerMovement.Camera.performed += i => _cameraInput = i.ReadValue<Vector2>();
        }

        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    public void HandleInput()
    {
        // handle all inputs
        HandleMovementInput();
        HandleCameraInput();
    }

    private void HandleMovementInput()
    {
        // update animation and make player move
        _animatorMgr.HandlePlayerMovementAnimation(_movementInput.x, _movementInput.y);
        _movementCtrl.HandleMovement(_movementInput.x, _movementInput.y);
    }

    private void HandleCameraInput()
    {

    }

    public Vector2 GetCameraInput()
    {
        return _cameraInput;
    }

    public Vector2 GetMovementInput()
    {
        return _movementInput;
    }
}
