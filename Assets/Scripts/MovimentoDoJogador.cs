using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoDoJogador : MonoBehaviour
{
    [Header("Referências")]
    private Rigidbody2D oRigidbody2D;
    private Animator oAnimator;

    [Header("Movimento Horizontal")]

    public float velocidadeDoJogador;
    public bool irParaDireita;

    [Header ("Salto")]
 
    public bool estaNoChao;
    public float alturaDoSalto;
    public float tamanhoDoRaioDeVerificacao;
    public Transform verificadorDeChao;
    public LayerMask layerDoChao;

    [Header ("Salto Parede")]

    public bool estaNaParede;
    public bool estaSaltarParede;
    public float forcaXDoSaltoParede;
    public float forcaYDoSaltoParede;
    public Transform verificadorDeParede;

    [Header ("Verificações")]

    public bool JogadorVivo;
    void Awake()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();
        oAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        JogadorVivo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(JogadorVivo == true)
        {
            MovimentarJogador();
            Saltar();
            SaltoNaParede();
        }
    }

    // Trata da movimentação horizontal do jogador
    private void MovimentarJogador()
    {
        // Recebe a movimentação Horizontal do jogador
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        oRigidbody2D.velocity = new Vector2(movimentoHorizontal * velocidadeDoJogador, oRigidbody2D.velocity.y);

        // Espelha a imagem do jogador dependendo da direção
        if (movimentoHorizontal > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            irParaDireita = true;
        }
        else if (movimentoHorizontal < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            irParaDireita = false;
        }

        // Mostra a animação dependendo do movimento do jogador
        if(movimentoHorizontal == 0 && estaNoChao == true)
        {
            oAnimator.Play("jogador_idle");
        }
        else if (movimentoHorizontal != 0 && estaNoChao == true)
        {
            oAnimator.Play("jogador_moving");
        }
    }

    // Trata do salto do jogador
    private void Saltar()
    {
        estaNoChao = Physics2D.OverlapCircle(verificadorDeChao.position, tamanhoDoRaioDeVerificacao, layerDoChao);

        // Se a condição estiver certa, é imposta uma força no jogador (salto)
        if (Input.GetButtonDown("Jump") && estaNoChao == true)
        {
            ManagerDeSom.instance.SomDoSalto.Play();
            oRigidbody2D.AddForce(new Vector2(0f, alturaDoSalto), ForceMode2D.Impulse);
        }

        // Se a condição estiver certa, é mostrada a animação do jogador a saltar
        if (estaNoChao == false)
        {
            oAnimator.Play("jogador_saltar");

        }

    }

    // Trata do salto do jogador nas paredes
    private void SaltoNaParede()
    {
        estaNaParede = Physics2D.OverlapCircle(verificadorDeParede.position, tamanhoDoRaioDeVerificacao, layerDoChao);

        // Se a condição estiver certa, significa que o jogador está na parede
        if(Input.GetButtonDown("Jump") && estaNaParede == true && estaNoChao == false)
        {
            estaSaltarParede = true;

        }

        // Se a condição estiver certa, é imposta uma força no jogador dependendo da direção
        if (estaSaltarParede == true)
        {
            if (irParaDireita == true)
            {
                oRigidbody2D.velocity = new Vector2(-forcaXDoSaltoParede, forcaYDoSaltoParede);
            }
            else
            {
               oRigidbody2D.velocity = new Vector2(forcaXDoSaltoParede, forcaYDoSaltoParede);
            }

            Invoke(nameof(SaltarNaParedeFalso), 0.1f);
        }
    }

    // Trata da variável se o jogador não estiver a saltar na parede
    private void SaltarNaParedeFalso()
    {
        estaSaltarParede = false; 
    }

    public void ImpulsoJogador(float forcaImpulso)
    {
        oRigidbody2D.velocity = new Vector2(oRigidbody2D.velocity.x, 0f);
        oRigidbody2D.AddForce(new Vector2(0f, forcaImpulso), ForceMode2D.Impulse);
    }

    public bool PodeAtacar()
    {
        return true;
    }
}
