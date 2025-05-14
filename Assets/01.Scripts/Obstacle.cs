using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag("Player"))
        {
            // �ڽ� ������Ʈ�� ���� ���ɼ����� ���
            HealthBar playerHealth = other.GetComponentInChildren<HealthBar>();
            if (playerHealth != null)
            {
                Debug.Log("�� ü�� ��� ��...");
                int damage = 20;
                playerHealth.TakeDamage((int)damage);
            }
            else
            {
                Debug.LogWarning("HealthBar ������Ʈ�� ã�� �� ����");
            }
        }
    }
}

