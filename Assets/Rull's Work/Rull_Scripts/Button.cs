using System;
using UnityEngine;
using UnityEngine.AI;
public class Button : MonoBehaviour
{
    [SerializeField] private Door door;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite redSprite;
    [SerializeField] private Sprite greenSprite;

    private int objectsOnButton = 0;

    private AudioSource audioSource;
    [SerializeField] private AudioClip buttonOn;
    [SerializeField] private AudioClip buttonOff;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (spriteRenderer != null && redSprite != null)
        {
            spriteRenderer.sprite = redSprite;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player) || other.TryGetComponent(out Stone stone))
        {
            objectsOnButton++;

            if (objectsOnButton == 1)
            {
                audioSource.PlayOneShot(buttonOn);
                door.SetOpen(true);

                if (spriteRenderer != null && greenSprite != null)
                {
                    spriteRenderer.sprite = greenSprite; 
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player) || other.TryGetComponent(out Stone stone))
        {
            objectsOnButton--;

            if (objectsOnButton <= 0)
            {
                objectsOnButton = 0;

                audioSource.PlayOneShot(buttonOff);
                door.SetOpen(false);

                if (spriteRenderer != null && redSprite != null)
                {
                    spriteRenderer.sprite = redSprite; 
                }
            }
        }
    }
}
