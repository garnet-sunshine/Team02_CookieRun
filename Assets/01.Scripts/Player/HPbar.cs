using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    [SerializeField] private Slider hpbar;
    private float maxHp = 100;
    private float curHp = 100;

    // Start is called before the first frame update
    void Start()
    {
        hpbar.value = (float)curHp / (float)maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            curHp -= 10;
        }

        HandleHp();
    }

    private void HandleHp()
    {
        hpbar.value = (float)curHp / (float)maxHp;
    }
}
