using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragment : MonoBehaviour
{
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
    }
}
