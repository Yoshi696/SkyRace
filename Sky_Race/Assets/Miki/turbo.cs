using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turbo : MonoBehaviour
{
    private Rigidbody rB;
    private Vector3 rbVelo;

    public float turboForce = 10.0f;
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
        if (other.gameObject.tag == "Turbo")
        {
            Vector3 vel = rB.velocity;
            rB.AddForce(vel.x * turboForce, 0, vel.z * turboForce, ForceMode.Impulse);
        }
    }
}
