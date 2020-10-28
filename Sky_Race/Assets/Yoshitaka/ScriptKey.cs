using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptKey : MonoBehaviour
{
    public PlayerMove playermove;
    float Agility;

    // Start is called before the first frame update
    void Start()
    {
        playermove = GetComponent<PlayerMove>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            GetComponent<StartRun>().enabled = false;
            GetComponent<PlayerMove>().enabled = true;
        }
    }
}
