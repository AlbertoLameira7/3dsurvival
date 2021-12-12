using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    private Animator _animator;
    private float _tmpHorizontalValue, _tmpVerticalValue;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void HandlePlayerMovementAnimation(float horizontal, float vertical)
    {
        if (horizontal > 0)
            _tmpHorizontalValue = 1;
        else if (horizontal < 0)
            _tmpHorizontalValue = -1;
        else
            _tmpHorizontalValue = 0;

        if (vertical > 0)
            _tmpVerticalValue = 1;
        else if (vertical < 0)
            _tmpVerticalValue = -1;
        else
            _tmpVerticalValue = 0;

        _animator.SetFloat("Horizontal", _tmpHorizontalValue, 0.1f, Time.deltaTime);
        _animator.SetFloat("Vertical", _tmpVerticalValue, 0.1f, Time.deltaTime);
    }
}
