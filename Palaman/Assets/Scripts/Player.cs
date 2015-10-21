using UnityEngine;
using System.Collections;
using System.Threading;

public class player : MonoBehaviour {

    private Rigidbody2D myRB2D;
    public GameObject mycamera,peakObj;
    private Vector3 offset;
    public bool rigth = false;
    public float speed;
    public bool jumping = false;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    bool grounded = false;
    public float jumpForce = 100f;

    private Animator anima;
    public bool run = false;

	// Use this for initialization
	void Start () {
        myRB2D = gameObject.GetComponent<Rigidbody2D>();
        anima = gameObject.GetComponent<Animator>();
        offset = mycamera.transform.position;
	}
	
	// Update is called once per frame
	void Update () {      
        saltar();
        caminar();
        cavar();
        mycamera.transform.position = this.transform.position + offset ;
	}


    void FixedUpdate()
    {
        anima.SetBool("hSpeed", run); // Envia valor run al animator
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.5f, whatIsGround);
        // detectamos si estamos colisionando con tierra dando la posision, radio y objetos que acepte colisionar
        anima.SetBool("Ground", grounded); // envio el valor de grounded al animator
        if (grounded)
        {
            jumping = false;
        }
        else
        {
            jumping = true;
        }
        anima.SetBool("Jump",jumping);
    }

    private void caminar()
{
 	if (Input.GetAxis("Horizontal") < 0) // mirando a la derecha
        {
            rigth = false;
            Vector3 newScale = transform.localScale; // obtengo los valores de la imagen x default
            newScale.x = -0.8f; // giro
            transform.localScale = newScale; // aplico el giro de imagen
            run = true; // caminamos [animacion]
            transform.Translate( Input.GetAxis("Horizontal") * speed, 0f, 0f); // nos desplazamos en el eje x
        }
        else
        {
            if (Input.GetAxis("Horizontal") > 0)// mirando a la Izquierda
            {
                rigth = true;
                Vector3 newScale = transform.localScale; // obtengo los valores de la imagen x default
                newScale.x = 0.8f; // giro
                transform.localScale = newScale; // aplico el giro de imagen
                run = true; // caminamos [animacion]
                transform.Translate(Input.GetAxis("Horizontal") * speed, 0f, 0f); // nos desplazamos en el eje x
            }
            else
            {
                run = false; // nos detenemos [animacion]
            }
    }
}

    private void saltar()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space)) 
            // estoy pisando tierra y preciono spacio
        {
            myRB2D.AddForce(new Vector2(0, jumpForce)); // salto sobre el eje Y
            anima.SetBool("Ground", false); // ya no estoy en tierra
            anima.SetBool("Jump", true); // ya no estoy en tierra
        }
        else
        {
            anima.SetBool("Ground", grounded); // estoy pisando tierra
        }
    }

    private void cavar()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if (rigth)
            {
                Instantiate(peakObj, new Vector3(this.transform.position.x + 1f, this.transform.position.y, -1f), transform.rotation);
            }
            else
            {
                Instantiate(peakObj, new Vector3(this.transform.position.x - 1f, this.transform.position.y, -1f), transform.rotation);
            }
            
            anima.SetBool("Dig",true);
        }
    }

    void finCavar() {
        anima.SetBool("Dig", false);
    }

}
