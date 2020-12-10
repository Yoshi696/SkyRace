using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCameraPos : MonoBehaviour
{


    GameObject playerObj;
    private Vector3 a;
    private void FixedUpdate()
    {
        playerObj = GameObject.Find("Player");
        a = playerObj.transform.position;
    }
    private void Update()
    {
        transform.position = new Vector3(a.x, a.y, a.z);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }


}
