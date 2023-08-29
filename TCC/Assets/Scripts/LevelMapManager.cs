using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMapManager : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        panel.SetActive(false);
    }

    public void ChangeSceneMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitSettings()
    {
        panel.SetActive(false);
    }

    public void OpenSettings()
    {
        panel.SetActive(true);
    }
}
