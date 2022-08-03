using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject failedPanel;
    public GameObject player;

    public static int Life = 100;
    public Text lifeText;

    private void Awake()
    {
        Life = 100;
        failedPanel.SetActive(false);
    }

    private void Update()
    {
        lifeText.text = "Life: " + Life;
        if(Life <= 0)
        {
            OpenFailedPanel();
            SceneManager.LoadScene(1);
        }
        if(player.transform.position.z >= 130)
        {
            SceneManager.LoadScene(1);
        }

    }

    private void OpenFailedPanel()
    {
        failedPanel.SetActive(true);
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
