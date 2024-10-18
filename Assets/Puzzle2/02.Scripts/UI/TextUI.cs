using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI expText;
    public List<string> expTexts = new List<string>();//받아온 텍스트배열
    public GameObject nextBtn; //다음텍스트 버튼
    public GameObject getBtn; //아이템획득버튼
    public GameObject destroyBtn; //병 부수는버튼
    public GameObject fixingLeverBtn; //레버를 고치는 버튼
    public GameObject openBoxBtn; //상자를 여는 버튼
    public GameObject objectInfo; //현재 받은 텍스트의 게임오브젝트 정보.
    public float typingSpeed = 0.08f;
    public int textCnt = 0;


    void Start()
    {
        EventHandler.OnTextChange += TouchHandler_OnTextChange;
    }

    private void TouchHandler_OnTextChange(string name, List<string> exp, GameObject obj)
    {
        if (obj.GetComponent<Objects>().ignore)
            return;
        expTexts.Clear();
        textCnt = 0;
        nameText.text = name;
        expTexts.AddRange(exp);
        objectInfo = obj;
        UpdateExpText();
        UpdateDestroyButton();
        UpdateGetButton();
        UpdateOpenButton();
        UpdateFixingButton();
    }

    private void UpdateExpText()
    {

        StartCoroutine(TypeText(expTexts[textCnt]));

    }

    private void UpdateDestroyButton()
    {
        if (GameManager2.instance.getItem.ItemHammerCheck() && nameText.text == "병")
        {
            destroyBtn.SetActive(true);
        }
        else
        {
            destroyBtn.SetActive(false);
        }
    }

    private void UpdateGetButton()
    {
        if (objectInfo.GetComponent<Objects>().objectType == Objects.Type.Item)
        {
            if (objectInfo.GetComponent<Hammer>() && Quest.instance.stepOneCheck)
                getBtn.SetActive(true);
            if (objectInfo.GetComponent<LeverHandle>() && Quest.instance.stepThreeCheck)
                getBtn.SetActive(true);
        }
        else
        {
            getBtn.SetActive(false);
        }
    }

    private void UpdateFixingButton()
    {
        if (Quest.instance.stepFourCheck && !Quest.instance.stepFiveCheck && nameText.text == "레버")
        {
            fixingLeverBtn.SetActive(true);
        }
        else
        {
            fixingLeverBtn.SetActive(false);
        }
    }

    private void UpdateOpenButton()
    {
        if (Quest.instance.stepFourCheck && !Quest.EndCheck && nameText.text == "완성된 레버")
        {
            openBoxBtn.SetActive(true);
        }
        else
        {
            openBoxBtn.SetActive(false);
        }
    }

    //public void SetTextExp(string text) //설명 변경
    //{
    //    StartCoroutine(TypeText(text));
    //}

    public void NextBtnSet(bool set) //텍스트배열의 마지막이면 버튼을 가린다.
    {
        nextBtn.SetActive(set);
    }

    public void BtnTextEvent() //다음텍스트 버튼클릭시 호출
    {
        StartCoroutine(TypeText(expTexts[0]));
        //SetTextExp(expTexts[0]);
        //if (expTexts.Count - 1 == textCnt)
        //{
        //    NextBtnSet(false);
        //}
    }
    IEnumerator TypeText(string exp) //텍스트를 한글자씩 뜨게하는거
    {
        expText.text = "";
        NextBtnSet(false);
        foreach (char letter in exp)
        {
            expText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        if (expTexts.Count > 1)
        {
            expTexts.RemoveAt(0);
            NextBtnSet(true);
        }
        else
        {
            NextBtnSet(false);
        }
    }
}
