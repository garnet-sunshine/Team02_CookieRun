using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D _rigidbody = null;
    BoxCollider2D boxCollider = null;

    public Vector2 originalColliderSize;
    public Vector2 slidingColliderSize;
    public Vector2 originalColliderOffset;
    public Vector2 slidingColliderOffset;

    public float jumpForce = 6f; // ���� �Ŀ�
    public float speed = 3f; // �����̵� ���ǵ�

    public bool isSliding = false;
    public bool isJump = false;
    public bool isDoubleJump = false;
    public bool isRun = false;

    public bool isGround;
    [SerializeField] Transform pos;
    [SerializeField] float radius;
    [SerializeField] LayerMask layer;

    float deathCooldown = 0f;
    public bool IsDie = false;
    public bool godMode = false;

    Button JumpBtn;
    Button SlideBtn;

    public void OnClickJumpButton() // ������ư ����� ������ �̺�Ʈ
    {
        Debug.Log("JumpButton Click");
        isJump = true;
    }

    public void OnClickSlideButton() // ������ư ����� ������ �̺�Ʈ
    {
        Debug.Log("SlideButton Click");
        isSliding = true;
    }

    void Start()
    {

        animator = transform.GetComponentInChildren<Animator>();
        _rigidbody = transform.GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        
    }

    void Update()
    {
        if (IsDie)
        {
            deathCooldown -= Time.deltaTime;

            if (deathCooldown <= 0 && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
            {
                // ���� �����
            }

            return;
        }

        bool inputPressed = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);

        if (inputPressed)
        {
            if (isGround)
            {
                isJump = true;           // ù ���� ����
                isDoubleJump = false;    // �������� �ʱ�ȭ
            }
            else if (!isDoubleJump)
            {
                isJump = true;           // �������� ����
                isDoubleJump = true;     // �������� ��� ó��
            }
        }




        // �����̵� ó��
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            isSliding = true;
            boxCollider.size = slidingColliderSize;
            boxCollider.offset = slidingColliderOffset;
            animator.SetBool("isSliding", true);
        }
        else
        {
            isSliding = false;
            boxCollider.size = originalColliderSize;
            boxCollider.offset = originalColliderOffset;
            animator.SetBool("isSliding", false);
        }
    }

    public void FixedUpdate()
    {
        if (IsDie) return;

        isGround = Physics2D.OverlapCircle(pos.position, radius, layer);

        if (isGround)
        {
            animator.SetBool("isJump", false); // ���� �ִϸ��̼� ����
        }

        animator.SetBool("isRun", isGround);

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = speed;

        if (isJump)
        {
            velocity.y = jumpForce;
            animator.SetBool("isJump", true);
            Debug.Log(isDoubleJump ? "��������" : "����");

            isJump = false; // ���� �� �ʱ�ȭ
        }

        if (isSliding)
        {
            boxCollider.size = slidingColliderSize;
            boxCollider.offset = slidingColliderOffset;
            animator.SetBool("isSliding", true);
            Debug.Log("sliding");
        }

        _rigidbody.velocity = velocity;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Ground"))
        //{
        //    isRun = true;
        //}

        if (godMode)
            return;

        if (IsDie)
        {
            //SoundManager.PlayClip(SoundManager.instance.dieClip); ����Ŵ��� ������ �ּ�����
            return;
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            GameManager.Instance.OnGameOver();
        }
    }
}
