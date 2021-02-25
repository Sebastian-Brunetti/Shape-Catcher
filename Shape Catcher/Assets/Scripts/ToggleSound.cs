using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSound : MonoBehaviour
{
    public SpriteRenderer statusDisplayMark;
    public Sprite checkMark;
    public Sprite crossMark;

    private bool soundActive;

    void Start()
    {
        if (PlayerPrefs.GetFloat("SoundToggle") == 0)
        {
            soundActive = false;
            statusDisplayMark.sprite = crossMark;
        }
        else
        {
            soundActive = true;
            statusDisplayMark.sprite = checkMark;
        }
    }

    void OnMouseUp()
    {
        if (soundActive)
        {
            soundActive = false;
            PlayerPrefs.SetFloat("SoundToggle", 0);
            statusDisplayMark.sprite = crossMark;
        }
        else
        {
            soundActive = true;
            PlayerPrefs.SetFloat("SoundToggle", 1);
            statusDisplayMark.sprite = checkMark;
        }
    }

    public bool SoundActive()
    {
        return soundActive;
    }
}
