using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerDaMusica : MonoBehaviour
{
    public static ManagerDaMusica instance;
    public AudioSource musica;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        musica.Play();
    }
}
