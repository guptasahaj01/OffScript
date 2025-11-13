using UnityEngine;

public class FreezeManager : MonoBehaviour
{
    private float originalTimeScale = 1f;

    public void Freeze()
    {
        Debug.Log("FREEZE CALL RECEIVED");
        originalTimeScale = Time.timeScale;
        Time.timeScale = 0f;
    }

    public void Unfreeze()
    {
        Debug.Log("UNFREEZE CALL RECEIVED");
        Time.timeScale = originalTimeScale;
    }
}