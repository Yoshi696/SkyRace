using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 15f;
    public float yoko = 0.5f;
    public float zen = 0.05f;
    //private Vector3 playerpos;

    private void Start()
    {
        //    playerpos = transform.position;
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        //キーボード
        float velox = speed * Input.GetAxisRaw("Horizontal");
        float nox = speed * Input.GetAxisRaw("Vertical");

        float ang = 0.005f * Input.GetAxisRaw("Horizontal");

        float gen = Input.GetAxisRaw("Vertical");
        float rot = Input.GetAxisRaw("Horizontal");

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        float jin = 0f;

        Vector3 pos = this.gameObject.transform.position;
        this.gameObject.transform.position = new Vector3(pos.x,pos.y, pos.z + zen);

        rb.AddForce(x * speed, 0, jin+zen, ForceMode.Impulse);

        if(rot == 1)
        {
            //transform.Rotate(-50 * Time.deltaTime, 0, 0);
            transform.Rotate(0, -50 * -ang, 0);
            //Vector3 yes = this.gameObject.transform.position;
            //this.gameObject.transform.position = new Vector3(ang*yoko, yes.y/*pos.x, pos.y*/, yes.z + zen);
        }
        else if (rot < 0)
        {
            transform.Rotate(0, -50 * -ang, 0);

        }


        //GetComponent<Rigidbody>().velocity = new Vector3(pos.x, pos.y, pos.z + zen);

        if (gen < 0)
        {
           GetComponent<Rigidbody>().velocity = new Vector3(velox, nox, 0f + zen);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(velox, 0f, 0f + zen);
        }
    }

    //private void FixedUpdate()
    //{
    //    //下にだけ反応するようにする


    //    //コントローラ
    //    //var luck = speed * Input.GetAxisRaw("Controler1RL");
    //    //GetComponent<Rigidbody>().velocity = new Vector3(luck, 0f, 0f);

    //    //Vector3 tmp = GameObject.Find("Player").transform.position;
    //    //float y = tmp.y;


    //    //if (/*Input.GetKey("down")*/ /*||*/ Input.GetButton("Vertical"))
    //    //{

    //    //velox = speed * Input.GetAxisRaw("Vertical");
    //    //GetComponent<Rigidbody>().velocity = new Vector3(0f, velox, 0f);
    //    //velox = speed * Input.GetAxisRaw("Controler1D");
    //    //GetComponent<Rigidbody>().velocity = new Vector3(0f, velox, 0f);
    //    //GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
    //    //}
    //}
}
