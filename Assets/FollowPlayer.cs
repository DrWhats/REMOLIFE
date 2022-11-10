using Unity.XR.OpenVR;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject target;
    public Bird bird;
    public float maxVelocity; 

    private Rigidbody _rigidbody;
    
    private OpenVRHMD _hmd;
    private OpenVROculusTouchController _rightController; // Как привязать их к соответствующим контроллерам?
    private OpenVROculusTouchController _leftController; // Как привязать их к соответствующим контроллерам?
    
    // .deviceVelocity возвращает вектор скоростей в 3хмерном пространстве (х, у, z)
    // .valueSizeInBytes не уверен, но надеюсь он приводит вектор к скаляру
    
    /*
    void Update()
    {
        if (_hmd.deviceVelocity.valueSizeInBytes > maxVelocity || 
            _rightController.deviceVelocity.valueSizeInBytes > maxVelocity || 
            _leftController.deviceVelocity.valueSizeInBytes > maxVelocity)
        {
            Debug.Log("Don't move so quick.");
            bird.StartFly();
        }
    }
    */
    
    // Update is called once per frame
    void Update()
    {
        if (_rigidbody && _rigidbody.velocity.magnitude > maxVelocity)
        {
            Debug.Log("Player is very fast.");
            bird.StartFly();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            _rigidbody = other.attachedRigidbody;
            Debug.Log("Player in zone");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target)
        {
            _rigidbody = null;
            bird.StopFly();
            Debug.Log("Player not in zone");
        }
    }
}
