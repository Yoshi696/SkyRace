using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalEffect : MonoBehaviour
{
    //花火のエフェクト（赤の場合）
    private ParticleSystem _Hanabi1;
    //private ParticleSystem Hanabi2;
    //private ParticleSystem Hanabi3;

    // Start is called before the first frame update
    void Start()
    {
        _Hanabi1 = GameObject.Find("Hanabi1").GetComponent<ParticleSystem>();
        //Hanabi2 = GameObject.Find("Hanabi2").GetComponent<ParticleSystem>();
        //Hanabi3 = GameObject.Find("Hanabi3").GetComponent<ParticleSystem>();
        _Hanabi1.Stop();
        //_Hanabi1.Play();
        //Hanabi2.Stop();
        //Hanabi3.Stop();
    }

    private void Update()
    {
       // _Hanabi1.Play();
        //Hanabi2.Play();
        //Hanabi3.Play();
    }

    private void OnTriggerEnter(Collider other)    //ゴールに接触した瞬間に入る
    {
        if (other.gameObject.tag == "High_P")
        {
            _Hanabi1.Play();
            //Hanabi2.Play();
            //Hanabi3.Play();

        }
        else if (other.gameObject.tag == "Medium_P")
        {
            _Hanabi1.Play();
            //Hanabi2.Play();
            //Hanabi3.Play();

        }
        else if (other.gameObject.tag == "Low_P")
        {
            _Hanabi1.Play();
            //Hanabi2.Play();
            //Hanabi3.Play();

        }
    }
}
