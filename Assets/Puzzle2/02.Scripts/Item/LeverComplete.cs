using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverComplete : MonoBehaviour
{
    public GameObject lever;


    public void PullLever()
    {
        lever.GetComponent<Animator>().SetTrigger("Start");
        if (!Quest.instance.stepFiveCheck)
            Quest.instance.stepFiveCheck = true;
        UIManager.instance.textUI.gameObject.SetActive(false);
    }
}
