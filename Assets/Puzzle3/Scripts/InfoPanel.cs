using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InfoPanel : MonoBehaviour
{
    private GameObject infoPanel;
    public GameObject text_Cat, text_Dog, text_Lake, text_HanRiver;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)       
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    EffectSound.instance.InfoPadTouchSoundPlay();
                    if (hit.collider.CompareTag("INFOPAD_CAT"))
                    {
                        Select_Cat();
                    }
                    if (hit.collider.CompareTag("INFOPAD_DOG"))
                    {
                        Select_Dog();
                    }
                    if (hit.collider.CompareTag("INFOPAD_LAKE"))
                    {
                        Select_Lake();
                    }
                    if (hit.collider.CompareTag("INFOPAD_HANRIVER"))
                    {
                        Select_HanRiver();
                    }
                }
                
            }
        }
    }

    private void Select_Cat()
    {
        if (!text_Cat.activeInHierarchy)
            text_Cat.SetActive(true);
        else
            text_Cat.SetActive(false);
    }
    private void Select_Dog()
    {
        if (!text_Dog.activeInHierarchy)
            text_Dog.SetActive(true);
        else
            text_Dog.SetActive(false);
    }
    private void Select_Lake()
    {
        if (!text_Lake.activeInHierarchy)
            text_Lake.SetActive(true);
        else
            text_Lake.SetActive(false);
    }
    private void Select_HanRiver()
    {
        if (!text_HanRiver.activeInHierarchy)
            text_HanRiver.SetActive(true);
        else
            text_HanRiver.SetActive(false);
    }

}
