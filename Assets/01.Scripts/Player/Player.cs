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

    public float jumpForce = 6f; // 점프 파워
    public float speed = 3f; // 정면이동 스피드

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

    public void OnClickJumpButton() // 점프버튼 실행시 나오는 이벤트
    {
        Debug.Log("JumpButton Click");
        isJump = true;
    }

    public void OnClickSlideButton() // 점프버튼 실행시 나오는 이벤트
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
            if (isGround == true && Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                //SoundManager.PlayClip(SoundManager.instance.jumpClip); 사운드매니저 삽입후 주석해제
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
                //SoundManager.PlayClip(SoundManager.instance.slideClip); 사운드매니저 삽입후 주석해제
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
        Vector3 velocity = _rigidbody.velocity; // 직접 _rigidbody.velocity.x = ...처럼 쓰는 것은 불가능하기 때문
        velocity.x = speed; // rigidbody.velocity.x에 speed 값을 할당
        isGround = Physics2D.OverlapCircle(pos.position, radius, layer); // vector2 point, float radiut, int layer

        if (isJump) // 점프 중이라면
        {
            animator.SetBool("isJump", true);
            velocity.y += speed; // rigidbody.velocity.y 값에 속도값을 더한다


            animator.SetBool("isJump", false);
            isJump = false;

            Debug.Log("jump");
        }

        if (isDoubleJump) // 더블점프 중이라면
        {
            animator.SetBool("isJump", true);
            velocity.y += speed; // rigidbody.velocity.y 값에 속도값을 더한다

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
        Debug.Log("슬라이드 시작");
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
            //SoundManager.PlayClip(SoundManager.instance.dieClip); 사운드매니저 삽입후 주석해제
            return;
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Finish에 닿음, 게임오버");
            GameManager.Instance.OnGameOver();
        }
    }
}
