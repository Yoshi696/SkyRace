using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRotation : MonoBehaviour
{
    //private float i = 0;
    private Vector3 a;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        GameObject playerObj = GameObject.Find("Player");
        a = playerObj.transform.position;
        //if (playerObj != null)
        //{

        //    transform.position = playerObj.transform.position;
        //}
    }

    //IEnumerator Roto1()
    //{
    //    for (i = 0; i < 100; i++)
    //    {
    //        yield return new WaitForSeconds(0.00001f);
    //    }
    //    if (i >= 100)
    //    {
    //        i = 0;
    //    }
    //}


    // Update is called once per frame
    private void Update()
    {
        //StartCoroutine("Roto1");
        transform.position = new Vector3(a.x,a.y+20,a.z);
        transform.rotation = Quaternion.Euler(90, 0, 0);

    }
}
