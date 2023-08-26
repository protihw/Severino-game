using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu, optionsMenu;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
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
        Application.OpenURL("file:///C:/Users/Aluno/Documents/GitHub/TCC/img/index.html");
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
