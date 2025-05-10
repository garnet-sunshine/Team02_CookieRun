using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float moveSpeed = 0.7f;

    void Update()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }

}
