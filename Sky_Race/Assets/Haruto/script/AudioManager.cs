using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip sound01;
    public AudioClip sound02;
    public AudioClip sound03;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Jump")
        {
            audioSource.PlayOneShot(sound01);
        }
        if(other.gameObject.tag == "Take of")
        {
            audioSource.PlayOneShot(sound02);
        }
        if(other.gameObject.tag == "Turbo")
        {
            audioSource.PlayOneShot(sound03);
        }
    }
}
