using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button bgmOnBtn;
    [SerializeField] private Button bgmOffBtn;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private AudioSource bgmAudio; // 오디오 소스 추가

    private Button currentSelected;
    private bool suppressSliderCallback = false;
    private bool isMuted = false; // 음소거 상태 확인

    void Start()
    {
        SetSelectedButton(bgmOnBtn);
        bgmSlider.value = 0.5f;
        //ApplyVolume(); // 시작 시 오디오 볼륨 반영
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject clicked = EventSystem.current.currentSelectedGameObject;

            if (clicked == bgmSlider.gameObject)
            {
                SetSelectedButton(bgmOnBtn);
                return;
            }

            if (clicked != bgmOnBtn.gameObject && clicked != bgmOffBtn.gameObject)
            {
                EventSystem.current.SetSelectedGameObject(currentSelected.gameObject);
            }
        }
    }

    public void BGMOnClick()
    {
        isMuted = false;
        SetSelectedButton(bgmOnBtn);
        //ApplyVolume(); // 사운드 적용
    }

    public void BGMOffClick()
    {
        isMuted = true;

        suppressSliderCallback = true;
        bgmSlider.value = 0;
        suppressSliderCallback = false;

        SetSelectedButton(bgmOffBtn);
        ApplyVolume(); // 사운드 적용
    }

    public void OnBGMSliderChanged(float value)
    {
        if (suppressSliderCallback) return;

        isMuted = false;
        SetSelectedButton(bgmOnBtn);
        ApplyVolume();

        SoundManager.instance.SetBGMVolume(value);
        SetSelectedButton(bgmOnBtn);
    }

    private void ApplyVolume()
    {
        if (bgmAudio != null)
        {
            bgmAudio.volume = isMuted ? 0f : bgmSlider.value;
        }
    }

    private void SetSelectedButton(Button btn)
    {
        currentSelected = btn;
        EventSystem.current.SetSelectedGameObject(btn.gameObject);
    }

}


