using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private PauseUIManager pauseUIManager;


    [Header("StartScene UI")]
    public GameObject startCanvas;
    public GameObject stageCanvas;
    public GameObject[] loadingCanvas;

    [Header("GameScene UI")]
    public GameObject playCanvas;
    public GameObject gameOverCanvas;

    [Header("Stage BGM")]
    public AudioClip[] stageBGMs;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject); // ÆÄ±«µÇÁö ¾Ê°Ô
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // StartScene Èå¸§

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


    // GameScene Èå¸§
    public void OnGameStart()
    {
        playCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
    }

    public void OnGameOver()
    {
        Time.timeScale = 0f;
        playCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
    }

    public void OnGameOverConfirm()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseUIManager.ShowPauseUI();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseUIManager.HidePauseUI();
    }
}

