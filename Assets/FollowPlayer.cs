using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject target;
    public Bird bird;
    public float maxVelocity; 

    private Rigidbody _rigidbody;

    // Update is called once per frame
    void Update()
    {
        if (_rigidbody && _rigidbody.velocity.magnitude > maxVelocity)
        {
            Debug.Log("Player is very quick.");
            bird.StartFly();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            _rigidbody = other.attachedRigidbody;
            Debug.Log("Player is in zone");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target)
        {
            _rigidbody = null;
            bird.StopFly();
        }
    }
}
