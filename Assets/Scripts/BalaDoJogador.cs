using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaDoJogador : MonoBehaviour
{
    [SerializeField] private float velocidade;
    private bool acertar;
    private float direcao;
    private float tempoDeVida;

    private BoxCollider2D oBoxCollider2D;
    private Animator oAnimator;
    public GameObject efeitoExplosao;
    
    private void Awake()
    {
        oBoxCollider2D = GetComponent<BoxCollider2D>();
        oAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(acertar == true)
        {
            return;
        } 

        float velocidadeMovimento = velocidade * Time.deltaTime * direcao;
        transform.Translate(velocidadeMovimento, 0, 0);

        tempoDeVida += Time.deltaTime;

        if(tempoDeVida > 5) 
        {
            gameObject.SetActive(false);
        }

    }

    public void SetDirecao(float _direcao)
    {
        tempoDeVida = 0;
        direcao = _direcao;
        gameObject.SetActive(true);
        acertar = false;
        oBoxCollider2D.enabled = true;

        float escalaEmX = transform.localScale.x;

        if(Mathf.Sign(escalaEmX) != _direcao)
        {
            escalaEmX = -escalaEmX;
        } 

        transform.localScale = new Vector3(escalaEmX, transform.localScale.y, transform.localScale.z);
    }
    
    private void DesativarBala()
    {
        gameObject.SetActive(false);
    }
}
