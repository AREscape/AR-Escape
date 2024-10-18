using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraFlagChange : MonoBehaviour
{
    public static void SceneChange()
    {
        SceneManager.LoadScene("Sky");
    }
    public static void CameraFlagsChange()
    {
        Camera.main.clearFlags = CameraClearFlags.Skybox;
    }
}
