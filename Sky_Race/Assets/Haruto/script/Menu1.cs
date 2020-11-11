using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu1 : MonoBehaviour
{
	Button title;

    void Start()
	{
		// ボタンコンポーネントの取得
		title = GameObject.Find("/Canvas/Title").GetComponent<Button>();
		title.Select();
	}
}
