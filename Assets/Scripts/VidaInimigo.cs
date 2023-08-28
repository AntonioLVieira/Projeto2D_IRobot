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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    public void FerirInimigo()
    {
        ManagerDeSom.instance.somDeDano.Play();
        FindObjectOfType<Inimigos>().inimigoVivo = false;
        oRigidbody2D.velocity = new Vector2(0f, 0f);
        Destroy(this.gameObject);
    }

}
