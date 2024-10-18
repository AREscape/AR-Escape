using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    public List<GameObject> items;

    void Start()
    {
        EventHandler.OnItemPickedUp += EventHandler_OnItemPickedUp;
    }

    private void EventHandler_OnItemPickedUp(GameObject item)
    {
        items.Add(item);
        item.SetActive(false);
    }

    public bool ItemHammerCheck() //아이템중에 해머가 있는지 확인
    {
        foreach (var item in items)
        {
            if (item.GetComponent<Hammer>() != null)
            {
                return true;
            }
        }
        return false;
    }
    public bool ItemLeverHandleCheck() //아이템중에 레버손잡이가 있는지 확인
    {
        foreach (var item in items)
        {
            if (item.GetComponent<LeverHandle>() != null)
            {
                return true;
            }
        }
        return false;
    }
}
