using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDeFase : MonoBehaviour
{
    // É chamado, sempre que o objeto onde está este script colide com o jogador
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            // Procura o GameManager da cena onde se encontra, e chama a Coroutine 
            FindObjectOfType<GameManager>().CoroutinePassarDeCena();
        }
    }
}
