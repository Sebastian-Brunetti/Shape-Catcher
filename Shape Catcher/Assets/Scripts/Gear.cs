using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public float posMin;
    public float posMax;
    public Lasers laser;

    private bool moving = false;

    private Vector3 screenPoint;
    private Vector3 offset;
    private float currPositionX;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        moving = true;
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        Vector3 finalPosition = new Vector3(Mathf.Clamp(curPosition.x, posMin, posMax), -3.8f, curPosition.z); //el mathf.clamp es para que no se pase de las torres
        transform.position = finalPosition;
    }

    void Update()
    {
        if (transform.position.x < currPositionX && moving)
        {
            currPositionX = transform.position.x;
        }
        else if (transform.position.x > currPositionX && moving)
        {
            currPositionX = transform.position.x;
        }
    }

    public void FireLasers()
    {
        StartCoroutine(LaserBarrage());
    }

    IEnumerator LaserBarrage()
    {
        for (int i = 0; i < 20; i++)
        {
            Instantiate(laser, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
        }
    }
}
