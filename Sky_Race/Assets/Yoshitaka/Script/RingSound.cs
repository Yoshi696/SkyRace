using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSound : MonoBehaviour
{

    AudioSource audio;
    public AudioClip sound2;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            audio.PlayOneShot(sound2);
        }
    }
}
