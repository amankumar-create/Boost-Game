using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] AudioClip death, success;
    [SerializeField] ParticleSystem successParticles, crashParticles;
    AudioSource audioSource;
    bool collisionDisabled = false;
    bool isActive;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isActive = true;
    }
    private void Update()
    {
        RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;
        }
    }
     
    private void OnCollisionEnter(Collision collision)
    {
        if (!isActive || collisionDisabled) return;
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Bumped into friendly");
                break;
            case "Finish":
                StartSuccessSequence();
                break;  
            case "Fuel":
                Debug.Log("Bumped into Fuel");
                break;
            default:
                StartCrashSequence();
                break;

        }
    }
    void StartSuccessSequence()
    {

        if (isActive)
        {
            audioSource.PlayOneShot(success);
            successParticles.Play();

        }
        isActive = false;
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", 1f);
    }

    void StartCrashSequence()
    {

        if (isActive)
        {
            audioSource.PlayOneShot(death);
            crashParticles.Play();
        }
        isActive = false;
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", 2f);
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene((currentSceneIndex+1)%SceneManager.sceneCountInBuildSettings);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Debug.Log("Bumped into Obstacle");
    }
}
