using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("StartScene UI")]
    public GameObject startCanvas;
    public GameObject stageCanvas;
    public GameObject loadingCanvas;

    [Header("GameScene UI")]
    public GameObject playCanvas;
    public GameObject gameOverCanvas;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // StartScene »Â∏ß

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
        loadingCanvas.SetActive(true);
        StartCoroutine(LoadStageAfterDelay(stageIndex));
    }

    private IEnumerator LoadStageAfterDelay(int stageIndex)
    {
        yield return new WaitForSeconds(2f);

        string sceneName = "GameScene" + stageIndex; // GameScene1, GameScene2, GameScene3
        SceneManager.LoadScene(sceneName);
    }


    // GameScene »Â∏ß
    public void OnGameStart()
    {
        playCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
    }

    public void OnGameOver()
    {
        playCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
    }

    public void OnGameOverConfirm()
    {
        SceneManager.LoadScene("StartScene");
    }
}
