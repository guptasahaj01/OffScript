using UnityEngine;

public class HeroHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("References (Optional)")]
    public Animator animator; // hero hit animation
    public bool heroCanDie = false; 
    // hero only dies after Goo Phase 3, controlled by Scene2Manager

    void Start()
    {
        currentHealth = maxHealth;
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        // clamp so we NEVER accidentally drop below 0
        currentHealth = Mathf.Max(currentHealth, 0);

        Debug.Log($"Hero took damage: {amount}. Current health: {currentHealth}");

        // play hit animation (optional)
        if (animator != null)
            animator.SetTrigger("Hit");

        // Only allow death when Scene2Manager says so
        if (heroCanDie && currentHealth <= 0)
        {
            Debug.Log("HeroHealth: Hero has reached 0 HP. Death allowed now.");
            Die();
        }
    }

    void Die()
    {
        Debug.Log("HeroHealth: DIE() called.");
        if (animator != null)
            animator.SetTrigger("Die");

        // No Scene2Manager call here → Scene2Manager triggers death sequence manually.
    }

    // Called ONLY by Scene2Manager during final cutscene
    public void EnableRealDeath()
    {
        heroCanDie = true;
    }
}