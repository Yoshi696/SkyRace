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
		// ボタンコンポーネントの取得
		start = GameObject.Find("/Canvas/Start").GetComponent<Button>();
		help = GameObject.Find("/Canvas/Help").GetComponent<Button>();
		end = GameObject.Find("/Canvas/End").GetComponent<Button>();
		start.Select();
	}
}
