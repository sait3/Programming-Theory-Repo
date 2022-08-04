using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject failedPanel;
    public GameObject player;
    private static int life = 100;

    public static int Life  // ENCAPSULATION
    {
        get
        {
            return life;
        }
        set
        {
            life = value;
        }
    }

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
            InvokeRepeating("LoadLevelScene", 2f, 0f);
        }
        if(player.transform.position.z >= 153)
        {
            LoadLevelScene();
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

    public void LoadLevelScene()
    {
        SceneManager.LoadScene(1);
    }
}
