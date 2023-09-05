using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void ChangeLevelMapScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeMenuScene()
    {
        SceneManager.LoadScene(0);
    }
}
