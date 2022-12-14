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
    [SerializeField] private GameObject[] _popUp;

    [Header("Disable controllers by zone")] [SerializeField]
    private bool switchControllers;

    private bool inZone = false;
    private bool isFlying = false;
    

    void Update()
    {
        if ((currentLeftVelocity > maxVelocity || currentRightVelocity > maxVelocity) && inZone && !isFlying)
        {
            Debug.Log("Player is very fast.");
            bird.StartFly();
            _popUp[0].SetActive(true);
            isFlying = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _leftControllerDirect || other.gameObject == _rightControllerDirect)
        {
            inZone = true;
            Debug.Log("Player is in zone.");
            StartCoroutine(CalcSpeed());
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _rightControllerDirect || other.gameObject == _leftControllerDirect)
        {
            
            Debug.Log("Player out zone");
            inZone = false;
            isFlying = false;
            bird.StopFly();
            _popUp[1].SetActive(true);
            StopCoroutine(CalcSpeed());
        }

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