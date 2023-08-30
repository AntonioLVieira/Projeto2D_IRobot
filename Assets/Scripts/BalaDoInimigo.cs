using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaDoInimigo : MonoBehaviour
{
    [Header ("Referências")]
    private GameObject Jogador;
    private Rigidbody2D oRigidbody2D;

    [Header ("Valores")]
    public float force;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();
        Jogador = GameObject.FindGameObjectWithTag("Player");

        // Calcula a direção entre o jogador e a Bala
        Vector3 direcao = Jogador.transform.position - transform.position;

        // Calcula a rotação da bala consoante a posição do jogador
        float rotacao = Mathf.Atan2(-direcao.y, -direcao.x) * Mathf.Rad2Deg;

        // Acrescenta uma velocidade à bola 
        oRigidbody2D.velocity = new Vector2(direcao.x, direcao.y).normalized * force;

        // Rotaciona a bala para o sítio certo
        transform.rotation = Quaternion.Euler(0, 0, rotacao);
    }

    // Update is called once per frame
    void Update()
    {   
        // Verifica se a bala ainda existe
        if (gameObject != null)
        {
            timer += Time.deltaTime;

            // se já tiverem passado mais de sete segundos, destrói a bala
            if (timer > 7)
            {
                Destroy(gameObject);
            }
        }
    }

    // É chamada sempre que a Bala colide com o jogador
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // A bala é destruída
            Destroy(gameObject);
        }
    }
}