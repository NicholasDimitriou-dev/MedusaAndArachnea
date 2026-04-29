using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool LevelCompleted { get; private set; } = false;

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
            if (!LevelCompleted || currentCoins < coinsToWin)
            {
                LoseGame();
            }
        }
        /*
        if (timeRemaining <= 0)
        {
            LoseGame(); // fix later
        }
        */
    }
    public bool HasAllCoins()
    {
        return currentCoins >= coinsToWin;
    }
    
    public void SetLevelCompleted()
    {
        LevelCompleted = true;
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;
        UIManager.Instance.UpdateCoins(currentCoins, coinsToWin);

        if (currentCoins >= coinsToWin)
        {
            Debug.Log("All coins collected!");
        }
        /*
        if (currentCoins >= coinsToWin)
        {
            WinGame();
        }
        */
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
        else // Once the level is complete, need to go to the next level and also show the completed level and how many coins the player had collected
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
    { // Show the game is over and needs to restart the level again 
        gameEnded = true;
        Debug.Log("Time's up!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // fix this wea
    }
}
