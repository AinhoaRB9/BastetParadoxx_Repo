using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAI : MonoBehaviour
{
    public Transform player;  
    public float speed = 3f;  
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player == null) return; 

        
        Vector2 direction = (player.position - transform.position).normalized;

        
        rb.velocity = direction * speed;
    }
}

