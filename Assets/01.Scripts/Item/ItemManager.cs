using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    List<string> items = new List<string>();

    private void Start()
    {
        // 아이템 추가
        items.Add("부스트");
        items.Add("거대화");
        items.Add("체력회복");

        foreach(var item in items)
        {
            Debug.Log(item);
        }
    }

   
}
