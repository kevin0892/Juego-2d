using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float fuerzaEscalada;
    [SerializeField]
    private float fuerzaX = 3000;
    [SerializeField]
    private float fuerzaSalto = 1880;
    [SerializeField]
    private AudioSource jumpSFX, deathSFX;
    private bool canJump;
    private bool canScalate;
    

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Transform>().position = new Vector3(-38.5f, -17.7f, 0f);

        var parametrosdeEmision = new ParticleSystem.EmitParams();

        parametrosdeEmision.position = GetComponent<Transform>().position;

        gameObject.GetComponent<ParticleSystem>().Emit(parametrosdeEmision,14);
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetKey("left"))
        {
            if (canJump == true)
            {
                GetComponent<ParticleSystem>().Emit(1);
            }
        

            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-fuerzaX * Time.deltaTime, 0));
        }
        else if (Input.GetKey("right"))
        {

            if (canJump == true)
            {
                GetComponent<ParticleSystem>().Emit(1);
            }

            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(fuerzaX * Time.deltaTime, 0));
        }
             
         
        
        
        if (Input.GetKeyDown("up") && canJump == true)
        {
            var parametrosdeEmision = new ParticleSystem.EmitParams();

            parametrosdeEmision.velocity = new Vector3(0, 10, 0);

           // parametrosdeEmision.position = GetComponent<Transform>().position;

            GetComponent<ParticleSystem>().Emit(parametrosdeEmision,15);

            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,fuerzaSalto));
            canJump = false;

            if (jumpSFX != null)
            {
                jumpSFX.Play();
            }

        }
        if (Input.GetKey("up")&& canScalate == true)
        {
            transform.position = transform.position+ new Vector3(0,fuerzaEscalada * Time.deltaTime, 0);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground")
        {
            canJump = true;

            GetComponent<ParticleSystem>().Emit(4);
        }

        if (collision.transform.tag == "trap")
        {
            gameObject.GetComponent<Transform>().position = new Vector3(-38.5f, -17.7f, 0f);
            if (deathSFX != null)
            {
                deathSFX.Play();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "ladder")
        {
            canScalate = true;
            Debug.Log("si la tocó");
            GetComponent<Rigidbody2D>() ;
            var body = GetComponent<Rigidbody2D>();
            body.mass = 0.01f;
        }
    }
    //te amo
    private void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canScalate = false;
    }

}
