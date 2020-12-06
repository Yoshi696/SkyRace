using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalEffect : MonoBehaviour
{

    //花火のエフェクト（赤の場合）
    private ParticleSystem Hanabi1;
    private ParticleSystem Hanabi2;
    private ParticleSystem Hanabi3;

    //花火のエフェクト（黄色の場合）
    private ParticleSystem Hana1;
    private ParticleSystem Hana2;
    private ParticleSystem Hana3;

    //一回だけ出す
    private bool oneshot;

    //花火のエフェクト（白の場合）
    //private ParticleSystem Ha1;
    //private ParticleSystem Ha2;
    //private ParticleSystem Ha3;

    // Start is called before the first frame update
    void Start()
    {

        //赤半径の花火取得
        Hanabi1 = GameObject.Find("Hanabi1").GetComponent<ParticleSystem>();
        Hanabi2 = GameObject.Find("Hanabi2").GetComponent<ParticleSystem>();
        Hanabi3 = GameObject.Find("Hanabi3").GetComponent<ParticleSystem>();

        //黄色半径の花火取得
        Hana1 = GameObject.Find("Hana1").GetComponent<ParticleSystem>();
        Hana2 = GameObject.Find("Hana2").GetComponent<ParticleSystem>();
        Hana3 = GameObject.Find("Hana3").GetComponent<ParticleSystem>();

        //白半径の花火取得
        //Ha1 = GameObject.Find("Ha1").GetComponent<ParticleSystem>();
        //Ha2 = GameObject.Find("Ha2").GetComponent<ParticleSystem>();
        //Ha3 = GameObject.Find("Ha3").GetComponent<ParticleSystem>();

        //一度花火を止める
        //Hanabi1.Stop();
        //Hanabi2.Stop();
        //Hanabi3.Stop();

        //Hana1.Stop();
        //Hana2.Stop();
        //Hana3.Stop();

        //Ha1.Stop();
        //Ha2.Stop();
        //Ha3.Stop();
        oneshot = true;
    }

    private void Update()
    {
        // _Hanabi1.Play();
        //Hanabi2.Play();
        //Hanabi3.Play();
    }

    private void OnTriggerStay(Collider other)    //ゴールに接触した瞬間に入る
    {
        if (other.gameObject.tag == "High_P")
        {
            // Debug.Log("yes");
            if (oneshot == true)
            {
                Hana1.Stop();
                Hana2.Stop();
                Hana3.Stop();

                //Ha1.Stop();
                //Ha2.Stop();
                //Ha3.Stop();

                // Debug.Log("花火");
                Hanabi1.Play();
                Hanabi2.Play();
                Hanabi3.Play();

                oneshot = false;
            }

        }
        else if (other.gameObject.tag == "Medium_P")
        {

            //Ha1.Stop();
            //Ha2.Stop();
            //Ha3.Stop();
            if (oneshot == true)
            {
                Hana1.Play();
                Hana2.Play();
                Hana3.Play();
                oneshot = false;
            }

        }
        //else if (other.gameObject.tag == "Low_P")
        //{
        //    Ha1.Play();
        //    Ha2.Play();
        //    Ha3.Play();

        //}
    }
}
