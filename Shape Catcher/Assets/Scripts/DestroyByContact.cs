using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    GameController controller;
    public Fragment frag;

    void Start()
    {
        GameObject controllerObj = GameObject.FindWithTag("GameController");
        controller = controllerObj.GetComponent<GameController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Explosion"))
        { 
            Destroy(this.gameObject);
            controller.AddScore();
            for (int i = 0; i < 3; i++)
            {
                Instantiate(frag, transform.position, transform.rotation);
            }
        }

        if (other.CompareTag("Ground") || other.CompareTag("Tower"))
        {
            Destroy(this.gameObject);
            controller.LoseLife();
        }
	}
}
