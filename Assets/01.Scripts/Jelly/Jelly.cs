using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    public int scoreValue = 10; // 젤리 1개당 점수


    // 2D 콜라이더가 Is Trigger로 설정된 경우 , 다른 콜라이더와 닿았을 때 실행됨
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Jelly collided with: {collision.name}");

        ScoreManager.Instance.AddScore(scoreValue);

        if (collision.CompareTag("Player")) // 닿은 오브젝트의 Tag가 "Player"인지 확인 (플레이어만 반응하게 만들기 위한 조건문)
        {
            Debug.Log("Player와 충돌함!");

            PlayerController player = collision.GetComponent<PlayerController>(); // PlayerController스크립트 접근

            SoundManager.PlayClip(SoundManager.instance.jellyClip); // 젤리 먹는 소리 재생

            if (player != null)
            {
                player.AddScore(scoreValue); // 점수 추가
            }

            Destroy(gameObject); // 한번 먹으면 사라지게 만듬
        }
    }
}
