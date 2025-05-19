using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ene : MonoBehaviour
{
    public float speed = 2.5f;
    public float turnSpeed = 1.5f; // Qu谷 tan r芍pido gira hacia el jugador

    private Rigidbody2D rb;
    private Transform player;
    private SpriteRenderer spriteRenderer; // Para controlar el flip

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Obtener el SpriteRenderer
        rb.velocity = Random.insideUnitCircle.normalized * speed;

        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void FixedUpdate()
    {
        if (player == null) return;

        // Direcci車n actual del asteroide
        Vector2 currentDirection = rb.velocity.normalized;

        // Direcci車n deseada hacia el jugador
        Vector2 directionToPlayer = ((Vector2)(player.position - transform.position)).normalized;

        // Interpolamos entre la direcci車n actual y la deseada
        Vector2 newDirection = Vector2.Lerp(currentDirection, directionToPlayer, turnSpeed * Time.fixedDeltaTime).normalized;

        rb.velocity = newDirection * speed;

        // Aqu赤 hacemos el flip en base a la direcci車n de movimiento
        FlipBasedOnDirection(newDirection);
    }

    // Funci車n para voltear el sprite
    void FlipBasedOnDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            spriteRenderer.flipX = false; // Mirando a la derecha
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = true; // Mirando a la izquierda
        }
    }
}
