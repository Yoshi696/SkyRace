using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosswind : MonoBehaviour
{
    //public GameObject target;
    public float ClossMove = 0.25f;
    float clossmove=0.1f;

   //public GameObject myObj;

    void OnTriggerStay()
    {
        Vector3 myobj = this.transform.position;
        //Transform myobj = this.transform;
        Vector3 targ = GameObject.Find("Player").transform.position;
        if (myobj.x > targ.x) {
            clossmove = -ClossMove;
        }else if (myobj.x < targ.x)
        {
            clossmove = ClossMove;
        }
        GameObject.Find("Player").transform.position = new Vector3(targ.x + clossmove, targ.y, targ.z);
    }
}