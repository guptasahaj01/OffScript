using UnityEngine;
using UnityEngine.SceneManagement; // Make sure this is included
using UnityEngine.UI;
using TMPro; // Make sure this is included

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 7f;
    public float jumpForce = 15f;
    private Rigidbody2D rb;

    [Header("Ground Check")]
    private bool isGrounded = false;
    
    [Header("Act 1: Sweeping")]
    public float sweepRadius = 1.5f;
    public TextMeshProUGUI sweepCounterText;
    
    // This is the global score variable
    public static int score = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // Reset the score to 0 every time the scene starts
        score = 0; 
        UpdateSweepCounterText();
    }

    void Update()
    {
        // --- MOVEMENT ---
        float moveInput = Input.GetAxisRaw("Horizontal"); 
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // --- JUMPING ---
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (Input.GetButtonDown("Jump") && !isGrounded) Debug.Log("Jump button pressed but not grounded");

        // --- SWEEPING ---
        if (Input.GetKeyDown(KeyCode.E))
        {
            Sweep();
        }
    }

    void Sweep()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, sweepRadius);
        foreach (Collider2D hit in hits)
        {
            // Now it checks for the "Sweepable" tag
            if (hit.gameObject.CompareTag("Sweepable"))
            {
                Destroy(hit.gameObject);
                
                // Add 10 points to the score instead of 1
                score += 10; 
                UpdateSweepCounterText();
            }
        }
    }

    void UpdateSweepCounterText()
    {
        if (sweepCounterText != null)
        {
            // Update the text to show the new score
            sweepCounterText.text = "Score: " + score;
        }
    }
    
    // --- TRIGGER FUNCTIONS FOR JUMPING ---

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Player is entering ground");
        // This checks for the "Ground" tag on your invisible GroundTrigger object
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Player is grounded");
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Player is exiting ground");
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Player is not grounded");
            isGrounded = false;
        }
    }

    // --- COLLISION FUNCTION FOR DEATH ---
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // This is the line that checks for death
        if (collision.gameObject.CompareTag("Debris"))
        {
            // --- THIS IS THE CHANGED LINE ---
            // This now loads your "Game Over" scene.
            SceneManager.LoadScene("End");
        }
    }
}