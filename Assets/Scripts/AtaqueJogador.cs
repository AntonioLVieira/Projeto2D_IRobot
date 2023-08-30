using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJogador : MonoBehaviour
{
    [Header ("Referências")]
    private Animator oAnimator;
    private MovimentoDoJogador oMovimentoDoJogador;
    [SerializeField] private Transform PosicaoDaBala;
    [SerializeField] private GameObject [] balasDoJogador;
    
    
    [Header ("Valores")]
    [SerializeField] private float cooldownDisparos;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        oAnimator = GetComponent<Animator>();
        oMovimentoDoJogador = GetComponent<MovimentoDoJogador>();
    }

    private void Update()
    {
        /* O jogador só pode atacar, se as seguintes condições de aplicarem:
        Botão esquerdo do rato é pressionado, o tempo definido de colldown já terminou, o jogador pode atacar)*/
        if(Input.GetMouseButton(0) && cooldownTimer > cooldownDisparos && oMovimentoDoJogador.PodeAtacar())
        {
            Ataque();

            cooldownTimer += Time.deltaTime;
        }
    }

    // Método responsável pelo ataque do jogador
    private void Ataque()
    {   
        // Roda a animação de ataque
        oAnimator.SetTrigger("atacar");

        // dá "reset" ao cooldownTimer
        cooldownTimer = 0;

        // Define a posição da bala com base na posição do jogador
        balasDoJogador[ProcuraBalas()].transform.position = PosicaoDaBala.position;

        // Define a direção da bala com base na escala do jogador
        balasDoJogador[ProcuraBalas()].GetComponent<BalaDoJogador>().SetDirecao(Mathf.Sign(transform.localScale.x));
    }

    private int ProcuraBalas()
    {
        // Percorre o array das balas
        for (int i = 0; i < balasDoJogador.Length; i++)
        {
            // Verifica se a bala está ativa na hierarquia
            if (balasDoJogador[i].activeInHierarchy)
            {
                // Se estiver ativa, retorna essa bala
                return i;
            }
        }
        // Senão retorna 0, e a primeira bala é reciclada
        return 0;
    }
}
