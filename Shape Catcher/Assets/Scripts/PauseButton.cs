using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public SpriteRenderer spriteRen;
    public Sprite pauseSprite;
    public Sprite playSprite;

    public GameObject clickMan;
    public Collider2D leftTowerColl;
    public Collider2D rightTowerColl;
    public GameObject mainMenuButton;

    private bool pause = false;

    void OnMouseUp()
    {
        if (pause)
        {
            Time.timeScale = 1;
            pause = false;
            clickMan.SetActive(true);
            spriteRen.sprite = pauseSprite;
            leftTowerColl.enabled = true;
            rightTowerColl.enabled = true;
            mainMenuButton.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            pause = true;
            clickMan.SetActive(false);
            spriteRen.sprite = playSprite;
            leftTowerColl.enabled = false;
            rightTowerColl.enabled = false;
            mainMenuButton.SetActive(true);
        }
    }
}
