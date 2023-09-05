using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound Instace;
    public AudioSource musicSource, buttonsSource, effectsSource, voiceSource;
    public AudioClip[] buttonsClip, errorClip, acertosClip, voicesClip, musicClip;
    public AudioClip correr, pular;
    public AudioSource PlayerSource;
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

    public void PLayerCorrerEffect()
    {
        PlayerSource.PlayOneShot(correr);
    }
    public void PlayButtonEffect()
    {
        buttonsSource.PlayOneShot(buttonsClip[Random.Range(0, buttonsClip.Length)]);
    }
    public void PlayErrorEffect()
    {
        effectsSource.PlayOneShot(errorClip[Random.Range(0, errorClip.Length)]);
    }
    public void PlayAcertoEffect()
    {
        effectsSource.PlayOneShot(acertosClip[Random.Range(0, acertosClip.Length)]);
    }
    public void PlayVoiceEffect(int fase)
    {
        StartCoroutine(NewVoice(fase));
    }
    IEnumerator NewVoice(int fase)
    {
        voiceSource.Stop();
        yield return new WaitForSeconds(0.1f);
        voiceSource.PlayOneShot(voicesClip[fase]);
    }

    public void MuteUnmuteGame()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Pause();
            musicSource.volume = 0;
            effectsSource.volume = 0;
            buttonsSource.volume = 0;
            voiceSource.volume = 0;
        }
        else
        {
            musicSource.UnPause();
            musicSource.volume = 0.5f;
            effectsSource.volume = 1;
            buttonsSource.volume = 1;
            voiceSource.volume = 1;
        }
    }
}