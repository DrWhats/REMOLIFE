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
    [SerializeField] private bool DisableControllers;

    private bool inZone = false;
    private bool isFlying = false;

    // Update is called once per frame

    private void Start()
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
            if (DisableControllers)
            {
                _leftControllerDirect.SetActive(true);
                _rightControllerDirect.SetActive(true);
                _leftControllerXray.SetActive(false);
                _rightControllerXray.SetActive(false);
            }

            Debug.Log("Player in zone");
            inZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _rightControllerDirect || other.gameObject == _leftControllerDirect)
        {
            if (DisableControllers)
            {
                _leftControllerXray.SetActive(true);
                _rightControllerXray.SetActive(true);
                _leftControllerDirect.SetActive(false);
                _rightControllerDirect.SetActive(false);
            }

            Debug.Log("Player out of zone");
            bird.StopFly();
            _popUp[1].SetActive(true);
            isFlying = false;
            inZone = false;
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