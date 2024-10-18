using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public static Quest instance;

    public bool stepOneCheck; //병을 클릭했나?
    public bool stepTwoCheck; //망치를 획득했나?
    public bool stepThreeCheck; //병을 깨뜨렸나?
    public bool stepFourCheck; //레버손잡이를 먹었나?
    public bool stepFiveCheck; //레버를 완성했나?
    public static bool EndCheck = false;//열린 상자에서 열쇠를 먹었나?

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
