using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    public int isTouched = 0;
    public Transform pos;

    Animator anim;

    readonly int hashTouched = Animator.StringToHash("isTouched");

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    //public void Rotate()
    //{
    //    Quaternion rota = transform.rotation;
    //    rota.z += 60;
    //    transform.rotation = Quaternion.Slerp(transform.rotation, rota
    //        , Time.deltaTime * 8f);
    //}

    public void AnimationStart()
    {        
        if (isTouched == 0)
        {
            isTouched = 1;
            anim.SetInteger(hashTouched, 1);
        }
        else
        {
            isTouched = 0;
            anim.SetInteger(hashTouched, 0);
        }

    }
}
