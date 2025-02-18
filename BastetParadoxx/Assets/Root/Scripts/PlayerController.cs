using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
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

     private Vector3 respawnPoint; // Punto donde reaparecerá el jugador


    void Start()
    {
        // Obtener los componentes necesarios
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth; // Inicializa la vida al máximo

        respawnPoint = transform.position; // Guarda la posición inicial como punto de respawn
    }

    void Update()
    {
          if (currentHealth > 0) // Solo se mueve si está vivo
        // Leer el input del jugador (teclas A/D o flechas Izquierda/Derecha)
        float move = Input.GetAxis("Horizontal");

        // Aplicar movimiento en X
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // Actualizar la animación de correr
        anim.SetBool("Run", move != 0);

        // Girar el sprite según la dirección
        if (move > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (move < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Saltar si se presiona la tecla "Espacio" y está en el suelo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetTrigger("Jump");
        }

        // Ataque si se presiona "Fire1" (clic izquierdo o Ctrl)
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
        StartCoroutine(ResetAttackTrigger());
    }

    IEnumerator ResetAttackTrigger()
    {
        yield return new WaitForSeconds(0.5f); // Ajusta el tiempo según la animación
        anim.ResetTrigger("Attack"); // Resetea el Trigger para que no se quede atascado
    }

    // Detección de colisión con el suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("Jump", false); // Asegurar que la animación vuelva a Idle
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
           else if (collision.gameObject.CompareTag("Respawn")) // Si toca un punto de respawn
        {
            respawnPoint = collision.transform.position; // Guarda la nueva posición de respawn
        }
    }
}private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
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
        anim.SetTrigger("Death"); // Activa la animación de muerte
        rb.velocity = Vector2.zero; // Detiene el movimiento
        rb.isKinematic = true; // Desactiva la física
        GetComponent<Collider2D>().enabled = false; // Desactiva el collider

        Invoke("Respawn", 2f); // Espera 2 segundos y reaparece
    }
 void Respawn()
    {
        transform.position = respawnPoint; // Reaparece en el último punto guardado
        currentHealth = maxHealth; // Restaura la vida
        anim.SetTrigger("Respawn"); // Activa la animación de respawn (opcional)
        rb.isKinematic = false; // Reactiva la física
        GetComponent<Collider2D>().enabled = true; // Reactiva el collider
    }
}

