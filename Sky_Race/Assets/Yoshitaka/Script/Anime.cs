using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anime : MonoBehaviour
{
    private Animator anirunkey;
    public Animator aniStay;
    private Animator anijumpkey;

    private float SpeedC;

    public StartRun startrun;

    // Start is called before the first frame update
    void Start()
    {
        aniStay = GetComponent<Animator>();

        SpeedC = startrun.GetSpeedValue();
    }

    // Update is called once per frame
    void Update()
    {
        aniStay.SetBool("RunSet",true);
        //aniStay.SetBool("IdleSet", false);
        //anirunkey.SetBool("RunSet", true);
    }
}
