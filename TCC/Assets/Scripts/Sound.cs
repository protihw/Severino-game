using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound Instace;

    [Header("Musica")]
    public AudioSource musicSource;
    public AudioClip musicaMenu, musicaDeserto,musicaMar,musicaGameOver;

    [Header("cidade")]
    public AudioSource musicity;
    public AudioClip musicacidade;


    [Header("Inimigo")]
    public AudioSource inimigoSource;
    public AudioClip cobra;
    public AudioClip ducky;

    [Header("Player")]
    public AudioSource PlayerSource;
    public AudioClip correr, pular, dano, chicote;
    public bool dontDestroyOnLoad = true;

    [Header("Scenario")]
    public AudioSource scenarioSource;
    public AudioClip box;
    public AudioClip coin;

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
    public void PLayerdanoEffect()
    {
        PlayerSource.PlayOneShot(dano);
    }

    public void PLayerchicoteEffect()
    {
        PlayerSource.PlayOneShot(chicote);
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

    //Scenario

    public void ScenarioBox()
    {
        scenarioSource.PlayOneShot(box);
    }

    public void ScenarioCoin()
    {
        scenarioSource.PlayOneShot(coin);
    }

    //Musicas

    public void MudarMusicaMenu()
    {
        musicSource.Stop();
        musicSource.clip = musicaMenu;
        musicSource.Play();
    }

    public void MudarMusicaDeserto()
    {
        musicSource.Stop();
        musicSource.clip = musicaDeserto;
        musicSource.Play();
    }

    public void MudarMusicaMar()
    {
        musicSource.Stop();
        musicSource.clip = musicaMar;
        musicSource.Play();
    }

    public void MudarMusicaCidade()
    {
        musicSource.Stop();
        musicSource.clip = musicacidade;
        musicSource.Play();
    }

    public void MudarMusicaGameOver()
    {
        musicSource.Stop();
        musicSource.clip = musicaGameOver;
        musicSource.Play();
    }

    public void MudarMusicaCity()
    {
        
        musicity.Stop();
        musicity.clip = musicacidade;
        musicity.Play();

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