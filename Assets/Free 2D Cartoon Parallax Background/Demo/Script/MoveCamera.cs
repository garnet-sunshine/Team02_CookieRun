using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float moveSpeed = 0.0f; // ī�޶� �̵� �ӵ�

    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * moveSpeed;
    }
}