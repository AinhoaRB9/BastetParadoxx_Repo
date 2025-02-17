using System.Collections;
using UnityEngine;

public class EnemigoAtaque : MonoBehaviour
{
    public float rangoDeAtaque = 2f; // Distancia a la que ataca
    public float tiempoEntreAtaques = 1f; // Tiempo entre ataques
    public int daño = 10; // Daño que hace al jugador

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
        
}
