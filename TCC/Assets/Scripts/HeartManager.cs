using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeartManager : MonoBehaviour
{
    public static HeartManager heartManager;
    public TMP_Text heartText;

    void Start()
    {
        UpdateHeart(PlayerController.player.heart);
    }

    private void Awake()
    {
        heartManager = this;
    }

    public void UpdateHeart(int heart)
    {
        heartText.text = heart.ToString();
    }
}
