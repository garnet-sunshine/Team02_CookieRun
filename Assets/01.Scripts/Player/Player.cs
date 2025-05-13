using System.Collections;
using System.Collections.Generic;
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

    public float jumpForce = 6f; // 점프 파워
    public float speed = 3f; // 정면이동 스피드
    public int hp = 10;

    public bool isSliding = false;
    public bool isJump = false;
    public bool isRun = false;

    float deathCooldown = 0f;

    public bool IsDie = false;

    public bool godMode = false;

    Button JumpBtn;
    Button SlideBtn;

    [SerializeField]
    private Slider hpbar;

    private float maxHp = 100;
    private float curHp = 100;
    

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

        JumpBtn = GetComponent<Button>();
        JumpBtn.onClick.AddListener(OnClickJumpButton);

        SlideBtn = GetComponent<Button>();
        SlideBtn.onClick.AddListener(OnClickJumpButton);

        hpbar.value = (float)curHp / (float)maxHp;

        if (animator == null)
        {
            Debug.LogError("Not Founded Animator");
        }

        if (_rigidbody == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }
        if (boxCollider == null)
            Debug.LogError("Not Founded BoxCollider2D");
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            curHp -= 10;
        }

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
                isJump = true;
                //SoundManager.PlayClip(SoundManager.instance.jumpClip); 사운드매니저 삽입후 주석해제


            }

            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                isSliding = true;
                //SoundManager.PlayClip(SoundManager.instance.slideClip); 사운드매니저 삽입후 주석해제
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


        if (isJump) // 점프 중이라면
        {
            animator.SetBool("isJump", true);
            velocity.y += speed; // rigidbody.velocity.y 값에 속도값을 더한다
            isJump = false;

            Debug.Log("jump");
        }

        if (isSliding)
        {
            boxCollider.size = slidingColliderSize;
            animator.SetBool("isSliding", true);

            Debug.Log("sliding");
        }
        else
        {
            boxCollider.size = originalColliderSize;
            isSliding = false;
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

    private void HandleHp()
    {
        hpbar.value = (float)curHp / (float)maxHp;
    }

}
