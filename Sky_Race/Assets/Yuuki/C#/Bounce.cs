using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounce = 10.0f;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 norm = other.contacts[0].normal;
            Vector3 vel = other.rigidbody.velocity.normalized;
            vel += new Vector3(-norm.x * 2, 0f, -norm.z * 2);
            other.rigidbody.AddForce(vel * bounce, ForceMode.Impulse);
        }
    }
}
