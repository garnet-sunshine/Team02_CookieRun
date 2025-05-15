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
            TakeDamage(20);
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
            Debug.Log("hp=0, ���� ����");
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
        Debug.Log("�׽�Ʈ�Դϴ�.");
     //   if (hpSlider != null)
        {
            Debug.Log("�׽�Ʈ�Դϴ�2.");
            float ratio = (float)currentHP / maxHP;
            hpSlider.value = ratio;

            // ���� �ٲٰ�
            hpSlider.fillRect.GetComponent<Image>().color =
                Color.Lerp(Color.red, new Color(0.4f, 0.2f, 0.1f), 1 - ratio);

            Debug.Log($"[HPBar] Slider.value = {ratio}");
        }
    }
    }