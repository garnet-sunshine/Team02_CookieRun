using System.Collections;
using UnityEngine;

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
    public float slideDuration = 1f;

    public bool isJump = false;
    public bool isDoubleJump = false;

    [SerializeField] Transform pos;
    [SerializeField] float radius;
    [SerializeField] LayerMask layer;

    float deathCooldown = 0f;

    public bool IsDie = false;

    public bool godMode = false;

    public void OnClickJumpButton() // 점프버튼 실행시 나오는 이벤트
    {
        Debug.Log("JumpButton Click");
        Jump();
    }

    public void OnClickSlideButton() // 점프버튼 실행시 나오는 이벤트
    {
        Debug.Log("SlideButton Click");
        Slide();
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //SoundManager.PlayClip(SoundManager.instance.jumpClip); 사운드매니저 삽입후 주석해제
                Jump();
            }

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                Slide();
                //SoundManager.PlayClip(SoundManager.instance.slideClip); 사운드매니저 삽입후 주석해제
            }
        }
    }

    private void Jump()
    {
        if(isJump && isDoubleJump)
        {
            return;
        }
        if (isJump && isDoubleJump == false)
        {
            DoubleJump();
        }
        else
        {
            isJump = true;
            Debug.Log("JUMP");
            animator.SetBool("isJump", true);
            AddJumpVelocity();
        }
    }

    private void DoubleJump()
    {
        isDoubleJump = true;
        Debug.Log("DOUBLE JUMP");
        AddJumpVelocity();
    }

    private void AddJumpVelocity()
    {
        Vector2 velocity = _rigidbody.velocity;
        velocity.y += jumpForce;
        _rigidbody.velocity = velocity;
    }

    private void Slide()
    {
        StartCoroutine(SlideCoroutine());
    }
    private IEnumerator SlideCoroutine()
    {
        boxCollider.size = slidingColliderSize;
        boxCollider.offset = slidingColliderOffset;
        animator.SetBool("isSliding", true);

        Debug.Log("sliding");

        yield return new WaitForSeconds(slideDuration);

        boxCollider.size = originalColliderSize;
        boxCollider.offset = originalColliderOffset;

        animator.SetBool("isSliding", false);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = isDoubleJump = false;
            animator.SetBool("isJump", false);
        }

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
