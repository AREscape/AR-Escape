using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleEvent : MonoBehaviour
{
    [SerializeField] GameObject brokenBottlePrefab;
    public GameObject bottle;
    public GameObject leverHandle;

    void Update() // just for testing
    {
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    Explode();
        //}
    }

    public void Explode()
    {
        EffectSound.instance.CrackingSoundPlay();
        GameObject brokenBottle = Instantiate(brokenBottlePrefab, bottle.transform.position, Quaternion.identity);
        brokenBottle.GetComponent<BrokenBottle>().RandomVelocities();
        Instantiate(leverHandle, bottle.transform.position, Quaternion.identity);
        Destroy(bottle);
        UIManager.instance.textUI.gameObject.SetActive(false);
        if (!Quest.instance.stepThreeCheck)
            Quest.instance.stepThreeCheck = true;
    }
}
