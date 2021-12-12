using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform _pivot;
    [SerializeField] private Camera _cameraObj;
    [SerializeField] private GameObject _player;
    [SerializeField] float _cameraSmoothTime = 0.2f;

    private Vector3 _cameraFollowVelocity = Vector3.zero;
    private Vector3 _targetPos;

    public void CameraMovement()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        _targetPos = Vector3.SmoothDamp(transform.position, _player.transform.position, ref _cameraFollowVelocity, _cameraSmoothTime * Time.deltaTime);
        transform.position = _targetPos;
    }
}
