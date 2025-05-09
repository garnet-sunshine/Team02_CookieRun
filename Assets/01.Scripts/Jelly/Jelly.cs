using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    public GameObject[] coinsPrefab; // ���� ������ ����
    public int coinCount = 10; // ������ � ��������
    public float spacing = 1.5f; // ���� ����

    private void Start()
    {
        SpawnCoins();
    }

    void SpawnCoins()
    {
        Vector3 startPos = transform.position; // ���� ��ġ

        for (int i = 0; i < coinCount; i++)
        {
            int randomIndex = Random.Range(0, coinsPrefab.Length);
            GameObject prefabToSpawn = coinsPrefab[randomIndex];

            Vector3 spawnPos = new Vector3(startPos.x + (i * spacing), startPos.y, startPos.z);
            Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
        }
    }
}
