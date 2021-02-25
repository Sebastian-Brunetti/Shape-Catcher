using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScreen : MonoBehaviour
{
    public Sprite primeraPagina;
    public Sprite[] explicacion;
    public SpriteRenderer imagen;

    private int pageNumber = 0;

    void OnMouseUp()
    {
        ++pageNumber;
        NextPage();
    }

    public void NextPage()
    {
        if (pageNumber == 5)
        {
            gameObject.SetActive(false);
            pageNumber = 0;
        }
        else
        {
            imagen.sprite = explicacion[pageNumber];
        }
        Debug.Log(pageNumber);
    }
}
