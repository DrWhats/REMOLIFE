using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSwitchZone : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject leftXRay;
    [SerializeField] private GameObject rightXRay;
    [SerializeField] private GameObject leftDirect;
    [SerializeField] private GameObject rightDirect;
    void Start()
    {
        leftXRay = GameObject.Find("LeftHand Xray");
        rightXRay = GameObject.Find("RightHand Xray");
        leftDirect = GameObject.Find("LeftHand Direct");
        rightDirect = GameObject.Find("RightHand Direct");
        SetActiveDirectControllers(false);
    }
    
    void SetActiveDirectControllers(bool target)
    {
        ;
        leftDirect.SetActive(target);
        rightDirect.SetActive(target);
    }

    void SetActiveXrayControllers(bool target)
    {
        leftXRay.transform.localPosition = leftDirect.transform.localPosition;
        rightXRay.transform.localPosition = rightDirect.transform.localPosition;
        leftXRay.SetActive(target);
        rightXRay.SetActive(target);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == leftXRay || other.gameObject == rightXRay)
        {
            leftDirect.transform.localPosition = leftXRay.transform.localPosition;
            rightDirect.transform.localPosition = rightXRay.transform.localPosition;
            SetActiveDirectControllers(true);
            SetActiveXrayControllers(false);
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == leftDirect || other.gameObject == rightDirect)
        {
            SetActiveDirectControllers(false);
            SetActiveXrayControllers(true);
        }
    }


}
