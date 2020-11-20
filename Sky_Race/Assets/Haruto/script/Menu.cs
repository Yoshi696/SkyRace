using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
	Button start;
    Button help;
	Button end;

    void Start()
	{
		//マウスポインタ消すやつ
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Locked;
		Screen.lockCursor = false;

		// ボタンコンポーネントの取得
		start = GameObject.Find("/Canvas/Start").GetComponent<Button>();
		help = GameObject.Find("/Canvas/Help").GetComponent<Button>();
		end = GameObject.Find("/Canvas/End").GetComponent<Button>();
		start.Select();
	}


	void Update()
	{
		//クリックされた時 かつ lockStateがLockedではない時だけ実行
		if (Input.GetMouseButtonDown(0) && Cursor.lockState != CursorLockMode.Locked)
		{
			OnClick();  //クリックされた時の処理
		}
	}

	//クリックされた時にOnClickを呼び出すようにしておく
	void OnClick()
	{
		if (Cursor.lockState == CursorLockMode.Locked)
		{
			return;  //lockStateがLockedだったら以後の処理をしない
		}
	}
}
