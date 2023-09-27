using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Playercontroler : MonoBehaviour
{
    public TextMeshProUGUI CountText;
    public GameObject WinText;

    public float Speed = 100f;

    private float _horizontalinput;
    private float _forwardinput;

    private int _count;

    private Rigidbody _playerRigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        _count = 0;
        CountText.text = "Count:" + _count.ToString();
        WinText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalinput = Input.GetAxis("Horizontal");
            _forwardinput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(_horizontalinput, 0.0f, _forwardinput);

        _playerRigidbody.AddForce(movement*Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            _count = _count + 1;
            CountText.text = "Count:" + _count.ToString();

            if(_count >= 8)
            {
                WinText.gameObject.SetActive(true);
            }
        }

    }
}
