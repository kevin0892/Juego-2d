using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controleney : MonoBehaviour
{
    [SerializeField]
    private float velocidad = .5F;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Esta es el movimiento hacia un eje en positivo
    void Update()
    {
        transform.Translate(0, velocidad * Time.deltaTime, 0);

    }
    //esto hace que el movimiento entre en negativo cuando toca algo 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Barreraenemy")
        {
            velocidad *= -1;
        }
    }
}
