using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteAudio : MonoBehaviour
{

    public Toggle toggle;

    void Start()
    {
     
    }

    public void Mute() 
    {
        if (toggle.isOn == true)
        {
            Sound.Instace.MuteUnmuteGame();
        }
    }

    public void Unmute()
    {
        if (toggle.isOn == false)
        {
          Sound.Instace.MuteUnmuteGame();
        }
    }
}
