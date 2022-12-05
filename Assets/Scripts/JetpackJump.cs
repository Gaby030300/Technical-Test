using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class JetpackJump : MonoBehaviour
{
    //Get Rigidbody component from the object
    private Rigidbody rb;
    //Set Jetpack force and max 
    [SerializeField] private int jetPackForce;
    private float jetPackFuel = 10;

    private bool isUsing;
    public ParticleSystem  particleJetpack;
    [SerializeField] private Image UIBar;

    void Start()
    {     
        //Iniatilize RigidBody
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        // Control Maz Jetpack Fuel
        if (jetPackFuel >= 10)
        {
            jetPackFuel = 10;
        }
        // Show in the UI the Jetpack Fuel Status
        UIBar.fillAmount = jetPackFuel / 10;

        // Through the left button JetPack Movement Starts
        if (Input.GetButton("Fire1"))
        {
            if (jetPackFuel > 0)
            {
                StartJetPack();
            }
        }
        else
        {
            StopJetPack();
        }
        // If the Jetpack fuel is 0 and is on the floor the jetpack movement stops.
        if (jetPackFuel <= 0 && isUsing == false)
        {
            StopJetPack();
        }
    }
    //Start JetPack Movement Function
    void StartJetPack()
    {
        rb.AddForce(Vector3.up * jetPackForce);
        jetPackFuel -= Time.deltaTime;
        isUsing = true;
        particleJetpack.Play();
    }
    //Stop JetPack Movement Function
    void StopJetPack()
    {
        jetPackFuel += Time.deltaTime;
        isUsing = false;
        particleJetpack.Stop();        
    }
}
