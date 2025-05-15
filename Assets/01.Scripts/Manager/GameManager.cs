using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("StartScene UI")]
    public GameObject startCanvas;
    public GameObject stageCanvas;
    public GameObject[] loadingCanvas;

    [Header("GameScene UI")]
    public GameObject playCanvas;
    public GameObject gameOverCanvas;

    [Header("Stage BGM")]
    public AudioClip[] stageBGMs;

    [SerializeField] private PauseUIManager pauseUIManager;
    public HealthBar healthBar;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject); // 파괴되지 않게
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // StartScene 흐름

    public void OnClickStartGame()
    {
        startCanvas.SetActive(false);
        stageCanvas.SetActive(true);
    }

    public void OnClickTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void OnClickStage(int stageIndex)
    {
        stageCanvas.SetActive(false);
        loadingCanvas[stageIndex].SetActive(true);
        StartCoroutine(LoadStageAfterDelay(stageIndex));
    }

    private IEnumerator LoadStageAfterDelay(int stageIndex)
    {
        yield return new WaitForSeconds(2f);

        if (SoundManager.instance != null && stageIndex < stageBGMs.Length)
        {
            SoundManager.instance.ChangeBackGroundMusic(stageBGMs[stageIndex]);
        }

        string sceneName = "GameScene_" + stageIndex; // GameScene_0, GameScene_1, GameScene_2
        SceneManager.LoadScene(sceneName);
    }


    // GameScene 흐름
    public void OnGameStart()
    {
        playCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
    }

    public void OnGameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0f;

        if (playCanvas != null)
        {
            playCanvas.SetActive(false);
        }
        else
        {
            Debug.LogWarning("playCanvas가 연결되지 않았습니다!");
        }

        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }
        else
        {
            Debug.LogWarning("gameOverCanvas가 연결되지 않았습니다!");
        }
    }

    public void OnGameOverConfirm()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void TakeDamage(int amount)
    {
        healthBar.TakeDamage(amount);
    }


   

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseUIManager.ShowPauseUI();  // pauseCanvas 활성화
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseUIManager.HidePauseUI();  // pauseCanvas 비활성화
    }
}
