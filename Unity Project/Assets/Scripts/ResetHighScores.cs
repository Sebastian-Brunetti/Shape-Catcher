using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHighScores : MonoBehaviour
{
    public GameObject yesButton;
    public GameObject noButton;

    public GameController gameCont;

    void OnMouseUp()
    {
        yesButton.SetActive(true);
        noButton.SetActive(true);
    }

    public void ChoiceConfirmed(bool confirmed)
    {
        if (confirmed)
        {
            gameCont.DeleteAllScores();

        }
        yesButton.SetActive(false);
        noButton.SetActive(false);
    }
}
