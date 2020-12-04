using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private float befor_button;

    private AudioSource audioSource;

    public AudioClip sound01;
    public AudioClip sound02;
    public AudioClip sound03;

    Button start;
    Button help;
    Button end;

    private int i = 0;
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        //マウスポインタ消すやつ
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        //Screen.lockCursor = false;


        

        // ボタンコンポーネントの取得
        start = GameObject.Find("/Canvas/Start").GetComponent<Button>();
        help = GameObject.Find("/Canvas/Help").GetComponent<Button>();
        end = GameObject.Find("/Canvas/End").GetComponent<Button>();
        start.Select();
    }


    void Update()
    {
        float click = Input.GetAxisRaw("Vertical");

        //クリックされた時 かつ lockStateがLockedではない時だけ実行
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2) && Cursor.lockState == CursorLockMode.Locked)
        {
             OnClick();  //クリックされた時の処理
        }

        if (Input.GetButton("Submit"))
        {
            audioSource.PlayOneShot(sound01);
        }

        //左スティック（今までと同じ）
        if (click != 0 && befor_button == 0.00f)
        {
            audioSource.PlayOneShot(sound02);
        }

        befor_button = click;
    }

    private void FixedUpdate()
    {
        
    }
    IEnumerable _corsol()
    {
        audioSource.PlayOneShot(sound02);
        yield return new WaitForSeconds(0.1f);
    }

    //private void FixedUpdate()
    //{
    //    float StartCorsol = Input.GetAxisRaw("Vertical");

    //    if (StartCorsol == 1 || StartCorsol == -1)
    //    {
    //        audioSource.PlayOneShot(sound02);
    //        StartCoroutine("_WaitStart");
    //    }

    //}

    //クリックされた時にOnClickを呼び出すようにしておく
    void OnClick()
    {
        // UnityEditor.EditorApplication.isPlaying = false;

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            //Debug.Log("yes");

            return;  //lockStateがLockedじゃなかったら以後の処理をしない
        }
    }
}
