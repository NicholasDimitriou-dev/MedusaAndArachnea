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

    public static void SetLevel2Completed()
    {
        PlayerPrefs.SetInt("Level2Completed", 1);
        PlayerPrefs.Save();
    }

    public static bool IsLevel2Completed()
    {
        return PlayerPrefs.GetInt("Level2Completed", 0) == 1;
    }
    public static void SetLevel3Completed()
    {
        PlayerPrefs.SetInt("Level3Completed", 1);
        PlayerPrefs.Save();
    }

    public static bool IsLevel3Completed()
    {
        return PlayerPrefs.GetInt("Level3Completed", 0) == 1;
    }
    public static void SetLevel4Completed()
    {
        PlayerPrefs.SetInt("Level4Completed", 1);
        PlayerPrefs.Save();
    }

    public static bool IsLevel4Completed()
    {
        return PlayerPrefs.GetInt("Level4Completed", 0) == 1;
    }
}