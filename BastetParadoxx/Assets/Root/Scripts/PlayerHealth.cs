using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Image barraDeVida;         // La imagen UI de la barra de vida
    public Transform respawnPoint;    // Objeto vacío en la escena donde reaparecerá el jugador
    public float respawnDelay = 2f;   // Tiempo que espera antes del respawn

    private bool isDead = false;      // Evita que muera varias veces

    private void Start()
    {
        currentHealth = maxHealth;
        ActualizarBarraDeVida();

        if (barraDeVida == null)
            Debug.LogWarning("Barra de vida no asignada en PlayerHealth.");
        if (respawnPoint == null)
            Debug.LogWarning("Punto de respawn no asignado en PlayerHealth.");
    }

    public void Heal(int amount)
    {
        if (isDead) return;

        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        ActualizarBarraDeVida();
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            ActualizarBarraDeVida();
            StartCoroutine(HandleDeath());
            return;
        }

        ActualizarBarraDeVida();
    }

    void ActualizarBarraDeVida()
    {
        if (barraDeVida != null)
            barraDeVida.fillAmount = (float)currentHealth / maxHealth;
    }

    IEnumerator HandleDeath()
    {
        isDead = true;

        // Aquí NO hay animación, solo espera el tiempo definido
        yield return new WaitForSeconds(respawnDelay);

        // Respawn
        transform.position = respawnPoint.position;
        currentHealth = maxHealth;
        ActualizarBarraDeVida();
        isDead = false;

        Debug.Log("Jugador ha hecho respawn.");
    }
}
