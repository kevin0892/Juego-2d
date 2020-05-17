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
            coinSFX.Play();
            Puntaje.puntos++;
           // Puntos++;
            //Debug.Log(Puntos);
            transform.position = transform.position + new Vector3(-300, 0, 0);
            Destroy(gameObject, 1F);
        }
     
    }
    private void Update()
    {
    }
}
