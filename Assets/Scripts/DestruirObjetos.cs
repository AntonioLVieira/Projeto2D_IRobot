using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirObjetos : MonoBehaviour
{
    [Header ("Valores")] 
    public float tempo;

    // Start is called before the first frame update
    void Start()
    {
        // Destrói o Objeto após o tempo definido
        Destroy(this.gameObject, tempo);       
    }
}