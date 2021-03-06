﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    //プレイヤーを変数に格納
    public GameObject Player;

    //回転させるスピード
    private float rotateSpeed = 0.5f;
    public Vector3 yes;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //回転させる角度
        float angle = 1 * rotateSpeed;

        //プレイヤー位置情報
        //Vector3 playerPos = Player.transform.position;

        //カメラを回転させる
        transform.RotateAround(Player.transform.position, Vector3.up, angle);
    }
}
