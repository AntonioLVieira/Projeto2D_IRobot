using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletaveis : MonoBehaviour
{
    [Header ("Referências")]
    public GameObject efeitoExplosao;

    // É chamado quando o coletável colide com o jogador
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {   
            // Toca o som de "apanhar Itens"
            ManagerDeSom.instance.somDosItens.Play();

            // Executa o efeito da explosão no local exato do Objeto (Seringas)
            Instantiate(efeitoExplosao, transform.position, transform.rotation);

            // Destrói a Seringa
            Destroy(this.gameObject);
        }
    }
}
