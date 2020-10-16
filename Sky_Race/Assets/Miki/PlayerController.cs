using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 12.0f;
    public float brake = 0.5f;
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
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        rB.AddForce(x * speed, 0, z * speed, ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Jump")
        {
            rB.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }
}
