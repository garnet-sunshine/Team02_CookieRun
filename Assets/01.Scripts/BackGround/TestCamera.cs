using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamera : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    public float forwardSpeed = 3f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;
        _rigidbody.velocity = velocity;
    }

 }

