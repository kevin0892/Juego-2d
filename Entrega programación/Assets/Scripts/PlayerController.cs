using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private Rigidbody2D myRigidbody;
    public GameObject respawn;


    // Start is called before the first frame update
    void Awake()
    {
        respawn = GameObject.FindWithTag("Spawnpoint");
    }
    void Start()
    {
        transform.position = respawn.transform.position;
        myRigidbody = GetComponent<Rigidbody2D>();
        //gameObject.GetComponent<Transform>().position = new Vector3(-38.5f, -17.7f, 0f);

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
   
        if (Input.GetKeyDown("z") && canJump == true)
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

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground")
        {
            canJump = true;

            GetComponent<ParticleSystem>().Emit(4);
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "trap")
        {
            transform.position = respawn.transform.position;

            //gameObject.GetComponent<Transform>().position = new Vector3(-38.5f, -17.7f, 0f);
            if (deathSFX != null)
            {
                deathSFX.Play();
            }
        }
        if (collision.transform.tag == "ground" && (collision.transform.tag == "ladder"))
        {
            canJump = false;

            GetComponent<ParticleSystem>().Emit(4);
        }
        if (collision.transform.tag == "ladder")
        {
            myRigidbody.gravityScale = 0;
            canJump = false;
        }
        if (collision.transform.tag == "metas")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "ladder")
        {
            myRigidbody.gravityScale = 0;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(transform.up * fuerzaEscalada * Time.deltaTime);

            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(-transform.up * fuerzaEscalada * Time.deltaTime);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "ladder")
        {
            myRigidbody.gravityScale = 1;
        }

    }

}
