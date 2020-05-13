using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour
{
    [SerializeField]
    private AudioSource coinSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            coinSFX.Play();
            ScoreManager.scoreManager.RaiseScore(1);

            transform.position = transform.position + new Vector3(-300, 0, 0);
        }
       

        //if (coinSFX.isPlaying)
                //  gameObject.SetActive(false);
        //Destroy(gameObject);
        //}

    }
}
