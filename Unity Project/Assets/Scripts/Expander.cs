using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expander : MonoBehaviour
{
    public float explosionSize;
    private Vector3 sizeVector;

    void Start()
    {
        sizeVector = new Vector3(explosionSize, explosionSize, 0.0f);
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, sizeVector, Time.deltaTime);
    }
    
}
