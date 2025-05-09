using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType { Boost, BigJelly, Heal }
    public ItemType itemType;

    public float speedBoostAmount = 3f;
    public float speedBoostDuration = 5f;

    public float giantScaleMultiplier = 2f;
    public float giantDuration = 5F;

    public int healAmount = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            if (player != null)
            {
                // 아이템 리스트
                switch (itemType)
                {
                    case ItemType.Boost:
                        player.IncreaseSpeed(speedBoostAmount, speedBoostDuration);
                        break;
                    case ItemType.BigJelly:
                        player.Grow(giantScaleMultiplier, giantDuration);
                        break;
                    case ItemType.Heal:
                        player.Heal(healAmount);
                        break;
                }
            }



            // 아이템을 먹으면 사라짐
            Destroy(gameObject);
        }
    }
}
