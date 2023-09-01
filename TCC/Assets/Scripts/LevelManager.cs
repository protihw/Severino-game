using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;
    public GameObject panel;
    public CanvasGroup panelCanvasGroup;
    public bool isOpen = false;
    public SceneManager currentScene;
    void Awake()
    {
        levelManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    void Update()
    {
        if (isOpen == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                OpenSettings();
                isOpen = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                ExitSettings();
                isOpen = false;
            }
        }
            
    }

    // Update is called once per frame
    public void ChangeSceneMenuScene()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Cheguei");
    }

    public void ChangeNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void OpenSettings()
    {
        panel.SetActive(true);
        panelCanvasGroup.interactable = true;
        Debug.Log("Cheguei");
    }

    public void ExitSettings()
    {
        panel.SetActive(false);
        panelCanvasGroup.interactable = false;
        Debug.Log("Cheguei");
    }
}
