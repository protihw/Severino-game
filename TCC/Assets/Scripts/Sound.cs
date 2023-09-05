using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound Instace;

    [Header("Musica")]
    public AudioSource musicSource;
    public AudioClip musicaMenu, musicaDeserto,musicaMar,musicaCidade,musicaGameOver;

    [Header("Inimigo")]
    public AudioSource inimigoSource;
    public AudioClip cobra;
    public AudioClip ducky;

    [Header("Player")]
    public AudioSource PlayerSource;
    public AudioClip correr, pular, dano;
    public bool dontDestroyOnLoad = true;
    private void Awake()
    {
        if (Instace == null)
        {
            Instace = this;
            if (Instace == null)
            {
                Debug.LogError("No Transitioner was found in this scene. Make sure you place one in the scene.");
                return;
            }
            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(Instace.gameObject);
            }
        }
        else
        {
            DestroyNonInstanceTransitioners();
        }
        //if (!musicSource.isPlaying)
        //{
        //   // musicSource.Play();
        //}
    }
    private bool DestroyNonInstanceTransitioners()
    {
        if (this != Instace)
        {
            Destroy(gameObject);
            return true;
        }
        return false;
    }

    //Player
    public void PLayerCorrerEffect()
    {
        PlayerSource.PlayOneShot(correr);
    }
    public void PLayerpularEffect()
    {
        PlayerSource.PlayOneShot(pular);
    }



    //Inimigos
    public void InimigoCobrar()
    {
        inimigoSource.PlayOneShot(cobra);
    }

    public void Inimigoducky()
    {
        inimigoSource.PlayOneShot(ducky);
    }

    //Musicas

    public void MudarMusicaMenu()
    {
        musicSource.Stop();
        musicSource.clip = musicaMenu;
        musicSource.Play();
    }


    public void MuteUnmuteGame()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Pause();
            musicSource.volume = 0;
            inimigoSource.volume = 0;
            PlayerSource.volume = 0;
        }
        else
        {
            musicSource.UnPause();
            musicSource.volume = 0.5f;
            inimigoSource.volume = 1;
            PlayerSource.volume = 1;
        }
    }
}