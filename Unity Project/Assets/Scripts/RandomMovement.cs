using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {

    public Rigidbody2D rb;
    public Vector2 explosionSpeed;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.Rotate(Vector3.forward, Random.Range(0, 360));
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.up * 0.1f);
    }
}
