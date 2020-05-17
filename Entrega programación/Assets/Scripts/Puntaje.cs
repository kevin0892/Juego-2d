using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Puntaje : MonoBehaviour
{
    public Text puntaje;
    public static int puntos = 0;
     void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("1"))
        {
            puntos = 0;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        puntaje.text = puntos.ToString();
    }
}
