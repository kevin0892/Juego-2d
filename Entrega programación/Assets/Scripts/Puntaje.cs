using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Puntaje : MonoBehaviour
{
    public Text puntaje;
    // esto está pa que el valor de punto pueda ser accedido por otra clase(la clase es coin controller)
    public static int puntos = 0;
    //este gameobject está en todas las escenas y el dontdestroy on load es pa que este empty no se destruya al cambiar de escena
     void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    //esto es que si la escena en la que está es igual a la primera deje el int puntos en 0 por si alguien le da jugar de nuevo en 
    //la pantalla final
    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("1"))
        {
            puntos = 0;
        }
       
    }

    // Update is called once per frame
    // esto es pa que ponga en el texto del canvas el puntaje, el tostring es pa volver un numero en una letra
    void Update()
    {
        puntaje.text = puntos.ToString();
    }
}
