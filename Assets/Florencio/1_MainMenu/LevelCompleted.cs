using UnityEngine;
public static class LevelCompleted
{
    public static void SetLevel1Completed()
    {
        PlayerPrefs.SetInt("Level1Completed", 1);
        PlayerPrefs.Save();
    }
    public static bool IsLevel1Completed()
    {
        return PlayerPrefs.GetInt("Level1Completed", 0) == 1;
    }
}