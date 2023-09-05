using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteAudio : MonoBehaviour
{
    public static MuteAudio instance;
    public AudioSource AudioSource;
    public Toggle toggle;

    void Awake(){
        instance = this;
    }

    void Start()
    {
        AudioSource.mute = false;
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
