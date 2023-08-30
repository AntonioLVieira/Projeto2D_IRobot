using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerDeSom : MonoBehaviour
{
    [Header ("Referências")]
    public static ManagerDeSom instance;
    public AudioSource somDosItens;
    public AudioSource somDeDano;
    public AudioSource SomDoSalto;

    void Awake()
    {
        // Instancia o som, dependendo de onde este script é posto
        instance = this;
    }
}

