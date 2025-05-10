using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountain : MonoBehaviour
{
    public float moveSpeed = 1f;

    void Update()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }

}
