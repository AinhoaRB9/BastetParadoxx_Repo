using UnityEngine;

public class SoundPickup : MonoBehaviour
{
    public AudioClip pickupSound; // Arrastra el sonido desde Unity
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica que sea el jugador
        {
            audioSource.PlayOneShot(pickupSound); // Reproduce el sonido
            gameObject.SetActive(false); // Desactiva el pickup
        }
    }
}

