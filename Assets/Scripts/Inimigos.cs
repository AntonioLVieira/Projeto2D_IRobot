using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour
{
    [Header("Percurso do Inimigo")]
    public Transform[] pontosPercurso;
    public int pontoAtual;

    [Header("Movimento do Inimigo")]
    public float velocidadeInimigo;
    public float ultimaPosicaoX;

    [Header ("Verificações")]
    public bool inimigoVivo;

    void Start()
    {
        inimigoVivo = true;
        pontoAtual = 0;
        transform.position = pontosPercurso[0].position;
    }
    void Update()
    {
        MoverInimigo();
        VirarInimigo();
    }
    
    // Inimigo move para o próximo ponto do percurso
    private void MoverInimigo()
    {
        transform.position = Vector2.MoveTowards(transform.position, pontosPercurso[pontoAtual].position, velocidadeInimigo * Time.deltaTime);

        //Vê se Inimigo chegou ao ponto
        if (transform.position == pontosPercurso[pontoAtual].position)
        {
            pontoAtual += 1;
            ultimaPosicaoX = transform.localPosition.x;

            //Se o número passar o número máximo da array, volta ao início do percurso
            if (pontoAtual >= pontosPercurso.Length)
            {
                pontoAtual = 0; 
            }
        }
    }

    // Vira o inimigo dependendo da direção que segue
    private void VirarInimigo()
    {
        if(transform.localPosition.x < ultimaPosicaoX)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(transform.localPosition.x > ultimaPosicaoX)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }


}
