using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinningalien : MonoBehaviour
{
    Vector3 centerPoint; // The center point around which the object will move
    public float radius = 15.0f;  // The radius of the circular motion
    public float speed = 2.0f;   // The speed of rotation

    private float angle = 0.0f;
    private void Start()
    {
        centerPoint = transform.position;
    }
    void Update()
    {
        
            // Calculate the new position in a circle
            float x = centerPoint.x + Mathf.Cos(angle) * radius;
            float z = centerPoint.z + Mathf.Sin(angle) * radius;

            // Update the object's position
            transform.position = new Vector3(x, centerPoint.y, z);

            // Increment the angle based on the speed
            angle += speed * Time.deltaTime;

            // Ensure the angle stays within the [0, 2π] range
            if (angle > Mathf.PI * 2)
            {
                angle -= Mathf.PI * 2;
            }
        
    }
}


