using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountain2 : MonoBehaviour
{
    public float moveSpeed = 0.5f;

    void Update()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        Debug.Log("��� ��ġ: " + transform.position.x);
    }

}
