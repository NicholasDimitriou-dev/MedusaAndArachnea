using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public enum Scene
    {
        LevelOne,
        LevelTwo,
        LevelThreeForAnimation,
        LevelA,
        Credits,
        LoadingScene,
    }

    public static Scene[] levelList = { Scene.LevelOne, Scene.LevelTwo, Scene.LevelThreeForAnimation, Scene.LevelA, Scene.Credits};
    public static int index = 1;

    private static Scene targetScene;

    public static void Load(Scene targetScene)
    {
        
        Loader.targetScene = targetScene;
        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    public static void LoaderCallback()
    {
        SceneManager.LoadScene(levelList[index++].ToString());
    }
}
