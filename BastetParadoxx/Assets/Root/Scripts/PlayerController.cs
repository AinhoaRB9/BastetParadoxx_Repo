using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Variables para movimiento
    public float speed = 5f;
    public float jumpForce = 7f;

    // Componentes
    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;

    void Start()
    {
        // Obtener los componentes necesarios
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
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
    }
}
