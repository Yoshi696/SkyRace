using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour { 

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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Jump")
        {
            rB.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }
}
