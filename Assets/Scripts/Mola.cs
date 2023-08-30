using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mola : MonoBehaviour
{
    [Header ("Referências")]
    private Animator oAnimator;

    [Header ("Valores")]
    public float forcaMola;

    void Awake()
    {
        oAnimator = GetComponent<Animator>();
    }

    // Verifica se o objeto colidiu com o Jogador
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            // Roda a animação da mola ativa
            oAnimator.Play("animacao_mola_ativa");

            // toca o som do salto
            ManagerDeSom.instance.SomDoSalto.Play();

            // Aplica um impulso ao jogador
            other.gameObject.GetComponent<MovimentoDoJogador>().ImpulsoJogador(forcaMola);
        }
    }
}
