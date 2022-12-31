using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSwitchZone : MonoBehaviour
{
    
    [SerializeField] private SwitchConrollers controllers;
    [SerializeField] private GameObject leftDirect;
    [SerializeField] private GameObject rightDirect;
    [SerializeField] private GameObject leftXray;
    [SerializeField] private GameObject rightXray;
    
    
    void Awake()
    {
        FindReference();
        controllers = GameObject.FindObjectOfType<SwitchConrollers>();

    }
    
    private void FindReference()
    {
        while (controllers == null)
        {
            Debug.Log("Finding reference");
            controllers = GameObject.FindObjectOfType<SwitchConrollers>();
            leftDirect = controllers.getLeftDirect();
            rightDirect = controllers.getRightDirect();
            leftXray = controllers.getLeftXray();
            rightXray = controllers.getRightXray();
        }

    }
    
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == leftXray || other.gameObject == rightXray)
        {
            controllers.SetActiveDirectControllers(true);
            controllers.SetActiveXrayControllers(false);
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == leftDirect || other.gameObject == rightDirect)
        {
            controllers.SetActiveDirectControllers(false);
            controllers.SetActiveXrayControllers(true);
        }
    }


}
