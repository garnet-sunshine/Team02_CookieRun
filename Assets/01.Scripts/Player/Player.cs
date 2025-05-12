using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D _rigidbody = null;

    public float jumpForce = 6f; // ���� �Ŀ�
    public float speed = 3f; // �����̵� ���ǵ�
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
                    // ���� �����
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
        Vector3 velocity = _rigidbody.velocity; // ���� _rigidbody.velocity.x = ...ó�� ���� ���� �Ұ����ϱ� ����
        velocity.x = speed; // rigidbody.velocity.x�� speed ���� �Ҵ�

        if (IsJump) // ���� ���̶��
        {

            velocity.y += speed; // rigidbody.velocity.y ���� �ӵ����� ���Ѵ�

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
