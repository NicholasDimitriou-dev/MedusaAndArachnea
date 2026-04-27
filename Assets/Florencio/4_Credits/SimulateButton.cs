using UnityEngine;
using UnityEngine.EventSystems;

public class SimulateButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private CreditsManager creditsManager;

    private enum ButtonAction
    {
        OpenExitMenu, GoToMainMenu, ExitGame
    }

    [SerializeField] private ButtonAction buttonAction;

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (buttonAction)
        {
            case ButtonAction.OpenExitMenu:
                creditsManager.ExitMenu();
                break;

            case ButtonAction.GoToMainMenu:
                creditsManager.MainMenu();
                break;

            case ButtonAction.ExitGame:
                creditsManager.Quit();
                break;
        }
    }
}