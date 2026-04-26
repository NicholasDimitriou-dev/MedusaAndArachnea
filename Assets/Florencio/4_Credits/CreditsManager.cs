using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI creditsText;
    
    [SerializeField] private GameObject thanks;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private GameObject exitMenu;

    [SerializeField] private RectTransform openExitMenu;
    [SerializeField] private RectTransform goToMainMenu;
    [SerializeField] private RectTransform quitGame;

    private Animator ani;
    
    private float timer = 0f;

    private bool creditsFinished = false;
    private bool exitButtonShown = false;

    AnimatorStateInfo stateInfo;

    private void Awake()
    {
        ani = creditsText.GetComponent<Animator>();
        
        thanks.SetActive(false);
        exitButton.SetActive(false);
        exitMenu.SetActive(false);
    }

    private void Update()
    {
        ClickHandler();
        
        if(creditsFinished)
        {
            if(!exitButtonShown)
            {
                timer += Time.deltaTime;

                if(timer >= 3f)
                {
                    exitButton.SetActive(true);
                    exitButtonShown = true;
                }
            }
            return;
        }

        stateInfo = ani.GetCurrentAnimatorStateInfo(0);

        if(stateInfo.IsName("Credits_Scroll") && stateInfo.normalizedTime >= 1f)
        {
            thanks.SetActive(true);
            creditsFinished = true;
        }
    }
    
    private void ClickHandler()
    {
        Vector2 pos = Mouse.current.position.ReadValue();

        if(HoveringOverUI(openExitMenu, pos) && Mouse.current.leftButton.isPressed)
        {
            ExitMenu();
        }

        if(HoveringOverUI(goToMainMenu, pos) && Mouse.current.leftButton.isPressed)
        {
            MainMenu();
        }

        if(HoveringOverUI(quitGame, pos) && Mouse.current.leftButton.isPressed)
        {
            Quit();
        }
    }

    private bool HoveringOverUI(RectTransform rectTrans, Vector2 screenPos)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rectTrans, screenPos, null);
    }

    public void ExitMenu()
    {
        exitMenu.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("quitting game");
    }
}