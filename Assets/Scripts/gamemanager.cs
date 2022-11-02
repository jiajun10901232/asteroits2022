using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public static gamemanager instance;
    public int vida;
    public int puntuacion;

    private void Awake()
    {
        instance = this;
    }


}
