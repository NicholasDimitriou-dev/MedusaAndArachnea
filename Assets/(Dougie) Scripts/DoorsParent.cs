using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorsParent : MonoBehaviour
{
    [SerializeField] private IndividualDoor medusaDoor;
    [SerializeField] private IndividualDoor arachneaDoor;
    private bool medusaExit = false;
    private bool arachneaExit = false;
    // Added by Florencio
    private bool levelCompleted = false;
    //

    private event EventHandler checkIfFinished;
    private AudioSource audioSource;
    private bool victorySound = true;
    private void Start()
    {
        medusaDoor.MedusaOnDoor += MedusaDoor_OnEntrance;
        medusaDoor.MedusaOffDoor += MedusaDoor_OnExit;
        arachneaDoor.ArachnaeOffDoor += ArachneaDoor_OnExit;
        arachneaDoor.ArachnaeOnDoor += ArachneaDoor_OnEntrance;
        checkIfFinished += CheckIfFinished;


    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void ArachneaDoor_OnEntrance(object sender, EventArgs e)
    {
        arachneaExit = true;
        Debug.Log("Arachnea is on her door");
        checkIfFinished?.Invoke(this, EventArgs.Empty);
    }

    private void ArachneaDoor_OnExit(object sender, EventArgs e)
    {
        arachneaExit = false;
        Debug.Log("Arachnea is off her door");
        checkIfFinished?.Invoke(this, EventArgs.Empty);
        
        
    }

    private void MedusaDoor_OnExit(object sender, EventArgs e)
    {
        medusaExit = false;
        Debug.Log("Medusa is off her door");
        checkIfFinished?.Invoke(this, EventArgs.Empty);
        
    }

    private void MedusaDoor_OnEntrance(object sender, EventArgs e)
    {
        medusaExit = true;
        Debug.Log("Medusa is on her door");
        checkIfFinished?.Invoke(this, EventArgs.Empty);
        
    }
    
    
    private void CheckIfFinished(object sender, EventArgs e)
    {
        if (medusaExit && arachneaExit)
        {
            // Debug.Log("BOTH CHARACTERS ARE ON THEIR EXITS!!!"); // Commented out for testing
            if (victorySound)
            {
                victorySound = false;
                audioSource.Play();
                StartCoroutine(TransitionToNextLevel());
            }
        }

        // Added by Rull
        // if (!levelCompleted && medusaExit && arachneaExit)
        // if (medusaExit && arachneaExit)
        // {
            // if (GameManager.Instance.HasAllCoins())
            // {
                // levelCompleted = true;
                // GameManager.Instance.SetLevelCompleted();

                // StartCoroutine(TransitionToNextLevel());
            // }
            // else
            // {
                // Debug.Log("Need all coins before exiting!");
            // }
        // }
        // Debug.Log("Medusa: " + medusaExit + " | Arachnea: " + arachneaExit);
        // Debug.Log("Coins: " + GameManager.Instance.HasAllCoins());
        
        // Added by Florencio
        /* Edited my Rull
        if (!levelCompleted && medusaExit && arachneaExit)
        {
            levelCompleted = true; // Added by Florencio
            Debug.Log("BOTH CHARACTERS ARE ON THEIR EXITS!!!");
            string currentSceneName = SceneManager.GetActiveScene().name;
            if(currentSceneName == "LevelOne(Dupe)")
            {
                LevelCompleted.SetLevel1Completed();
            }
            StartCoroutine(TransitionToNextLevel());
        }
        //
        */
    }

    IEnumerator TransitionToNextLevel()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Changing Level!");          // Commented out for testing
        Loader.Load(Loader.Scene.LevelOne);

    //     // Added by Florencio
    //     yield return new WaitForSeconds(3);
    //     Debug.Log("Changing Level!");
    //     string currentSceneName = SceneManager.GetActiveScene().name;
    //     
    //     //Edited by Rull
    //     if(currentSceneName == "LevelOneForanimation")
    //     {
    //         SceneManager.LoadScene("LevelTwoForAnimation");
    //     }
    //     else if(currentSceneName == "LevelTwoForAnimation")
    //     {
    //         SceneManager.LoadScene("LevelThreeForAnimation");
    //     }
    //     else if(currentSceneName == "LevelThreeForAnimation")
    //     {
    //         SceneManager.LoadScene("CreditsForAnimation");
    //     }
    //     /*
    //     if(currentSceneName == "LevelOne(Dupe)")
    //     {
    //         SceneManager.LoadScene("LevelTwo(Dupe)");
    //     }
    //     
    //     else if(currentSceneName == "LevelTwo(Dupe)")
    //     {
    //         SceneManager.LoadScene("Credits");
    //     }
    //     */
    //     //
    }
}
