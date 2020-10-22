using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContllore : MonoBehaviour
{
    public float speed = 2.0f;
    private Rigidbody rB;

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
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Buns")
        {
            StartCoroutine("WaitKeyInput");
        }
    }
    IEnumerator WaitKeyInput()
    {
        this.gameObject.GetComponent<PlayerContllore>().enabled = false;
        {
            yield return new WaitForSeconds(1.0f);
        }
        this.gameObject.GetComponent<PlayerContllore>().enabled = true;
    }
}
