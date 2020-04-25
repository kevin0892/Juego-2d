using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float fuersaX = 1000;
    [SerializeField]
    private float fuerzaSalto = 1000;
    bool canJump;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Transform>().position = new Vector3(-38.5f, -17.7f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-fuersaX * Time.deltaTime, 0));
        }
        if (Input.GetKey("right")) 
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(fuersaX * Time.deltaTime, 0));
        }
        if (Input.GetKeyDown("up") && canJump)
        {
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,fuerzaSalto));
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground")
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
        if (collision.transform.tag == "trap")
        {
            gameObject.GetComponent<Transform>().position = new Vector3(-38.5f, -17.7f, 0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "rojo")
        {

        }
    }

}
