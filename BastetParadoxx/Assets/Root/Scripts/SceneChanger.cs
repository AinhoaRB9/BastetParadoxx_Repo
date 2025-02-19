using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerIndex : MonoBehaviour
{
    public int sceneIndex; // Número de la escena a la que cambiar

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Si el jugador toca el objeto
        {
            SceneManager.LoadScene(sceneIndex); // Cambia de escena por número
        }
    }
}
