using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GameManager1 : MonoBehaviour
{
    public List<GameObject> puzzles;
    public GameObject[] Locks;
    public GameObject openDoor;

    ARRaycastManager raycastManager;

    GameObject placeTarget;
    GameObject currentPuzzle;
    TrackableCollection<ARPlane> plane;

    //랜덤게임
    const float DISTANCE = 3f;
    public int clear = 0;
    int randomPuzzle;
    bool detect = true;
    bool duplication = false;
    List<Vector3> puzzlePosition = new List<Vector3>();
    Quaternion currentRotation;
    Dictionary<int, PlaneDetectionMode> puzzleOption = new Dictionary<int, PlaneDetectionMode>() {{0, PlaneDetectionMode.Horizontal},
        {1, PlaneDetectionMode.Horizontal },
        {2,PlaneDetectionMode.Horizontal},
        {3,PlaneDetectionMode.Horizontal}};


    // Start is called before the first frame update
    void Start()
    {
        raycastManager = FindAnyObjectByType<ARRaycastManager>();
        placeTarget = this.transform.GetChild(0).gameObject;
        placeTarget.SetActive(false);

        ButtonManager.isCleared += Clear;
        Key.isCleared += Clear;
        FrameManager.isCleared += Clear;
        Keypad.isCleared += Clear;

    }

    // Update is called once per frame
    void Update()
    {
        //터치사운드
        if (Input.touchCount > 0 &&
        Input.touches[0].phase == TouchPhase.Began &&
        !EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
        {
            EffectSound.instance.TouchSoundPlay();
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) &&
            clear > 4)
            {
                if (hit.collider != null)
                {
                    if (hit.collider.CompareTag("DOOR"))
                    {
                        CameraFlagChange.SceneChange();
                    }
                }
            }
        }


        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if (detect)
            raycastManager.Raycast(new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height)), hits, TrackableType.Planes);
        else
            raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);
        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            float distance = Vector3.Distance(Camera.main.transform.position, transform.position);

            if (!placeTarget.activeInHierarchy && distance >= 1)
            {
                //placeTarget.SetActive(true);
                //placeTarget.transform.position
                //Camera.main.transform.position
                if (detect && clear < 4)
                {
                    randomPuzzle = Random.Range(0, puzzles.Count);

                    if (puzzlePosition.Count > 0)
                    {
                        duplication = false;
                        foreach (var item in puzzlePosition)
                        {
                            if (Vector3.Distance(Camera.main.transform.position, transform.position) < DISTANCE &&
                                System.Math.Abs(currentRotation.y) - System.Math.Abs(Camera.main.transform.rotation.y) < 180)
                            {
                                duplication = true;
                            }
                        }
                        if (!duplication)
                            CreatePuzzle();
                    }
                    else
                    {
                        CreatePuzzle();
                    }
                }
            }
        }
        else if (clear == 4)
        {
            //문열림
            openDoor.GetComponent<Animation>().Play("Open");
            clear++;
        }
    }
    void CreatePuzzle()
    {
        currentPuzzle = Instantiate(puzzles[randomPuzzle], transform.position, transform.rotation);
        puzzlePosition.Add(transform.position);
        currentRotation = Camera.main.transform.rotation;
        puzzles.RemoveAt(randomPuzzle);
        detect = false;
    }
    public void Clear()
    {
        Locks[clear].GetComponent<Animation>().Play("UnLock");
        clear++;
        Destroy(currentPuzzle.gameObject);
        if (clear == 4)
            openDoor.GetComponent<Animation>().Play("Open");
        detect = true;
    }
}

