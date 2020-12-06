using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioSource audioSource2;
    private AudioSource audioSource3;

    public AudioClip sound01;
    public AudioClip sound02;
    public AudioClip sound03;
    public AudioClip sound04;
    public AudioClip sound05;
    public AudioClip sound06;
    public AudioClip sound07;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource3 = gameObject.AddComponent<AudioSource>();
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
            audioSource3.Stop();
        }
        if(other.gameObject.tag == "Goal")
        {
            audioSource2.Stop();
        }
        if (other.gameObject.tag == "High_P")
        {
            audioSource.PlayOneShot(sound05);
        }
        if (other.gameObject.tag == "Medium_P")
        {
            audioSource.PlayOneShot(sound05);
        }
        if (other.gameObject.tag == "wind")
        {
            audioSource.PlayOneShot(sound06);
        }
        if(other.gameObject.tag == "Dash")
        {
            audioSource3.PlayOneShot(sound07);
        }
    }
}
