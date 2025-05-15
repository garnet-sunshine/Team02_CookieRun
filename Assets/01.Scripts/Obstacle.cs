using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag("Player"))
        {
            Debug.Log("¡æ Ã¼·Â ±ð´Â Áß...");
            int damage = 20;
            GameManager.Instance.TakeDamage(damage);
        }
    }
}


