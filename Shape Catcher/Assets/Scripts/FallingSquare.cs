using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSquare : MonoBehaviour {

    private float speed;
    public Rigidbody2D rb;

    public void Drop (float randomSpeed)
    {
        rb.velocity = transform.up * -randomSpeed;
    }
}
