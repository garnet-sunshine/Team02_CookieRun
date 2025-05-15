using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    public int scoreValue = 10; // ���� 1���� ����


    // 2D �ݶ��̴��� Is Trigger�� ������ ��� , �ٸ� �ݶ��̴��� ����� �� �����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Jelly collided with: {collision.name}");

        ScoreManager.Instance.AddScore(scoreValue);

        if (collision.CompareTag("Player")) // ���� ������Ʈ�� Tag�� "Player"���� Ȯ�� (�÷��̾ �����ϰ� ����� ���� ���ǹ�)
        {
            Debug.Log("Player�� �浹��!");

            PlayerController player = collision.GetComponent<PlayerController>(); // PlayerController��ũ��Ʈ ����

            SoundManager.PlayClip(SoundManager.instance.jellyClip); // ���� �Դ� �Ҹ� ���

            if (player != null)
            {
                player.AddScore(scoreValue); // ���� �߰�
            }

            Destroy(gameObject); // �ѹ� ������ ������� ����
        }
    }
}
