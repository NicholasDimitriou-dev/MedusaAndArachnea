using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void CompleteLevel()
    {
        SaveLevelCompleted();

        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            PlayerPrefs.SetInt("OpenLevelSelect", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene(1);
        }
    }

    private void SaveLevelCompleted()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "LevelOne")
        {
            LevelCompleted.SetLevel1Completed();
        }
        else if (sceneName == "LevelTwo")
        {
            LevelCompleted.SetLevel2Completed();
        }
        else if (sceneName == "LevelThreeForAnimation")
        {
            LevelCompleted.SetLevel3Completed();
        }
        else if (sceneName == "LevelA")
        {
            LevelCompleted.SetLevel4Completed();
        }
    }
}