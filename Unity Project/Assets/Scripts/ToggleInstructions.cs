using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInstructions : MonoBehaviour
{
    public GameObject instructionsPanel;

    void OnMouseUp()
    {
        instructionsPanel.SetActive(true);
        TutorialScreen tutScreen = instructionsPanel.gameObject.GetComponent<TutorialScreen>();
        tutScreen.NextPage();
    }
}
