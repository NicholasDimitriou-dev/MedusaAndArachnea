using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    [SerializeField] private RectTransform resumeButton;
    [SerializeField] private RectTransform selectLevelButton;
    [SerializeField] private RectTransform exitButton;
    [SerializeField] private Canvas resolutionUI;
    private bool isPaused = false;
    private void Awake()
    {
        pause.SetActive(false);
    }
    private void Update()
    {
        HandleClicks();
        Pause();
    }
    private void HandleClicks()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        if(!Mouse.current.leftButton.wasPressedThisFrame)
        {
            return;
        }
        if(resumeButton.gameObject.activeInHierarchy && HoveringOnButton(resumeButton, mousePosition))
        {
            isPaused = false;
            pause.SetActive(false);
            Time.timeScale = 1f;
        }
        if(selectLevelButton.gameObject.activeInHierarchy && HoveringOnButton(selectLevelButton, mousePosition))
        {
            PlayerPrefs.SetInt("OpenLevelSelect", 1);
            PlayerPrefs.Save();

            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
        }    
        if(exitButton.gameObject.activeInHierarchy && HoveringOnButton(exitButton, mousePosition))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
        }
    }
    private bool HoveringOnButton(RectTransform rect, Vector2 position)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rect, position);
    }
    private void Pause()
    {
        if(Keyboard.current.pKey.wasPressedThisFrame && !isPaused)
        {
            isPaused = true;
            resolutionUI.gameObject.SetActive(false);
            Time.timeScale = 0f;
            pause.SetActive(true);
        }
        else if (Keyboard.current.pKey.wasPressedThisFrame && isPaused)
        {
            isPaused = false;
            resolutionUI.gameObject.SetActive(true);
            pause.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}