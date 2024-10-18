using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIObjectWindow : MonoBehaviour
{
    public GameObject objectText; //오브젝트 터치했을때 나오는 설명창
    public GameObject getItemBtn; //획득하기 버튼창

    public float timer;
    public float maxTextTime = 3f; //텍스트가 열린후 3초후에 닫히게 설정

    private void OnEnable()
    {
        StartCoroutine(ToggleUIOnOff());
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                timer = 0;
                ToggleUI(false);
            }
        }
    }

    public void ToggleUI(bool set)
    {
        objectText.SetActive(set);
        if (set)
        {
            timer = maxTextTime;
        }
    }

    IEnumerator ToggleUIOnOff()
    {
        ToggleUI(true);
        yield return new WaitForSeconds(0.1f);
        ToggleUI(false);
    }
}
