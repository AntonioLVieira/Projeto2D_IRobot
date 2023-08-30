using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaJogador : MonoBehaviour
{
    [Header ("Referências")]
    public GameObject efeitoExplosao;
    private Rigidbody2D oRigidbody2D;
    private Animator oAnimator;
    public Image FullHealthBar;
    public Image EmptyHealthBar;


    [Header ("Valores")]
    public float tempoDeDestruicao;

    void Awake()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();
        oAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Ativa a Barra de vida cheia
        FullHealthBar.gameObject.SetActive(true);

        // Desativa a barra de vida vazia
        EmptyHealthBar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    // método que trata da morte do jogador
    public void FerirJogador()
    {
        // toca o som do dano
        ManagerDeSom.instance.somDeDano.Play();

        // Procura a variável do jogador vivo e mata-o
        FindObjectOfType<MovimentoDoJogador>().JogadorVivo = false;

        // Coloca a velocidade do jogador a 0
        oRigidbody2D.velocity = new Vector2(0f, 0f);

        // Desativa a barra do jogador cheia
        FullHealthBar.gameObject.SetActive(false);

        // Ativa a barra do jogador vazia
        EmptyHealthBar.gameObject.SetActive(true);

        // Roda a animação do jogador a morrer
        oAnimator.Play("jogador_a_morrer");

        // Espera algum tempo e depois o jogador desaparece
        StartCoroutine(JogadorDesaparece());
    }  

    private IEnumerator JogadorDesaparece()
    {
        // Espera algum tempo antes de continuar
        yield return new WaitForSeconds(tempoDeDestruicao);

        // Procura o método GameOver() e executa-o
        FindObjectOfType<GameManager>().GameOver();

        // instancia o efeito de explosão na posição do jogador
        Instantiate(efeitoExplosao, transform.position, transform.rotation);

        // Destrói o jogador
        Destroy(this.gameObject);

    }
}