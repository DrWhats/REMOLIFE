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
        birdAnimator.SetBool("PlayerTooFast", true);
        birdContainer.SetBool("PlayerInZone", true);
        birdContainer.Play("fly");
        birdAnimator.Play("StartFly");
        Debug.Log("Start Flying");
    }

    public void StopFly()
    {
        //birdAnimator.SetBool("PlayerTooFast", false);
        birdContainer.SetBool("PlayerInZone", false);
        birdAnimator.SetBool("PlayerTooFast", false);
        birdContainer.Play("land");
        birdAnimator.Play("Flying 0");
        Debug.Log("Stop Flying");
    }
}
