using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType { Boost , BigJelly , Heal }
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
                switch (itemType)
                {
                    case ItemType.Boost:
                        Debug.Log("Boost 발동!");
                        player.IncreaseSpeed(speedBoostAmount, speedBoostDuration);
                        break;
                    case ItemType.BigJelly:
                        Debug.Log("Giant 발동!");
                        player.Grow(giantScaleMultiplier, giantDuration);
                        break;
                    case ItemType.Heal:
                        Debug.Log("Heal 발동!");
                        player.Heal(healAmount);
                        break;
                }
            }

            Destroy(gameObject);
        }
    }
}
