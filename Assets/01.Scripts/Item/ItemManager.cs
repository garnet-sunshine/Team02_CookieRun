using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    List<string> items = new List<string>();

    private void Start()
    {
        // ������ �߰�
        items.Add("�ν�Ʈ");
        items.Add("�Ŵ�ȭ");
        items.Add("ü��ȸ��");

        foreach(var item in items)
        {
            Debug.Log(item);
        }
    }

   
}
