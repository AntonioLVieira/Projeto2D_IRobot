using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCamera : MonoBehaviour
{
    [Header ("Movimento da Câmara")]
    public float velocidadeCamara;
    public float desvioEmY;
    public float desvioEmX;
    public Transform alvo;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(640, 360, true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 novaPosicao = new Vector3(alvo.position.x + desvioEmX, alvo.position.y + desvioEmY, -10f);
        transform.position = Vector3.Slerp(transform.position, novaPosicao, velocidadeCamara * Time.deltaTime);
    }
}
