using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectStageg : MonoBehaviour
{
    private float befor_button;
    public Text text;

    bool clickone = false;
    bool clicktwo = false;

    private int no = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float sayu = Input.GetAxisRaw("Horizontal");

        if (clickone == true && no != 3)
        {
            no++;
            clickone = false;
            clicktwo = false;
        }
        if (clicktwo == true && no != 0)
        {
            no--;
            clickone = false;
            clicktwo = false;
        }

        if (no == 2)
        {
            text.text = "夜";
        }
        if (no == 1)
        {
            text.text = "昼";
        }
        if (no == 0)
        {
            text.text = "朝";
        }

        //if (clickone == true)
        //{
        //    clickone = false;
        //}
        //if (clicktwo == true)
        //{
        //    clicktwo = false;
        //}

        if(sayu == 1 && befor_button == 0.0f) 
        {
            clickone = true;
        }
        if (sayu == -1 && befor_button == 0.0f)
        {
            clicktwo = true;
        }

        befor_button = sayu;
    }

    public int GetChangeSky()
    {
        return no;
    }
}

