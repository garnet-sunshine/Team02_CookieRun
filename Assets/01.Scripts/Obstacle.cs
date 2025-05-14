using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float damage = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HealthBar player = other.GetComponent<HealthBar>();
            if (player != null)
            {
               // player.TakeDamage(damage);
            }
        }
    }
}
