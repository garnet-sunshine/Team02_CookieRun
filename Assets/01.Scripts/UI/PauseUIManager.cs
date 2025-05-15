using UnityEngine;

public class PauseUIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;

    public void ShowPauseUI()
    {
        Debug.Log("ShowPauseUI ȣ��");
        pauseCanvas.SetActive(true);  //�Ͻ����� UI ���
    }

    public void HidePauseUI()
    {
        pauseCanvas.SetActive(false); //�Ͻ����� UI ����
    }
}
