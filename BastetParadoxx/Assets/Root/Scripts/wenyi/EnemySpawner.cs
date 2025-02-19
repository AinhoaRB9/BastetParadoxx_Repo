using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // 敌人预制体
    public int enemyCount = 10;     // 生成的敌人数量
    public Vector2 spawnAreaMin;    // 生成区域最小值
    public Vector2 spawnAreaMax;    // 生成区域最大值

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 spawnPosition = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}