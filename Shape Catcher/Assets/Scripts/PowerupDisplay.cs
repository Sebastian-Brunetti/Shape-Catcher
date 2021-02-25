using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupDisplay : MonoBehaviour {

    public Sprite score;
    public Sprite lasers;
    public Sprite boom;
    public Sprite reload;
    public Sprite life;

    public Transform spawnTransform;

    private SpriteRenderer spriteRen;
    private bool move = false;

    void Start()
    {
        spriteRen = gameObject.GetComponent<SpriteRenderer>();
        spriteRen.enabled = false;
    }

    public void DisplayText(int selector)
    {
        transform.position = spawnTransform.position;
        spriteRen.enabled = true;
        switch (selector)
        {
            case 1: { spriteRen.sprite = score; break; }
            case 2: { spriteRen.sprite = lasers; break; }
            case 3: { spriteRen.sprite = boom; break; }
            case 4: { spriteRen.sprite = reload; break; }
            case 5: { spriteRen.sprite = life; break; }
        }
        move = true;
    }
	
	void Update ()
    {
        if (move)
        {
            transform.Translate(Vector3.up * Time.deltaTime);
        }
        
        if (transform.position.y >= -2.0f)
        {
            move = false;
            spriteRen.enabled = false;
        }
	}
}
