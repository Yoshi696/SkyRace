using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptKey : MonoBehaviour
{
    private StartRun StartRun;
    Vector3 Agility1;
    Vector3 Agility2;

    // Start is called before the first frame update
    void Start()
    {
        StartRun = GetComponent<StartRun>();
        Agility1 = StartRun.GetJumpValue();
        Agility2 = StartRun.GetJumpValue();
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
