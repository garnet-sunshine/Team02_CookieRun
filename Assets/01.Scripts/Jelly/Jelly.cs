using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    public GameObject[] coinsPrefab; // ���� ������ ����
<<<<<<< Updated upstream
    public int scoreValue = 10; // ���� 1���� ����

=======
    // public int coinCount = 10; // ������ � ��������
    // public float spacing = 1.5f; // ���� ����
    public int scoreValue = 10; // ���� 1���� ����
   
        
>>>>>>> Stashed changes

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            if (player != null)
            {
                player.AddScore(scoreValue); // ���� �߰�
            }

            Destroy(gameObject);
        }
    }
}
