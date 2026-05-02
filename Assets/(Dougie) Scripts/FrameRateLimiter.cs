using UnityEngine;

public class FrameRateLimiter : MonoBehaviour
{
    public int targetFPS = 60;

    void Awake()
    {
        // 1. Disable VSync (set to 0) to allow manual capping
        QualitySettings.vSyncCount = 0;

        // 2. Set the desired target frame rate
        Application.targetFrameRate = targetFPS;
    }
}