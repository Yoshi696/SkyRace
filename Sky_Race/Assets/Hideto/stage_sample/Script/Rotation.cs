using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private float i = 10;
    private float j = 0;

    [SerializeField] private Vector3 localGravity;
    private Rigidbody rBody;
    private void Start()
    {

        rBody = this.GetComponent<Rigidbody>();
        rBody.useGravity = true; //最初にrigidBodyの重力を付ける
    }

    private void FixedUpdate()
    {

    }
    IEnumerator Roto1()
    {
        if (i <= -10)
        {
            //           yield return new WaitForSeconds(0.3f);
            for (i = -9; i < 10; i++)
            {
                yield return new WaitForSeconds(0.00001f);
                //             i = 10;
            }
        }
        else if (i >= 10)
        {
            //           yield return new WaitForSeconds(0.3f);
            for (i = 9; i > -10; i--)
            {
                yield return new WaitForSeconds(0.00001f);
                //              i = -10;
            }
        }

        //if (j >= 10)
        //{
        //    //               yield return new WaitForSeconds(0.3f);
        //    for (j = 9; j > 0; j--)
        //    {
        //        yield return new WaitForSeconds(0.00001f);
        //    }
        //}
        //else
        if (j <= 0)
        {
            for (j = 1; j < 15; j++)
            {
                yield return new WaitForSeconds(0.00001f);
            }
        }


    }
    private void Update()
    {
        StartCoroutine("Roto1");
        transform.rotation = Quaternion.Euler(j, 0, i);
    }


    private void OnTriggerExit(Collider other)
    {//トリガーから出たとき
        if (other.gameObject.tag == "MoveOn")
        {
            StartCoroutine("Roto2");

        }
    }
    IEnumerator Roto2()
    {
        if (j <= 15)
        {
            //               yield return new WaitForSeconds(0.3f);
            for (j = 14; j > 0; j--)
            {
                yield return new WaitForSeconds(0.00001f);
            }
        }


 //       yield return new WaitForSeconds(0.000000001f);

        rBody.useGravity = false; //最初にrigidBodyの重力を付ける
        GetComponent<PlayerMove>().enabled = true;
        GetComponent<Gravity>().enabled = true;
        //GetComponent<PM_test>().enabled = true;
        //GetComponent<sampleRotation>().enabled = false;
        GetComponent<Rotation>().enabled = false;
    }
}
