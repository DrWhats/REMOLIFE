using System.Collections;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] float currentRightVelocity;
    [SerializeField] float currentLeftVelocity;
    [SerializeField] float maxVelocity;

    [SerializeField] private GameObject _rightControllerDirect;
    [SerializeField] private GameObject _leftControllerDirect;
    [SerializeField] private GameObject _rightControllerXray;
    [SerializeField] private GameObject _leftControllerXray;
    [SerializeField] private GameObject[] _popUp;
    
    [Header("Disable controllers by zone")]
    [SerializeField] private bool switchControllers;

    private bool inZone = false;
    private bool isFlying = false;
    

    void EnableSpeedometer()
    {
        StartCoroutine(CalcSpeed());
    }

    void Update()
    {
        if ((currentLeftVelocity > maxVelocity ||
             currentRightVelocity > maxVelocity) && inZone && !isFlying)
        {
            Debug.Log("Player is very fast.");
            bird.StartFly();
            _popUp[0].SetActive(true);
            isFlying = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _rightControllerXray || other.gameObject == _leftControllerXray)
        {
            if (switchControllers)
            {
                SetXrayControllers(false);
                SetDirectControllers(true);
            }

            Debug.Log("Player in zone");
            inZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _rightControllerDirect || other.gameObject == _leftControllerDirect)
        {
            if (switchControllers)
            {
                SetXrayControllers(true);
                SetDirectControllers(false);
            }

            Debug.Log("Player out of zone");
            bird.StopFly();
            _popUp[1].SetActive(true);
            isFlying = false;
            inZone = false;
        }
    }

    void SetDirectControllers(bool target)
    {
        _leftControllerDirect.SetActive(target);
        _rightControllerDirect.SetActive(target);
    }

    void SetXrayControllers(bool target)
    {
        _leftControllerXray.SetActive(target);
        _rightControllerXray.SetActive(target);
    }

    IEnumerator CalcSpeed()
    {
        while (true)
        {
            Vector3 prevRightPos = _rightControllerDirect.transform.position;
            Vector3 prevLeftPos = _leftControllerDirect.transform.position;

            yield return new WaitForFixedUpdate();

            currentRightVelocity = (Vector3.Distance(_rightControllerDirect.transform.position,
                prevRightPos) / Time.fixedDeltaTime);

            currentLeftVelocity = (Vector3.Distance(_leftControllerDirect.transform.position,
                prevLeftPos) / Time.fixedDeltaTime);
        }
    }
}