using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    [Header ("Valores")]
    public string PrimeiraCena;
    
    void Start()
    {
        // Define a resolução do jogo e põe em "FullScreen"
        Screen.SetResolution(640, 360, true);
    }

    // método que inicial o jogo
    public void IniciarJogo()
    {
        // Dá "load" à peimeira cena do jogo
        SceneManager.LoadScene(PrimeiraCena);
    }
    
    // método que sai do jogo 
    public void SairJogo()
    {
        // Jogo é encerrado
        Application.Quit();
    }
}
