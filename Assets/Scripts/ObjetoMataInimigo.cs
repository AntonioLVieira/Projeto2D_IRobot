using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoMataInimigo : MonoBehaviour
{
    // Verifica que o objeto está a colidir com o Inimigo
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Inimigo"))
        {
            // Chama o método para matar o inimigo
            other.gameObject.GetComponent<VidaInimigo>().FerirInimigo();
        }
    }
}
