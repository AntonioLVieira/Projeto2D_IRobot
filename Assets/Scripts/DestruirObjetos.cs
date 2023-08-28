using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirObjetos : MonoBehaviour
{
    public float tempo;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, tempo);       
    }
}