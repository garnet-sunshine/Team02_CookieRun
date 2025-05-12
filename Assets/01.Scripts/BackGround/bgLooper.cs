using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgLooper : MonoBehaviour
{
    public int numBgCount = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BackGround"))
        {
            float WidthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += WidthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }
    }
}
