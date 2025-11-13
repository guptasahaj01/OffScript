using UnityEngine;

public class StickyGooBomb : MonoBehaviour
{
    public float interactRange = 1f;

    private Scene2Manager scene2Manager;
    private bool canUse = true;

    void Start()
    {
        scene2Manager = FindFirstObjectByType<Scene2Manager>();
    }

    void Update()
    {
        if (!canUse) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player == null) return;

            float dist = Vector2.Distance(transform.position, player.transform.position);

            if (dist <= interactRange)
            {
                canUse = false;
                Debug.Log("Goo Bomb used!");

                // 🔥 Correct method name:
                scene2Manager.TriggerGooDialogue();

                Destroy(gameObject);
            }
        }
    }
}