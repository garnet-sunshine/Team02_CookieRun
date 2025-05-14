using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    public int scoreValue = 10; // ���� 1���� ����


    // 2D �ݶ��̴��� Is Trigger�� ������ ��� , �ٸ� �ݶ��̴��� ����� �� �����
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ���� ������Ʈ�� Tag�� "Player"���� Ȯ�� (�÷��̾ �����ϰ� ����� ���� ���ǹ�)
        {
            PlayerController player = other.GetComponent<PlayerController>(); // PlayerController��ũ��Ʈ ����

            if (player != null)
            {
                player.AddScore(scoreValue); // ���� �߰�

                SoundManager.PlayClip(SoundManager.instance.jellyClip); // ���� �Դ� �Ҹ� ���
            }

            Destroy(gameObject); // �ѹ� ������ ������� ����
        }
    }
}
