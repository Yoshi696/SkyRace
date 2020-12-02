using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anime : MonoBehaviour
{
    private Animator anirunkey;
    public Animator aniStay;
    private Animator anijumpkey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        aniStay.SetBool("IdleSet", true);
        //aniStay.SetBool("IdleSet", false);
        //anirunkey.SetBool("RunSet", true);
    }
}
