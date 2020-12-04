using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Action") == true)
        {
            // SceneManager.sceneLoaded += GameSceneLoaded;
            SceneManager.LoadSceneAsync("MakeDebug");
            //var SkyPoint = GameObject.FindWithTag("ChangeSky").GetComponent<ChangeSky>();
            //SkyPoint.skyselect = no;
            //SceneManager.sceneLoaded
        }
    }
}
