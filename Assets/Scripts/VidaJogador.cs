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

    [Header ("Valores")]
    public float tempoDeDestruicao;


    public Image FullHealthBar;
    public Image EmptyHealthBar;

    void Awake()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();
        oAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        FullHealthBar.gameObject.SetActive(true);
        EmptyHealthBar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
            
    }


    public void FerirJogador()
    {
        ManagerDeSom.instance.somDeDano.Play();
        FindObjectOfType<MovimentoDoJogador>().JogadorVivo = false;
        oRigidbody2D.velocity = Vector2.zero;
        FullHealthBar.gameObject.SetActive(false);
        EmptyHealthBar.gameObject.SetActive(true);
        oAnimator.Play("jogador_a_morrer");
        StartCoroutine(JogadorDesaparece());
    }  

    private IEnumerator JogadorDesaparece()
    {
        yield return new WaitForSeconds(tempoDeDestruicao);
        FindObjectOfType<GameManager>().GameOver();
        Instantiate(efeitoExplosao, transform.position, transform.rotation);
        Destroy(this.gameObject);

    }
}