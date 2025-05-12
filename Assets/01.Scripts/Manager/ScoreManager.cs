using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
   public static ScoreManager Instance; // 전역에서 ScoreManager.Instance로 접근 가능하게 만듬

    public TextMeshProUGUI scoreText; // 현재 점수를 나타내는 UI
    public TextMeshProUGUI highScoreText; // 최고 점수를 나타내는 UI


    private int currentScore = 0;
    private int highScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 유지
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }
    }

    // 최고 점수 불러오기
    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0); // 게임 시작 시 로컬 저장소(PlayerPrefs)에서 최고 점수를 불러옴
        UpdateUI();
    }

    // 점수 기능 추가
    public void AddScore(int amount) 
    {
        currentScore += amount; // 점수를 amount만큼 증가
        if (currentScore >= highScore) // 현재 점수가 최고 점수보다 크다면
        {
            highScore = currentScore; // 최고점수를 현재점수에 저장
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        UpdateUI();
    }

    // UI 업데이트
    private void UpdateUI()
    {
        // 현재 점수 및 최고 점수를 화면에 표시
        if (scoreText != null)
            scoreText.text = "Score: " + currentScore;

        if (highScoreText != null)
            highScoreText.text = "High Score: " + highScore;
          }
    

    // 점수 초기화
    public void ResetScore()
    {
        currentScore = 0;
        UpdateUI();
    }
}

