using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Método para cargar el juego
    public void PlayGame()
    {
        SceneManager.LoadScene("Nivel_1"); // Reemplaza con el nombre de la primera escena del juego
    }

    // Método para salir del juego
    public void ExitGame()
    {
        Debug.Log("Saliendo del juego..."); // Solo para probar en Unity
        Application.Quit(); // Cierra el juego (funciona en la build, no en el editor)
    }
}
