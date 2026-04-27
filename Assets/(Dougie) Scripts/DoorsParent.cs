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
    private void Start()
    {
        medusaDoor.MedusaOnDoor += MedusaDoor_OnEntrance;
        medusaDoor.MedusaOffDoor += MedusaDoor_OnExit;
        arachneaDoor.ArachnaeOffDoor += ArachneaDoor_OnExit;
        arachneaDoor.ArachnaeOnDoor += ArachneaDoor_OnEntrance;
        checkIfFinished += CheckIfFinished;


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
        //if (medusaExit && arachneaExit)
        //{
        //    Debug.Log("BOTH CHARACTERS ARE ON THEIR EXITS!!!"); // Commented out for testing
        //    StartCoroutine(TransitionToNextLevel());
        //}

        // Added by Florencio
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
    }

    IEnumerator TransitionToNextLevel()
    {
        //yield return new WaitForSeconds(3);
        //Debug.Log("Changing Level!");          // Commented out for testing
        //Loader.Load(Loader.Scene.LevelOne);

        // Added by Florencio
        yield return new WaitForSeconds(3);
        Debug.Log("Changing Level!");
        string currentSceneName = SceneManager.GetActiveScene().name;
        if(currentSceneName == "LevelOne(Dupe)")
        {
            SceneManager.LoadScene("LevelTwo(Dupe)");
        }
        else if(currentSceneName == "LevelTwo(Dupe)")
        {
            SceneManager.LoadScene("Credits");
        }
        //
    }
}
