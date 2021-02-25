using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    public GameObject optionsMenu;
    public Collider2D button1;
    public Collider2D button2;
    public Collider2D button3;

    private bool optionsMenuActive = false;

    void OnMouseUp()
    {
        if (!optionsMenuActive)
        {
            optionsMenu.SetActive(true);
            optionsMenuActive = true;
            button1.enabled = false;
            button2.enabled = false;
            button3.enabled = false;
        }
        else
        {
            optionsMenu.SetActive(false);
            optionsMenuActive = false;
            button1.enabled = true;
            button2.enabled = true;
            button3.enabled = true;
        }     
    }
}
