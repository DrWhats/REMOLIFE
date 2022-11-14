using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Vector3 _initialPosition;
    private Vector3 _flyPosition;
    private Rigidbody _rigidbody;
    private Animator animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        _initialPosition = _rigidbody.position;
        _flyPosition = _initialPosition + new Vector3(0, 10, 0);
    }

    public void StartFly()
    {
        _rigidbody.MovePosition(_flyPosition); // Заменить на старт анимации полёта
    }

    public void StopFly()
    {
        _rigidbody.MovePosition(_initialPosition); // Заменить на прекращение полёта
    }
}
