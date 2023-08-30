using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [Header ("Referências")]
    public Text scoreText;

    [Header ("Valores")]
    private int scoreNumber;
    // Start is called before the first frame update
    void Start()
    {
        // Coloca o número a 0
        scoreNumber = 0;
        // Define o texto do score
        scoreText.text = "" + scoreNumber;
    }

    // Verifica que o objeto está a colidir com a seringa
    void OnTriggerEnter2D(Collider2D Seringa)
    {
        if(Seringa.tag == "seringa")
        {
            // adiciona 1 ao score
            scoreNumber ++;
            // escreve o novo resultado
            scoreText.text = "" + scoreNumber;
        }
        
    }
}
