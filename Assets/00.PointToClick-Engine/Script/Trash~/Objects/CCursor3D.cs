using UnityEngine;

public class CCursor3D : MonoBehaviour
{
    public float distanceFromCamera = 5f; // Default distance from the camera
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Set the cursor's position to the center of the screen
        Vector3 centerScreen = new Vector3(Screen.width / 2f, Screen.height / 2f, distanceFromCamera);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(centerScreen);
        transform.position = worldPosition;
    }

    // Method to adjust the cursor's distance from the camera
    public void AdjustDistance(float amount)
    {
        distanceFromCamera += amount;
        distanceFromCamera = Mathf.Clamp(distanceFromCamera, 1f, 20f); // Adjust min and max as needed
    }
}
