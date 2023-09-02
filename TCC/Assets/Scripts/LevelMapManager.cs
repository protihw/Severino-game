using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMapManager : MonoBehaviour
{
    public static LevelMapManager levelMapManager;
    public GameObject panel;
    public GameObject key;

    void Awake()
    {
        levelMapManager = this;
    }

    void Start()
    {
        panel.SetActive(false);
        key.SetActive(false);
    }

    public void ChangeSceneMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeSceneLevel(int currentWaypoint)
    {
        if (currentWaypoint == 1)
        {
            if (PlayerPrefs.GetInt("Levels") >= 2)
            {
                SceneManager.LoadScene(2);
            }
        }
        else if (currentWaypoint == 6)
        {
            if (PlayerPrefs.GetInt("Levels") >= 3)
            { 
                SceneManager.LoadScene(3);
            }
        }
        else if (currentWaypoint == 11)
        {
            if (PlayerPrefs.GetInt("Levels") >= 4)
            { 
                SceneManager.LoadScene(4);
            }
        }
    }

    public void OnKey()
    {
        Vector3 playerPosition = WaypointController.waypointController.transform.position;
        Vector3 keyPosition = playerPosition + new Vector3(1.3f, 0.5f, 0f);
        key.transform.position = keyPosition;
        key.SetActive(true);
    }

    public void OutKey()
    {
        key.SetActive(false);
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
