using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARObjectInteraction : MonoBehaviour
{
    public static bool isClear = false;

    [SerializeField] private GameObject passwordUI; // ��й�ȣ �Է� UI
    private bool isUIVisible = false; // UI�� Ȱ��ȭ�� �������� ����


    void Update()
    {
        if (Input.touchCount > 0 && !isClear)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // AR ������Ʈ ��ġ ����
                if (Physics.Raycast(ray, out hit))
                {
                    // ��ġ�� ������Ʈ�� AR ������Ʈ�� ���
                    if (hit.collider.gameObject == gameObject)
                    {
                        // ��й�ȣ �Է� UI�� Ȱ��ȭ�Ǿ� ���� ���� ��쿡�� Ȱ��ȭ
                        if (!isUIVisible)
                        {
                            ShowPasswordUI();
                        }
                        else
                        {
                            // �̹� UI�� Ȱ��ȭ�� ���¿��� �ٽ� ��ġ���� ��, UI�� ��Ȱ��ȭ�մϴ�.
                            HidePasswordUI();
                        }
                    }
                }
            }
        }
    }

    // ��й�ȣ �Է� UI�� Ȱ��ȭ�ϴ� �Լ�
    private void ShowPasswordUI()
    {
        passwordUI.SetActive(true);
        isUIVisible = true;
    }

    // ��й�ȣ �Է� UI�� ��Ȱ��ȭ�ϴ� �Լ�
    private void HidePasswordUI()
    {
        passwordUI.SetActive(false);
        isUIVisible = false;
        
    }
}
