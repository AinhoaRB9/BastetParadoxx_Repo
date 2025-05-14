using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float detectionRange = 5f;
    public Transform player;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float direction = 1f;
    private float changeDirectionTime = 2f;
    private float changeTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        changeTimer = changeDirectionTime;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            // Perseguir al jugador
            direction = Mathf.Sign(player.position.x - transform.position.x);
        }
        else
        {
            // Movimiento aleatorio
            changeTimer -= Time.deltaTime;
            if (changeTimer <= 0)
            {
                direction = Random.Range(0, 2) == 0 ? -1f : 1f;
                changeTimer = changeDirectionTime;
            }
        }

        // Aplicar movimiento
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

        // Flip sprite
        if (direction != 0)
            spriteRenderer.flipX = direction < 0;
    }

}
