using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownBob : MonoBehaviour {

    private bool goDown = true;
    private Vector3 originalPosition;

    public float bobSpeed;
    public Vector3 bobPosition;

    void Start ()
    {
        originalPosition = transform.position;
	}
	

	void Update ()
    {
		if (goDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, bobPosition, Time.deltaTime * bobSpeed);
            if (transform.position == bobPosition)
            {
                goDown = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, Time.deltaTime * bobSpeed);
            if (transform.position == originalPosition)
            {
                goDown = true;
            }
        }

	}
}
