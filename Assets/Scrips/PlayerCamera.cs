using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform _pivot;
    [SerializeField] private GameObject _player;
    [SerializeField] float _cameraSmoothTime = 0.2f;
    [SerializeField] float _maxCameraPivotAngle = 23;
    [SerializeField] float _minCameraPivotAngle = -15;
    [SerializeField][Range(0.01f, 2)] float _mouseXSensitivity = 0.2f;
    [SerializeField][Range(0.01f, 2)] float _mouseYSensitivity = 0.1f;
    [SerializeField] bool _invertMouseX = true;
    [SerializeField] bool _invertMouseY = true;

    private InputManager _inputManager;

    private Vector3 _cameraFollowVelocity = Vector3.zero;
    private Vector3 _targetPos;
    private float _tmpHorizontalValue, _tmpVerticalValue;
    private Vector3 _cameraRotation;
    private Quaternion _targetRotation;
    private int _invertMouseXValue, _invertMouseYValue;


    private void Awake()
    {
        _inputManager = _player.GetComponent<InputManager>();
        SetMouseValues();
    }

    private void SetMouseValues()
    {
        _invertMouseXValue = _invertMouseX ? -1 : 1;
        _invertMouseYValue = _invertMouseY ? -1 : 1;
    }

    public void CameraMovement()
    {
        FollowPlayer();
        RotateCamera();
    }

    private void FollowPlayer()
    {
        _targetPos = Vector3.SmoothDamp(transform.position, _player.transform.position, ref _cameraFollowVelocity, _cameraSmoothTime * Time.deltaTime);
        transform.position = _targetPos;
    }

    private void RotateCamera()
    {
        _tmpVerticalValue = _tmpVerticalValue + (_inputManager.GetCameraInput().y) * _invertMouseYValue * _mouseYSensitivity;
        _tmpHorizontalValue = _tmpHorizontalValue - (_inputManager.GetCameraInput().x) * _invertMouseXValue * _mouseXSensitivity;
        _tmpVerticalValue = Mathf.Clamp(_tmpVerticalValue, _minCameraPivotAngle, _maxCameraPivotAngle);

        _cameraRotation = Vector3.zero;
        _cameraRotation.y = _tmpHorizontalValue;
        _targetRotation = Quaternion.Euler(_cameraRotation);
        _targetRotation = Quaternion.Slerp(transform.rotation, _targetRotation, _cameraSmoothTime);
        transform.rotation = _targetRotation;

        _cameraRotation = Vector3.zero;
        _cameraRotation.x = _tmpVerticalValue;
        _targetRotation = Quaternion.Euler(_cameraRotation);
        _targetRotation = Quaternion.Slerp(_pivot.localRotation, _targetRotation, _cameraSmoothTime);
        _pivot.localRotation = _targetRotation;
    }
}
