using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sensitivity = 2f;

    public TextMeshProUGUI fpsText;
    public TextMeshProUGUI memoryText;

    private float fpsUpdateInterval = 0.5f; // Update FPS every half second
    private float totalMemoryUpdateInterval = 10f; // Update total memory usage every ten seconds

    private float accum = 0.0f; // FPS accumulated over the interval
    private int frames = 0; // Frames drawn over the interval
    private float fpsNextInterval = 0.0f; // Next interval to display FPS

    private float memoryNextUpdate = 0.0f; // Next interval to update total memory usage

    void Start()
    {
        if (fpsText == null || memoryText == null)
        {
            Debug.LogError("TextMeshProUGUI components not assigned in the inspector!");
        }
    }

    void Update()
    {
        // Handle camera movement
        MoveCamera();

        // Handle camera rotation
        RotateCamera();

        // Update FPS and total memory
        UpdateFPS();
        UpdateTotalMemory();
    }

    void MoveCamera()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 rotation = new Vector3(-mouseY * sensitivity, mouseX * sensitivity, 0f);
        transform.Rotate(rotation);
    }

    void UpdateFPS()
    {
        frames++;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow > fpsNextInterval)
        {
            float fps = frames / (timeNow - fpsNextInterval);
            accum = 0.0f;
            frames = 0;
            fpsNextInterval = timeNow + fpsUpdateInterval;
            fpsText.text = "FPS: " + fps.ToString("F2");
        }
        // Comment out the line below to fix the FPS issue
        // accum += Time.timeScale / Time.deltaTime;
    }
    void UpdateTotalMemory()
    {
        if (Time.realtimeSinceStartup > memoryNextUpdate)
        {
            long totalMemory = System.GC.GetTotalMemory(false);
            memoryText.text = "Total Memory: " + BytesToMegabytes(totalMemory).ToString("F2") + " MB";
            memoryNextUpdate = Time.realtimeSinceStartup + totalMemoryUpdateInterval;
        }
    }

    float BytesToMegabytes(long bytes)
    {
        return bytes / (1024f * 1024f);
    }
}


