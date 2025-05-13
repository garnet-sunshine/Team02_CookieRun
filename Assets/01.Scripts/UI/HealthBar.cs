using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Slider healthSlider; // 체력바 슬라이더

    public void UpdateHealth(int currentHealth, int MaxHealth)
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / MaxHealth;
        }
    }
}
