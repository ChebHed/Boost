using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
    }

    void ProcessThrust(){
        if(Input.GetKey(KeyCode.Space)){
            Debug.Log("Space pressed");
        }
        if(Input.GetKey(KeyCode.Q)){
            Debug.Log("Rotating Left");
        }
        else if(Input.GetKey(KeyCode.A)){
            Debug.Log("Rotating Right");
        }
    }
}
