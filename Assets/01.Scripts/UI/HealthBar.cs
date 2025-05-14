using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider hpSlider;

    private int maxHP = 100;
    private int currentHP;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TakeDamage(10);
        }
    }

    void Start()
    {
        currentHP = maxHP;
        UpdateHPBar();
    }

    public void SetMaxHP(int hp)
    {
        maxHP = hp;
        currentHP = hp;
        UpdateHPBar();
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
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
        if (hpSlider != null)
        {
            float ratio = (float)currentHP / maxHP;
            hpSlider.value = ratio;

            // 색도 바꾸고
            hpSlider.fillRect.GetComponent<Image>().color =
                Color.Lerp(Color.red, new Color(0.4f, 0.2f, 0.1f), 1 - ratio);

            Debug.Log($"[HPBar] Slider.value = {ratio}");
        }
    }
    }