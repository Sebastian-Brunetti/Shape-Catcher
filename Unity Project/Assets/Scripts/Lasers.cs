using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * 1500, Space.Self);
    }
}
