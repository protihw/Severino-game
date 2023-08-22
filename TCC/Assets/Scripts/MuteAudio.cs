using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteAudio : MonoBehaviour
{
    public AudioSource soundtrack;
    public Toggle toggle;

    void Start()
    {
        soundtrack.mute = false;
    }

    public void Mute() 
    {
        if (toggle.isOn == true)
        {
            soundtrack.mute = true;
        }
    }

    public void Unmute()
    {
        if (toggle.isOn == false)
        {
            soundtrack.mute = false;
        }
    }
}
