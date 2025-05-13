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

    public float jumpForce = 6f; // ���� �Ŀ�
    public float speed = 3f; // �����̵� ���ǵ�
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
                isJump = true;
                //SoundManager.PlayClip(SoundManager.instance.jumpClip); ����Ŵ��� ������ �ּ�����


            }

            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                isSliding = true;
                //SoundManager.PlayClip(SoundManager.instance.slideClip); ����Ŵ��� ������ �ּ�����
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


        if (isJump) // ���� ���̶��
        {
            animator.SetBool("isJump", true);
            velocity.y += speed; // rigidbody.velocity.y ���� �ӵ����� ���Ѵ�
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
            //SoundManager.PlayClip(SoundManager.instance.dieClip); ����Ŵ��� ������ �ּ�����
            return;
        }

    }

    private void HandleHp()
    {
        hpbar.value = (float)curHp / (float)maxHp;
    }

}
