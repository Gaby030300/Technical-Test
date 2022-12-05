using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Get Rigidbody from the player
    private Rigidbody playerRb;
    // Get Focal Point from the camera
    private GameObject focalPoint;
    // Set player movement velocity

    // Set player movement parameters
    [Header("Player Movement Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;

    private bool isOnGround;

    //Set Audio Effects
    [Header("Audio Effects")]
    public AudioClip key;
    AudioSource audioSource;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        //Initialize and get Audio Source Componet
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        // Add force to player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);
        JumpPlayer();
    }
    //Jump Player
    private void JumpPlayer()
    {
        // Add force to the player setting up the force vector and the force mode
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isOnGround = false;
        }
    }
    //When the player touch the floor
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }        
    }
    // Collect key item ad add it into a counter.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            audioSource.PlayOneShot(key, 1f);
            //Instanciate the KeyObject Class to use keyCount variable
            OpenDoor.keyCount++;
            Destroy(other.gameObject);
        }
    }
}
