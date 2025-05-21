using System.Collections;
using UnityEngine;

public class EnemigoAtaque : MonoBehaviour
{
    public float rangoDeAtaque = 2f; // Distancia a la que ataca
    public float tiempoEntreAtaques = 1f; // Tiempo entre ataques
    public int daño = 10; // Daño que hace al jugador
    public int health = 50;

    private Transform jugador;
    private Animator animator;
    private bool puedeAtacar = true; // Controla el tiempo entre ataques

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (jugador != null && Vector2.Distance(transform.position, jugador.position) <= rangoDeAtaque)
        {
            if (puedeAtacar)
            {
                StartCoroutine(Atacar());
            }
        }
    }

    IEnumerator Atacar()
    {
        puedeAtacar = false;
        animator.SetTrigger("Attack"); // Activa la animación de ataque

        yield return new WaitForSeconds(tiempoEntreAtaques); // Espera antes de volver a atacar

        puedeAtacar = true;
    }
    public Collider2D hitbox; // Arrástralo en el Inspector

    public void ActivarCollider()
    {
        hitbox.enabled = true;
    }

    public void DesactivarCollider()
    {
        hitbox.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Si la hitbox golpea al jugador
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(daño); // Hace daño al jugador
                Debug.Log($"El enemigo golpe?al jugador e hizo {daño} de daño.");
            }
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage; // Resta el daño recibido

        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        animator.SetTrigger("Death"); // Activa la animación de muerte
        GetComponent<Collider2D>().enabled = false; // Desactiva colisiones
        this.enabled = false; // Desactiva el script del enemigo
        Destroy(gameObject, 1f); // Destruye al enemigo después de 1 segundo
    }

}
