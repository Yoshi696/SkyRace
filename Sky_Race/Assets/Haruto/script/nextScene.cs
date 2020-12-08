using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nextScene : MonoBehaviour
{
    public Image Manual;
    public Image NextManual;
    public Button back;
    public Button next;
    public Button back2;
    public Text Sousa;
    public Text Help;
    public Text Gai;

    Selectable backs;

    public Button disableAdsButton;
    public Button disableAdsButton2;
    public Button disableAdsButton3;

    private void Start()
    {
        backs = GameObject.Find("Canvas/back").GetComponent<Selectable>();

        disableAdsButton.gameObject.SetActive(false);

        Sousa.enabled = true;
        Help.enabled = true;
        Gai.enabled = false;

        Manual.enabled = true;
        back.enabled = true;
        next.enabled = true;
        NextManual.enabled = false;
        back2.enabled = false;

    }

    public void GetButton()
    {
        Sousa.enabled = false;
        Help.enabled = false;
        Gai.enabled = true;

        Manual.enabled = false;
        back.enabled = false;
        next.enabled = false;
        NextManual.enabled = true;
        back2.enabled = true;
        backs.Select();

        disableAdsButton.gameObject.SetActive(true);
        disableAdsButton2.gameObject.SetActive(false);
        disableAdsButton3.gameObject.SetActive(false);
    }
}