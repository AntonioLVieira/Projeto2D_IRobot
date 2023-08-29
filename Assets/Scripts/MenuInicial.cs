using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public string PrimeiraCena;
    
    void Start()
    {
        Screen.SetResolution(640, 360, true);
    }

    public void IniciarJogo()
    {
        SceneManager.LoadScene(PrimeiraCena);
    }
    
    public void SairJogo()
    {
        
        Application.Quit();
    }
}
