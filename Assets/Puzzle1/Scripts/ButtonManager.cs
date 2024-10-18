using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour
{
    public delegate void ClickAction();
    public static event ClickAction isCleared;
    public TextMeshProUGUI display;

    public static Dictionary<string, int> answer = new Dictionary<string, int>()
    {{"Black",0 },{"Red",0 },{"Green",0 },{"Yellow",0 },{"Blue",0 }
    };

    bool isClear = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 &&
            Input.touches[0].phase == TouchPhase.Began &&
            !EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
        {
            //pm.requestedDetectionMode = PlaneDetectionMode.Vertical;

            //foreach (var p in pm.trackables)
            //{
            //    p.gameObject.SetActive(false);

            //}
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) &&
            !isClear)
            {
                float distance = Vector3.Distance(Camera.main.transform.position, hit.transform.position);
                if (hit.collider != null && distance <= 5f)
                {
                    if (hit.collider.CompareTag("BUTTON"))
                    {
                        hit.collider.gameObject.GetComponent<Button>().ChangeColor();
                        int isAnswer = 0;
                        foreach (var item in answer.Values)
                        {
                            isAnswer += item;
                        }
                        if (isAnswer == 5)
                        {
                            isClear = true;
                            isCleared();
                        }
                    }
                }
                else if(hit.collider != null)
                {
                    StartCoroutine(Display());
                }
            }
        }
        IEnumerator Display()
        {
            display.gameObject.SetActive(true);
            yield return new WaitForSeconds(3f);
            display.gameObject.SetActive(false);
        }
    }
}
