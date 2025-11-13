using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    // Set these values in the Inspector
    public float minX = -10f;
    public float maxX = 10f;

    // LateUpdate runs after movement calculations
    void LateUpdate()
    {
        // Get the player's current position
        Vector3 currentPosition = transform.position;

        // Clamp the X value between the min and max
        float clampedX = Mathf.Clamp(currentPosition.x, minX, 28);

        // Set the player's position to the new, clamped position
        // This only changes the X, leaving Y and Z alone.
        transform.position = new Vector3(clampedX, currentPosition.y, currentPosition.z);
    }
}