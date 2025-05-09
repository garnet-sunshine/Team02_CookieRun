using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera camera;

    // �ӵ� ����
    public float moveSpeed = 5f; // ���� �ӵ�
    private bool isSpeedBoosted = false;

    // �Ŵ�ȭ
    private Vector3 originalScale; // ���� ũ��
    private bool isGiant = false;

    // ü�� ����
    public int maxHealth = 100; // ���� ü��
    public int currentHealth;

    // �ı� ���
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

    // �ӵ� ����
    internal void IncreaseSpeed(float speedBoostAmount, float speedBoostDuration)
    {
        if (!isSpeedBoosted)
        {
            StartCoroutine(SpeedBoostCoroutine(speedBoostAmount, speedBoostDuration));
        }
    }

    private IEnumerator SpeedBoostCoroutine(float amount, float duration)
    {
        isSpeedBoosted = true; // �ν�Ʈ�� ������
        isDestroyMode = true; // �ı� ��� Ȱ��ȭ

        Debug.Log("Boost Ȱ��ȭ!");
        moveSpeed += amount;

        yield return new WaitForSeconds(duration);

        moveSpeed -= amount;
        isDestroyMode = false;
        isSpeedBoosted = false;

        Debug.Log("Boost ����.");
    }

    // �Ŵ�ȭ
    internal void Grow(float giantScaleMultiplier, float giantDuration)
    {
        if (!isGiant)
        {
            StartCoroutine(GrowCoroutine(giantScaleMultiplier, giantDuration));
        }
    }

    private IEnumerator GrowCoroutine(float multiplier, float duration)
    {
        isGiant = true; // �Ŵ�ȭ�� �Ǹ�
        isDestroyMode = true; // �ı� ��� Ȱ��ȭ

        Debug.Log("�Ŵ�ȭ!!");
        transform.localScale = originalScale * multiplier;

        yield return new WaitForSeconds(duration);

        transform.localScale = originalScale;
        isDestroyMode = false;
        isGiant = false;

        Debug.Log("�Ŵ�ȭ ����..");
    }

    // ü�� ȸ��
    internal void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        Debug.Log($"ü�� ȸ�� : + {healAmount}, ���� ü�� : {currentHealth}");
    }
}