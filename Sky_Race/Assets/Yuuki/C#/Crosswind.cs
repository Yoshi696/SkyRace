using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosswind : MonoBehaviour
{
    public float ClossMove = 0.25f;
    private float clossmove=0.1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 myobj = this.transform.position;
            Vector3 targ = GameObject.Find("Player").transform.position;
            if (myobj.x > targ.x)
            {
                clossmove = -ClossMove;
            }
            else if (myobj.x <= targ.x)
            {
                clossmove = ClossMove;
            }
        }
    }
    void OnTriggerStay()
    {
        Vector3 myobj = this.transform.position;
        Vector3 targ = GameObject.Find("Player").transform.position;
        
        GameObject.Find("Player").transform.position = new Vector3(targ.x + clossmove, targ.y, targ.z);
    }
}