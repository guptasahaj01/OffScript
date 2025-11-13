using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    void Update()
    {
        // If the player presses "B", load Act2 scene immediately
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("🔁 Switching to Act2...");
            SceneManager.LoadScene("Act2");
        }
    }
}