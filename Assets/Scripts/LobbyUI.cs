using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class LobbyUI : MonoBehaviour
{

    public void StartButton()
    {
            SceneManager.LoadScene("AREscape");
    }
}
