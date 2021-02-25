using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffButton : MonoBehaviour {

    public GameController gameCont;
    public int difficulty;
    public GameObject mainMenu;

    void OnMouseDown()
    {
        gameCont.SetDifficulty(difficulty);
        mainMenu.SetActive(false);
        gameCont.StartGame();
    }
}
