using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public delegate void ClickAction();
    public static event ClickAction isCleared;
    public GameObject KeyPad;

    [SerializeField] private Text Ans;
    [SerializeField] private GameObject keypadUI; // Reference to the UI GameObject

    private string Answer = "96";

    public void Number(int number)
    {
        Ans.text += number.ToString();
    }

    public void Confirm()
    {
        if (Ans.text == Answer)
        {
            Ans.text = "CORRECT";
            ARObjectInteraction.isClear = true;
            isCleared();
            StartCoroutine(CloseUIAfterDelay(1.5f)); // Close the UI after 1.5 seconds
            Destroy(KeyPad);

        }
        else
        {
            Ans.text = "WRONG";
            StartCoroutine(ResetTextAfterDelay(1.5f));
        }
    }

    IEnumerator ResetTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Ans.text = "";
    }

    IEnumerator CloseUIAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        keypadUI.SetActive(false); // Close the UI after the delay
    }
}
