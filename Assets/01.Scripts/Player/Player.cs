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

    private bool isGround;
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
            if (isGround == true && Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                //SoundManager.PlayClip(SoundManager.instance.jumpClip); ����Ŵ��� ������ �ּ�����
                if (isJump == true && isDoubleJump == false)
                {
                    isDoubleJump = true;
                }
                isJump = true;
                

            }

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                isSliding = true;
                boxCollider.size = slidingColliderSize;
                boxCollider.offset = slidingColliderOffset;

                animator.SetBool("isSliding", true);
                //SoundManager.PlayClip(SoundManager.instance.slideClip); ����Ŵ��� ������ �ּ�����
            }
            else
            {
                isSliding = false;
                boxCollider.size = originalColliderSize;
                boxCollider.offset = originalColliderOffset;
                animator.SetBool("isSliding", false);
            }
        }
    }

    public void FixedUpdate()
    {
        if (IsDie)
            return;

        animator.SetBool("isRun", true);
        Vector3 velocity = _rigidbody.velocity; // ���� _rigidbody.velocity.x = ...ó�� ���� ���� �Ұ����ϱ� ����
        velocity.x = speed; // rigidbody.velocity.x�� speed ���� �Ҵ�
        isGround = Physics2D.OverlapCircle(pos.position, radius, layer); // vector2 point, float radiut, int layer

        if (isJump) // ���� ���̶��
        {
            animator.SetBool("isJump", true);
            velocity.y += speed; // rigidbody.velocity.y ���� �ӵ����� ���Ѵ�


            animator.SetBool("isJump", false);
            isJump = false;

            Debug.Log("jump");
        }

        if (isDoubleJump) // �������� ���̶��
        {
            animator.SetBool("isJump", true);
            velocity.y += speed; // rigidbody.velocity.y ���� �ӵ����� ���Ѵ�

            animator.SetBool("isJump", false);
            isJump = false;

            Debug.Log("Dobulejump");
        }


        if (isSliding)
        {
            boxCollider.size = slidingColliderSize;
            boxCollider.offset = slidingColliderOffset;
            animator.SetBool("isSliding", true);

            Debug.Log("sliding");

            //StartCoroutine(SlideCoroutine());
        }
        _rigidbody.velocity = velocity;
    }

    private IEnumerator SlideCoroutine()
    {
        Debug.Log("�����̵� ����");
        isSliding = true;

        boxCollider.size = slidingColliderSize;
        boxCollider.offset = slidingColliderOffset;

        animator.SetBool("isSliding", true);

        Debug.Log("sliding");

        yield return new WaitForSeconds(0.5f);

        boxCollider.size = originalColliderSize;
        boxCollider.offset = originalColliderOffset;

        animator.SetBool("isSliding", false);
        isSliding = false;
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
            Debug.Log("Finish�� ����, ���ӿ���");
            GameManager.Instance.OnGameOver();
        }
    }
}
