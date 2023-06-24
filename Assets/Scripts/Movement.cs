using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody body;
    AudioSource aSource;
    [SerializeField] AudioClip mainThrust;
    [SerializeField] ParticleSystem leftThrustParticles;
    [SerializeField] ParticleSystem rightThrustParticles;
    [SerializeField] ParticleSystem mainThrustParticles;

    [SerializeField] float thrust = 1000f;
    [SerializeField] float rotationThrust = 1000f;
    bool allowMoving = true;
    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (allowMoving)
        {
            ProcessThrust();
            ProcessRotation();
        }
        else
        {
            if (aSource.isPlaying || isDead)
            {
                aSource.Stop();
            }
        }

    }
    public void StopMovement()
    {
        allowMoving = false;
        isDead = true;
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // Debug.Log("boost");
            body.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
            if (!aSource.isPlaying && !isDead)
            {
                aSource.PlayOneShot(mainThrust);
            }
            if (!mainThrustParticles.isPlaying)
                mainThrustParticles.Play();
        }
        else
        {
            if (aSource.isPlaying)
                aSource.Stop();
            if (mainThrustParticles.isPlaying)
                mainThrustParticles.Stop();
        }
        return;
    }
    void ProcessRotation()
    {

        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
            if (!rightThrustParticles.isPlaying)
                rightThrustParticles.Play();

        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);

            if (!leftThrustParticles.isPlaying)
                leftThrustParticles.Play();

        }
        else
        {
            if (leftThrustParticles.isPlaying)
                leftThrustParticles.Stop();
            if (rightThrustParticles.isPlaying)
                rightThrustParticles.Stop();
        }

        return;
    }

    void ApplyRotation(float rotationThisFrame)
    {
        body.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        body.freezeRotation = false; // unfreeze after manual rotation

    }
}
