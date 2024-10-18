using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundList : MonoBehaviour
{
    static public SoundList soundList;
    [Header("배경음악 ")]
    public AudioClip bgm1; //괜찮은 브금이 별로없네요
    [Header("효과음")]
    public AudioClip uiTouchSound; //화면 터치할때마다 들리는효과음
    public AudioClip crackingSound; //병 깨질때 들리는 효과음
    public AudioClip frametouchSound;
    public AudioClip infopadtouchSound;
    public AudioClip keyfoundSound;
    public AudioClip nokeySound;

    private void Awake()
    {
        if (soundList == null)
        {
            soundList = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
