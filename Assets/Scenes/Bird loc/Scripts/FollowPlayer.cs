
using System.Collections;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] float currentRightVelocity;
    [SerializeField] float currentLeftVelocity;
    [SerializeField] float maxVelocity;

    [SerializeField] private GameObject _rightController;
    [SerializeField] private GameObject _leftController;
    [SerializeField] private GameObject[] _popUp;

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
        if (other.gameObject == _rightController || other.gameObject == _leftController)
        {
            Debug.Log("Player in zone");
            inZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _rightController || other.gameObject == _leftController)
        {
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
            Vector3 prevRightPos = _rightController.transform.position;
            Vector3 prevLeftPos = _leftController.transform.position;

            yield return new WaitForFixedUpdate();

            currentRightVelocity = (Vector3.Distance(_rightController.transform.position,
                prevRightPos) / Time.fixedDeltaTime);
            
            currentLeftVelocity = (Vector3.Distance(_leftController.transform.position,
                prevLeftPos) / Time.fixedDeltaTime);
        }
    }
}