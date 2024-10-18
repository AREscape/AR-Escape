using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSound : MonoBehaviour
{
    public static EffectSound instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TouchSoundPlay()
    {
        audioSource.PlayOneShot(SoundList.soundList.uiTouchSound);
    }
    public void CrackingSoundPlay()
    {
        audioSource.PlayOneShot(SoundList.soundList.crackingSound);
    }
    public void FrameTouchSoundPlay()
    {
        audioSource.PlayOneShot(SoundList.soundList.frametouchSound);
    }
    public void InfoPadTouchSoundPlay()
    {
        audioSource.PlayOneShot(SoundList.soundList.infopadtouchSound);
    }
    public void KeyFoundSoundPlay()
    {
        audioSource.PlayOneShot(SoundList.soundList.keyfoundSound);
    }
    public void NoKeySoundPlay()
    {
        audioSource.PlayOneShot(SoundList.soundList.nokeySound);
    }
}
