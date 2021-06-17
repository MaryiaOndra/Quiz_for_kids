using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspect : MonoBehaviour
{
    [SerializeField]
    float cameraWidth;

    Camera targetCamera;

    void Awake()
    {
        targetCamera = GetComponent<Camera>();
    }

    void Update()
    {
        targetCamera.orthographicSize = (float)Screen.height / Screen.width * cameraWidth;
    }
}