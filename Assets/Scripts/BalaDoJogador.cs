using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaDoJogador : MonoBehaviour
{
    [Header ("Referências")]
    private BoxCollider2D oBoxCollider2D;
    private Animator oAnimator;
    public GameObject efeitoExplosao;

    [Header ("Valores")]
    [SerializeField] private float velocidade;
    private bool acertar;
    private float direcao;
    private float tempoDeVida;
    
    private void Awake()
    {
        oBoxCollider2D = GetComponent<BoxCollider2D>();
        oAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Verifica se a bala acertou o Inimigo
        if(acertar == true)
        {
            // Se acertou, não é executado o resto do código
            return;
        } 

        // Calcula a velocidade da bala
        float velocidadeMovimento = velocidade * Time.deltaTime * direcao;

        // A bala move-se somente na horizontal
        transform.Translate(velocidadeMovimento, 0, 0);

        tempoDeVida += Time.deltaTime;

        // Se já tiverem passado 5 segundos desde o início do disparo, a bala é desactivada
        if(tempoDeVida > 5) 
        {
            gameObject.SetActive(false);
        }

    }

    // Define a direção da bala
    public void SetDirecao(float _direcao)
    {
        // dá "reset" ao tempoDeVida da bala
        tempoDeVida = 0;

        // Define a direção da bala
        direcao = _direcao;

        // ativa a bala
        gameObject.SetActive(true);

        // dá "reset" ao estado da bala
        acertar = false;

        // Ativa o BoxCollider da bala
        oBoxCollider2D.enabled = true;

        float escalaEmX = transform.localScale.x;

        // Verifica se a bala está virada para a direção correta e muda se necessário
        if(Mathf.Sign(escalaEmX) != _direcao)
        {
            escalaEmX = -escalaEmX;
        } 
        transform.localScale = new Vector3(escalaEmX, transform.localScale.y, transform.localScale.z);
    }
    
    // Desativa a bala
    private void DesativarBala()
    {
        gameObject.SetActive(false);
    }
}
