using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public string menuPrincipal;
    
    public void MenuPrincipal()
    {
        SceneManager.LoadScene(menuPrincipal);
    }
    
    public void SairJogo()
    {
        
        Application.Quit();
    }
}