using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public delegate void ClickAction();
    public static event ClickAction isCleared;
    void Start()
    {
        EventHandler.OnObjectInteraction += EventHandler_OnObjectInteraction;
        
    }

    private void EventHandler_OnObjectInteraction(string name, GameObject obj)
    {
        if(name == "¿­¼è")
        {
            Quest.EndCheck = true;
            isCleared();
        }
    }

    void Update()
    {
        
    }
}
