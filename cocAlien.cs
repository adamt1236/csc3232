using UnityEngine;
using System.Collections;



public class RotateObjectAfterDelay : MonoBehaviour
{

    private bool isZPressed = false;

    void Update()
    {
        // Check if the 'Z' key is pressed
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // Set a flag to indicate that 'Z' is pressed
            isZPressed = true;
        }

        // If 'Z' is pressed, start the rotation after a delay
        if (isZPressed)
        {
            StartCoroutine(RotateAfterDelay(5.5f));
        }
    }

    IEnumerator RotateAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Change the X rotation to 90 degrees
        RotateObject();

        // Reset the flag so that the rotation doesn't occur repeatedly
        isZPressed = false;
    }

    void RotateObject()
    {
        // Modify the rotation of the object
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}