using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Vida máxima del jugador
    private int currentHealth;  // Vida actual

    private void Start()
    {
        currentHealth = maxHealth; // Iniciar con vida completa
    }

    public void Heal(int amount)
    {
        int previousHealth = currentHealth; // Guardar la vida antes de la curación

        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // No pasar el máximo
        }

        Debug.Log($"Jugador curado: {amount} de vida. Antes: {previousHealth}, Ahora: {currentHealth}");
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
