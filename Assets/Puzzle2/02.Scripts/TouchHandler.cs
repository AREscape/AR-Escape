using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchHandler : MonoBehaviour
{
    #region pc테스트용
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(clickPosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit) && !Quest.EndCheck)
            {
                GameObject clickedObject = hit.collider.gameObject;
                if (clickedObject.CompareTag("Object") && !EventSystem.current.IsPointerOverGameObject())
                {
                    UIManager.instance.uIObjectWindow.ToggleUI(true);
                    //이름과 내용을 이벤트 전달
                    EventHandler.RaiseTextChangeEvent(clickedObject.GetComponent<Objects>()
                        .objectname, clickedObject.GetComponent<Objects>().objectExp, clickedObject);
                    //이름을 스트링으로 이벤트 전달
                    EventHandler.HandleObjectInteraction(clickedObject.GetComponent<Objects>().objectname,
                        clickedObject);
                }
                else if (EventSystem.current.IsPointerOverGameObject())
                {
                    UIManager.instance.uIObjectWindow.ToggleUI(true);
                }
                else
                {
                    UIManager.instance.uIObjectWindow.ToggleUI(false);
                }
            }
        }
    }
    #endregion

    #region AR모바일 터치용
    //void Update()
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        Touch touch = Input.GetTouch(0);

    //        if (touch.phase == TouchPhase.Began)
    //        {
    //            Vector2 touchPosition = touch.position;
    //            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
    //            RaycastHit hit;

    //            if (Physics.Raycast(ray, out hit))
    //            {
    //                GameObject clickedObject = hit.collider.gameObject;
    //                if (clickedObject.CompareTag("Object"))
    //                {
    //                    UIManager.instance.uIObjectWindow.ToggleUI(true);
    //                    //이름과 내용을 이벤트 전달
    //                    EventHandler.RaiseTextChangeEvent(clickedObject.GetComponent<Objects>()
    //                        .objectname, clickedObject.GetComponent<Objects>().objectExp, clickedObject);
    //                    //타입을 스트링으로 이벤트 전달
    //                    EventHandler.HandleObjectInteraction(clickedObject.GetComponent<Objects>().objectname,
    //                        clickedObject);
    //                }
    //                else if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
    //                {
    //                    UIManager.instance.uIObjectWindow.ToggleUI(true);
    //                }
    //                else
    //                {
    //                    UIManager.instance.uIObjectWindow.ToggleUI(false);
    //                }
    //            }
    //        }
    //    }
    //}
    #endregion

}
