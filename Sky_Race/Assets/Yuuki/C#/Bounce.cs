﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounce = 10.0f;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 norm = other.contacts[0].normal;
            Vector3 vel = other.rigidbody.velocity.normalized;
            vel += new Vector3(-norm.x * 2, 0f, -norm.z * 2);
            other.rigidbody.AddForce(vel * bounce, ForceMode.Impulse);
        }
    }
    //プレイヤーのそばにUターンポイントを置き、遊びのデザイン講座にも出てた「プレイヤーの周りを回るオブジェクト」を参考にする
    //範囲に入ると、設置しているポイントの周りをグルグル回り続ければ次の段階に行く
    //次は、竜巻の範囲に入ったら180度Uターンさせ、Uターンしたら、フラグなりスクリプトなりをOffにする事で実現可能になる可能性がある
}
