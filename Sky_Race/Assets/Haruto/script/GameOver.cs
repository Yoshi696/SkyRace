using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private GameObject mainCamera;
    private GameObject subCamera;

    public Text OverText;

    void Start()
    {
        mainCamera = GameObject.Find("Camera");
        subCamera = GameObject.Find("SubCamera");
        OverText.enabled = false;

        subCamera.SetActive(false);
        mainCamera.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Over")
        {
            mainCamera.SetActive(false);
            subCamera.SetActive(true);
            OverText.enabled = true;
            Invoke("LoadScene", 2f);
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene("GameResult");
    }
}
