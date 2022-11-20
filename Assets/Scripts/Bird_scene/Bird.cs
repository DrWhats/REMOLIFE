using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private Animator birdAnimator;
    [SerializeField] private Animator birdContainer;

    private void Start()
    {
        
    }

    public void StartFly()
    {
        Debug.Log("Start Flying");
        birdAnimator.Play("StartFly");
    }

    public void StopFly()
    {
        Debug.Log("Stop Flying");
        birdAnimator.Play("Landing");
    }
}
