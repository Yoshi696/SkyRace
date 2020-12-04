using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectStageg : MonoBehaviour
{
    // Skyboxのマテリアル
    public Material sky0;
    public Material sky1;
    public Material sky2;
    public Material sky3;
    public Material sky4;


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
        Debug.Log(sayu);
        if (clickone == true && no != 5)
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
        if(no >= 5)
        {
            no = 4;
        }
        if (no <= 0)
        {
            no = 0;
        }

        if (no == 4)
        {
            RenderSettings.skybox = sky4;
            text.text = "砂漠";
        }
        if (no == 3)
        {
            RenderSettings.skybox = sky3;
            text.text = "光";
        }
        if (no == 2)
        {
            RenderSettings.skybox = sky2;
            text.text = "夜";
        }
        if (no == 1)
        {
            RenderSettings.skybox = sky1;
            text.text = "昼";
        }
        if (no == 0)
        {
            RenderSettings.skybox = sky0;
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

    public int GetSky()
    {
        return no;
    }

    //private void GameSceneLoaded(Scene next,LoadSceneMode mode)
    //{
    //    var SkyPoint = GameObject.FindWithTag("ChangeSky").GetComponent<ChangeSky>();
    //    SkyPoint.skyselect = no;

    //    SceneManager.sceneLoaded -= GameSceneLoaded;
    //    //return no;
    //}
}

