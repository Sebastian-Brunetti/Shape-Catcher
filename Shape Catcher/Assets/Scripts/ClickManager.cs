using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public Tower leftTower;
    public Tower rightTower;

    void OnMouseDown()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x < 0)
        {
            leftTower.Shoot(mousePos);
        }
        else
        {
            rightTower.Shoot(mousePos);
        }
    }
}
