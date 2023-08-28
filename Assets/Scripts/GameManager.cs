using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float tempoRecarregarCena;
    public float tempoRecarregarNovaCena;
    public string proximaFase;
    public string MenuInicial;
    public Text scoreText;
    public int scoreNecessario;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            VoltarAoMenu();
        }
    }

    public void GameOver()
    {
        CoroutineRecarregaCena();
    }

    public void CoroutineRecarregaCena()
    {
        StartCoroutine(RecarregarCena());
    }

    private IEnumerator RecarregarCena()
    {
        yield return new WaitForSeconds(tempoRecarregarCena);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CoroutinePassarDeCena()
    {
        StartCoroutine(PassarDeCena());
    }
    private IEnumerator PassarDeCena()
    {
        int scoreValor = int.Parse(scoreText.text);
        if (scoreValor < scoreNecessario)
        {
            yield break;
        }
        else
        {
            yield return new WaitForSeconds(tempoRecarregarNovaCena);
            SceneManager.LoadScene(proximaFase);
        }   
    }
    private void VoltarAoMenu()
    {
    SceneManager.LoadScene(MenuInicial);    
    }
}
