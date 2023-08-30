using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaInimigo : MonoBehaviour
{
    [Header ("Referências")]
    public GameObject efeitoExplosao;
    private Rigidbody2D oRigidbody2D;
    private Animator oAnimator;

    [Header ("Valores")]
    public float tempoDeDestruicao;

    void Awake()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();
        oAnimator = GetComponent<Animator>();
    }

    // Método que trata da morte do Inimigo
    public void FerirInimigo()
    {
        // toca o som do dano
        ManagerDeSom.instance.somDeDano.Play();

        // Procura a variável do Inimigo vivo mata-o
        FindObjectOfType<Inimigos>().inimigoVivo = false;

        // coloca a velocidade do Inimigo a 0
        oRigidbody2D.velocity = new Vector2(0f, 0f);

        // Destrói o Inimigo
        Destroy(this.gameObject);
    }

}
