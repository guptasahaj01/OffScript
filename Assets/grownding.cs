using UnityEngine;

public class grownding : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Debug.Log("Player is entering ground");
        // This checks for the "Ground" tag on your invisible GroundTrigger object
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Player is grounded");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Player is exiting ground");
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Player is not grounded");
        }
    }
}
