 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColectGems : MonoBehaviour
public class CollectGems : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    public Text scoreTxt;
    private int score;

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        
        scoreTxt.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("coin"))
        {
            score = score + 1;
            Destroy(col.gameObject);
        }
    }
}