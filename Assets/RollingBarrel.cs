using UnityEngine;

public class RollingBarrel : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Start()
    {
        // Destroy the barrel after 10 seconds if it gets stuck
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        // Move the barrel horizontally
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    // This destroys the barrel once it goes off-screen to save memory
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}