using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchConrollers : MonoBehaviour
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

    public GameObject getLeftXray()
    {
        if (leftXRay == null)
        {
            return GameObject.Find("LeftHand Xray");
        }
        return leftXRay;
        
    }
    
    public GameObject getRightXray()
    {
        if (rightXRay == null)
        {
            return GameObject.Find("RightHand Xray");
        }
        return rightXRay;
    }
    
    public GameObject getLeftDirect()
    {
        if (leftDirect == null)
        {
            return GameObject.Find("LeftHand Direct");
        }
        return leftDirect;
    }
    
    public GameObject getRightDirect()
    {
        if (rightDirect == null)
        {
            return GameObject.Find("RightHand Direct");
        }
        return rightDirect;
    }

    public void SwitchControllers()
    {
        if (leftXRay.activeSelf)
        {
            SetActiveDirectControllers(true);
            SetActiveXrayControllers(false);
        }
        else
        {
            SetActiveDirectControllers(false);
            SetActiveXrayControllers(true);
        }
    }
    
    public void SetActiveDirectControllers(bool target)
    {
        leftDirect.transform.localPosition = leftXRay.transform.localPosition;
        rightDirect.transform.localPosition = rightXRay.transform.localPosition;
        leftDirect.SetActive(target);
        rightDirect.SetActive(target);
    }

    public void SetActiveXrayControllers(bool target)
    {
        leftXRay.transform.localPosition = leftDirect.transform.localPosition;
        rightXRay.transform.localPosition = rightDirect.transform.localPosition;
        leftXRay.SetActive(target);
        rightXRay.SetActive(target);
    }
}
