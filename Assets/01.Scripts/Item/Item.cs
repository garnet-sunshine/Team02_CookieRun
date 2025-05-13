using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType { Boost , BigJelly , Heal } // enum 열거형으로 아이템 종류를 미리 정해둠
    public ItemType itemType;

    public float speedBoostAmount = 3f; // 속도가 얼마나 빨라질지
    public float speedBoostDuration = 5f; // 부스트가 몇 초 동안 지속될지

    public float giantScaleMultiplier = 2f; // 캐릭터의 크기를 2배만큼 키움
    public float giantDuration = 5F; // 거대화가 몇 도 동안 유지될지

    public int healAmount = 20; // 체력 회복 양

    // 2D 콜라이더가 Is Trigger로 설정된 경우 , 다른 콜라이더와 닿았을 때 실행됨
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           PlayerController player = collision.GetComponent<PlayerController>(); // PlayerController스크립트에 접근

            if (player != null)
            {
                switch (itemType)
                {
                    // 부스트
                    case ItemType.Boost:
                        Debug.Log("Boost 발동!");
                        player.IncreaseSpeed(speedBoostAmount, speedBoostDuration);
                        SoundManager.PlayClip(SoundManager.instance.itemClip);
                        break;
                    // 거대화
                    case ItemType.BigJelly:
                        Debug.Log("Giant 발동!");
                        player.Grow(giantScaleMultiplier, giantDuration);
                        SoundManager.PlayClip(SoundManager.instance.itemClip);
                        break;
                    // 체력회복
                    case ItemType.Heal:
                        Debug.Log("Heal 발동!");
                        player.Heal(healAmount);
                        SoundManager.PlayClip(SoundManager.instance.itemClip);
                        break;
                }
            }

            Destroy(gameObject); // 한번 먹으면 파괴
        }
    }
}
