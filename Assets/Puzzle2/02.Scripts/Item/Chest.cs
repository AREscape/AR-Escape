using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenBox()
    {
        if (Quest.instance.stepFiveCheck)
        {
            anim.SetTrigger("Start");
            GetComponent<BoxCollider>().enabled = false;
            GetComponentInChildren<Key>().GetComponent<BoxCollider>().enabled = true;
            UIManager.instance.textUI.gameObject.SetActive(false);
            GetComponent<Objects>().ignore = true;
        }
    }
}
