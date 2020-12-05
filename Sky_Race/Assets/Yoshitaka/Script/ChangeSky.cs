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
    public Material sky3;
    public Material sky4;

    //変数取得
    InportSky Stage;
    //public int skyselect;
    private int skyselect;

    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    public AudioClip sound5;

    AudioSource audios;

    private bool cont;

    // Start is called before the first frame update
    void Start()
    {
        GameObject debug = GameObject.Find("SceneInport");
        Stage = debug.GetComponent<InportSky>();
        skyselect = Stage.GetSkyInport();
        audios = GetComponent<AudioSource>();
        cont = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(skyselect);
        //audios.loop = sound1;

        if (Input.GetKey(KeyCode.C))
        {

        }
        if (Input.GetKey(KeyCode.V))
        {
            skyselect = 0;
        }

        if (skyselect == 0)
        {
            if (cont == true)
            {
                audios.clip = sound1;
                audios.Play();
                cont = false;
            }
            // Skyboxを変更する
            RenderSettings.skybox = sky0;
        }
        if (skyselect == 1)
        {
            if (cont == true)
            {
                audios.clip = sound2;
                audios.Play();
                cont = false;
            }
            // Skyboxを変更する
            RenderSettings.skybox = sky1;
        }
        if (skyselect == 2)
        {
            if (cont == true)
            {
                audios.clip = sound3;
                audios.Play();
                cont = false;
            }
            // Skyboxを変更する
            RenderSettings.skybox = sky2;
        }
        if (skyselect == 3)
        {
            if (cont == true)
            {
                audios.clip = sound4;
                audios.Play();
                cont = false;
            }
            // Skyboxを変更する
            RenderSettings.skybox = sky3;
        }
        if (skyselect == 4)
        {
            if (cont == true)
            {
                audios.clip = sound5;
                audios.Play();
                cont = false;
            }
            // Skyboxを変更する
            RenderSettings.skybox = sky4;
        }
    }
}
