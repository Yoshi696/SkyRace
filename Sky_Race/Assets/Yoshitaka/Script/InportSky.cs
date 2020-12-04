using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InportSky : MonoBehaviour
{
    public SelectStageg sky;
    private int skyselect;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(skyselect);
        skyselect = sky.GetSky();
    }

    public int GetSkyInport()
    {
        return skyselect;
    }
}
