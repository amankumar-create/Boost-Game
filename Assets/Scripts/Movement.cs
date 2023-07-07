using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] int mainThrust = 1000;
    [SerializeField] int rotationThrust = 500;
    [SerializeField] AudioClip mainEngine ;
    [SerializeField] ParticleSystem mtParticleSystem, stlParticleSystem, strParticleSystem;
    Rigidbody rb;
    AudioSource audioSource;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if(!audioSource.isPlaying)
                audioSource.PlayOneShot(mainEngine);

            if (!mtParticleSystem.isPlaying)
                mtParticleSystem.Play();
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

        }   
        else
        {
            audioSource.Stop();
            mtParticleSystem.Stop();
        }
         
         
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(1);
            if(!stlParticleSystem.isPlaying)
                stlParticleSystem.Play();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-1);
            if (!strParticleSystem.isPlaying)
                strParticleSystem.Play();
        }
        else {
            stlParticleSystem.Stop();
            strParticleSystem.Stop();
        }
         
    }
    void ApplyRotation(int direction)
    {
        rb.freezeRotation = true;

        transform.Rotate(Vector3.forward * rotationThrust * Time.deltaTime *direction);
        rb.freezeRotation = false;

    }
}
