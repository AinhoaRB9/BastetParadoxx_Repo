using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Vector2 spawn;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) // 确保玩家有 "Player" 标签
        {
            return;
        }
        other.transform.position = (spawn); // 调用 Respawn 方法
    }
}