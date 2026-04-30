using System;
using UnityEngine;
using UnityEngine.AI;
public class Button : MonoBehaviour
{
    [SerializeField] private Door door;
    private int objectsOnButton = 0;

    private AudioSource audioSource;
    [SerializeField] private AudioClip buttonOn;
    [SerializeField] private AudioClip buttonOff;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if (objectsOnButton == 0)
            {
                audioSource.PlayOneShot(buttonOn);
                door.SetOpen(true);
            }
            objectsOnButton++;
            // door.SetOpen(true);
        } else if (other.TryGetComponent(out Stone stone))
        {
            audioSource.PlayOneShot(buttonOn);
            objectsOnButton++;
            door.SetOpen(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            objectsOnButton--;

            if (objectsOnButton <= 0)
            {
                audioSource.PlayOneShot(buttonOff);
                door.SetOpen(false);
            }
        }else if (other.TryGetComponent(out Stone stone))
        {
            objectsOnButton--;

            if (objectsOnButton <= 0)
            {
                audioSource.PlayOneShot(buttonOff);
                door.SetOpen(false);
            }
        }
    }
}
