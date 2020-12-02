using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioSource audioSource2;

    public AudioClip sound01;
    public AudioClip sound02;
    public AudioClip sound03;
    public AudioClip sound04;
    public AudioClip sound05;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();
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
        if(other.gameObject.tag == "Take of")
        {
            audioSource2.PlayOneShot(sound04);
        }
        if(other.gameObject.tag == "Goal")
        {
            audioSource2.Stop();
        }
        if(other.gameObject.tag == "Goal"){
            audioSource.PlayOneShot(sound05);
        }
    }
}
