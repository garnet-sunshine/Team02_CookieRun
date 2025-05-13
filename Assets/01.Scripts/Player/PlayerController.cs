using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera camera;
    private UIManager uiManager;

    // 점수
    public int score = 0;

    // 속도 증가
    public float moveSpeed = 5f;   // 기존 속도
    private bool isSpeedBoosted = false;

    // 거대화
    private Vector3 originalScale;
    private bool isGiant = false;

    // 체력 관련
    public int maxHealth = 100;
    public int currentHealth;

    // 파괴 모드
    public bool isDestroyMode = false;

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
        originalScale = transform.localScale;
        currentHealth = maxHealth;

        uiManager = FindObjectOfType<UIManager>();
        uiManager.UpdateHealth(currentHealth, maxHealth);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate(); 

        _rigidbody.velocity = movementDirection * moveSpeed;  
    }
    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movementDirection = new Vector2(horizontal, vertical).normalized;

        if (Mathf.Abs(horizontal) > 0.01f)
        {
            lookDirection = new Vector2(horizontal, 0).normalized;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (uiManager != null)
        {
            uiManager.UpdateHealth(currentHealth, maxHealth); 
        }

        if (currentHealth <= 0)
        {
            Die(); 
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("현재 점수 : " + score);
    }

    // 속도 증가
    internal void IncreaseSpeed(float speedBoostAmount, float speedBoostDuration)
    {
        if (!isSpeedBoosted)
        {
            StartCoroutine(SpeedBoostCoroutine(speedBoostAmount, speedBoostDuration));
        }
    }

    private IEnumerator SpeedBoostCoroutine(float amount, float duration)
    {
        isSpeedBoosted = true;
        isDestroyMode = true;  // 파괴 모드 활성화

      
        moveSpeed += amount;

        yield return new WaitForSeconds(duration);

        moveSpeed -= amount;
        isDestroyMode = false;
        isSpeedBoosted = false;
    }

    // 거대화
    internal void Grow(float giantScaleMultiplier, float giantDuration)
    {
        if (!isGiant)
        {
            StartCoroutine(GrowCoroutine(giantScaleMultiplier, giantDuration));
        }
    }

    private IEnumerator GrowCoroutine(float multiplier, float duration)
    {
        isGiant = true;
        isDestroyMode = true;  // 파괴 모드 활성화
        transform.localScale = originalScale * multiplier;

        yield return new WaitForSeconds(duration);

        transform.localScale = originalScale;
        isDestroyMode = false;
        isGiant = false;
    }

    // 체력 회복
    internal void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    private void Die()
    {
        Debug.Log("Player가 사망했습니다!");
    }
}

