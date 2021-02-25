using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    Vector2 targetPosition;
    public GameObject explosion;

    public void SetTarget(Vector2 target)
    {
        targetPosition = target;
    }
    
	void FixedUpdate ()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }
}
