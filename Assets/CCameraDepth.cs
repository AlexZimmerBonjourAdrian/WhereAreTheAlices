using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCameraDepth : MonoBehaviour
{
    private Camera CameraFPS;
   void Start()
    {
        CameraFPS = GetComponent<Camera>();
        // Set this camera to render after the main camera
        CameraFPS.depth = CameraFPS.depth + 1;
    }
}
