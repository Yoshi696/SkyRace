using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSky : MonoBehaviour
{
    // Skyboxのマテリアル
    public Material sky0;
    public Material sky1;

    //変数取得
    //public SelectStageg sky;
    private int skyselect;

    // Start is called before the first frame update
    void Start()
    {
       // skyselect = sky.GetChangeSky();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            skyselect = 1;
        }
        if (Input.GetKey(KeyCode.V))
        {
            skyselect = 0;
        }

        if (skyselect == 0)
        {
            // Skyboxを変更する
            RenderSettings.skybox = sky0;
        }

        if (skyselect == 1)
        {
            // Skyboxを変更する
            RenderSettings.skybox = sky1;
        }
    }
}
