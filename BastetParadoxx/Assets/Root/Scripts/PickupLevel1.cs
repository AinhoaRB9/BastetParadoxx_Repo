using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupLevel1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int totalPickups = 10; // Número total de pickups en el nivel
    private int collectedPickups = 0; // Contador de pickups recogidos

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pickup")) // Verifica si el objeto tiene la etiqueta "Pickup"
        {
            collectedPickups++; // Suma 1 al contador
            Destroy(other.gameObject); // Elimina el pickup

            if (collectedPickups >= totalPickups) // Si se han recogido todos los pickups
            {
                ChangeScene(); // Cambia de escena
            }
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Carga la siguiente escena
    }
}

