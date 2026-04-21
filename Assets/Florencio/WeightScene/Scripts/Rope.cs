using UnityEngine;

public class Rope : MonoBehaviour
{
    private static Rope activeRope;

    [SerializeField] private Platform_Rope connectedPlatform;
    [SerializeField] private Transform user;

    private Controls controls;

    private bool isPlayerInside;
    private bool isArachneaUser;
    private bool wasHoldingLastFrame;

    private void Awake()
    {
        controls = new Controls();
        isArachneaUser = user.GetComponent<Arachnea>() != null;
    }
    private void Update()
    {
        if(!isArachneaUser)
        {
            if(connectedPlatform != null)
            {
                connectedPlatform.SetRopeActive(false);
            }

            return;
        }
        bool isHolding = controls.Player.ArachneaInteract.IsPressed();
        bool pressedThisFrame = isHolding && !wasHoldingLastFrame;
        if(pressedThisFrame && isPlayerInside)
        {
            if(activeRope == null || activeRope == this)
            {
                activeRope = this;

            }
        }
        if((!isHolding || !isPlayerInside) && activeRope == this)
        {
            activeRope = null;
        }
        bool isUsingThisRope = activeRope == this && isPlayerInside && isHolding;
        if(connectedPlatform != null)
        {
            connectedPlatform.SetRopeActive(isUsingThisRope);
        }
        wasHoldingLastFrame = isHolding;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!isArachneaUser)
        {
            return;
        }
        if(other.transform != user)
        {
            return;
        }
        isPlayerInside = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if(!isArachneaUser)
        {
            return;
        }
        if(other.transform != user)
        {
            return;
        }
        isPlayerInside = false;
        if(activeRope == this)
        {
            activeRope = null;
        }
        if(connectedPlatform != null)
        {
            connectedPlatform.SetRopeActive(false);
        }
    }
    private void OnEnable()
    {
        controls.Player.Enable();
    }
    private void OnDisable()
    {
        if(controls != null)
        {
            controls.Player.Disable();
        }
        if (activeRope == this)
        {
            activeRope = null;
        }
        if(connectedPlatform != null)
        {
            connectedPlatform.SetRopeActive(false);
        }
        isPlayerInside = false;
        wasHoldingLastFrame = false;
    }
}