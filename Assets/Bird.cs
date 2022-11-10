using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 flyPosition;
    private Rigidbody _rigidbody;
    private Animator animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        initialPosition = _rigidbody.position;
        flyPosition = initialPosition + new Vector3(0, 10, 0);
    }

    public void StartFly()
    {
        _rigidbody.MovePosition(flyPosition);
    }

    public void StopFly()
    {
        _rigidbody.MovePosition(initialPosition);
    }
}
