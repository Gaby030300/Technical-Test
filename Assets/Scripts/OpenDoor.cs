using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class OpenDoor : MonoBehaviour
{
    //Key Counter 
    public static int keyCount;
    //Max amount of keys to open the door.
    public int maxKey;
    //Active door animation
    public Animator animator;

    //Set Audio Effects
    AudioSource audioSource;
    public AudioClip door;

    private void Start()
    {
        //Initialize and get Audio Source Componet
        audioSource = GetComponent<AudioSource>();
    }

    //Open Door with the Key
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && keyCount == maxKey)
        {
            keyCount--;
            animator.enabled = true;
            audioSource.PlayOneShot(door, 1f);
        }
    }
}
