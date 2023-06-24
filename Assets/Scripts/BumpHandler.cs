using UnityEngine;
using UnityEngine.SceneManagement;


public class BumpHandler : MonoBehaviour
{
    public Movement movementScript;
    public Rigidbody rocketRB;
    [SerializeField] AudioClip explosionClip;
    [SerializeField] AudioClip successClip;

    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] ParticleSystem successParticles;

    ParticleSystem particleSource;
    AudioSource aSource;

    bool isTransitioning = false;



    [SerializeField] float loadDelay = 0.5f;
    void Start()
    {
        movementScript = GetComponent<Movement>();
        aSource = GetComponent<AudioSource>();
        // particleSource = GameObject
    }
    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning) return;

        switch (other.gameObject.tag)
        {
            case "Finish":
                movementScript.StopMovement();
                movementScript.enabled = false;
                aSource.Stop();
                aSource.PlayOneShot(successClip);
                isTransitioning = true;
                successParticles.Play();
                Invoke("LoadNextScene", loadDelay);
                break;
            case "Friendly":
                break;
            case "Fuel":
                break;
            default:
                movementScript.StopMovement();
                movementScript.enabled = false;
                aSource.Stop();
                aSource.PlayOneShot(explosionClip);
                isTransitioning = true;
                explosionParticles.Play();
                Invoke("ReloadScene", loadDelay);
                break;
        }
    }

    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        isTransitioning = false;
    }
    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = ++currentSceneIndex;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
        isTransitioning = false;
    }

}
