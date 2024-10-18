using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameManager : MonoBehaviour
{
    public delegate void ClickAction();
    public static event ClickAction isCleared;
    public List<GameObject> keys = new List<GameObject>();
    public bool keyCheck = false;

    bool isClear = false;
    int keyIdx;

    void Start()
    {        

    }

    //모바일용
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;                
            if (Physics.Raycast(ray, out hit) && !isClear)
            {
                if (hit.collider.CompareTag("Frame"))
                {
                    if (!keyCheck)
                    {
                        keyIdx = Random.Range(0, 3);
                        keys[keyIdx].SetActive(true);
                        keyCheck = true;
                    }
                    EffectSound.instance.FrameTouchSoundPlay();
                    hit.collider.gameObject.GetComponent<Frame>().AnimationStart();
                    
                    //if(hit.collider.gameObject.name != keys[keyIdx].GetComponentInParent<GameObject>().name)
                    //{
                    //    StartCoroutine(soundPlay());
                    //}
                }
                else if (hit.collider.CompareTag("Key"))
                {
                    //EffectSound.instance.KeyFoundSoundPlay();
                    isClear = true;
                    isCleared();
                }
            }
        }
    }

    IEnumerator soundPlay()
    {
        EffectSound.instance.NoKeySoundPlay();
        yield return new WaitForSeconds(1);
    }
}






