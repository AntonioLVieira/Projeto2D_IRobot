using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaDoInimigo : MonoBehaviour
{
    private GameObject Jogador;
    private Rigidbody2D oRigidbody2D;
    public float force;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();
        Jogador = GameObject.FindGameObjectWithTag("Player");

        Vector3 direcao = Jogador.transform.position - transform.position;
        float rotacao = Mathf.Atan2(-direcao.y, -direcao.x) * Mathf.Rad2Deg;

        oRigidbody2D.velocity = new Vector2(direcao.x, direcao.y).normalized * force;

        transform.rotation = Quaternion.Euler(0, 0, rotacao);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject != null)
        {
            timer += Time.deltaTime;

            if (timer > 7)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}