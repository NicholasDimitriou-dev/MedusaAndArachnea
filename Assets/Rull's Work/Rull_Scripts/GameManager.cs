using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int coinsToWin = 5;
    private int currentCoins = 0;

    [SerializeField] private float timeLimit = 60f;
    private float timeRemaining;

    private bool gameEnded = false;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        timeRemaining = timeLimit;
        UIManager.Instance.UpdateCoins(currentCoins, coinsToWin);
    }

    private void Update()
    {
        if (gameEnded) return;

        timeRemaining -= Time.deltaTime;
        UIManager.Instance.UpdateTimer(timeRemaining);

        if (timeRemaining <= 0)
        {
            LoseGame();
        }
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;
        UIManager.Instance.UpdateCoins(currentCoins, coinsToWin);

        if (currentCoins >= coinsToWin)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        gameEnded = true;
        Debug.Log("You win!");

        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            Debug.Log("Level completed!");
            SceneManager.LoadScene(1);

        }
    }
    /*private void WinGame()
    {
        gameEnded = true;
        Debug.Log("You win!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    */

    private void LoseGame()
    {
        gameEnded = true;
        Debug.Log("Time's up!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
