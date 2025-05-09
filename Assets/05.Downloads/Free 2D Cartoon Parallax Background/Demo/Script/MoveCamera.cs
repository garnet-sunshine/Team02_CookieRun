using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float moveSpeed = 0.0f; // 카메라 이동 속도

    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * moveSpeed;
    }
}