
using Unity.VisualScripting;
using UnityEngine;


public class AppleHarvest : MonoBehaviour
{
    [SerializeField] private byte _appleCounter = 0;
    [SerializeField] private GameObject[] _applesInBasket;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Apples"))
        {
            Debug.Log("Яблоко ударилось об корзину");
            _applesInBasket[_appleCounter].SetActive(true);
            Destroy(other.gameObject);
            _appleCounter++;
        }
    }
    
    
}
