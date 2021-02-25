using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public Bullet shot;
    public Transform shotSpawn;
    public float fireRate;

    private int ammunition;
    private bool canReload = false;

    public GameObject[] ammoCounter;

    private float nextFire;

    void Start()
    {
        ammunition = 6;
        if (GameController.Difficulty() < 2)
        {
            CanReload(true);
        }
    }

    public void Shoot(Vector2 objetivoPos)
    {
        if (Time.time > nextFire && ammunition > 0)
        {
            Bullet disparo = Instantiate(shot, shotSpawn.position, Quaternion.identity);
            disparo.SetTarget(objetivoPos);
            nextFire = Time.deltaTime + fireRate;

            if (GameController.Difficulty() > 0)
            {
                ammunition--;
                ammoCounter[ammunition].SetActive(false);
            }
        }
    }

    void OnMouseUp()
    {
        if (GameController.Difficulty() > 0 && canReload)
        {
            ammunition = 6;
            foreach (GameObject ammo in ammoCounter)
            {
                ammo.SetActive(true);
            }
        }
    }

    public void CanReload(bool canRel)
    {
        canReload = canRel;
    }

    void OnTriggerEnter2D(Collider2D gearColl)
    {
        if (gearColl.gameObject.CompareTag("Gear") && GameController.Difficulty() == 2)
        {
            CanReload(true);
        }
    }

    void OnTriggerExit2D(Collider2D gearColl)
    {
        if (gearColl.gameObject.CompareTag("Gear") && GameController.Difficulty() == 2)
        {
            CanReload(false);
        }
    }

    public void InstantReload()
    {
        ammunition = 6;

        foreach (GameObject ammo in ammoCounter)
        {
            ammo.SetActive(true);
        }
    }
}