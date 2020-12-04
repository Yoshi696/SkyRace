using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeSky : MonoBehaviour
{
    // Skyboxのマテリアル
    public Material sky0;
    public Material sky1;
    public Material sky2;

    //変数取得
    private SelectStageg sky;
    SelectStageg Stage;
    //public int skyselect;
    private int skyselect;

    public AudioClip sound1;
    AudioSource audios;

    // Start is called before the first frame update
    void Start()
    {
        GameObject debug = GameObject.Find("SceneInport");
        Stage = debug.GetComponent<SelectStageg>();
        skyselect = Stage.GetSky();
        audios = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(skyselect);
        //audios.loop = sound1;

        if (Input.GetKey(KeyCode.C))
        {
            audios.clip = sound1;
            audios.Play();
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
        if (skyselect == 2)
        {
            // Skyboxを変更する
            RenderSettings.skybox = sky2;
        }
    }
}
