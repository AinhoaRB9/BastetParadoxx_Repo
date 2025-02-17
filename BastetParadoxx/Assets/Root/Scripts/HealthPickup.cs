using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 20; // Cuánta vida cura

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verificar si lo toca el jugador
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount); // Curar al jugador
                Destroy(gameObject); // Eliminar el pickup después de usarlo
            }
        }
    }
}
