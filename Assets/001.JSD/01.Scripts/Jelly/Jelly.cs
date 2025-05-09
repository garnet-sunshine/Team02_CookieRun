using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    public GameObject[] coinsPrefab; // 코인 프리펩 연결
    public int coinCount = 10; // 코인을 몇개 생성할지
    public float spacing = 1.5f; // 코인 간격

    private void Start()
    {
        SpawnCoins();
    }

    void SpawnCoins()
    {
        Vector3 startPos = transform.position; // 시작 위치

        for (int i = 0; i < coinCount; i++)
        {
            int randomIndex = Random.Range(0, coinsPrefab.Length);
            GameObject prefabToSpawn = coinsPrefab[randomIndex];

            Vector3 spawnPos = new Vector3(startPos.x + (i * spacing), startPos.y, startPos.z);
            Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
        }
    }
}
