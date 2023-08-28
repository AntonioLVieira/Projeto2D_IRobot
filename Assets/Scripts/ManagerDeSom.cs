using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerDeSom : MonoBehaviour
{
    public static ManagerDeSom instance;
    public AudioSource somDosItens;
    public AudioSource somDeDano;
    public AudioSource SomDoSalto;

    void Awake()
    {
        instance = this;
    }
}

