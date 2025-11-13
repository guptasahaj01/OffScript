using UnityEngine;

public class HeroController : MonoBehaviour
{
    public Animator animator;
    public float bobAmplitude = 0.1f;
    public float bobSpeed = 2f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;

        if (animator == null)
            animator = GetComponent<Animator>();
    }

    void Update()
    {
        // simple flying/bobbing motion
        transform.position = startPos + new Vector3(
            0,
            Mathf.Sin(Time.time * bobSpeed) * bobAmplitude,
            0
        );
    }

    // --- Animation Triggers ---

    public void PlayGooHitAnimation()
    {
        if (animator != null)
            animator.SetTrigger("GooHit");
    }

    public void PlayHit()
    {
        if (animator != null)
            animator.SetTrigger("Hit");
    }

    public void PlaySlip()
    {
        if (animator != null)
            animator.SetTrigger("Slip");
    }

    public void PlayDie()
    {
        if (animator != null)
            animator.SetTrigger("Die");
    }
}