using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag("Player"))
        {
            // 자식 오브젝트에 있을 가능성까지 고려
            HealthBar playerHealth = other.GetComponentInChildren<HealthBar>();
            if (playerHealth != null)
            {
                Debug.Log("→ 체력 깎는 중...");
                int damage = 20;
                playerHealth.TakeDamage((int)damage);
            }
            else
            {
                Debug.LogWarning("HealthBar 컴포넌트를 찾을 수 없음");
            }
        }
    }
}

