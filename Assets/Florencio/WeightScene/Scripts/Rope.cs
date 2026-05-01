using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Rope : MonoBehaviour
{
    private static Rope activeRope;

    [SerializeField] private Platform_Rope connectedPlatform;
    [SerializeField] private Transform user;

    private Controls controls;

    private bool isPlayerInside;
    private bool isArachneaUser;
    private bool wasHoldingLastFrame;

    private AudioSource audioSource;
    private bool canPlay = true;

    private void Awake()
    {
        controls = new Controls();
        isArachneaUser = user.GetComponent<Arachnea>() != null;
        audioSource = GetComponent<AudioSource>();
    }
    
    
    private void ToggleRopeSound (bool on)
    {
        if (canPlay && on)
        {
            audioSource.Play();
            canPlay = false;
        }
        else if (!canPlay && on)
        {
            return;
        }
        else if (!canPlay && !on)
        {
            canPlay = true;
            IEnumerator pause = PauseSound(audioSource, 0.3f);
            StartCoroutine(pause);
        }
    }
    
    private static IEnumerator PauseSound(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
        audioSource.Stop();
        audioSource.volume = startVolume;
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
                ToggleRopeSound(true);
                activeRope = this;

            }
        }
        if((!isHolding || !isPlayerInside) && activeRope == this)
        {
            activeRope = null;
            ToggleRopeSound(false);
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