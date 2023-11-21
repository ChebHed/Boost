using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;

    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem successParticles;
    AudioSource myAudioSource;

    bool isTransitionning = false;

    void Start(){
        myAudioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other) 
    {
        if(isTransitionning){
            return;
        }
        switch (other.gameObject.tag)
        {
            case "Fiendly":
                Debug.Log("This is friendly");
                break;
            
            case "Finish":
                StartSuccessSequence();               
                break;
            default: 
                StartCrashingSequence();
                break;
        }
        }

        void StartCrashingSequence(){
            crashParticles.Play();
            isTransitionning = true;
            myAudioSource.Stop();
            crashParticles.Play();
            myAudioSource.PlayOneShot(crash);
            GetComponent<Movement>().enabled = false;
            Invoke("ReloadLevel", levelLoadDelay);                
        }

        void StartSuccessSequence(){
            isTransitionning = true;
            myAudioSource.Stop();
            successParticles.Play();
            myAudioSource.PlayOneShot(success);
            GetComponent<Movement>().enabled = false;
            Invoke("NextLevel", levelLoadDelay);                
        }

        void ReloadLevel(){
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex);
        }

        void NextLevel(){
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                int nextSceneIndex = currentSceneIndex + 1;
                if(nextSceneIndex == SceneManager.sceneCountInBuildSettings){
                    nextSceneIndex = 0;
                }
                SceneManager.LoadScene(nextSceneIndex);
                
        }
    
}
