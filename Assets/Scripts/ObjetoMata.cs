using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoMata : MonoBehaviour
{
    // Verifica que o objeto está a collidir com o Jogador
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            // Chama o método para matar o jogador
            other.gameObject.GetComponent<VidaJogador>().FerirJogador();
        }
    }
}
