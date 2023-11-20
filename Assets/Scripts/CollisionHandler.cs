using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This is friendly");
                break;
            
            case "Finish":
                Debug.Log("This is the end");
                break;
            
            case "Fuel":
                Debug.Log("this is fuel");
                break;
            default: 
                Debug.Log("You blew up");
                break;
        }
    }
}
