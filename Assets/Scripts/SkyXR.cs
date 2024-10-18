using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyXR : MonoBehaviour
{
    void Update()
    {
        if (Camera.main.clearFlags != CameraClearFlags.Skybox)
            CameraFlagChange.CameraFlagsChange();
    }
}
