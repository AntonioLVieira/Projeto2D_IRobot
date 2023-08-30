using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerDaMusica : MonoBehaviour
{
    public static ManagerDaMusica instance;
    public AudioSource musica;

    void Awake()
    {
        // não destrói a música quando muda de cena
        DontDestroyOnLoad(this.gameObject);
        // Se já houver uma instancia, o objeto é destruído
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // Senão, instancia o novo objeto
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // Toca a música
        musica.Play();
    }
}
