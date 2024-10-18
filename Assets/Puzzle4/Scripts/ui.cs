using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARObjectInteraction : MonoBehaviour
{
    public static bool isClear = false;

    [SerializeField] private GameObject passwordUI; // 비밀번호 입력 UI
    private bool isUIVisible = false; // UI가 활성화된 상태인지 여부


    void Update()
    {
        if (Input.touchCount > 0 && !isClear)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // AR 오브젝트 터치 감지
                if (Physics.Raycast(ray, out hit))
                {
                    // 터치한 오브젝트가 AR 오브젝트인 경우
                    if (hit.collider.gameObject == gameObject)
                    {
                        // 비밀번호 입력 UI가 활성화되어 있지 않은 경우에만 활성화
                        if (!isUIVisible)
                        {
                            ShowPasswordUI();
                        }
                        else
                        {
                            // 이미 UI가 활성화된 상태에서 다시 터치했을 때, UI를 비활성화합니다.
                            HidePasswordUI();
                        }
                    }
                }
            }
        }
    }

    // 비밀번호 입력 UI를 활성화하는 함수
    private void ShowPasswordUI()
    {
        passwordUI.SetActive(true);
        isUIVisible = true;
    }

    // 비밀번호 입력 UI를 비활성화하는 함수
    private void HidePasswordUI()
    {
        passwordUI.SetActive(false);
        isUIVisible = false;
        
    }
}
