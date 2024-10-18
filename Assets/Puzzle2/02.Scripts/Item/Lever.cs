using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject Lever_Complete;


    public void LeverFixing()
    {
        if (GameManager2.instance.getItem.ItemLeverHandleCheck() && !Quest.instance.stepFiveCheck)
        {
            Lever_Complete.SetActive(true);
            //GameObject ins = Instantiate(Lever_Complete, transform.position, transform.rotation);
            // ins.transform.parent = FindObjectOfType<Parent>().gameObject.transform;
            //if (!Quest.instance.stepFiveCheck)
            //    Quest.instance.stepFiveCheck = true;  
            UIManager.instance.textUI.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
