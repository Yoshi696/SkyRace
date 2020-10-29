using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class StartRun : MonoBehaviour
{
    private Rigidbody rb;

    private float run = 0;
    public float plus = 0.0001f;
    public float jumpForce = 40f;
    private bool Button = false;
    private bool JumoB = false;
    Vector3 jump1;
    Vector3 jump2;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

    }

    private void OnTriggerStay(Collider other)
    {
        Vector3 _this = this.gameObject.transform.position;
        if (Input.GetKeyUp(KeyCode.Z))
        {
            if (other.gameObject.tag == "JosouJ")
            {
                //this.gameObject.transform.position = new Vector3(_this.x, _this.y+jumpForce, _this.z);
                //rb.AddForce(force, ForceMode.Force);    //ジャンプ
                rb.velocity = Vector3.up * jumpForce;
                //jump1 = rb.velocity;
                //jump2 = rb.velocity;
                JumoB = true;
            }
        }
    }

    public Vector3 GetJumpValue()
    {
        return rb.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.gameObject.transform.position;//
        Vector3 force = new Vector3(0.0f, 0.0f, jumpForce);
        this.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z + run);//助走（前進）

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Button = true;
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            Button = false;
        }
        if(Button == true)
        {
            run = run + plus;
        }
        
        //if(JumoB == true)
        //{
        //    jump1 = this.gameObject.transform.position;
        //}

        //if (jump1.y < jump2.y)
        //{
        //    GetComponent<StartRun>().enabled = false;
        //    GetComponent<PlayerMove>().enabled = true;
        //}

        //if(JumoB == true)
        //{
        //    jump2 = this.gameObject.transform.position;
        //}
    }
}
