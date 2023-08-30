using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo_Inimigo : MonoBehaviour
{
    [Header ("Referências")]
    public GameObject bala;
    public Transform balaPosicao;
    private GameObject Jogador;

    [Header ("Valores")]
    private float timer;    

    // Start is called before the first frame update
    void Start()
    {
        Jogador =  GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Calcula a distância entre o Inimigo e o Jogador
        float distancia = Vector2.Distance(transform.position, Jogador.transform.position);
        
        // Vê se o jogador está a menos de 7 unidades de distância
        if (distancia < 7)
        {
            timer += Time.deltaTime;

            // Vê se o tempo passado é maior que 4 segundos
            if(timer > 4)
            {
                // Se for maior, o timer dá "reset"
                timer = 0; 

                // E o Inimigo dispara
                Shoot();    
            }
        }

       
        
    }

    void Shoot()
    {
        // Instancia uma bala na posição correta
        Instantiate(bala, balaPosicao.position, Quaternion.identity); 
    }
}
