using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmButton : MonoBehaviour
{
    public ResetHighScores resetButton;
    public bool confirm;

    void OnMouseDown()
    {
        resetButton.ChoiceConfirmed(confirm);
    }
}
