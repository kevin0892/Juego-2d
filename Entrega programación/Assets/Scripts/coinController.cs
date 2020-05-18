using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class coinController : MonoBehaviour
{
    [SerializeField]
    private AudioSource coinSFX;


    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            //activar el sonidito
            coinSFX.Play();
            //acceder a la variable puntos de la clase llamada puntaje y cambiar su valor en 1 cada vez que toque al jugador
            Puntaje.puntos++;
            //la cambio de lugar antes de destruirla porque quiero que reproduzca el sonido antes de que se destruya
            transform.position = transform.position + new Vector3(-300, 0, 0);
            //aqui hago que la moneda se destruya despues de un segundo 
            Destroy(gameObject, 1F);
        }
     
    }
    private void Update()
    {
    }
}
