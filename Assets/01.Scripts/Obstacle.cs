using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag("Player"))
        {
            Debug.Log("�� ü�� ��� ��...");
            int damage = 20;
            GameManager.Instance.TakeDamage(damage);
        }
    }
}


