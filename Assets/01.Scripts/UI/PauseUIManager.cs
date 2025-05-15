using UnityEngine;

public class PauseUIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;

    public void ShowPauseUI()
    {
        Debug.Log("ShowPauseUI 호출");
        pauseCanvas.SetActive(true);  //일시정지 UI 띄움
    }

    public void HidePauseUI()
    {
        pauseCanvas.SetActive(false); //일시정지 UI 닫음
    }
}
