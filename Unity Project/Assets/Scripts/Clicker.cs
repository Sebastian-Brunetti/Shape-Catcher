using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    private Vector3 clickSize;
    private Vector3 originalSize;

    void Start()
    {
        originalSize = new Vector3(transform.localScale.x, transform.localScale.y, 1);
        clickSize = new Vector3(transform.localScale.x * 0.9f, transform.localScale.y * 0.9f, 1);
    }

    void OnMouseDown()
    {
        transform.localScale = clickSize;
    }

    void OnMouseUp()
    {
        transform.localScale = originalSize;
    }
}