using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform respawnPoint; // ?? respawn ???

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RespawnTrigger")) // ??????? "RespawnTrigger"
        {
            Respawn();
        }
    }

    void Respawn()
    {
        // ???????? respawnPoint
        transform.position = respawnPoint.position;
    }
}
