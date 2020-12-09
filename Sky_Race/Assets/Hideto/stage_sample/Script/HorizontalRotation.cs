using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalRotation : MonoBehaviour
{
    private float i = 10;
    private float j = 0;
    private Vector3 a;

    //   [SerializeField] private Vector3 localGravity;
    private Rigidbody rBody;
    private void Start()
    {
        a = gameObject.transform.localEulerAngles;
        rBody = this.GetComponent<Rigidbody>();
        rBody.useGravity = true; //最初にrigidBodyの重力を付ける
    }
    private void Update()
    {
        transform.rotation = Quaternion.Euler(j, a.y, i);
        StartCoroutine("Roto2");
    }


    //private void OnTriggerExit(Collider other)
    //{//トリガーから出たとき
    //    if (other.gameObject.tag == "MoveOn")
    //    {

    //    }
    //}
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
        i = 0;
    }
}
