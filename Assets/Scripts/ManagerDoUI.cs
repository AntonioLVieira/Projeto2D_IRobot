using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerDoUI : MonoBehaviour
{
    public static ManagerDoUI instance;
    public Image scoreImage;
    public Image fullHealthBar;
    public Image emptyHealthBar;
    public Text scoreText;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreImage.gameObject.SetActive(true);
        fullHealthBar.gameObject.SetActive(true);
        emptyHealthBar.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }
}
