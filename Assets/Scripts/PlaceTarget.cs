using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceTarget : MonoBehaviour
{
    public List<GameObject> puzzles;

    ARRaycastManager raycastManager;
    GameObject placeTarget;
    bool detect = true;
    void Start()
    {
        raycastManager = FindAnyObjectByType<ARRaycastManager>();
        placeTarget = this.transform.GetChild(0).gameObject;
        placeTarget.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if(detect)
            raycastManager.Raycast(new Vector2(Random.Range(0,Screen.width), Random.Range(Screen.height, Screen.height - Screen.height/4)), hits, TrackableType.Planes);
        else
            raycastManager.Raycast(new Vector2(Screen.width/2, Screen.height / 2), hits, TrackableType.Planes);
        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
            if (!placeTarget.activeInHierarchy)
            {
                placeTarget.SetActive(true);
                //placeTarget.transform.position
                //Camera.main.transform.position
                if (detect)
                {
                    Instantiate(puzzles[1], transform.position, transform.rotation);
                    detect = false;
                }
            }
            

        }
    }
}
