using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialButton : MonoBehaviour {

    public GameObject instructions;

    void OnMouseDown()
    {
        instructions.SetActive(true);
    }
}
