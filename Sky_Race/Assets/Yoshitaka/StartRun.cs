using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRun : MonoBehaviour
{
    private Rigidbody rb;

    public float run = 0f;
    public float plus = 0.0001f;
    public float jumpForce = 40f;
    private bool Button = false;
    private bool JumpK = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 _this = this.gameObject.transform.position;

        if (other.gameObject.tag == "JosouJ" /*&& Input.GetKeyUp(KeyCode.Z)*/)
        {
            //this.gameObject.transform.position = new Vector3(_this.x, _this.y+jumpForce, _this.z);
            //rb.AddForce(force, ForceMode.Force);    //ジャンプ
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);

            JumpK = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(JumpK);

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

        //if (JumpK == true && Input.GetKeyUp(KeyCode.Z))
        //{
        //    rb.AddForce(pos.x, pos.y+jumpForce, pos.z,ForceMode.Impulse);
        //    //rb.AddForce(force, ForceMode.Force);    //ジャンプ
        //}
    }
}
