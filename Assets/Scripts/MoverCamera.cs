using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCamera : MonoBehaviour
{
    [Header ("Referências")]
    public Transform alvo;

    [Header ("Valores")]
    public float velocidadeCamara;
    

    // Start is called before the first frame update
    void Start()
    {
        // Define a resolução do jogo e coloca em "FullScreen" 
        Screen.SetResolution(640, 360, true);
    }

    // Update is called once per frame
    void Update()
    {
        // Calcula a nova posição da câmara com base no Jogador e nos desvios
        Vector3 novaPosicao = new Vector3(alvo.position.x, alvo.position.y, -10f);

        // Move a câmara em direção à nova posição usando o Slerp (movimento suave)
        transform.position = Vector3.Slerp(transform.position, novaPosicao, velocidadeCamara * Time.deltaTime);
    }
}
