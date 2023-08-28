using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text scoreText;
    private int scoreNumber;
    // Start is called before the first frame update
    void Start()
    {
        scoreNumber = 0;
        scoreText.text = "" + scoreNumber;
    }

    void OnTriggerEnter2D(Collider2D Seringa)
    {
        if(Seringa.tag == "seringa")
        {
            scoreNumber ++;
            scoreText.text = "" + scoreNumber;
        }
        
    }

}
