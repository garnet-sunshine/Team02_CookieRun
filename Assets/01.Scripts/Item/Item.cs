using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType { Boost , BigJelly , Heal } // enum ���������� ������ ������ �̸� ���ص�
    public ItemType itemType;

    public float speedBoostAmount = 3f; // �ӵ��� �󸶳� ��������
    public float speedBoostDuration = 5f; // �ν�Ʈ�� �� �� ���� ���ӵ���

    public float giantScaleMultiplier = 2f; // ĳ������ ũ�⸦ 2�踸ŭ Ű��
    public float giantDuration = 5F; // �Ŵ�ȭ�� �� �� ���� ��������

    public int healAmount = 20; // ü�� ȸ�� ��

    // 2D �ݶ��̴��� Is Trigger�� ������ ��� , �ٸ� �ݶ��̴��� ����� �� �����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           PlayerController player = collision.GetComponent<PlayerController>(); // PlayerController��ũ��Ʈ�� ����

            if (player != null)
            {
                switch (itemType)
                {
                    // �ν�Ʈ
                    case ItemType.Boost:
                        Debug.Log("Boost �ߵ�!");
                        player.IncreaseSpeed(speedBoostAmount, speedBoostDuration);
                        SoundManager.PlayClip(SoundManager.instance.itemClip);
                        break;
                    // �Ŵ�ȭ
                    case ItemType.BigJelly:
                        Debug.Log("Giant �ߵ�!");
                        player.Grow(giantScaleMultiplier, giantDuration);
                        SoundManager.PlayClip(SoundManager.instance.itemClip);
                        break;
                    // ü��ȸ��
                    case ItemType.Heal:
                        Debug.Log("Heal �ߵ�!");
                        player.Heal(healAmount);
                        SoundManager.PlayClip(SoundManager.instance.itemClip);
                        break;
                }
            }

            Destroy(gameObject); // �ѹ� ������ �ı�
        }
    }
}
