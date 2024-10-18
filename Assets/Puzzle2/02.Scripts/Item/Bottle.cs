using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public string[] texts; //나중에 바뀔 텍스트

    private void Start()
    {
        texts = new string[1];
        texts[0] = "이제 이걸 깨버리면 될거같은데?";
        GameManager2.instance.bottleEvent.bottle = this.gameObject;
        EventHandler.OnObjectInteraction += EventHandler_OnObjectInteraction;
    }

    private void EventHandler_OnObjectInteraction(string name, GameObject obj)
    {
        if (obj == null) return;

        if (!Quest.instance.stepOneCheck && name == "병")
        {
            Quest.instance.stepOneCheck = true;
        }
        else if (Quest.instance.stepTwoCheck && name == "망치" && GetComponent<Objects>().objectname == "병")
        {
            GetComponent<Objects>().TextChange(texts);
        }
    }
}
