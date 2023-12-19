using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coccoon : MonoBehaviour
{
    
    public float speed = 2.0f;
    public float amplitude = 1.0f;
    public bool raising = true;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (raising)
        {
            float yOffset = Mathf.Sin(Time.time * speed) * amplitude;
            transform.position = startPosition + new Vector3(0f, yOffset, 0f);
        }
        
    }
}

