using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType { Boost , BigJelly , Heal }
    public ItemType itemType;

    public float speedBoostAmount = 3f;
    public float sppedBoostDuration = 5f;

    public float giantScaleMultiplier = 2f;
    public float giantDuration = 5F;

    public int healAmount = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
          

        // 플레이어 능력 올리기
        Destroy(gameObject);
        }
    }
}
