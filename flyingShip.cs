using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingShip : MonoBehaviour
{
    private bool moveUp = false;
    private bool moveHorizontal = false;
    private bool moveDown = false;

    // Movement distances
    private float upDistance = 100f;
    private float horizontalDistance = 700f;
    private float downDistance = 100f;

    // Speed of movement
    public float speed = 5f;

    void Update()
    {
        // Check for input to start movement
        if (Input.GetKeyDown(KeyCode.G))
        {
            moveUp = true;
        }

        // Move up
        if (moveUp)
        {
            speed = 10f;
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            if (transform.position.y >= upDistance)
            {
                moveUp = false;
                moveHorizontal = true;
            }
        }

        // Move horizontally
        else if (moveHorizontal)
        {
            speed = 30f;
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (transform.position.z >= horizontalDistance)
            {
                moveHorizontal = false;
                moveDown = true;
            }
        }

        // Move down
        else if (moveDown)
        {
            speed = 10f;
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            if (transform.position.y <= 15)
            {
                // Movement complete, reset positions for potential reuse
                moveDown = false;
                
            }
        }
    }
}