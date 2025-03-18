using UnityEngine;

public class CCursor : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Get the mouse position in screen space
        Vector3 mousePos = Input.mousePosition;

        // Convert the mouse position to world space
        // Note: This assumes your camera is at z = 0
        mousePos.z = 10; // Adjust this value if your camera is at a different z position
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        // Set the cursor's position to the calculated world position
        transform.position = worldPos;
    }
}