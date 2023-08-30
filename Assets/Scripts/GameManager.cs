using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header ("Referências")]
    public Text scoreText;

    [Header ("Valores")]
    public float tempoRecarregarCena;
    public float tempoRecarregarNovaCena;
    public string proximaFase;
    public string MenuInicial;
    public int scoreNecessario;

    // Start is called before the first frame update
    void Start()
    {
        // Define a resolução do jogo em "FullScreen"
        Screen.SetResolution(640, 360, true);
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica se a tecla "Escape" está a ser pressionada
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // Se estiver a ser pressionada chama o método VoltarAoMenu()
            VoltarAoMenu();
        }
    }

    // É chamado, sempre que o jogador morre
    public void GameOver()
    {
        // Recarrega uma nova Cena com intervalo
        CoroutineRecarregaCena();
    }

    // Inicia a Coroutine para recarregar a cena 
    public void CoroutineRecarregaCena()
    {
        StartCoroutine(RecarregarCena());
    }

    // Recarrega a cena após algum tempo
    private IEnumerator RecarregarCena()
    {
        // Espera um tempo antes de recarregar a nova cena
        yield return new WaitForSeconds(tempoRecarregarCena);

        // Recarrega a Cena
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Inicia a Coroutine para passar de cena
    public void CoroutinePassarDeCena()
    {
        StartCoroutine(PassarDeCena());
    }

    // Coroutine que passa para a proxima cena, se o jogador tiver o score necessário
    private IEnumerator PassarDeCena()
    {
        int scoreValor = int.Parse(scoreText.text);
        if (scoreValor < scoreNecessario)
        {

            // Se o jogador não tiver o score necessário, não passa de cena (sai da Coroutine)
            yield break;
        }
        else
        {
            // Espera algum tempo antes de recarregar uma nova cena
            yield return new WaitForSeconds(tempoRecarregarNovaCena);

            // Recarrega a próxima fase
            SceneManager.LoadScene(proximaFase);
        }   
    }

    // Volta ao Menu Inicial
    private void VoltarAoMenu()
    {
    SceneManager.LoadScene(MenuInicial);    
    }
}
