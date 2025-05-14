using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class HealthBar : MonoBehaviour
{

    //[SerializeField] private Slider healthSlider; // 체력바 슬라이더

    //public void UpdateHealth(int currentHealth, int MaxHealth)
    //{
    //    if (healthSlider != null)
    //    {
    //        healthSlider.value = (float)currentHealth / MaxHealth;
    //    }
    //}

public class HPBarController : MonoBehaviour
{
    [SerializeField] private Slider hpSlider;

    private int maxHP = 100;
    private int currentHP;

    void Start()
    {
        currentHP = maxHP;
        UpdateHPBar();
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        UpdateHPBar();

        if (currentHP <= 0)
        {
       
            GameManager.Instance.OnGameOver();
        }
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        UpdateHPBar();
    }

    private void UpdateHPBar()
    {
        hpSlider.value = (float)currentHP / maxHP;
    }

    public void SetMaxHP(int hp)
    {
        maxHP = hp;
        currentHP = hp;
        UpdateHPBar();
    }
}

}
