using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground_0 : MonoBehaviour
{
    public bool Camera_Move = true;
    public float Camera_MoveSpeed = 100f;

    [Header("Layer Setting")]
    public float[] Layer_Speed = new float[7]; // 예: [0.1, 0.3, 0.5, 0.8]
    public GameObject[] Layer_Objects = new GameObject[7];

    private Transform _camera;
    private Vector3 lastCameraPos;

    void Start()
    {
        _camera = Camera.main.transform;
        lastCameraPos = _camera.position;
    }

    void Update()
    {
        // 카메라 이동
        if (Camera_Move)
        {
            _camera.position += Vector3.right * Time.deltaTime * Camera_MoveSpeed;
        }

        Vector3 deltaMovement = _camera.position - lastCameraPos;

        // 배경 이동 (패럴랙스 효과)
        for (int i = 0; i < 4; i++)
        {
            if (Layer_Objects[i] == null) continue;
            Layer_Objects[i].transform.position += deltaMovement * (1f - Layer_Speed[i]);
        }

        lastCameraPos = _camera.position;
    }
}