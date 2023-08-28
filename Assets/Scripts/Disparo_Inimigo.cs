using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo_Inimigo : MonoBehaviour
{
    public GameObject bala;
    public Transform balaPosicao;
    private GameObject Jogador;

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

        float distancia = Vector2.Distance(transform.position, Jogador.transform.position);

        if (distancia < 7)
        {
            timer += Time.deltaTime;

            if(timer > 4)
            {
                timer = 0; 
                Shoot();    
            }
        }

       
        
    }

    void Shoot()
    {
        Instantiate(bala, balaPosicao.position, Quaternion.identity); 
    }
}
