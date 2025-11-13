using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Drag your Player object here
    public Vector3 offset;   // For X and Z. (e.g., X:0, Y:0, Z:-10)
    public float minY = 0f;  // Your fixed Y-height

    void LateUpdate()
    {
        if (player != null)
        {
            // Get the player's X position and add the X offset
            float newX = player.position.x + offset.x;

            // Use your 'minY' value as the new FIXED Y position.
            float newY = 1.5f;

            // Use the Z offset (this should be -10)
            float newZ = offset.z;

            // Set the camera's position directly. No smoothing.
            transform.position = new Vector3(newX, newY, newZ);
        }
    }
}