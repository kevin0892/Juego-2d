using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlenex : MonoBehaviour
{
    [SerializeField]
    private float velocidad = .5F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // Esta es la movimiento hacia un eje en positivo
    void Update()
    {
        transform.Translate(velocidad *Time.deltaTime, 0, 0); 
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Barreraenemy")
        {
            velocidad *= -1;
        }
    }
}
