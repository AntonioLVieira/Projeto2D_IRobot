using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mola : MonoBehaviour
{
    private Animator oAnimator;
    public float forcaMola;

    void Awake()
    {
        oAnimator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            oAnimator.Play("animacao_mola_ativa");
            ManagerDeSom.instance.SomDoSalto.Play();
            other.gameObject.GetComponent<MovimentoDoJogador>().ImpulsoJogador(forcaMola);
        }
    }
}
