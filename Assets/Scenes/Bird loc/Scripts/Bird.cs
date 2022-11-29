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
        birdAnimator.SetBool("PlayerInZone", true);
        birdAnimator.SetBool("PlayerTooFast", true);
        birdContainer.SetBool("PlayerInZone", true);
        birdContainer.SetBool("PlayerTooFast", true);
        Debug.Log("Start Flying");
    }

    public void StopFly()
    {
        birdContainer.SetBool("PlayerInZone", false);
        birdAnimator.SetBool("PlayerTooFast", false);
        birdAnimator.SetBool("PlayerInZone", false);
        birdContainer.SetBool("PlayerTooFast", false);
        birdAnimator.Play("Flying 0");
        birdContainer.Play("land");
        Debug.Log("Stop Flying");
    }
}
