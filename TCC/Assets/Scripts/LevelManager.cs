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

        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 2:
                Sound.Instace.MudarMusicaDeserto();
                break;
               
            case 3:
                Sound.Instace.MudarMusicaMar();
                break;
            case 4:
                Sound.Instace.MudarMusicaCity();
                break;

            case 5:
                Sound.Instace.MudarMusicaGameOver();
                break;
        }
    }


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

    public void ChangeSceneMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeNextScene()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenSettings()
    {
        panel.SetActive(true);
        panelCanvasGroup.interactable = true;
    }

    public void ExitSettings()
    {
        panel.SetActive(false);
        panelCanvasGroup.interactable = false;
    }


    public void GameOver() 
    {
        SceneManager.LoadScene(5);
    }

    public void GameOverAnimation()
    {
        Animator animatorPlayer = PlayerController.player.GetComponent<Animator>();
        animatorPlayer.SetBool("isDied", true);

        PlayerPrefs.SetInt("Lives", 3);
        PlayerPrefs.SetInt("Score", 0);

        StartCoroutine(WaitForAnimationAndGameOver(animatorPlayer));
    }

    private IEnumerator WaitForAnimationAndGameOver(Animator animator)
    {
        yield return new WaitForSeconds(3.470f);

        GameOver();
    }
}
