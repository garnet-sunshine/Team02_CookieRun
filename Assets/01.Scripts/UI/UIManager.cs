using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button bgmOnBtn;
    [SerializeField] private Button bgmOffBtn;
    [SerializeField] private Slider bgmSlider;

    private Button currentSelected;
    private bool suppressSliderCallback = false;

    void Start()
    {
        bgmSlider.value = .5f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject clicked = EventSystem.current.currentSelectedGameObject;

            if (clicked == bgmSlider.gameObject)
            {
                EventSystem.current.SetSelectedGameObject(currentSelected.gameObject);
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
        SetSelectedButton(bgmOnBtn);
    }

    public void BGMOffClick()
    {
        suppressSliderCallback = true;
        bgmSlider.value = 0;
        SetSelectedButton(bgmOffBtn);
        suppressSliderCallback = false;
    }

    public void OnBGMSliderChanged(float value)
    {
        if (suppressSliderCallback) return;

        SetSelectedButton(bgmOnBtn);
    }

    private void SetSelectedButton(Button btn)
    {
        currentSelected = btn;
        EventSystem.current.SetSelectedGameObject(btn.gameObject);
    }
}
