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

   // public StartRun startrun;

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

        //↓前進
        Vector3 pos = this.gameObject.transform.localPosition;
        this.transform.localPosition = new Vector3(pos.x, pos.y, pos.z+zen);

        //↓前進
        //Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
        //Vector3 go = rb.position;
        //go += new Vector3(0, 0, 0.05f);
        //rb.position = go;

        //↓左右キーで回転
        if (rot == 1)
        {
            transform.Rotate(0, -50 * -ang, 0);
            this.transform.localPosition = new Vector3(pos.x+zen, pos.y, pos.z+zen);
        }
        else if (rot < 0)
        {
            transform.Rotate(0, -50 * -ang, 0);

        }

        //↓下キー入力で落下
        if (gen < 0)
        {
           GetComponent<Rigidbody>().velocity = new Vector3(0, nox, 0f + zen);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0f, 0f + zen);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Buns")
        {
            transform.Rotate(new Vector3(0, 180, 0));
            StartCoroutine("WaitKeyInput");
        }
    }
    IEnumerator WaitKeyInput()
    {
        this.gameObject.GetComponent<PlayerMove>().enabled = false;
        {
            yield return new WaitForSeconds(1.0f);
        }
        this.gameObject.GetComponent<PlayerMove>().enabled = true;
    }

    private void FixedUpdate()
    {

    }
}
