using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{

    public AudioClip sound1;

    AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Action") == true)
        {
            audio.PlayOneShot(sound1);
            // SceneManager.sceneLoaded += GameSceneLoaded;
              SceneManager.LoadSceneAsync("MakeDebug");
            //var SkyPoint = GameObject.FindWithTag("ChangeSky").GetComponent<ChangeSky>();
            //SkyPoint.skyselect = no;
            //SceneManager.sceneLoaded
        }
    }
}
