using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoMataInimigo : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Inimigo"))
        {
            other.gameObject.GetComponent<VidaInimigo>().FerirInimigo();
        }
    }
}
