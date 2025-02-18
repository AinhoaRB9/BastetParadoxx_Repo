using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void RetryGame()
    {
        // Cargar la escena 1 (índice 1 en Build Settings)
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        // Cerrar el juego
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
