using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D _rigidbody = null;

    public float jumpForce = 6f; // 점프 파워
    public float speed = 3f; // 정면이동 스피드
    public int hp = 10;

    public bool isSliding = false;
    public bool IsJump = false;
    public bool IsRun = false;

    float deathCooldown = 0f;

    public bool IsDie = false;

    public bool godMode = false;

    void Start()
    {
        animator = transform.GetComponentInChildren<Animator>();
        _rigidbody = transform.GetComponent<Rigidbody2D>();

        if (animator == null)
        {
            Debug.LogError("Not Founded Animator");
        }

        if (_rigidbody == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }
    }

    void Update()
    {
        if (IsDie)
        {
            if (deathCooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    // 게임 재시작
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                IsJump = true;
            }
        }
    }

    public void FixedUpdate()
    {
        if (IsDie)
            return;

        animator.SetBool("IsRun", true);
        Vector3 velocity = _rigidbody.velocity; // 직접 _rigidbody.velocity.x = ...처럼 쓰는 것은 불가능하기 때문
        velocity.x = speed; // rigidbody.velocity.x에 speed 값을 할당

        if (IsJump) // 점프 중이라면
        {

            velocity.y += speed; // rigidbody.velocity.y 값에 속도값을 더한다

            IsJump = false;
            

        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsRun = true;
        }

        if (godMode)
            return;

        if (IsDie)
            return;

        animator.SetInteger("IsDie", 1);
        IsDie = true;
        deathCooldown = 1f;
    }
}
