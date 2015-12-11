using UnityEngine;
using System.Collections;

public class Controles : MonoBehaviour {
  
    float nextJump, timeOver;
    public float jumpRate = 1.0f;
    public bool pressButton = false,boolInventary = true;
    public string controlObject;
    float tiempoEspero = 0;
    public bool PAUSA;
    player palaman;

    void Start()
    {
        // referenciamos el scrip player
        palaman = GameObject.Find("Shalike").GetComponent<player>();
    }

    void Update()
    {
        ActivePausa();
        BotonesRL();
        BotonesCPS();
        
    }

    private void BotonesCPS()
    {
        if (pressButton && Time.time > timeOver && !PAUSA)
        {
            timeOver = Time.time + 0.5f;

            if (controlObject == "BtnBloque")
            {
                controlObject = "";
                palaman.ColocarBloque();
            }
            else
            {
                if (controlObject == "BtnPico")
                {
                    controlObject = "";
                    palaman.cavar();
                    
                }
                else
                {
                    if (controlObject == "btnSalto" && palaman.fronteo)
                    {
                        controlObject = "";
                        palaman.saltar();
                    }
                }
            }
        }
    }

    private void ActivePausa()
    {
        // Si detectamos un click y fue encima del inventario
        if (pressButton && controlObject == "Inventario")
        {
            controlObject = "";
            if (Time.time > tiempoEspero && boolInventary)
            {
                tiempoEspero = Time.time + 1f;

                if (PAUSA)
                {
                    PAUSA = false; // Desactivamos Pausa
                    // Desplasamos el inventario
                    for (int i = 0; i < 80; i++)
                        // Movemos el inventario en el eje Y hacia abajo
                        GameObject.Find("Inventario").transform.position = new Vector3(GameObject.Find("Inventario").transform.position.x, GameObject.Find("Inventario").transform.position.y + 0.1f, GameObject.Find("Inventario").transform.position.z);

                    boolInventary = false; // El inventario esta oculto
                }
                else
                {
                    PAUSA = true; // Activamos Pausa
                    // Desplasamos el inventario
                    for (int i = 0; i < 80; i++)
                        // Movemos el inventario en el eje Y hacia abajo
                        GameObject.Find("Inventario").transform.position = new Vector3(GameObject.Find("Inventario").transform.position.x, GameObject.Find("Inventario").transform.position.y - 0.1f, GameObject.Find("Inventario").transform.position.z);

                    boolInventary = false; // El inventario se esta mostrando
                }
            }
            else
                boolInventary = true;
        }
    }

    private void BotonesRL()
    {
        if (pressButton) // si se detecta un click
        {
            if (controlObject == "Right") // si el click fue en la flecha izquierda
                palaman.caminar(1); // Caminamos hacia adelante
            else
                if (controlObject == "Left")// si el click fue en la flecha derecha
                    palaman.caminar(-1); // Caminamos hacia atras
        }
    }

    void OnMouseDrag()
    {
        controlObject = this.name; // nombre del objeto al cual le dimos click encima
        pressButton = true; // Estamos dando click en la pantalla
    }

    void OnMouseUp()
    {
        pressButton = false; // Ya no hay click
        palaman.caminar(0);
    }

}
