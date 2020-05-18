using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
  public void CargarEscena()
    {
        //cambiar la escena actual por la siguiente, las escenas estan en el build del proyecto, esto esta conectado a un botón
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //conectado al otro botón
    //esto está conectado con la primera y la ultima escena en los botones salir
    public void CerrarJuego()
    {
        Application.Quit();
        Debug.Log("Salió");
    }
    //Esto está conectado a la última escena el botón de volver a jugar
    public void JugarDeNuevo()
    {
        SceneManager.LoadScene(1);

    }
}
