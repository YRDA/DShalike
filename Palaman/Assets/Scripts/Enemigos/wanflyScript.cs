using UnityEngine;
using System.Collections;

public class wanflyScript : MonoBehaviour {

    public float speed = 0.03f, playerX = 0, playerY = 0;
    public Transform checkBarWanfly;
    public LayerMask existBarWanfly;
    bool barra;
    bool rigth = true;
    float tiempoEspera;
    public GameObject areaVision;
    Controles controlX;
    Animator anima;
    public bool stepPlayer;
    float timeOver;    

    void Start()
    {
        // obtenemos referencia al animator de wanfly
        anima = gameObject.GetComponent<Animator>();
        // obtenemos referencia al script del inventario
        controlX = GameObject.Find("Inventario").GetComponent<Controles>();
    }

	void Update () 
    {
        playerX = GameObject.Find("Shalike").gameObject.transform.position.x; // actualizamos las coordenadas en X del personaje
        playerY = GameObject.Find("Shalike").gameObject.transform.position.y; // actualizamos las coordenadas en Y del personaje

        // Si no esta activa PAUSA y Seguir al personaje
        if (!controlX.PAUSA && !stepPlayer) 
        {
            Mover(); // me muevo
            anima.SetBool("Fly", true); // muevo la animacion para q paresca volar
        }
        else
        {
            // si Esta activa seguir al personaje y no la PAUSA
            if (stepPlayer && !controlX.PAUSA)
            {
                anima.SetBool("Fly", true); // sigo animando a wanfly
                SeguirPersonaje();         // Empiezo a seguir al personaje
            }
            else
                anima.SetBool("Fly", false); // Pausa esta activo y Detengo la animacion de wanfly
        }

        
	}

    private void SeguirPersonaje()
    {
        // si la posicion del personaje en X es menor a la mia
            if (playerX > transform.position.x)
                transform.Translate(1 * speed, 0f, 0f); // la incremento
            else
                transform.Translate(1 * -speed, 0f, 0f); // la disminuyo

       // si la posicion del personaje en Y es menor a la mia
            if (playerY > transform.position.y)
                transform.Translate(0f, 1 * speed, 0f); // la incremento
            else
                transform.Translate( 0f, 1 * -speed, 0f); // la disminuyo
    }

    void FixedUpdate()
    {
        // estoy dentro de la barra de movimiento?
        barra = Physics2D.OverlapCircle(checkBarWanfly.position, 0.3f, existBarWanfly);
    }

    private void Mover()
    {
        if (!barra) // si salimos de la barra
            if (Time.time > tiempoEspera)
            {
                tiempoEspera = Time.time + 1;

                if (rigth)
                    rigth = false; // Regresamos por la izquierda
                else
                    rigth = true; // regresamos por la derecha
            }

        if (rigth) // vamos para la derecha?
        {
            areaVision.transform.Rotate(new Vector3(0, 0, Mathf.Repeat(3 * 5,8) * speed)); // rotamos el campo de vision
            // avanzamos hacia la derecha
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
        else
        {
            areaVision.transform.Rotate(new Vector3(0, 0, Mathf.Repeat(3 * 5,8) * -speed)); // rotamos el campo de vision
            // avanzamos hacia la izquierda
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }
            
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // si chocamos con el personaje nos destruimos
        if (col.gameObject.tag == "Player")
        {
            player shalike;
            shalike = GameObject.Find("Shalike").GetComponent<player>();
            shalike.Vidas(-1);
            Destroy(this.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D col2)
    {
        // si entramos en modo perseguir y estamos dentro de la barra
        if ( stepPlayer && col2.gameObject.tag == "Barwanfly")
        {
            Destroy(col2.gameObject); // destruyo la barra
        }
    }
}
