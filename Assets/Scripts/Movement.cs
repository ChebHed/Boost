using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    Rigidbody rb;
    // Start is called before the first frame update
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;

    void Start()
    {
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
        }
    }

    void ProcessRotation(){
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if(Input.GetKey(KeyCode.D)){
            ApplyRotation(-rotationThrust);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
    }
}
