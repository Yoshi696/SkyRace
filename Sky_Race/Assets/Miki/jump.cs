﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{

    private Rigidbody rB;
    private Vector3 rbVelo;

    public float jumpForce = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Jump")
        {
            rB.AddForce(0, jumpForce, 0, ForceMode.Force);
           // this.gameObject.GetComponent<PlayerMove>().enabled = false;
            //Debug.Log(jumpForce);
        }
    }
}
