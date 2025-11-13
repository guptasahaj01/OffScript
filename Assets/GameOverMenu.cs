using UnityEngine;
using UnityEngine.SceneManagement; // Don't forget this!

public class GameOverMenu : MonoBehaviour
{
    // This function will be called by our button
    public void RestartGame()
    {
        // This loads your main game scene. 
        // Make sure the name is EXACTLY right.
        SceneManager.LoadScene("Act1");
    }
}