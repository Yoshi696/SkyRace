using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //public Rigidbody rb;
    public float speed = 15f;
    public float zen = 0.05f;
    //private Vector3 playerpos;

    //private void Start()
    //{
    ////    playerpos = transform.position;
    //rb = GetComponent<Rigidbody>();

    //}

    private void Update()
    {
        //キーボード
        float velox = speed * Input.GetAxisRaw("Horizontal");
        float nox = speed * Input.GetAxisRaw("Vertical");
        float gen = Input.GetAxisRaw("Vertical");

        Vector3 pos = this.gameObject.transform.position;
        this.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z + zen);
       // float den = pos.y;


        //if (pos.y < den)
        //{
        //rb.AddForce(velox, nox, 0f);
        if (gen < 0) {
            GetComponent<Rigidbody>().velocity = new Vector3(velox, nox, 0f);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(velox, 0f, 0f);
        }
    }

    private void FixedUpdate()
    {
        //下にだけ反応するようにする


        //コントローラ
        //var luck = speed * Input.GetAxisRaw("Controler1RL");
        //GetComponent<Rigidbody>().velocity = new Vector3(luck, 0f, 0f);

        //Vector3 tmp = GameObject.Find("Player").transform.position;
        //float y = tmp.y;


        //if (/*Input.GetKey("down")*/ /*||*/ Input.GetButton("Vertical"))
        //{

        //velox = speed * Input.GetAxisRaw("Vertical");
        //GetComponent<Rigidbody>().velocity = new Vector3(0f, velox, 0f);
        //velox = speed * Input.GetAxisRaw("Controler1D");
        //GetComponent<Rigidbody>().velocity = new Vector3(0f, velox, 0f);
        //GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        //}
    }
}
