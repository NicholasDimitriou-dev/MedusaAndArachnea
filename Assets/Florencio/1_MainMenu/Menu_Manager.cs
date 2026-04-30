using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu_Manager : MonoBehaviour
{
    [SerializeField] private GameObject regular;
    [SerializeField] private RectTransform startButton;
    [SerializeField] private RectTransform selectLevelButton;
    [SerializeField] private RectTransform creditsButton;
    [SerializeField] private RectTransform quitButton;
    public GameObject levelSelectMenu;
    [SerializeField] private RectTransform levelOneButton;
    [SerializeField] private RectTransform levelTwoButton;
    [SerializeField] private RectTransform backButton;
    [SerializeField] private TextMeshProUGUI levelErrorMessage;
    [SerializeField] private GameObject quitMenu;
    [SerializeField] private RectTransform yesButton;
    [SerializeField] private RectTransform noButton;
    [SerializeField] private Image levelTwoImage;
    [SerializeField] private Color lockedColor = new Color(80f, 80f, 80f, 255f);
    [SerializeField] private Color unlockedColor = Color.white;
    public static Menu_Manager instance;
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        regular.SetActive(true);
        levelSelectMenu.SetActive(false);
        levelErrorMessage.gameObject.SetActive(false);
        quitMenu.SetActive(false);
        UpdateLevel2Button();
        if(PlayerPrefs.GetInt("OpenLevelSelect", 0) == 1)
        {
            levelSelectMenu.SetActive(true);
            PlayerPrefs.DeleteKey("OpenLevelSelect");
            PlayerPrefs.Save();
        }
    }
    private void Update()
    {
        HandleClicks();
    }
    private void HandleClicks()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        if(!Mouse.current.leftButton.wasPressedThisFrame)
        {
            return;
        }
        if(startButton.gameObject.activeInHierarchy && HoveringOnButton(startButton, mousePos))
        {
            SceneManager.LoadScene("LevelOneForanimation");
            //SceneManager.LoadScene("LevelOne(Dupe)");
            return;
        }
        else if(selectLevelButton.gameObject.activeInHierarchy && HoveringOnButton(selectLevelButton, mousePos))
        {
            regular.SetActive(false);
            levelSelectMenu.SetActive(true);
            return;
        }
        else if(levelSelectMenu.activeInHierarchy && HoveringOnButton(levelOneButton, mousePos))
        {
            SceneManager.LoadScene("LevelOneForanimation");
            //SceneManager.LoadScene("LevelOne(Dupe)");
            return;
        }
        else if(levelSelectMenu.activeInHierarchy && HoveringOnButton(levelTwoButton, mousePos))
        {
            if(LevelCompleted.IsLevel1Completed())
            {
                SceneManager.LoadScene("LevelTwo(Dupe)");
            }
            else
            {
                levelErrorMessage.gameObject.SetActive(true);
                levelErrorMessage.canvasRenderer.SetAlpha(1f);
                levelErrorMessage.CrossFadeAlpha(0f, 1f, false);
            }
            return;
        }
        else if(backButton.gameObject.activeInHierarchy && HoveringOnButton(backButton, mousePos))
        {
            levelSelectMenu.SetActive(false);
            regular.SetActive(true);
            return;
        }
        else if(creditsButton.gameObject.activeInHierarchy && HoveringOnButton(creditsButton, mousePos))
        {
            SceneManager.LoadScene("Credits");
            return;
        }
        else if(quitButton.gameObject.activeInHierarchy && HoveringOnButton(quitButton, mousePos))
        {
            regular.SetActive(false);
            quitMenu.SetActive(true);
            return;
        }
        else if(yesButton.gameObject.activeInHierarchy && HoveringOnButton(yesButton, mousePos))
        {
            Application.Quit();
            Debug.Log("Quittig game");
            return;
        }
        else if(noButton.gameObject.activeInHierarchy && HoveringOnButton(noButton, mousePos))
        {
            quitMenu.SetActive(false);
            regular.SetActive(true);
            return;
        }
    }
    private bool HoveringOnButton(RectTransform rect, Vector2 position)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rect, position);
    }
    private void UpdateLevel2Button()
    {
        if(LevelCompleted.IsLevel1Completed())
        {
            levelTwoImage.color = unlockedColor;
        }
        else
        {
            levelTwoImage.color = lockedColor;
        }
    }
}