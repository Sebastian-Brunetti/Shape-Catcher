using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMusic : MonoBehaviour
{
    public SpriteRenderer statusDisplayMark;
    public Sprite checkMark;
    public Sprite crossMark;

    public GameObject musicObject;
    //private AudioSource musicAudioSource;

    void Start()
    {
        //musicAudioSource = musicObject.GetComponent<AudioSource>();

        if (PlayerPrefs.GetFloat("MusicToggle") == 0)
        {
            statusDisplayMark.sprite = crossMark;
            musicObject.SetActive(false);
            //musicAudioSource.mute = true;
        }
        else
        {
            musicObject.SetActive(true);
            statusDisplayMark.sprite = checkMark;
            //musicAudioSource.mute = false;
        }
    }

    void OnMouseUp()
    {
        if (PlayerPrefs.GetFloat("MusicToggle") == 1)
        {
            PlayerPrefs.SetFloat("MusicToggle", 0);
            musicObject.SetActive(false);
            statusDisplayMark.sprite = crossMark;
            //musicAudioSource.mute = true;
        }
        else
        {
            PlayerPrefs.SetFloat("MusicToggle", 1);
            musicObject.SetActive(true);
            statusDisplayMark.sprite = checkMark;
            //musicAudioSource.mute = false;
        }
    }


}
