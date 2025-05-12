using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
   public static ScoreManager Instance; // �������� ScoreManager.Instance�� ���� �����ϰ� ����

    public TextMeshProUGUI scoreText; // ���� ������ ��Ÿ���� UI
    public TextMeshProUGUI highScoreText; // �ְ� ������ ��Ÿ���� UI


    private int currentScore = 0;
    private int highScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� ����
        }
        else
        {
            Destroy(gameObject); // �ߺ� ����
        }
    }

    // �ְ� ���� �ҷ�����
    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0); // ���� ���� �� ���� �����(PlayerPrefs)���� �ְ� ������ �ҷ���
        UpdateUI();
    }

    // ���� ��� �߰�
    public void AddScore(int amount) 
    {
        currentScore += amount; // ������ amount��ŭ ����
        if (currentScore >= highScore) // ���� ������ �ְ� �������� ũ�ٸ�
        {
            highScore = currentScore; // �ְ������� ���������� ����
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        UpdateUI();
    }

    // UI ������Ʈ
    private void UpdateUI()
    {
        // ���� ���� �� �ְ� ������ ȭ�鿡 ǥ��
        if (scoreText != null)
            scoreText.text = "Score: " + currentScore;

        if (highScoreText != null)
            highScoreText.text = "High Score: " + highScore;
          }
    

    // ���� �ʱ�ȭ
    public void ResetScore()
    {
        currentScore = 0;
        UpdateUI();
    }
}

