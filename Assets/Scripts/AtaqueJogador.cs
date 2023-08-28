using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJogador : MonoBehaviour
{
    private Animator oAnimator;
    private MovimentoDoJogador oMovimentoDoJogador;
    [SerializeField] private Transform PosicaoDaBala;
    [SerializeField] private GameObject [] balasDoJogador;

    [SerializeField] private float cooldownDisparos;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        oAnimator = GetComponent<Animator>();
        oMovimentoDoJogador = GetComponent<MovimentoDoJogador>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && cooldownTimer > cooldownDisparos && oMovimentoDoJogador.PodeAtacar())
        {
            Ataque();

            cooldownTimer += Time.deltaTime;
        }
    }

    private void Ataque()
    {   
        oAnimator.SetTrigger("atacar");
        cooldownTimer = 0;

        balasDoJogador[ProcuraBalas()].transform.position = PosicaoDaBala.position;
        balasDoJogador[ProcuraBalas()].GetComponent<BalaDoJogador>().SetDirecao(Mathf.Sign(transform.localScale.x));
    }

    private int ProcuraBalas()
    {
        for (int i = 0; i < balasDoJogador.Length; i++)
        {
            if (balasDoJogador[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
