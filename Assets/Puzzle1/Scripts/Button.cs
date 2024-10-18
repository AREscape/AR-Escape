using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    int colorIdx;


    Dictionary<int,Color> color = new Dictionary<int, Color>()
    {{0,Color.black},{1,Color.red},
        {2,Color.green},{3,Color.yellow},
        {4,Color.blue}
    };
    Dictionary<int, string> colorName = new Dictionary<int, string>()
    {{0,"Black"},{1,"Red"},
        {2,"Green"},{3,"Yellow"},
        {4,"Blue"}
    };
    private void Start()
    {
        colorIdx = 0;
    }

    public void ChangeColor()
    {
        if (colorIdx > 4)
            colorIdx = 0;
        this.GetComponent<MeshRenderer>().material.color = color[colorIdx];
        if (this.gameObject.name == colorName[colorIdx])
            ButtonManager.answer[this.gameObject.name] = 1;
        else if(this.gameObject.name != colorName[colorIdx])
            ButtonManager.answer[this.gameObject.name] = 0;
        colorIdx++;
    }
}
