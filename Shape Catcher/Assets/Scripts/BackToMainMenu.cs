﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
