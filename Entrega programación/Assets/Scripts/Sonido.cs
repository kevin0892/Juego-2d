using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonido : MonoBehaviour
{
    // Start is called before the first frame update
    //cuando la escena cambie no quiero que la música pare tonces el empty debe perdurar entre escenas entonces digo que no se destruya
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
