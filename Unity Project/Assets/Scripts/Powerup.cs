using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb;

    private int selector;

    GameController controller;

    void Start()
    {
        GameObject controllerObj = GameObject.FindWithTag("GameController");
        controller = controllerObj.GetComponent<GameController>();
        switch (GameController.Difficulty())
        {
            case 0: { selector = 3; break; }
            case 1: { selector = 4; break; }
            case 2: { selector = 5; break; }
        }
    }
        
    public void Drop()
    {
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Gear"))
        {
            switch (Random.Range(1,selector))
            {
                case 1:
                    {
                        controller.BonusScore();
                        break;
                    }
                case 2:
                    {
                        controller.FireLasers();
                        break;
                    }
                case 3:
                    {
                        controller.DestroyAll();
                        break;
                    }
                case 4:
                    {
                        controller.InstantReload();
                        break;
                    }
                case 5:
                    {
                        controller.BonusLife();
                        break;
                    }  
            }
            Destroy(this.gameObject);
        }
    }
}
