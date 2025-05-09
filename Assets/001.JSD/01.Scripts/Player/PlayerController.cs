using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera camera;

    // 속도 증가
    public float moveSpeed = 5f; // 기존 속도
    private bool isSpeedBoosted = false;

    // 거대화
    private Vector3 originalScale; // 기존 크기
    private bool isGiant = false;

    // 체력 관련
    public int maxHealth = 100; // 기존 체력
    public int currentHealth;

    // 파괴 모드
    public bool isDestroyMode = false;

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
        originalScale = transform.localScale;
        currentHealth = maxHealth;
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movementDirection = new Vector2(horizontal, vertical).normalized;
        
        if(Mathf.Abs(horizontal) > 0.01f)
        {
            lookDirection = new Vector2(horizontal, 0).normalized;
        }
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
        isSpeedBoosted = true; // 부스트가 켜지면
        isDestroyMode = true; // 파괴 모드 활성화

        Debug.Log("Boost 활성화!");
        moveSpeed += amount;

        yield return new WaitForSeconds(duration);

        moveSpeed -= amount;
        isDestroyMode = false;
        isSpeedBoosted = false;

        Debug.Log("Boost 종료.");
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
        isGiant = true; // 거대화가 되면
        isDestroyMode = true; // 파괴 모드 활성화

        Debug.Log("거대화!!");
        transform.localScale = originalScale * multiplier;

        yield return new WaitForSeconds(duration);

        transform.localScale = originalScale;
        isDestroyMode = false;
        isGiant = false;

        Debug.Log("거대화 종료..");
    }

    // 체력 회복
    internal void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        Debug.Log($"체력 회복 : + {healAmount}, 현제 체력 : {currentHealth}");
    }
}