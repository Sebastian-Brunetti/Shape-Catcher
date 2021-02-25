using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseThreatText : MonoBehaviour {

    private Vector3 initialPos;
    private bool move;

    public float speed;
	
	void Start ()
    {
        initialPos = transform.position;
        move = false;
	}

    public void MoveText()
    {
        move = true;
    }
	
	void Update ()
    {
        if (move)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x <= -16)
        {
            move = false;
            transform.position = initialPos;
        }
    }
}
