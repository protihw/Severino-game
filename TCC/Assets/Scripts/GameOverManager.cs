using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    private void Awake()
    {
        Sound.Instace.MudarMusicaGameOver();
    }
    public void ChangeLevelMapScene()
    
    {
        //Sound.Instace.MudarMusicaGameOver();
        SceneManager.LoadScene(1);
    }

    public void ChangeMenuScene()
    {
        SceneManager.LoadScene(0);
    }
}
