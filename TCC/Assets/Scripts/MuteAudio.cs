using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{
    // Start is called before the first frame update
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
