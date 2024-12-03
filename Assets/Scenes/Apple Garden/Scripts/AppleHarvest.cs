
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class AppleHarvest : MonoBehaviour
{
    [SerializeField] private byte _appleCounter = 0;
    [SerializeField] private GameObject[] _applesInBasket;
    [SerializeField] private TextMeshProUGUI _counter;
    [SerializeField] private GameObject _button;
    [SerializeField] private AudioSource _fanfara;

    private void Start()
    {
        _fanfara = GameObject.Find("Fanfara_audio").GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Apples"))
        {
            Debug.Log("Яблоко ударилось об корзину");
            _applesInBasket[_appleCounter].SetActive(true);
            Destroy(other.gameObject);
            IncrementCounter();
        }
    }

    private void IncrementCounter()
    {
        _appleCounter++;
        _counter.text = _appleCounter.ToString();
        if (_appleCounter == 10)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        _fanfara.Play();
        Destroy(_fanfara.GameObject(), 3);
        _button.SetActive(true);
        Debug.Log("Молодец!!!");
    }
    
    
}
