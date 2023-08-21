using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{

    public void MuteHandler(bool mute) 
    {
        if(mute)
        {
            AudioListener.volume = 0;
        }

        else
        {
            AudioListener.volume = 1;
        }
    }
}
