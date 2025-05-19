using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mini_soles : MonoBehaviour
{
    public GameObject solGrande;
    int soles;

    private void OnEnable()
    {
        solGrande.SetActive(false);
        soles = 0;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("mini sol"))
        {
            Destroy(collision.gameObject);
            soles = soles+1;
        }
    }
    private void Update()
    {
        if (soles >= 5)
        {
            solGrande.SetActive(true);
        }
    }
}
