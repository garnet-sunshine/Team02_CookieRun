using UnityEngine;

public class PauseUIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;

    public void ShowPauseUI()
    {
        pauseCanvas.SetActive(true);
    }

    public void HidePauseUI()
    {
        pauseCanvas.SetActive(false);
    }
}
