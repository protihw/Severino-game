using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu, optionsMenu;
    void Start()
    {

        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);

        Time.timeScale = 1;

        Sound.Instace.MudarMusicaMenu();
    }

    public void ChangeSceneSampleScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangePanelMain()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void ChangePanelOptions()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(true);
    }

    public void ChangePanelCredits()
    {
        Application.OpenURL("https://64f7446191311f1505307e11--luxury-fox-82a8d5.netlify.app");
    }


    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
