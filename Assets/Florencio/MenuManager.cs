using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private RectTransform startButton;
    [SerializeField] private RectTransform levelSelectButton;
    [SerializeField] private RectTransform creditsButton;
    [SerializeField] private RectTransform quitButton;

    [SerializeField] private GameObject levelSelectMenu;
    [SerializeField] private GameObject quitMenu;

    [SerializeField] private GameObject transition;

    private Animator ani;
    private AnimatorStateInfo stateInfo;

    private void Awake()
    {
        levelSelectMenu.SetActive(false);
        quitMenu.SetActive(false);
        ani = transition.GetComponent<Animator>();
    }

    private void Update()
    {
        stateInfo = ani.GetCurrentAnimatorStateInfo(0);
        HandleClicks();
    }

    private void HandleClicks()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        if(isHoveringOnButton(levelSelectButton, mousePosition) && Mouse.current.leftButton.isPressed)
        {
            DisplayLevelMenu();
        }
        if(isHoveringOnButton(creditsButton, mousePosition) && Mouse.current.leftButton.isPressed)
        {
            ToCredits();
        }
        if(isHoveringOnButton(quitButton, mousePosition) && Mouse.current.leftButton.isPressed)
        {
            DisplayQuitMenu();
        }
    }

    private bool isHoveringOnButton(RectTransform rect, Vector2 position)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rect, position);
    }

    private void DisplayLevelMenu()
    {
        levelSelectMenu.SetActive(true);
    }
    private void ToCredits()
    {
        ani.Play("Transition");
        if(stateInfo.IsName("Transition") && stateInfo.normalizedTime >= 1f)
        {
            SceneManager.LoadScene("CreditsScene");
        }
    }
    private void DisplayQuitMenu()
    {
        quitMenu.SetActive(true);
    }
}