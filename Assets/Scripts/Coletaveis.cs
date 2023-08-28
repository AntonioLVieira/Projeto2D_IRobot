using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletaveis : MonoBehaviour
{
    public GameObject efeitoExplosao;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {   
            ManagerDeSom.instance.somDosItens.Play();
            Instantiate(efeitoExplosao, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
