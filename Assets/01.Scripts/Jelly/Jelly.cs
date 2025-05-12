using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    public GameObject[] coinsPrefab; // 코인 프리펩 연결
<<<<<<< Updated upstream
    public int scoreValue = 10; // 젤리 1개당 점수

=======
    // public int coinCount = 10; // 코인을 몇개 생성할지
    // public float spacing = 1.5f; // 코인 간격
    public int scoreValue = 10; // 젤리 1개당 점수
   
        
>>>>>>> Stashed changes

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            if (player != null)
            {
                player.AddScore(scoreValue); // 점수 추가
            }

            Destroy(gameObject);
        }
    }
}
