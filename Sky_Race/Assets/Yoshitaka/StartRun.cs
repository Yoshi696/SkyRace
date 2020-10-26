using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRun : MonoBehaviour
{
    public float run = 0f;
    public float plus = 0.0001f;
    public float jumpForce = 5f;
    private bool Button = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Vector3 _this = this.gameObject.transform.position;

        if (other.gameObject.tag=="jump" && Input.GetKeyUp(KeyCode.Z))
        {
            this.gameObject.transform.position = new Vector3(_this.x, _this.y+jumpForce, _this.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.gameObject.transform.position;
        this.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z + run);

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
    }
}
