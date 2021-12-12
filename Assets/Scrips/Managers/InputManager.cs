using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls _playerCtrls;
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
        if (_playerCtrls == null)
        {
            _playerCtrls = new PlayerControls();

            _playerCtrls.PlayerMovement.Movement.performed += i => _movementInput = i.ReadValue<Vector2>();
            _playerCtrls.PlayerMovement.Camera.performed += i => _cameraInput = i.ReadValue<Vector2>();
        }

        _playerCtrls.Enable();
    }

    private void OnDisable()
    {
        _playerCtrls.Disable();
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
}
