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

    public bool isGround;
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
            deathCooldown -= Time.deltaTime;

            if (deathCooldown <= 0 && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
            {
                // 게임 재시작
            }

            return;
        }

        bool inputPressed = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);

        if (inputPressed)
        {
            if (isGround)
            {
                isJump = true;           // 첫 점프 예약
                isDoubleJump = false;    // 더블점프 초기화
            }
            else if (!isDoubleJump)
            {
                isJump = true;           // 더블점프 예약
                isDoubleJump = true;     // 더블점프 사용 처리
            }
        }




        // 슬라이드 처리
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
            animator.SetBool("isJump", false); // 점프 애니메이션 종료
        }

        animator.SetBool("isRun", isGround);

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = speed;

        if (isJump)
        {
            velocity.y = jumpForce;
            animator.SetBool("isJump", true);
            Debug.Log(isDoubleJump ? "더블점프" : "점프");

            isJump = false; // 실행 후 초기화
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
            //SoundManager.PlayClip(SoundManager.instance.dieClip); 사운드매니저 삽입후 주석해제
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
