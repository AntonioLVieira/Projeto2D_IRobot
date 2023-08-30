using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [Header ("Valores")]
    public string menuPrincipal;
    
    // É chamado, quando o botão de dirigir para o menu Inicial é pressionado
    public void MenuPrincipal()
    {
        // Dá load à cena do menu Inicial
        SceneManager.LoadScene(menuPrincipal);
    }
    
    // É chamado, quando o botão de sair do jogo é pressionado
    public void SairJogo()
    {
        // O jogo é encerrado
        Application.Quit();
    }
}