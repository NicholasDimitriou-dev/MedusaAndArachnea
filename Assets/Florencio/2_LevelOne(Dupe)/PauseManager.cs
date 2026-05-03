using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    [SerializeField] private RectTransform resumeButton;
    [SerializeField] private RectTransform selectLevelButton;
    [SerializeField] private RectTransform settingsButton;
    [SerializeField] private RectTransform backSettingsButton;
    [SerializeField] private RectTransform exitButton;
//<<<<<<< Updated upstream
    [SerializeField] private Canvas resolutionUI;
//=======

    [SerializeField] private GameObject SettingsMenu;
    [SerializeField] private GameObject levelSelectMenu;

    [SerializeField] private RectTransform levelOneButton;
    [SerializeField] private RectTransform levelTwoButton;
    [SerializeField] private RectTransform backButton;

    [SerializeField] private TextMeshProUGUI levelErrorMessage;
    [SerializeField] private Image levelTwoImage;

    [SerializeField] private Color lockedColor = new Color32(80, 80, 80, 255);
    [SerializeField] private Color unlockedColor = Color.white;

//>>>>>>> Stashed changes
    private bool isPaused = false;

    private void Awake()
    {
        Time.timeScale = 1f;

        pause.SetActive(false);
        SettingsMenu.SetActive(false);
        levelSelectMenu.SetActive(false);

        levelErrorMessage.gameObject.SetActive(false);

        UpdateLevel2Button();

        if (PlayerPrefs.GetInt("OpenLevelSelect", 0) == 1)
        {
            levelSelectMenu.SetActive(true);
            PlayerPrefs.DeleteKey("OpenLevelSelect");
            PlayerPrefs.Save();
        }
    }

    private void Update()
    {
        HandleClicks();
        HandlePauseInput();
    }

    private void HandleClicks()
    {
        if (Mouse.current == null || !Mouse.current.leftButton.wasPressedThisFrame)
        {
            return;
        }

        Vector2 mousePosition = Mouse.current.position.ReadValue();

        if (resumeButton.gameObject.activeInHierarchy && HoveringOnButton(resumeButton, mousePosition))
        {
            ResumeGame();
            return;
        }

        if (selectLevelButton.gameObject.activeInHierarchy && HoveringOnButton(selectLevelButton, mousePosition))
        {
            pause.SetActive(false);
            SettingsMenu.SetActive(false);
            levelSelectMenu.SetActive(true);
            return;
        }

        if (levelSelectMenu.activeInHierarchy && HoveringOnButton(levelOneButton, mousePosition))
        {
            LoadSceneUnpaused("LevelOneForanimation");
            return;
        }

        if (levelSelectMenu.activeInHierarchy && HoveringOnButton(levelTwoButton, mousePosition))
        {
            if (LevelCompleted.IsLevel1Completed())
            {
                SceneManager.LoadScene("LevelTwo(Dupe)");
                return;
            }
            levelErrorMessage.gameObject.SetActive(true);
            levelErrorMessage.canvasRenderer.SetAlpha(1f);

            levelErrorMessage.CrossFadeAlpha(0f, 0.5f, true);
        }

        if (backButton.gameObject.activeInHierarchy && HoveringOnButton(backButton, mousePosition))
        {
            levelSelectMenu.SetActive(false);
            SettingsMenu.SetActive(false);
            pause.SetActive(true);
            return;
        }

        if (settingsButton.gameObject.activeInHierarchy && HoveringOnButton(settingsButton, mousePosition))
        {
            pause.SetActive(false);
            levelSelectMenu.SetActive(false);
            SettingsMenu.SetActive(true);
            return;
        }

        if (backSettingsButton.gameObject.activeInHierarchy && HoveringOnButton(backSettingsButton, mousePosition))
        {
            SettingsMenu.SetActive(false);
            levelSelectMenu.SetActive(false);
            pause.SetActive(true);
            return;
        }

        if (exitButton.gameObject.activeInHierarchy && HoveringOnButton(exitButton, mousePosition))
        {
            LoadSceneUnpaused("MainMenu");
            return;
        }
    }

    private void HandlePauseInput()
    {
        if (Keyboard.current == null || !Keyboard.current.pKey.wasPressedThisFrame)
        {
            return;
        }

        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;

        pause.SetActive(true);
        SettingsMenu.SetActive(false);
        levelSelectMenu.SetActive(false);

        if (levelErrorMessage != null)
        {
            levelErrorMessage.gameObject.SetActive(false);
        }

        UpdateLevel2Button();
    }

    private void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;

        pause.SetActive(false);
        SettingsMenu.SetActive(false);
        levelSelectMenu.SetActive(false);

        if (levelErrorMessage != null)
        {
            levelErrorMessage.gameObject.SetActive(false);
        }
    }

    private void LoadSceneUnpaused(string sceneName)
    {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    private bool HoveringOnButton(RectTransform rect, Vector2 position)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rect, position);
    }

    public void UpdateLevel2Button()
    {

        if (LevelCompleted.IsLevel1Completed())
        {
            //<<<<<<< Updated upstream
            isPaused = true;
            resolutionUI.gameObject.SetActive(false);
            Time.timeScale = 0f;
            pause.SetActive(true);
            //=======
            levelTwoImage.color = unlockedColor;
            //>>>>>>> Stashed changes
        }
        else
        {
            //<<<<<<< Updated upstream
            isPaused = false;
            resolutionUI.gameObject.SetActive(true);
            pause.SetActive(false);
            Time.timeScale = 1f;
            //=======
            levelTwoImage.color = lockedColor;
            //>>>>>>> Stashed changes
        }
        
    }
}