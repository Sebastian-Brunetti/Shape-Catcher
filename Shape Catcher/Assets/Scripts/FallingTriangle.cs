using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTriangle : MonoBehaviour {

    private float speed;
    private Vector2 targetPos;

    public void SetTarget(float target, float randomSpeed)
    {
        speed = randomSpeed;
        targetPos = new Vector2 (target, -4.0f);
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
