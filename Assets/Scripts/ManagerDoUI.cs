using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerDoUI : MonoBehaviour
{
    [Header ("Referências")]
    public static ManagerDoUI instance;
    public Image scoreImage;
    public Image fullHealthBar;
    public Image emptyHealthBar;
    public Text scoreText;

    void Awake()
    {
        // Não destrói o objeto, ao carregar uma nova Cena
        DontDestroyOnLoad(this.gameObject);

        // Se já houver uma instância, o objeto é destruído
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // Caso contrário, instancia o objeto
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // Ativa todas estas componentes
        scoreImage.gameObject.SetActive(true);
        fullHealthBar.gameObject.SetActive(true);
        emptyHealthBar.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }
}
