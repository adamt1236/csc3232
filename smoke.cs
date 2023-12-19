using UnityEngine;
using System.Collections;

public class ObjectController : MonoBehaviour
{
    public GameObject otherObject; // Drag and drop the other GameObject onto this field in the Unity Editor

    private bool isActive = false;

    void Update()
    {
        // Check if the 'Z' key is pressed
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // Toggle the activity of the other object
            isActive = !isActive;

            // If the other object is now active, start a 5-second timer
            if (isActive)
            {
                StartCoroutine(DeactivateOtherObjectAfterDelay(5f));
            }
        }

        // Set the other object's activity based on the current state
        if (otherObject != null)
        {
            otherObject.SetActive(isActive);
        }
    }

    // Coroutine to deactivate the other object after a delay
    IEnumerator DeactivateOtherObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Deactivate the other object
        if (otherObject != null)
        {
            isActive = false;
            otherObject.SetActive(false);
        }
    }
}