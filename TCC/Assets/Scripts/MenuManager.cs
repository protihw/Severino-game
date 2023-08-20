using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject mainMenu, optionsMenu, creditsMenu;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    // Update is called once per frame
    public void ChangeSceneSampleScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangePanelMain()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    public void ChangePanelOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
       creditsMenu.SetActive(false);
    }

    public void ChangePanelCredits()
     {
         mainMenu.SetActive(false);
         optionsMenu.SetActive(false);
         creditsMenu.SetActive(true);
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
