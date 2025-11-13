using UnityEngine;

public class VillainController : MonoBehaviour
{
    Animator anim;
    void Awake() => anim = GetComponent<Animator>();
    public void PlayEnter() => anim.SetTrigger("Enter");
    public void PlayIdle() => anim.SetTrigger("Idle");
}