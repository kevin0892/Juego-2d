using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escape : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //salir del juego cuando se toque la letra escape
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
