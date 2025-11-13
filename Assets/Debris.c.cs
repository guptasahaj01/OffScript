using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // Ensures this object always has physics
public class Debris : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component attached to this object
        rb = GetComponent<Rigidbody2D>();
    }

    // This function is called by Unity when this object collides with another
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object we hit is tagged as "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            // --- IT HIT THE GROUND, SO MAKE IT SWEEPABLE ---
            
            // 1. Stop all physics (gravity, velocity) so it stays in place.
            rb.bodyType = RigidbodyType2D.Static;

            // 2. Change this object's tag from "Debris" (which kills the player)
            //    to "Sweepable" (which the player can clean up).
            gameObject.tag = "Sweepable";

            // 3. Start the 5-second expiration timer (from your SRS).
            //    This will automatically destroy the object after 5 seconds if not swept.
            Destroy(gameObject, 5.0f);
        }
    }
}