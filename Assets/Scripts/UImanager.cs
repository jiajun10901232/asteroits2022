using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UImanager : MonoBehaviour
{
    public TextMeshProUGUI time;
    public TextMeshProUGUI puntuacio;
    public TextMeshProUGUI vida;
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time.text = Time.time.ToString("00.00");
        puntuacio.text = gamemanager.instance.puntuacion.ToString();
        vida.text = gamemanager.instance.vida.ToString();

        if (gamemanager.instance.vida <= 0)
        {
            gameOver . SetActive(true);
        }
    }
}
