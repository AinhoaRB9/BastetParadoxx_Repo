using UnityEngine;
using System.Collections;

public class COntrollerPlayer : MonoBehaviour
{
    // Variables para movimiento
    public float speed = 5f;
    public float jumpForce = 7f;
    public int maxHealth = 100;
    private int currentHealth;

    // Componentes
    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;

    // Detección de suelo
    public Transform groundCheck; // 🔥 Asegúrate de asignarlo en el Inspector
    public LayerMask groundLayer; // 🔥 Debe estar configurado en el Inspector

    private Vector3 respawnPoint; // Punto donde reaparecerá el jugador

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        respawnPoint = transform.position;
    }

    void Update()
    {
        if (currentHealth > 0) // Solo se mueve si está vivo
        {
            // 🔥 Nueva detección de suelo en cada frame
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

            // 📌 Debug en la consola para verificar
            Debug.Log("isGrounded: " + isGrounded);

            // Leer el input del jugador
            float move = Input.GetAxis("Horizontal");

            // Aplicar movimiento en X
            rb.velocity = new Vector2(move * speed, rb.velocity.y);

            // Actualizar animación de correr
            anim.SetBool("Run", move != 0);

            // Girar el sprite según la dirección
            if (move > 0)
                transform.localScale = new Vector3(1, 1, 1);
            else if (move < 0)
                transform.localScale = new Vector3(-1, 1, 1);

            // 🔥 Saltar si está en el suelo
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                anim.SetTrigger("Jump");
            }

            // Ataque
            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
            }
        }
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
        StartCoroutine(ResetAttackTrigger());
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 1f, LayerMask.GetMask("Enemy"));

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemigoAtaque>()?.TakeDamage(50);
        }
    }

    IEnumerator ResetAttackTrigger()
    {
        yield return new WaitForSeconds(0.5f);
        anim.ResetTrigger("Attack");
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        anim.SetTrigger("Death");
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        GetComponent<Collider2D>().enabled = false;

        Invoke("Respawn", 2f);
    }

    void Respawn()
    {
        transform.position = respawnPoint;
        currentHealth = maxHealth;
        anim.SetTrigger("Respawn");
        rb.isKinematic = false;
        GetComponent<Collider2D>().enabled = true;
    }
}

