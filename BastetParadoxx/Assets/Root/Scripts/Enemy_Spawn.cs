using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    [Header("Spawn Configuration")]
    [SerializeField] GameObject[] spawnPrefab;
    [SerializeField] float initialSpawnTime = 5f;
    [SerializeField] float spawnRate = 2f;
    [SerializeField] bool gameOn;

    [Header("Spanw Randomizer")]
    [SerializeField] bool spawnIsRandom;
    [SerializeField] float limitYpositive;
    [SerializeField] float limitYnegative;

    private void Awake()
    {
        gameOn = true;
    }

    private void Start()
    {
        if (spawnIsRandom) InvokeRepeating(nameof(RandomSpawner), initialSpawnTime, spawnRate);
        else InvokeRepeating(nameof(Spawner), initialSpawnTime, spawnRate);
    }

    
    void Spawner()
    {
        if (gameOn)
        {
            int randomSpawner = Random.Range(0, spawnPrefab.Length);
            Instantiate(spawnPrefab[randomSpawner], transform.position, Quaternion.identity);
        }
    }

    void RandomSpawner()
    {
        if (gameOn)
        {
            int randomSpawner = Random.Range(0, spawnPrefab.Length);
            float randomY = Random.Range(limitYnegative, limitYpositive);
            Vector3 randomPos = new Vector3(transform.position.x, randomY, 0);
            Instantiate(spawnPrefab[randomSpawner], randomPos, Quaternion.identity);
        }
    }
}


