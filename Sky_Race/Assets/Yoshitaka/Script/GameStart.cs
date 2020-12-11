using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    //private float befor_button;
    
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
        float action = Input.GetAxisRaw("Action");
        if (/*Input.GetButton("Action")*/action == 1 /*&& befor_button == 0.00f*/)
        {
            audio.PlayOneShot(sound1);
            // SceneManager.sceneLoaded += GameSceneLoaded;
              SceneManager.LoadSceneAsync("MakeDebug");
            GetComponent<GameStart>().enabled = false;
            GetComponent<SelectStageg>().enabled = false;
            //var SkyPoint = GameObject.FindWithTag("ChangeSky").GetComponent<ChangeSky>();
            //SkyPoint.skyselect = no;
            //SceneManager.sceneLoaded
        }
        //befor_button = action;
    }
}
