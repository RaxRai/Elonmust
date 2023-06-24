using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;

    void Start()
    {
        // Play audio source 1
        audioSource1.Pause();

        // Pause audio source 2
        audioSource2.Pause();
    }

    // void Update()
    // {
    //     // Stop audio source 1 if a certain condition is met
    //     if (condition)
    //     {
    //         audioSource1.Stop();
    //     }
    // }
    public void Play1()
    {
        audioSource1.Play();
    }
    public void Play2()
    {
        audioSource2.Play();
    }
}
