using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingHexagon : MonoBehaviour
{
    public float targetRange;

    private float speed;
    private Vector2 targetPos; 

    private float changeDirectionCoord;
    private bool originalDirection = true;

    void Start()
    {
        changeDirectionCoord = Random.Range(0.5f, 3.5f);
    }

    public void SetTarget(float target, float randomSpeed)
    {
        speed = randomSpeed;
        targetPos = new Vector2(target, -4.0f);
    }

    public void ChangeDirection()
    {
        targetPos.x = (Random.Range(-targetRange, targetRange));
        originalDirection = false;
    }

    void FixedUpdate()
    {
        if (originalDirection && transform.position.y < changeDirectionCoord)
        {
            ChangeDirection();
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}