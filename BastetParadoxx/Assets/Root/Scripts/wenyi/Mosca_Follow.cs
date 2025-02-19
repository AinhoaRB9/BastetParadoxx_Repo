using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public float speed = 3f; // Velocidad de movimiento
    public float stoppingDistance = 0.5f; // Distancia m¨ªnima antes de detenerse

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player == null) return;

        // Calcular la direcci¨®n hacia el jugador
        Vector2 direction = (player.position - transform.position).normalized;
        float distance = Vector2.Distance(transform.position, player.position);

        // Mover al enemigo si est¨¢ fuera de la distancia m¨ªnima
        if (distance > stoppingDistance)
        {
            rb.velocity = direction * speed;
        }
        else
        {
            rb.velocity = Vector2.zero; // Detenerse si est¨¢ cerca del jugador
        }
    }
}
