using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody body;

    [SerializeField] float thrust = 1000f;
    [SerializeField] float rotationThrust = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
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
            // Debug.Log("boost");
            body.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
        }
        return;
    }
    void ProcessRotation()
    {

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("left");
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("right");
            ApplyRotation(-rotationThrust);

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
