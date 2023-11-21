using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem leftThrusterParticles;
    [SerializeField] ParticleSystem rightThrusterParticles;
    [SerializeField] ParticleSystem mainThrusterParticles;


    
    Rigidbody rb;
    AudioSource myAudioSource;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();

    }

    void ProcessThrust(){
        if(Input.GetKey(KeyCode.Space)){
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
            if(!myAudioSource.isPlaying)
            {
                myAudioSource.PlayOneShot(mainEngine);
            }
            if(!mainThrusterParticles.isPlaying){
                mainThrusterParticles.Play();
            }
            
        }else{
            myAudioSource.Stop();
            mainThrusterParticles.Stop();
        }
    }

    void ProcessRotation(){
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
            if(!rightThrusterParticles.isPlaying){
                rightThrusterParticles.Play();
            }
            
        }
        else if(Input.GetKey(KeyCode.D)){
            ApplyRotation(-rotationThrust);
            if(!leftThrusterParticles.isPlaying){
                leftThrusterParticles.Play();
            }
        }
        else{
            rightThrusterParticles.Stop();
            leftThrusterParticles.Stop();
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false; //unfreezing rotation
    }
}
