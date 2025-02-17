using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupLevel3 : MonoBehaviour
{

    public GameObject nivel;

    private void Start()
    {
        nivel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        nivel.SetActive(true);
    }
}
